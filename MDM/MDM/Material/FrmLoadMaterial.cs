using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace MDM.UI.Material
{
    public partial class FrmLoadMaterial : Form
    {
        private const string ConnectionString = "Server=localhost;Database=mdm_db;Uid=root;Pwd=123456;Port=3306;";
        private string query = "SELECT * FROM MaterialInfo";

        public FrmLoadMaterial()
        {
            InitializeComponent();
            // 加载数据到 DataGridView
            LoadData(dataGridView1);
            LoadData(dataGridView2);
            btnConfirm.Click += btnConfirm_Click;
        }
        private void LoadData(DataGridView dgv)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgv.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnQuery_Click_1(object sender, EventArgs e)
        {
            string deviceNumber = txtDeviceNumber.Text.Trim();
            if (deviceNumber == "AAB0-0002")
            {
                // 固定值填充
                txtDeviceType.Text = "Process";
                txtDeviceStatus.Text = "IDLE";
                txtPreviousStatus.Text = "IDLE";
                txtArea.Text = "AO";
                txtCommunicationStatus.Text = "offline";
                txtLockStatus.Text = "NotOnHold";
                txtE10Status.Text = "Standby";
                txtGroupNumber.Text = "EG-OVEN-01";
            }
            else
            {
                MessageBox.Show("设备号未找到。");
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string batchNumber = txtBatchNumber.Text.Trim();
            if (string.IsNullOrEmpty(batchNumber))
            {
                MessageBox.Show("请输入物料批次号。");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM MaterialInfo WHERE 物料批次号 = @BatchNumber";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BatchNumber", batchNumber);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                        }
                        else
                        {
                            MessageBox.Show("未找到该物料批次号。");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询物料失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}