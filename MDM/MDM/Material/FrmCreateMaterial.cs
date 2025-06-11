using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MDM.UI.Material
{
    public partial class FrmCreateMaterial : Form
    {
        private readonly string _connectionString = "Server=localhost;Database=mdm_db;Uid=root;Pwd=123456;Port=3306;";
        private string query = "SELECT * FROM MaterialInfo";
        private string selectedMaterialNumber;
        private string selectedBatchNumber;

        public FrmCreateMaterial()
        {
            InitializeComponent();
            InitializeMaterialTypeComboBox();
            InitializeBatchControls();
        }

        private void InitializeMaterialTypeComboBox()
        {
            comboBoxMaterialType.Items.Add("Consumable");
            comboBoxDetailType.Items.Add("ALL");
            comboBoxMaterialType.SelectedIndex = 0;
            comboBoxMaterialType.SelectedIndexChanged += ComboBoxMaterialType_SelectedIndexChanged;
        }



        private void InitializeBatchControls()
        {
            // 初始化批次相关控件
            btnGenerate.Click += btnGenerate_Click;
            textBoxBatchQuantity.KeyPress += TextBoxBatchQuantity_KeyPress;

        }

        private void TextBoxBatchQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 只允许输入数字和退格键
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ComboBoxMaterialType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMaterialData("Consumable");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string materialNumber = row.Cells["物料号"]?.Value?.ToString();
                string materialType = row.Cells["物料类型"]?.Value?.ToString();

                if (!string.IsNullOrEmpty(materialNumber))
                {
                    textBoxMaterialNumber.Text = materialNumber;
                    textBoxMaterialType.Text = materialType;
                    LoadMaterialBatchData(materialNumber);
                }
            }
        }

        private void LoadMaterialData(string materialType)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"SELECT 物料号, 物料描述, 物料类型, 详细类型, 物料名, 单位, 物料组, 数量, 
                                   `Calulate Y`, 设备配套型, 供应商号, 供应商物料号 
                                   FROM material 
                                   WHERE 物料类型 = @MaterialType";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaterialType", materialType);
                        var dataTable = new DataTable();
                        new MySqlDataAdapter(command).Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载数据失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMaterialBatchData(string materialNumber)
        {
            if (string.IsNullOrWhiteSpace(materialNumber)) return;

            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"SELECT 物料批次号, 物料号, 物料类型, 详细类型, 数量, 单位, 
                                  供应商号, 位置 FROM material_creation
                                  WHERE 物料号 = @MaterialNumber";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaterialNumber", materialNumber);
                        var dataTable = new DataTable();
                        new MySqlDataAdapter(command).Fill(dataTable);


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载批次数据失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxBatchQuantity.Text))
            {
                MessageBox.Show("请输入批次数量", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBoxBatchQuantity.Text, out int batchQuantity) || batchQuantity <= 0)
            {
                MessageBox.Show("请输入有效的正数批次数量", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxMaterialNumber.Text))
            {
                MessageBox.Show("请先选择物料", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // 加载物料批次数据
            LoadMaterialBatchData(textBoxMaterialNumber.Text, batchQuantity);
        }
        private void LoadMaterialBatchData(string materialNumber, int batchQuantity)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"SELECT * FROM material_creation 
                             WHERE 物料号 = @MaterialNumber 
                             LIMIT @BatchQuantity";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaterialNumber", materialNumber);
                        command.Parameters.AddWithValue("@BatchQuantity", batchQuantity);

                        var dataTable = new DataTable();
                        new MySqlDataAdapter(command).Fill(dataTable);

                        // 将数据绑定到 dataGridView2
                        dataGridView2.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载批次数据失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData(DataGridView dgv)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
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


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView2.Rows.Count)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                selectedBatchNumber = row.Cells["物料批次号"]?.Value?.ToString();
                selectedMaterialNumber = row.Cells["物料号"]?.Value?.ToString();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaterialNumber) || string.IsNullOrEmpty(selectedBatchNumber))
            {
                MessageBox.Show("请先选中一条物料批次数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();

                }
                MessageBox.Show("物料创建或更新成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(dataGridView1); // 刷新数据
                LoadData(dataGridView2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作物料失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}