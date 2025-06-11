using MDM.BLL.Factory;
using MDM.BLL.Users;
using MDM.BLL.Process; // 添加这个引用
using MDM.DAL.Factory;
using MDM.DAL.Users;
using MDM.DAL.Process; // 添加这个引用
using MDM.UI.MainForms;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace MDM.UI
{
    internal static class Program
    {
        private const string ConnectionString = "Server=localhost;Database=mdm_db;Uid=root;Pwd=5258;Port=3306;";

        // 添加公共属性来访问服务实例
        public static ReworkService ReworkService { get; private set; }

        // 程序的主入口点
        [STAThread]
        static void Main()
        {
            // 初始化应用程序配置
            ApplicationConfiguration.Initialize();

            // 创建 UserRepository 实例，用于数据库操作
            var userRepository = new UserRepository(ConnectionString);

            // 创建 PermissionRepository 实例，用于权限操作
            var permissionRepository = new PermissionRepository(ConnectionString);

            // 创建 FactoryRepository 实例，用于工厂数据操作
            var factoryRepository = new FactoryRepository(ConnectionString);

            // 创建 ReworkRepository 实例，用于返修数据操作
            var reworkRepository = new ReworkRepository(ConnectionString);

            // 创建 LoginService 实例，用于处理登录逻辑
            ILoginService userService = new UserService(userRepository, permissionRepository);

            // 创建 FactoryService 实例，用于处理工厂业务逻辑
            IFactoryService factoryService = new FactoryService(factoryRepository);

            // 创建 ReworkService 实例，用于处理返修业务逻辑
            ReworkService = new ReworkService(reworkRepository);

            // 启动登录窗体，传入登录服务实例和工厂服务实例
            Application.Run(new Frmlogin(userService, factoryService));

            // 测试数据库连接（可选），在登录窗体关闭后执行
            TestDatabaseConnection();
        }

        // 测试数据库连接的方法
        static void TestDatabaseConnection()
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("数据库连接成功！");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("数据库连接失败：" + ex.Message);
                }
            }
        }
    }
}