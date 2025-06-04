using MDM.DAL.Users; 
using MDM.Model.UserEntities; 
using MDM.BLL.Security; 
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Diagnostics;

namespace MDM.BLL.Users
{
    // 定义登录服务接口，包含用户验证和创建的方法
    public interface ILoginService
    {
        // 检查数据库中是否存在任何用户
        bool CheckAnyUserExists();

        // 验证用户的方法，返回是否验证成功，同时输出用户对象
        bool ValidateUser(string userName, string password, out User user);

        // 验证用户并返回详细结果的方法，输出用户对象，并返回具体的验证验证信息
        string ValidateUserWithDetail(string userName, string password, out User user, string factoryType);

        // 创建新用户的方法，返回是否创建成功
        bool CreateUser(string userId, string userType, string userName, string password, string userEnglishName, string displayLanguage, string eventUser);

        // 获取所有用户但不包含密码信息
        List<User> GetAllUsersWithoutPassword();

        // 获取所有用户包含密码信息
        List<User> GetAllUsers();

        // 添加这个属性来访问 UserRepository 实例
        UserRepository UserRepository { get; }

        // 添加这个属性来访问 PermissionRepository 实例
        PermissionRepository PermissionRepository { get; }

        // 根据用户ID获取所有权限相关的菜单项
        List<Menu> GetUserPermissionMenus(string userId, string userType);
    }

    // 实现登录服务接口的具体类
    public class UserService : ILoginService
    {
        // 用户仓储对象，用于数据库操作
        private readonly UserRepository _userRepository;

        // 权限仓储对象，用于权限操作
        private readonly PermissionRepository _permissionRepository;

        // 访问 PermissionRepository 实例的属性
        public PermissionRepository PermissionRepository => _permissionRepository;

        // 构造函数，通过依赖注入的方式传入用户仓储对象和权限仓储对象
        public UserService(UserRepository userRepository, PermissionRepository permissionRepository)
        {
            _userRepository = userRepository;
            _permissionRepository = permissionRepository;
        }

        // 检查数据库中是否存在任何用户
        public bool CheckAnyUserExists()
        {
            return _userRepository.CheckAnyUserExists();
        }

        // 验证用户的方法实现
        public bool ValidateUser(string userName, string password, out User user)
        {
            user = null;

            // 从数据库中获取用户对象
            User dbUser = _userRepository.GetUserByUserName(userName);
            if (dbUser == null) return false;

            // 将用户密码从数据库中分割为哈希值和盐值
            var passwordParts = dbUser.UserPassword.Split(':');
            if (passwordParts.Length != 2) return false;

            // 计算输入密码的哈希值
            var computedHash = PasswordHasher.HashPassword(password, passwordParts[1]).Split(':')[0];
            // 比较计算的哈希值和数据库中的哈希值
            if (passwordParts[0] != computedHash) return false;

            // 更新用户的最后登录时间
            _userRepository.UpdateLastLoginTime(dbUser.UserId, DateTime.Now);
            dbUser.LastLoginTime = DateTime.Now;

            // 将验证成功的用户对象赋值给输出参数
            user = dbUser;
            return true;
        }

