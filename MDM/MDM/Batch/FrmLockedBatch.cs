using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MDM.BLL.Batch;
using MDM.Model.BatchEntities;

using MySql.Data.MySqlClient;

namespace MDM.UI.Batch
{
    public partial class FrmLockedBatch : Form
    {
        public BatchService _batchService;
        // 添加成员变量
        private DataTable _lockCodesTable = new DataTable();
        private Dictionary<string, List<Tuple<string, string>>> _stationOperationsMap = new Dictionary<string, List<Tuple<string, string>>>();
        private DataTable _stationsTable = new DataTable();
        private DataTable _equipmentTable = new DataTable();

        public FrmLockedBatch()
        {
            InitializeComponent();
            _batchService = new BatchService("Server=localhost;Database=mdm_db;Uid=root;Pwd=Lmi503606707;Port=3305;");
            // 初始化下拉框
            InitializeComboBoxes();

            // 加载原因工艺流程
            LoadReasonProcessFlows();
        }

        // 初始化下拉框
        private void InitializeComboBoxes()
        {
            // 初始化 comboBox1
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;

            // 初始化 comboBox2
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox2.DrawItem += ComboBox2_DrawItem;
            comboBox2.DropDown += ComboBox2_DropDown;
            comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
            comboBox2.Enabled = false; // 初始禁用

            // 初始化 DataTable 结构
            _stationsTable = new DataTable();
            _stationsTable.Columns.Add("Station", typeof(string));
            _stationsTable.Columns.Add("OperationDesc", typeof(string));

            // 加载原因工艺流程数据
            LoadReasonProcessFlows();

            // 初始化comboBox3
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox3.DrawItem += ComboBox3_DrawItem;

            // 初始化设备号DataTable
            _equipmentTable.Columns.Add("ReasonEquipment", typeof(int));

            // 加载数据
            LoadEquipmentData();

            // 初始化 comboBox4
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox4.DrawItem += ComboBox4_DrawItem;
            comboBox4.DropDown += ComboBox4_DropDown;
            comboBox4.SelectedIndexChanged += ComboBox4_SelectedIndexChanged;

            // 初始化数据表结构
            _lockCodesTable.Columns.Add("LockCode", typeof(string));
            _lockCodesTable.Columns.Add("LockDescription", typeof(string));

            // 加载锁定代码数据
            LoadLockCodesData();
        }

