using MDM.BLL.Factory;
using MDM.BLL.Users;
using MDM.BLL.Process; // ����������
using MDM.DAL.Factory;
using MDM.DAL.Users;
using MDM.DAL.Process; // ����������
using MDM.UI.MainForms;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace MDM.UI
{
    internal static class Program
    {
        private const string ConnectionString = "Server=localhost;Database=mdm_db;Uid=root;Pwd=5258;Port=3306;";

        // ��ӹ������������ʷ���ʵ��
        public static ReworkService ReworkService { get; private set; }

        // ���������ڵ�
        [STAThread]
        static void Main()
        {
            // ��ʼ��Ӧ�ó�������
            ApplicationConfiguration.Initialize();

            // ���� UserRepository ʵ�����������ݿ����
            var userRepository = new UserRepository(ConnectionString);

            // ���� PermissionRepository ʵ��������Ȩ�޲���
            var permissionRepository = new PermissionRepository(ConnectionString);

            // ���� FactoryRepository ʵ�������ڹ������ݲ���
            var factoryRepository = new FactoryRepository(ConnectionString);

            // ���� ReworkRepository ʵ�������ڷ������ݲ���
            var reworkRepository = new ReworkRepository(ConnectionString);

            // ���� LoginService ʵ�������ڴ����¼�߼�
            ILoginService userService = new UserService(userRepository, permissionRepository);

            // ���� FactoryService ʵ�������ڴ�����ҵ���߼�
            IFactoryService factoryService = new FactoryService(factoryRepository);

            // ���� ReworkService ʵ�������ڴ�����ҵ���߼�
            ReworkService = new ReworkService(reworkRepository);

            // ������¼���壬�����¼����ʵ���͹�������ʵ��
            Application.Run(new Frmlogin(userService, factoryService));

            // �������ݿ����ӣ���ѡ�����ڵ�¼����رպ�ִ��
            TestDatabaseConnection();
        }

        // �������ݿ����ӵķ���
        static void TestDatabaseConnection()
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("���ݿ����ӳɹ���");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("���ݿ�����ʧ�ܣ�" + ex.Message);
                }
            }
        }
    }
}