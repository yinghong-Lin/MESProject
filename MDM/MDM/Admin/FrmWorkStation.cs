using System;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace MDM.UI.Admin
{
    public partial class FrmWorkStation : Form
    {
        private string connectionString = "server=localhost;user=root;password=123456;database=mdm_db"; // 替换你的数据库连接信息

        public FrmWorkStation()
        {
            InitializeComponent();
            InitializeDataGridView();
            InitializeDataGridView2();
            InitializeDataGridView3();
            InitializeComboBox1();
        }

        private void InitializeComboBox1()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT device_id, device_desc FROM equipment";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    comboBox1.ValueMember = "device_id";
                    comboBox1.DisplayMember = "device_desc";
                    comboBox1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载设备数据时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeDataGridView()
        {
            LoadDataFromDatabase(dataGridView1, "BomItemList");
            SetDataGridViewColumnHeaders(dataGridView1, "BOM物料清单");
        }

        private void InitializeDataGridView2()
        {
            LoadDataFromDatabase(dataGridView2, "carriers");
            SetDataGridViewColumnHeaders(dataGridView2, "载具表");
        }

        private void InitializeDataGridView3()
        {
            LoadDataFromDatabase(dataGridView3, "material");
            SetDataGridViewColumnHeaders(dataGridView3, "上料信息");
        }

        private void LoadDataFromDatabase(DataGridView dataGridView, string tableName)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = $"SELECT * FROM {tableName}";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载数据时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetDataGridViewColumnHeaders(DataGridView dataGridView, string tableTitle)
        {
            // 设置表名
            dataGridView.TopLeftHeaderCell.Value = tableTitle;

            // 设置列标题为中文
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (dataGridView == dataGridView1)
                {
                    switch (column.Name)
                    {
                        case "Id":
                            column.HeaderText = "ID";
                            break;
                        case "BomNo":
                            column.HeaderText = "BOM编号";
                            break;
                        case "BomVersion":
                            column.HeaderText = "BOM版本";
                            break;
                        case "Sequence":
                            column.HeaderText = "序列";
                            break;
                        case "StandardQuantity":
                            column.HeaderText = "标准数量";
                            break;
                        case "MaterialType":
                            column.HeaderText = "物料类型";
                            break;
                        case "DetailedMaterialType":
                            column.HeaderText = "详细物料类型";
                            break;
                        case "MaterialNo":
                            column.HeaderText = "物料号";
                            break;
                        case "MaterialName":
                            column.HeaderText = "物料名";
                            break;
                        case "MaterialUnit":
                            column.HeaderText = "物料单位";
                            break;
                        case "ConsumptionQuantity":
                            column.HeaderText = "消耗数量";
                            break;
                        case "MaterialBatchQuantity":
                            column.HeaderText = "物料批次数量";
                            break;
                        case "CreatedDate":
                            column.HeaderText = "创建日期";
                            break;
                        case "UpdatedDate":
                            column.HeaderText = "更新日期";
                            break;
                    }
                }
                else if (dataGridView == dataGridView2)
                {
                    // 根据 carriers 表的结构设置列标题
                    switch (column.Name)
                    {
                        case "CarrierId":
                            column.HeaderText = "载具ID";
                            break;
                        case "CarrierName":
                            column.HeaderText = "载具名称";
                            break;
                        case "CarrierType":
                            column.HeaderText = "载具类型";
                            break;
                        case "Capacity":
                            column.HeaderText = "容量";
                            break;
                        case "Description":
                            column.HeaderText = "描述";
                            break;
                        case "CreatedDate":
                            column.HeaderText = "创建日期";
                            break;
                        case "UpdatedDate":
                            column.HeaderText = "更新日期";
                            break;
                    }
                }
                else if (dataGridView == dataGridView3)
                {
                    // 根据 material 表的结构设置列标题
                    switch (column.Name)
                    {
                        case "MaterialNo":
                            column.HeaderText = "物料号";
                            break;
                        case "MaterialDescription":
                            column.HeaderText = "物料描述";
                            break;
                        case "MaterialType":
                            column.HeaderText = "物料类型";
                            break;
                        case "DetailedType":
                            column.HeaderText = "详细类型";
                            break;
                        case "MaterialName":
                            column.HeaderText = "物料名";
                            break;
                        case "Unit":
                            column.HeaderText = "单位";
                            break;
                        case "MaterialGroup":
                            column.HeaderText = "物料组";
                            break;
                        case "Quantity":
                            column.HeaderText = "数量";
                            break;
                        case "CalculateY":
                            column.HeaderText = "计算公式";
                            break;
                        case "EquipmentModel":
                            column.HeaderText = "设备配套型";
                            break;
                        case "SupplierNo":
                            column.HeaderText = "供应商号";
                            break;
                        case "SupplierMaterialNo":
                            column.HeaderText = "供应商物料号";
                            break;
                    }
                }
            }
        }

        private void FrmWorkStation_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void FrmWorkStation_Load_1(object sender, EventArgs e)
        {
        }

        private void label17_Click(object sender, EventArgs e)
        {
        }

        private void label24_Click(object sender, EventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;
            if (dataGridView != null && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView.Rows[e.RowIndex];
                BomItem selectedBomItem = row.DataBoundItem as BomItem;
                if (selectedBomItem != null)
                {
                    MessageBox.Show($"ID: {selectedBomItem.Id}\nBOM编号: {selectedBomItem.BomNo}\nBOM版本: {selectedBomItem.BomVersion}\n序列: {selectedBomItem.Sequence}\n标准数量: {selectedBomItem.StandardQuantity}\n物料类型: {selectedBomItem.MaterialType}\n详细物料类型: {selectedBomItem.DetailedMaterialType}\n物料号: {selectedBomItem.MaterialNo}\n物料名: {selectedBomItem.MaterialName}\n物料单位: {selectedBomItem.MaterialUnit}\n消耗数量: {selectedBomItem.ConsumptionQuantity}\n物料批次数量: {selectedBomItem.MaterialBatchQuantity}\n创建日期: {selectedBomItem.CreatedDate}\n更新日期: {selectedBomItem.UpdatedDate}");
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void label68_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string deviceId = comboBox1.SelectedValue.ToString();
                LoadEquipmentDetails(deviceId);
            }
        }

        private void LoadEquipmentDetails(string deviceId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM equipment WHERE device_id = @deviceId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@deviceId", deviceId);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // 更新程序名到 comboBox2
                        comboBox2.DataSource = null;
                        comboBox2.Items.Clear();
                        comboBox2.Items.Add(reader["program_name"].ToString());
                        comboBox2.SelectedIndex = 0;

                        // 更新文本框
                        textBox27.Text = reader["product_model"].ToString(); // 设备产品编号
                        textBox28.Text = reader["equipment_sequence"].ToString(); // 设备顺序名
                        textBox29.Text = reader["current_status"].ToString(); // 当前状态
                        // textBox30 不显示任何信息
                        textBox31.Text = reader["device_type"].ToString(); // 设备类型
                        textBox32.Text = reader["detail_type"].ToString(); // 详细类型
                        textBox33.Text = reader["program_name"].ToString(); // 设备程序名
                        textBox34.Text = reader["communication_status"].ToString(); // 通信状态
                        textBox35.Text = reader["equipment_status"].ToString(); // 设备状态
                        textBox36.Text = reader["equipment_group"].ToString(); // 设备组
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载设备详情时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox31_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox32_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox33_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox34_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox35_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox36_TextChanged(object sender, EventArgs e)
        {
        }
    }

    public class BomItem
    {
        public int Id { get; set; }
        public string BomNo { get; set; }
        public string BomVersion { get; set; }
        public int Sequence { get; set; }
        public int StandardQuantity { get; set; }
        public string MaterialType { get; set; }
        public string DetailedMaterialType { get; set; }
        public string MaterialNo { get; set; }
        public string MaterialName { get; set; }
        public string MaterialUnit { get; set; }
        public int ConsumptionQuantity { get; set; }
        public int MaterialBatchQuantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }

    public class Carrier
    {
        public string CarrierId { get; set; }
        public string CarrierName { get; set; }
        public string CarrierType { get; set; }
        public int Capacity { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }

    public class Material
    {
        public string MaterialNo { get; set; }
        public string MaterialDescription { get; set; }
        public string MaterialType { get; set; }
        public string DetailedType { get; set; }
        public string MaterialName { get; set; }
        public string Unit { get; set; }
        public string MaterialGroup { get; set; }
        public float Quantity { get; set; }
        public string CalculateY { get; set; }
        public string EquipmentModel { get; set; }
        public string SupplierNo { get; set; }
        public string SupplierMaterialNo { get; set; }
    }
}