        // 加载锁定代码数据
        private void LoadLockCodesData()
        {
            try
            {
                _lockCodesTable.Rows.Clear();

                // 绑定数据源
                comboBox4.DataSource = _lockCodesTable;
                comboBox4.DisplayMember = "LockCode";
                comboBox4.ValueMember = "LockCode";

                // 或者从数据库加载

                using (var connection = new MySqlConnection(_batchService._repository._connectionString))
                {
                    connection.Open();
                    string sql = "SELECT lock_code AS LockCode, lock_description AS LockDescription FROM locked_batch";
                    using (var adapter = new MySqlDataAdapter(sql, connection))
                    {
                        adapter.Fill(_lockCodesTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载锁定代码失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ComboBox4 绘制项
        private void ComboBox4_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            // 获取当前项的数据
            DataRowView row = (DataRowView)comboBox4.Items[e.Index];
            string lockCode = row["LockCode"].ToString();
            string lockDesc = row["LockDescription"].ToString();

            // 设置文本颜色
            Brush brush = Brushes.Black;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                brush = Brushes.White;
            }

            // 绘制两列文本
            e.Graphics.DrawString(lockCode, e.Font, brush, e.Bounds.Left, e.Bounds.Top);
            e.Graphics.DrawString(lockDesc, e.Font, brush, e.Bounds.Left + 120, e.Bounds.Top);

            e.DrawFocusRectangle();
        }

        // ComboBox4 下拉事件 - 调整下拉宽度
        private void ComboBox4_DropDown(object sender, EventArgs e)
        {
            // 计算需要的宽度
            int width = comboBox4.DropDownWidth;
            using (Graphics g = comboBox4.CreateGraphics())
            {
                int newWidth = 0;

                foreach (DataRowView item in comboBox4.Items)
                {
                    string lockCode = item["LockCode"].ToString();
                    string lockDesc = item["LockDescription"].ToString();

                    int codeWidth = (int)g.MeasureString(lockCode, comboBox4.Font).Width;
                    int descWidth = (int)g.MeasureString(lockDesc, comboBox4.Font).Width;

                    int totalWidth = codeWidth + descWidth + 150; // 添加间距

                    if (totalWidth > newWidth)
                        newWidth = totalWidth;
                }

                comboBox4.DropDownWidth = Math.Max(width, newWidth);
            }
        }

        // ComboBox4 选择变化事件
        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem == null) return;

            // 获取选中的行
            DataRowView selectedRow = (DataRowView)comboBox4.SelectedItem;

            // 更新锁定说明文本框
            textBox25.Text = selectedRow["LockDescription"].ToString();
        }

        private void LoadEquipmentData()
        {
            try
            {
                // 清空现有数据
                _equipmentTable.Rows.Clear();
                comboBox3.Items.Clear();

                // 从数据库locked_batch表中获取原因设备号数据
                using (var connection = new MySqlConnection(_batchService._repository._connectionString))
                {
                    connection.Open();

                    // 修改后的SQL，添加DISTINCT和ORDER BY
                    string sql = @"SELECT DISTINCT reason_equipment AS ReasonEquipment 
                          FROM locked_batch 
                          WHERE reason_equipment IS NOT NULL 
                          ORDER BY reason_equipment";

                    using (var command = new MySqlCommand(sql, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // 安全转换，避免null值
                            if (!reader.IsDBNull(0))
                            {
                                int equipmentNo = reader.GetInt32("ReasonEquipment");
                                _equipmentTable.Rows.Add(equipmentNo);
                            }
                        }
                    }
                }

                // 绑定数据源
                comboBox3.DataSource = _equipmentTable;
                comboBox3.DisplayMember = "ReasonEquipment";
                comboBox3.ValueMember = "ReasonEquipment";

                // 如果没有数据，显示提示
                if (comboBox3.Items.Count == 0)
                {
                    comboBox3.Text = "无可用设备号";
                }
            }
            catch (MySqlException mySqlEx)
            {
                MessageBox.Show($"数据库错误 (代码 {mySqlEx.Number}): {mySqlEx.Message}",
                               "数据库错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载设备号失败: {ex.Message}",
                               "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ComboBox3绘制方法
        private void ComboBox3_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            // 获取设备号
            int equipmentNo = (int)_equipmentTable.Rows[e.Index]["ReasonEquipment"];
            string displayText = $"{equipmentNo}";

            // 设置文本颜色
            Brush brush = (e.State & DrawItemState.Selected) == DrawItemState.Selected
                ? Brushes.White : Brushes.Black;

            // 绘制文本
            e.Graphics.DrawString(displayText, e.Font, brush, e.Bounds.Left + 5, e.Bounds.Top);

            e.DrawFocusRectangle();
        }

        // 加载原因工艺流程
        private void LoadReasonProcessFlows()
        {
            try
            {
                // 清空现有数据
                comboBox1.Items.Clear();
                _stationOperationsMap.Clear();

                // 从数据库加载原因工艺流程
                using (var connection = new MySqlConnection(_batchService._repository._connectionString))
                {
                    connection.Open();

                    // 加载工艺流程
                    string processSql = @"SELECT DISTINCT reason_process_flow 
                                FROM locked_batch 
                                WHERE reason_process_flow IS NOT NULL
                                ORDER BY reason_process_flow";

                    using (var command = new MySqlCommand(processSql, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string process = reader["reason_process_flow"].ToString();
                            comboBox1.Items.Add(process);
                        }
                    }

                    // 加载工站和工序说明
                    string stationSql = @"SELECT reason_process_flow, reason_station, reason_operation_desc 
                                FROM locked_batch 
                                WHERE reason_station IS NOT NULL 
                                AND reason_operation_desc IS NOT NULL
                                ORDER BY reason_process_flow, reason_station";

                    using (var command = new MySqlCommand(stationSql, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string process = reader["reason_process_flow"].ToString();
                            string station = reader["reason_station"].ToString();
                            string desc = reader["reason_operation_desc"].ToString();

                            if (!_stationOperationsMap.ContainsKey(process))
                            {
                                _stationOperationsMap[process] = new List<Tuple<string, string>>();
                            }

                            _stationOperationsMap[process].Add(new Tuple<string, string>(station, desc));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载工艺流程失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ComboBox1选择变化事件
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null) return;

            string selectedProcess = comboBox1.SelectedItem.ToString();

            // 清空ComboBox2和文本框
            comboBox2.DataSource = null;
            _stationsTable.Rows.Clear();
            textBox33.Clear();

            // 如果选择了有效的工艺流程，则加载对应的工站数据
            if (_stationOperationsMap.ContainsKey(selectedProcess))
            {
                // 填充DataTable
                foreach (var item in _stationOperationsMap[selectedProcess])
                {
                    _stationsTable.Rows.Add(item.Item1, item.Item2);
                }

                // 绑定数据到ComboBox2
                comboBox2.DataSource = _stationsTable;
                comboBox2.DisplayMember = "Station";
                comboBox2.ValueMember = "Station";

                // 启用ComboBox2
                comboBox2.Enabled = true;
            }
            else
            {
                comboBox2.Enabled = false;
            }
        }

        // ComboBox2绘制项
        private void ComboBox2_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            // 获取当前项的数据
            DataRowView row = (DataRowView)comboBox2.Items[e.Index];
            string station = row["Station"].ToString();
            string operationDesc = row["OperationDesc"].ToString();

            // 设置文本颜色
            Color textColor = (e.State & DrawItemState.Selected) == DrawItemState.Selected
                ? SystemColors.HighlightText : SystemColors.WindowText;

            using (Brush brush = new SolidBrush(textColor))
            {
                // 绘制工站列
                e.Graphics.DrawString(station, e.Font, brush, e.Bounds.Left + 2, e.Bounds.Top);

                // 绘制工序说明列
                e.Graphics.DrawString(operationDesc, e.Font, brush, e.Bounds.Left + 150, e.Bounds.Top);
            }

            // 绘制分隔线
            using (Pen pen = new Pen(SystemColors.ControlDark))
            {
                e.Graphics.DrawLine(pen, e.Bounds.Left + 140, e.Bounds.Top,
                                  e.Bounds.Left + 140, e.Bounds.Bottom);
            }

            e.DrawFocusRectangle();
        }

        // ComboBox2下拉事件
        private void ComboBox2_DropDown(object sender, EventArgs e)
        {
            // 调整下拉框宽度以显示两列
            int width = comboBox2.DropDownWidth;
            using (Graphics g = comboBox2.CreateGraphics())
            {
                int newWidth = 0;

                // 计算最大宽度
                foreach (DataRowView item in comboBox2.Items)
                {
                    string station = item["Station"].ToString();
                    string operationDesc = item["OperationDesc"].ToString();

                    int stationWidth = (int)g.MeasureString(station, comboBox2.Font).Width;
                    int descWidth = (int)g.MeasureString(operationDesc, comboBox2.Font).Width;

                    int totalWidth = stationWidth + descWidth + 170; // 添加间距

                    if (totalWidth > newWidth)
                        newWidth = totalWidth;
                }

                comboBox2.DropDownWidth = Math.Max(width, newWidth);
            }
        }

        // ComboBox2选择变化事件
        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == null) return;

            // 获取选中的行
            DataRowView selectedRow = (DataRowView)comboBox2.SelectedItem;

            // 更新工序说明文本框
            textBox33.Text = selectedRow["OperationDesc"].ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmLockedBatch_Load(object sender, EventArgs e)
        {
            //加载datagridview表头
            dataGridView1.Columns.Add("lock_time", "锁定时间");
            dataGridView1.Columns.Add("lock_code", "锁定代码");
            dataGridView1.Columns.Add("lock_description", "锁定说明");
            dataGridView1.Columns.Add("locked_by", "操作人员");
            dataGridView1.Columns.Add("reason_process_flow", "原因工艺流程");
            dataGridView1.Columns.Add("reason_station", "原因工站");
            dataGridView1.Columns.Add("reason_operation_desc", "原因工序说明");
            dataGridView1.Columns.Add("reason_equipment", "原因设备号");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string batchId = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(batchId))
            {
                MessageBox.Show("请输入批次号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var batchFlows = _batchService.GetBatchFlowByBatchId(batchId);
                //没有搜到记录
                if (batchFlows == null || batchFlows.Count == 0)
                {
                    MessageBox.Show("未找到该批次的信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAllTextBoxes();
                    return;
                }
                var batchFlow = batchFlows[0];
                DisplayBatchFlowInfo(batchFlow);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"查询批次流转信息时出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayBatchFlowInfo(BatchFlow batchFlow)
        {
            // 将 BatchFlow 对象的数据填充到各个文本框
            textBox2.Text = batchFlow.BatchType;
            textBox3.Text = batchFlow.DetailType;
            textBox4.Text = batchFlow.Qty.ToString();
            textBox5.Text = batchFlow.SubProductQty.ToString();
            textBox6.Text = batchFlow.Unit;
            textBox7.Text = batchFlow.LockStatus;
            textBox8.Text = batchFlow.ProductId;
            textBox9.Text = batchFlow.WorkOrderId;
            textBox10.Text = batchFlow.GoodQty.ToString();
            textBox26.Text = batchFlow.NGQty.ToString();
            textBox11.Text = batchFlow.OnProductState;
            textBox12.Text = batchFlow.RepairState;
            textBox13.Text = batchFlow.ProcessFlowNo;
            textBox15.Text = batchFlow.ProcessFlowVersion;
            textBox16.Text = batchFlow.FlowDescription;
            textBox14.Text = batchFlow.DestroyNum.ToString();
            textBox27.Text = batchFlow.SubProductQty.ToString();
            textBox17.Text = batchFlow.FlowState;
            textBox18.Text = batchFlow.ReworkStatus;
            textBox21.Text = batchFlow.StationType;
            textBox20.Text = batchFlow.StationVersion;
            textBox19.Text = batchFlow.DetailStationType;
            textBox22.Text = batchFlow.EquipmentNo;
            textBox23.Text = batchFlow.ProcessName;
            textBox24.Text = batchFlow.ParentBatch;
            comboBox5.Text = batchFlow.DetainCodeGroup;
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

        private void button2_Click(object sender, EventArgs e)
        {
            string batchId = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(batchId))
            {
                MessageBox.Show("请输入批次号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 验证必填字段
            if (string.IsNullOrEmpty(comboBox4.Text))
            {
                MessageBox.Show("请选择锁定代码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LockedBatch lockedBatch = new LockedBatch
            {
                BatchId = batchId,
                LockTime = DateTime.Now,
                LockCode = comboBox4.Text.Trim(),
                LockDescription = textBox25.Text.Trim(),
                LockedBy = "admin", // 使用当前系统用户
                LotReasonGroup = comboBox5.Text.Trim(),
                ReasonProcessFlow = comboBox1.Text.Trim(),
                ReasonStation = comboBox2.Text.Trim(),
                ReasonOperationDesc = textBox33.Text.Trim(),
                ReasonEquipment = int.TryParse(comboBox3.Text.Trim(), out int equipment) ? equipment : (int?)null,
                EventRemark = textBox35.Text.Trim()
            };

            try
            {
                if (_batchService.SaveLockedBatch(lockedBatch))
                {
                    MessageBox.Show("锁定信息保存成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 清空输入控件
                    ClearInputFields();

                    // 不需要刷新DataGridView，因为不显示数据
                }
                else
                {
                    MessageBox.Show($"锁定信息保存失败: {_batchService.GetLastError()}",
                                  "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存锁定信息时出错: {ex.Message}",
                                "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputFields()
        {
            // 保留批次号，清空其他锁定信息
            comboBox4.SelectedIndex = -1;
            textBox25.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            textBox33.Clear();
            comboBox3.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
            textBox34.Clear();
            textBox35.Clear();

            // 禁用依赖控件
            comboBox2.Enabled = false;
        }

        public void LoadLockedBatches(string batchId)
        {
            try
            {
                // 清空现有数据源
                dataGridView1.DataSource = null;

                // 只设置列结构，不绑定数据
                dataGridView1.Columns.Clear();

                // 手动添加列（只创建表头）
                dataGridView1.Columns.Add("lock_time", "锁定时间");
                dataGridView1.Columns.Add("lock_code", "锁定代码");
                dataGridView1.Columns.Add("lock_description", "锁定说明");
                dataGridView1.Columns.Add("locked_by", "操作人员");
                dataGridView1.Columns.Add("reason_process_flow", "原因工艺流程");
                dataGridView1.Columns.Add("reason_station", "原因工站");
                dataGridView1.Columns.Add("reason_operation_desc", "原因工序说明");
                dataGridView1.Columns.Add("reason_equipment", "原因设备号");

                // 执行查询确保批次存在（但不显示数据）
                using (var connection = new MySqlConnection(_batchService._repository._connectionString))
                {
                    connection.Open();
                    string sql = @"SELECT 1 FROM locked_batch WHERE batch_id = @BatchId LIMIT 1";
                    using (var command = new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@BatchId", batchId);
                        var exists = command.ExecuteScalar() != null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"验证批次时出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearAllTextBoxes();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}