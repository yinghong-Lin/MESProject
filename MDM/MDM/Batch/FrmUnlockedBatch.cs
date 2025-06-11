using System;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using MDM.BLL.Batch;
using MDM.Model.BatchEntities;
using MySql.Data.MySqlClient;

namespace MDM.UI.Batch
{
    public partial class FrmUnlockedBatch : Form
    {
        public BatchService _batchService;

        public FrmUnlockedBatch()
        {
            InitializeComponent();
            _batchService = new BatchService("Server=localhost;Database=mesproject;Uid=root;Pwd=Lmi503606707;Port=3305;");

            // 初始化DataGridView列
            InitializeDataGridViewColumns();
        }

        private void InitializeDataGridViewColumns()
        {
            // 清空现有列
            dataGridView1.Columns.Clear();

            // 添加所需的列
            dataGridView1.Columns.Add("lock_time", "锁定时间");
            dataGridView1.Columns.Add("lock_code", "锁定代码");
            dataGridView1.Columns.Add("lock_description", "锁定说明");
            dataGridView1.Columns.Add("locked_by", "锁定用户");
            dataGridView1.Columns.Add("event_remark", "代码说明");
            dataGridView1.Columns.Add("reason_equipment", "原因设备号");
            dataGridView1.Columns.Add("reason_process_flow", "原因工艺流程");
            dataGridView1.Columns.Add("reason_station", "原因工站");
            dataGridView1.Columns.Add("reason_operation_desc", "原因工序说明");

            // 设置列宽和格式
            dataGridView1.Columns["lock_time"].Width = 200;
            dataGridView1.Columns["lock_time"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

            // 设置为整行选中
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void DisplayBatchFlowInfo(BatchFlow batchFlow)
        {
            // 填充批次信息区域
            textBox1.Text = batchFlow.BatchId; // 批次号
            textBox2.Text = batchFlow.BatchType;  // 批次类型
            textBox3.Text = batchFlow.DetailType; // 详细类型
            textBox4.Text = batchFlow.Qty.ToString(); // 数量
            textBox5.Text = batchFlow.SubProductQty.ToString(); // 子数量
            textBox6.Text = batchFlow.Unit; // 单位
            textBox7.Text = batchFlow.LockStatus; // 锁定状态
            textBox8.Text = batchFlow.ProductId; // 产品编号
            textBox9.Text = batchFlow.WorkOrderId; // 工单号
            textBox11.Text = batchFlow.OnProductState; // 在制品状态
            textBox12.Text = batchFlow.RepairState; // 维修状态
            textBox13.Text = batchFlow.ProcessFlowNo; // 工艺流程
            textBox14.Text = batchFlow.DestoryNum.ToString();//报废数量

            // 其他信息
            textBox15.Text = batchFlow.ProcessFlowVersion; // 工艺流程版本
            textBox16.Text = batchFlow.FlowDescription; // 程序版本
            textBox17.Text = batchFlow.ProcessStatus; // 工艺状态
            textBox18.Text = batchFlow.ReworkStatus; // 返修状态
            textBox19.Text = batchFlow.Description; // 工站描述
            textBox20.Text = batchFlow.StationType; // 工站类型
            textBox21.Text = batchFlow.StationNo; // 工站
            textBox22.Text = batchFlow.EquipmentNo; // 设备号
            textBox23.Text = batchFlow.ProcessName; // 程序名
            textBox24.Text = batchFlow.ParentBatch; // 父批次号

            // Good/NG数量
            textBox10.Text = batchFlow.GoodQty.ToString(); // Good数量
            textBox36.Text = batchFlow.NGQty.ToString(); // NG数量

            // 报废数量/子数量
            textBox14.Text = batchFlow.DestoryNum.ToString(); // 报废数量
            textBox37.Text = batchFlow.SubProductQty.ToString(); // 子数量

            // 锁定相关信息
            textBox25.Text = batchFlow.DetainCodeGroup; // 滞留代码组别
        }

        private void LoadLockedBatchData(string batchId)
        {
            try
            {
                using (var connection = new MySqlConnection(_batchService._repository._connectionString))
                {
                    connection.Open();

                    // 1. 首先获取最新的锁定记录用于填充文本框
                    string latestLockSql = @"SELECT lock_code, lock_description,reason_equipment,reason_process_flow,reason_station,reason_operation_desc
                                   FROM locked_batch 
                                   WHERE batch_id = @BatchId 
                                   ORDER BY lock_time DESC 
                                   LIMIT 1";

                    using (var command = new MySqlCommand(latestLockSql, connection))
                    {
                        command.Parameters.AddWithValue("@BatchId", batchId);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBox26.Text = reader["lock_code"].ToString();
                                textBox27.Text = reader["lock_description"].ToString();
                                textBox30.Text = reader["reason_equipment"].ToString();
                                textBox31.Text = reader["reason_process_flow"].ToString();
                                textBox32.Text = reader["reason_station"].ToString();
                                textBox33.Text = reader["reason_operation_desc"].ToString();
                            }
                        }
                    }

                    // 2. 然后获取所有锁定记录用于DataGridView
                    string allLocksSql = @"SELECT 
                                lock_time, 
                                lock_code, 
                                lock_description, 
                                locked_by, 
                                detain_code_group, 
                                event_remark, 
                                reason_equipment, 
                                reason_process_flow, 
                                reason_station, 
                                reason_operation_desc 
                            FROM locked_batch 
                            WHERE batch_id = @BatchId 
                            ORDER BY lock_time DESC";

                    using (var command = new MySqlCommand(allLocksSql, connection))
                    {
                        command.Parameters.AddWithValue("@BatchId", batchId);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int rowIndex = dataGridView1.Rows.Add();
                                dataGridView1.Rows[rowIndex].Cells["lock_time"].Value = reader["lock_time"];
                                dataGridView1.Rows[rowIndex].Cells["lock_code"].Value = reader["lock_code"];
                                dataGridView1.Rows[rowIndex].Cells["event_remark"].Value = reader["lock_description"];
                                dataGridView1.Rows[rowIndex].Cells["locked_by"].Value = reader["locked_by"];
                                dataGridView1.Rows[rowIndex].Cells["lock_description"].Value = reader["event_remark"];
                                dataGridView1.Rows[rowIndex].Cells["reason_equipment"].Value = reader["reason_equipment"];
                                dataGridView1.Rows[rowIndex].Cells["reason_process_flow"].Value = reader["reason_process_flow"];
                                dataGridView1.Rows[rowIndex].Cells["reason_station"].Value = reader["reason_station"];
                                dataGridView1.Rows[rowIndex].Cells["reason_operation_desc"].Value = reader["reason_operation_desc"];
                            }
                        }
                    }
                }

                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("未找到该批次的锁定信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载锁定信息时出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearAllTextBoxes()
        {
            // 清空所有文本框
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Clear();
                }
            }
            // 清空下拉框
            foreach (Control control in this.Controls)
            {
                if (control is ComboBox)
                {
                    ((ComboBox)control).SelectedIndex = -1;
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // 保留原有代码
        }

        private void FrmUnlockedBatch_Load(object sender, EventArgs e)
        {
            LoadReasonGroups();
            LoadReasonCodes();
        }

        private void LoadReasonCodes()
        {
            try
            {
                using (var connection = new MySqlConnection(_batchService._repository._connectionString))
                {
                    connection.Open();

                    // 从unlocked_batch表获取原因代码和说明
                    string sql = "SELECT DISTINCT reason_code, reason_code_description FROM unlocked_batch ORDER BY reason_code";

                    using (var command = new MySqlCommand(sql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            // 清空现有项
                            comboBox2.Items.Clear();

                            // 创建一个DataTable来存储数据
                            DataTable dt = new DataTable();
                            dt.Columns.Add("reason_code", typeof(string));
                            dt.Columns.Add("reason_code_description", typeof(string));

                            while (reader.Read())
                            {
                                string code = reader["reason_code"].ToString();
                                string description = reader["reason_code_description"].ToString();
                                if (!string.IsNullOrEmpty(code))
                                {
                                    dt.Rows.Add(code, description);
                                }
                            }

                            // 绑定数据源
                            comboBox2.DataSource = dt;
                            comboBox2.DisplayMember = "reason_code"; // 显示原因代码
                            comboBox2.ValueMember = "reason_code_description"; // 值成员为原因代码说明

                            // 设置下拉框的显示格式
                            comboBox2.DropDown += (sender, e) =>
                            {
                                ComboBox combo = sender as ComboBox;
                                if (combo != null)
                                {
                                    int width = combo.DropDownWidth;
                                    Graphics g = combo.CreateGraphics();
                                    Font font = combo.Font;
                                    int vertScrollBarWidth = (combo.Items.Count > combo.MaxDropDownItems) ? SystemInformation.VerticalScrollBarWidth : 0;

                                    // 计算两列的宽度
                                    int col1Width = 0;
                                    int col2Width = 0;
                                    foreach (DataRowView item in combo.Items)
                                    {
                                        string code = item["reason_code"].ToString();
                                        string desc = item["reason_code_description"].ToString();
                                        col1Width = Math.Max(col1Width, (int)g.MeasureString(code, font).Width);
                                        col2Width = Math.Max(col2Width, (int)g.MeasureString(desc, font).Width);
                                    }

                                    // 设置下拉框的宽度
                                    combo.DropDownWidth = col1Width + col2Width + vertScrollBarWidth;
                                }
                            };

                            // 设置下拉框的绘制方式
                            comboBox2.DrawMode = DrawMode.OwnerDrawFixed;
                            comboBox2.DrawItem += (sender, e) =>
                            {
                                e.DrawBackground();
                                if (e.Index >= 0)
                                {
                                    DataRowView row = (DataRowView)comboBox2.Items[e.Index];
                                    string code = row["reason_code"].ToString();
                                    string desc = row["reason_code_description"].ToString();

                                    // 绘制两列数据
                                    e.Graphics.DrawString(code, e.Font, Brushes.Black, e.Bounds.Left, e.Bounds.Top);
                                    e.Graphics.DrawString(desc, e.Font, Brushes.Gray, e.Bounds.Left + 100, e.Bounds.Top);
                                }
                                e.DrawFocusRectangle();
                            };

                            // 添加选择事件
                            comboBox2.SelectedIndexChanged += (sender, e) =>
                            {
                                if (comboBox2.SelectedItem != null)
                                {
                                    DataRowView row = (DataRowView)comboBox2.SelectedItem;
                                    textBox28.Text = row["reason_code_description"].ToString();
                                }
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载原因代码时出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReasonGroups()
        {
            try
            {
                using (var connection = new MySqlConnection(_batchService._repository._connectionString))
                {
                    connection.Open();

                    // 从unlocked_batch表获取不重复的原因组选项
                    string sql = "SELECT DISTINCT reason_group FROM unlocked_batch ORDER BY reason_group";

                    using (var command = new MySqlCommand(sql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            comboBox1.Items.Clear();

                            while (reader.Read())
                            {
                                string group = reader["reason_group"].ToString();
                                if (!string.IsNullOrEmpty(group))
                                {
                                    comboBox1.Items.Add(group);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载原因组选项时出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string batchId = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(batchId))
            {
                MessageBox.Show("请输入批次号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 清空现有数据
                ClearAllTextBoxes();
                dataGridView1.Rows.Clear();

                // 获取批次流转信息
                var batchFlows = _batchService.GetBatchFlowByBatchId(batchId);

                if (batchFlows == null || batchFlows.Count == 0)
                {
                    MessageBox.Show("未找到该批次的流转信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 显示批次流转信息
                DisplayBatchFlowInfo(batchFlows[0]);

                // 获取并显示锁定信息
                LoadLockedBatchData(batchId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"查询信息时出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 检查是否有选中的行
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选择要解锁的行", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 获取选中的行
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

            // 获取批次号
            string batchId = textBox1.Text.Trim();

            // 获取锁定时间
            DateTime lockTime = (DateTime)selectedRow.Cells["lock_time"].Value;

            try
            {
                using (var connection = new MySqlConnection(_batchService._repository._connectionString))
                {
                    connection.Open();

                    // 删除 locked_batch 表中的记录
                    string deleteSql = @"DELETE FROM locked_batch 
                                 WHERE batch_id = @BatchId AND lock_time = @LockTime";

                    using (var command = new MySqlCommand(deleteSql, connection))
                    {
                        command.Parameters.AddWithValue("@BatchId", batchId);
                        command.Parameters.AddWithValue("@LockTime", lockTime);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // 删除成功，从 DataGridView 中移除该行
                            dataGridView1.Rows.RemoveAt(selectedRow.Index);

                            MessageBox.Show("解锁成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("解锁失败，未找到对应的锁定记录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"解锁时出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}