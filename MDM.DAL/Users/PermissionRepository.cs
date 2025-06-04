using MDM.Model.UserEntities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace MDM.DAL.Users
{
    // 权限仓储类，用于处理权限和菜单相关的数据库操作
    public class PermissionRepository
    {
        // 数据库连接字符串
        private readonly string _connectionString;

        // 构造函数，注入数据库连接字符串
        public PermissionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // 根据用户ID获取权限ID列表的方法
        public List<string> GetPermissionIdsByUserId(string userId)
        {
            var permissionIds = new List<string>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT permission_id FROM permission_user WHERE user_id = @userId";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                permissionIds.Add(reader["permission_id"].ToString());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"获取用户权限时发生错误: {ex.Message}");
                    }
                }
            }
            return permissionIds;
        }

        // 根据用户ID和工厂类型获取权限ID列表的方法
        public List<string> GetPermissionIdsByUserIdAndFactory(string userId, string factoryType)
        {
            var permissionIds = new List<string>();

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(factoryType))
            {
                Debug.WriteLine("GetPermissionIdsByUserIdAndFactory: userId 或 factoryType 为空");
                return permissionIds;
            }

            using (var connection = new MySqlConnection(_connectionString))
            {
                // 查询以工厂类型为前缀的权限
                string query = @"SELECT permission_id FROM permission_user 
                        WHERE user_id = @userId 
                        AND permission_id LIKE @factoryPrefix";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@factoryPrefix", factoryType + "_%");

                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                permissionIds.Add(reader["permission_id"].ToString());
                            }
                        }
                        Debug.WriteLine($"用户 {userId} 在工厂 {factoryType} 下找到 {permissionIds.Count} 个权限");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"获取用户工厂权限时发生错误: {ex.Message}");
                    }
                }
            }
            return permissionIds;
        }

        // 根据权限ID获取菜单ID列表的方法
        public List<int> GetMenuIdsByPermissionId(string permissionId)
        {
            var menuIds = new List<int>();

            if (string.IsNullOrEmpty(permissionId))
            {
                Debug.WriteLine("GetMenuIdsByPermissionId: permissionId 为空");
                return menuIds;
            }

            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT menu_id FROM permission_menu WHERE permission_id = @permissionId";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@permissionId", permissionId);
                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                menuIds.Add(reader["menu_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["menu_id"]));
                            }
                        }
                        Debug.WriteLine($"权限 {permissionId} 找到 {menuIds.Count} 个菜单ID");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"获取权限菜单时发生错误: {ex.Message}");
                    }
                }
            }
            return menuIds;
        }

        // 根据菜单ID获取菜单列表的方法
        public List<Menu> GetMenusByIds(List<int> menuIds)
        {
            var menus = new List<Menu>();

            if (menuIds == null || menuIds.Count == 0)
            {
                Debug.WriteLine("GetMenusByIds: menuIds 为空或为空列表");
                return menus;
            }

            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT * FROM menus WHERE menu_id IN (" + string.Join(",", menuIds) + ")";
                using (var command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                menus.Add(new Menu
                                {
                                    MenuId = reader["menu_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["menu_id"]),
                                    MenuName = reader["menu_name"].ToString(),
                                    FunctionId = reader["function_id"] == DBNull.Value ? null : reader["function_id"].ToString(),
                                    MenuDescription = reader["menu_description"] == DBNull.Value ? null : reader["menu_description"].ToString(),
                                    ParentMenuId = reader["parent_menu_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["parent_menu_id"]),
                                    EventUser = reader["event_user"] == DBNull.Value ? null : reader["event_user"].ToString(),
                                    EventRemark = reader["event_remark"] == DBNull.Value ? null : reader["event_remark"].ToString(),
                                    EditTime = reader["edit_time"] == DBNull.Value ? (DateTime?)null : (DateTime?)reader["edit_time"],
                                    CreateTime = reader["create_time"] == DBNull.Value ? (DateTime?)null : (DateTime?)reader["create_time"],
                                    EventType = reader["event_type"] == DBNull.Value ? null : reader["event_type"].ToString()
                                });
                            }
                        }
                        Debug.WriteLine($"成功获取 {menus.Count} 个菜单");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"获取菜单列表时发生错误: {ex.Message}");
                    }
                }
            }
            return menus;
        }

        // 为用户分配权限的方法
        public bool AssignPermissionToUser(string permissionId, string userId)
        {
            if (string.IsNullOrEmpty(permissionId) || string.IsNullOrEmpty(userId))
            {
                Debug.WriteLine("AssignPermissionToUser: permissionId 或 userId 为空");
                return false;
            }

            using (var connection = new MySqlConnection(_connectionString))
            {
                const string query = @"INSERT INTO permission_user 
                    (permission_id, user_id, event_user, create_time)
                    VALUES (@permissionId, @userId, @eventUser, @createTime)";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@permissionId", permissionId);
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@eventUser", userId); // 事件用户可以设置为admin或null
                    command.Parameters.AddWithValue("@createTime", DateTime.Now);

                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        Debug.WriteLine($"为用户 {userId} 分配权限 {permissionId} {(result > 0 ? "成功" : "失败")}");
                        return result > 0;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"分配权限时发生错误: {ex.Message}");
                        return false;
                    }
                }
            }
        }
    }
}