        // 验证用户并返回详细结果的方法实现
        public string ValidateUserWithDetail(string userName, string password, out User user, string factoryType)
        {
            user = null;

            try
            {
                // 从数据库中获取用户对象
                User dbUser = _userRepository.GetUserByUserName(userName);

                // 如果用户不存在
                if (dbUser == null)
                {
                    // 如果数据库中没有任何用户，系统初始化创建默认管理员
                    if (!_userRepository.CheckAnyUserExists())
                    {
                        var salt = PasswordHasher.GenerateSalt(32);
                        var newUser = new User
                        {
                            UserId = "admin",
                            UserType = "Admin",
                            UserName = userName,
                            UserPassword = PasswordHasher.HashPassword(password, salt),
                            EventType = "Create",
                            EventUser = "System"
                        };

                        if (_userRepository.CreateUser(newUser))
                        {
                            // 分配权限给新创建的管理员用户
                            if (_permissionRepository.AssignPermissionToUser($"{factoryType}_MDM", "admin"))
                            {
                                return "系统初始化成功，请重新登录！";
                            }
                            else
                            {
                                return "系统初始化时分配权限失败！";
                            }
                        }
                        return "系统初始化失败！";
                    }
                    return "用户名不存在！";
                }

                // 将用户密码从数据库中分割为哈希值和盐值
                var passwordParts = dbUser.UserPassword.Split(':');
                if (passwordParts.Length != 2) return "密码格式错误，请联系管理员";

                // 计算输入密码的哈希值
                var computedHash = PasswordHasher.HashPassword(password, passwordParts[1]).Split(':')[0];
                // 比较计算的哈希值和数据库中的哈希值
                if (passwordParts[0] != computedHash) return "密码错误，请重试！";

                // 更新用户的最后登录时间
                _userRepository.UpdateLastLoginTime(dbUser.UserId, DateTime.Now);
                dbUser.LastLoginTime = DateTime.Now;

                // 将验证成功的用户对象赋值给输出参数
                user = dbUser;
                return string.Empty;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"验证用户时发生错误: {ex.Message}");
                return "系统错误，请联系管理员！";
            }
        }

        // 创建新用户的方法实现
        public bool CreateUser(string userId, string userType, string userName, string password, string userEnglishName, string displayLanguage, string eventUser)
        {
            // 生成盐值
            var salt = PasswordHasher.GenerateSalt(32);
            // 计算加密后的用户密码
            var hashedPassword = PasswordHasher.HashPassword(password, salt);

            // 创建新的用户对象
            var newUser = new User
            {
                UserId = userId,
                UserType = userType,
                UserName = userName,
                UserPassword = hashedPassword,
                UserEnglishName = userEnglishName,
                DisplayLanguage = displayLanguage,
                EventUser = eventUser,
                EditTime = DateTime.Now,
                CreateTime = DateTime.Now,
                EventType = "Create"
            };

            // 调用用户仓储对象的方法创建新用户
            return _userRepository.CreateUser(newUser);
        }

        // 获取所有用户但不包含密码信息
        public List<User> GetAllUsersWithoutPassword()
        {
            return _userRepository.GetAllUsersWithoutPassword();
        }

        // 获取所有用户包含密码信息
        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        // 访问 UserRepository 实例的属性
        public UserRepository UserRepository => _userRepository;

        // 根据用户ID获取所有权限相关的菜单项
        public List<Menu> GetUserPermissionMenus(string userId, string userType)
        {
            try
            {
                // 参数验证
                if (string.IsNullOrEmpty(userId))
                {
                    Debug.WriteLine("GetUserPermissionMenus: userId 为空");
                    return new List<Menu>();
                }

                if (string.IsNullOrEmpty(userType))
                {
                    Debug.WriteLine("GetUserPermissionMenus: userType 为空");
                    return new List<Menu>();
                }

                // 获取用户在指定工厂下的权限ID列表
                var permissionIds = _permissionRepository.GetPermissionIdsByUserIdAndFactory(userId, userType);


                if (permissionIds.Count == 0)
                {
                    return new List<Menu>();
                }

                // 获取所有权限对应的菜单ID
                var menuIds = new List<int>();
                foreach (var permissionId in permissionIds)
                {
                    var ids = _permissionRepository.GetMenuIdsByPermissionId(permissionId);
                    menuIds.AddRange(ids);
                }

                // 去重
                menuIds = menuIds.Distinct().ToList();
                Debug.WriteLine($"找到 {menuIds.Count} 个不重复的菜单ID");

                if (menuIds.Count == 0)
                {
                    return new List<Menu>();
                }

                // 获取菜单详细信息
                var menus = _permissionRepository.GetMenusByIds(menuIds);
                Debug.WriteLine($"成功获取 {menus.Count} 个菜单");

                return menus;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"获取用户菜单时发生错误: {ex.Message}");
                return new List<Menu>();
            }
        }
    }
}
