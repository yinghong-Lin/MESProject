using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // 确保已安装 MySql.Data 包

namespace MDM.UI.Factory
{
    public partial class Frm_Factory : Form
    {
        private string connectionString = "Server=localhost;Database=mdm_db;Uid=root;Pwd=Lmi503606707;Port=3305;";

        public Frm_Factory()
        {
            InitializeComponent();
            InitializeListView();
            LoadFactories();
        }

        private void InitializeListView()
        {
            listView1.View = View.Details; // 设置视图为详细信息视图
            listView1.FullRowSelect = true; // 选择整行

            // 添加列
            listView1.Columns.Add("工厂ID", 100);
            listView1.Columns.Add("工厂类型", 150);
            listView1.Columns.Add("工厂描述", 300);
            listView1.Columns.Add("操作用户", 100);
            listView1.Columns.Add("操作备注", 200);
            listView1.Columns.Add("最后编辑时间", 180);
            listView1.Columns.Add("创建时间", 180);
            listView1.Columns.Add("事件类型", 100);
        }

        private void LoadFactories()
        {
            List<Factory> factories = GetFactoriesFromDatabase();
            FillListView(factories);
        }

        private void FillListView(List<Factory> factories)
        {
            listView1.Items.Clear(); // 清空现有的项

            foreach (var factory in factories)
            {
                ListViewItem item = new ListViewItem(factory.FactoryId.ToString()); // 第一列是工厂ID
                item.SubItems.Add(factory.FactoryType); // 第二列是工厂类型
                item.SubItems.Add(factory.FactoryDescription); // 第三列是工厂描述
                item.SubItems.Add(factory.EventUser); // 第四列是操作用户
                item.SubItems.Add(factory.EventRemark); // 第五列是操作备注
                item.SubItems.Add(factory.EditTime.ToString("yyyy-MM-dd HH:mm:ss")); // 第六列是最后编辑时间
                item.SubItems.Add(factory.CreateTime.ToString("yyyy-MM-dd HH:mm:ss")); // 第七列是创建时间
                item.SubItems.Add(factory.EventType); // 第八列是事件类型
                listView1.Items.Add(item); // 添加到 ListView 控件
            }
        }

        private List<Factory> GetFactoriesFromDatabase()
        {
            List<Factory> factories = new List<Factory>();
            string query = "SELECT * FROM factories";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                try
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Factory factory = new Factory
                            {
                                FactoryId = reader.GetInt32("factory_id"),
                                FactoryType = reader.GetString("factory_type"),
                                FactoryDescription = reader.GetString("factory_description"),
                                EventUser = reader.GetString("event_user"),
                                EventRemark = reader.GetString("event_remark"),
                                EditTime = reader.GetDateTime("edit_time"),
                                CreateTime = reader.GetDateTime("create_time"),
                                EventType = reader.GetString("event_type")
                            };
                            factories.Add(factory);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            return factories;
        }

        private void Frm_Factory_Load(object sender, EventArgs e)
        {

        }
    }

    public class Factory
    {
        public int FactoryId { get; set; }
        public string FactoryType { get; set; }
        public string FactoryDescription { get; set; }
        public string EventUser { get; set; }
        public string EventRemark { get; set; }
        public DateTime EditTime { get; set; }
        public DateTime CreateTime { get; set; }
        public string EventType { get; set; }
    }
}