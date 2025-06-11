using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MDM.BLL;
using MDM.BLL.Process;
using MDM.DAL.Process;
using MDM.Model;
using MySql.Data.MySqlClient;

namespace MDM.UI.Admin
{
    public partial class FrmMainPage : Form
    {
        // 业务逻辑层实例
        private WorkOrderBLL workOrderBLL;
        private CancelWorkOrderBLL cancelWorkOrderBLL;
        private DispatchWorkOrderBLL dispatchWorkOrderBLL;
        private ReworkService reworkService;

        // 数据库连接字符串
        private readonly string connectionString = "server=localhost;database=mdm_db;uid=root;password=123456;";

        // 当前选中的数据
        private DataTable currentWorkOrderData;
        private DataTable currentBatchFlowData;
        private DataTable currentEquipmentData;

        public FrmMainPage()
        {
            InitializeComponent();
            InitializeBLL();
            InitializeForm();
        }

        /// <summary>
        /// 初始化业务逻辑层
        /// </summary>
        private void InitializeBLL()
        {
            try
            {
                workOrderBLL = new WorkOrderBLL();
                cancelWorkOrderBLL = new CancelWorkOrderBLL();
                dispatchWorkOrderBLL = new DispatchWorkOrderBLL();

                // 初始化返修服务
                var reworkRepository = new ReworkRepository(connectionString);
                reworkService = new ReworkService(reworkRepository);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"初始化业务逻辑层失败：{ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 初始化窗体
        /// </summary>
        private void InitializeForm()
        {
            try
            {
                // 设置窗体属性
                this.Text = "MDM 制造数据管理系统 - 主页面";
                this.WindowState = FormWindowState.Maximized;

                // 设置默认选择
                radioButton1.Checked = true; // 默认选择工单

                // 初始化下拉框
                InitializeComboBoxes();

                // 初始化数据表格
                InitializeDataGridViews();

                // 绑定事件
                BindEvents();

                // 设置控件可见性
                SetControlVisibility();

                // 加载初始数据
                LoadInitialData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"初始化窗体失败：{ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 设置控件可见性
        /// </summary>
        private void SetControlVisibility()
        {
            if (radioButton1.Checked) // 工单模式
            {
                // 显示所有控件
                label2.Visible = true;
                label9.Visible = true;
                comboBox2.Visible = true;
                label3.Visible = true;
                label10.Visible = true;
                comboBox3.Visible = true;
                label5.Visible = true;
                label8.Visible = true;
                textBox2.Visible = true;
            }
            else // 设备模式
            {
                // 只显示区域和设备号
                label2.Visible = false;
                label9.Visible = false;
                comboBox2.Visible = false;
                label3.Visible = false;
                label10.Visible = false;
                comboBox3.Visible = false;
                label5.Visible = false;
                label8.Visible = false;
                textBox2.Visible = false;
            }
        }

        /// <summary>
        /// 初始化下拉框
        /// </summary>
        private void InitializeComboBoxes()
        {
            // 区域下拉框 - 从设备表获取设备组
            comboBoxArea.Items.Clear();
            LoadAreaComboBox();

            // 详细工站类型下拉框
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(new string[] { "全部", "Type1", "Type2", "Type3", "Type4" });
            comboBox2.SelectedIndex = 0;

            // 工站号下拉框
            comboBox3.Items.Clear();
            LoadOperationComboBox();
        }

        /// <summary>
        /// 加载区域下拉框
        /// </summary>
        private void LoadAreaComboBox()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT DISTINCT equipment_group FROM equipment WHERE equipment_group IS NOT NULL ORDER BY equipment_group";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    comboBoxArea.Items.Add("全部");
                    while (reader.Read())
                    {
                        comboBoxArea.Items.Add(reader["equipment_group"].ToString());
                    }
                    comboBoxArea.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载区域数据失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // 添加默认数据
                comboBoxArea.Items.AddRange(new string[] { "全部", "GROUP-A", "GROUP-B", "GROUP-C", "GROUP-D" });
                comboBoxArea.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 加载工站号下拉框
        /// </summary>
        private void LoadOperationComboBox()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT DISTINCT oper_id FROM batchflow WHERE oper_id IS NOT NULL ORDER BY oper_id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    comboBox3.Items.Add("全部");
                    while (reader.Read())
                    {
                        comboBox3.Items.Add(reader["oper_id"].ToString());
                    }
                    comboBox3.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载工站数据失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // 添加默认数据
                comboBox3.Items.AddRange(new string[] { "全部", "OP001", "OP002", "OP003", "OP004" });
                comboBox3.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 初始化数据表格
        /// </summary>
        private void InitializeDataGridViews()
        {
            // 设置第一个数据表格（工单/设备列表）
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false; // 只允许单选
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // 设置选中行颜色为蓝色
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Blue;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;

            // 添加滚动条
            dataGridView1.ScrollBars = ScrollBars.Both;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            // 设置第二个数据表格（批次流转信息）
            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = true;
            dataGridView2.ReadOnly = true;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.RowHeadersVisible = true;
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGreen;
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // 设置选中行颜色为蓝色
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.Blue;
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.White;

            // 添加滚动条
            dataGridView2.ScrollBars = ScrollBars.Both;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        /// <summary>
        /// 绑定事件
        /// </summary>
        private void BindEvents()
        {
            // 单选按钮事件
            radioButton1.CheckedChanged += RadioButton_CheckedChanged;
            radioButton2.CheckedChanged += RadioButton_CheckedChanged;

            // 数据表格选择事件
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            dataGridView1.CellClick += DataGridView1_CellClick;

            // 按钮事件
            button2.Click += Button_TrackIn_Click;      // 入站
            button3.Click += Button_CancelTrackIn_Click; // 取消入站
            button4.Click += Button_TrackOut_Click;     // 出站
            button5.Click += Button_Unlock_Click;       // 解锁
            button6.Click += Button_Lock_Click;         // 锁定

            // 下拉框事件
            comboBoxArea.SelectedIndexChanged += ComboBoxArea_SelectedIndexChanged;

            // 窗体加载事件
            this.Load += FrmMainPage_Load;
        }

        /// <summary>
        /// 区域下拉框选择改变事件
        /// </summary>
        private void ComboBoxArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked) // 设备模式
            {
                LoadEquipmentByArea();
            }
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmMainPage_Load(object sender, EventArgs e)
        {
            try
            {
                // 显示欢迎信息
                UpdateStatusInfo($"系统启动完成 - {DateTime.Now:yyyy-MM-dd HH:mm:ss}");

                // 执行初始查询
                PerformQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载数据失败：{ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 加载初始数据
        /// </summary>
        private void LoadInitialData()
        {
            try
            {
                // 根据当前选择加载数据
                if (radioButton1.Checked)
                {
                    LoadWorkOrderData();
                }
                else
                {
                    LoadEquipmentData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载初始数据失败：{ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 单选按钮选择改变事件
        /// </summary>
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked)
                {
                    // 选择工单模式
                    label4.Text = "工单号";
                    SetControlVisibility();
                    LoadWorkOrderData();
                    UpdateStatusInfo("切换到工单模式");
                }
                else if (radioButton2.Checked)
                {
                    // 选择设备模式
                    label4.Text = "设备号";
                    SetControlVisibility();
                    LoadEquipmentData();
                    UpdateStatusInfo("切换到设备模式");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"切换模式失败：{ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 查询按钮点击事件
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            PerformQuery();
        }

        /// <summary>
        /// 执行查询
        /// </summary>
        private void PerformQuery()
        {
            try
            {
                // 显示加载状态
                this.Cursor = Cursors.WaitCursor;
                button1.Enabled = false;
                button1.Text = "查询中...";

                if (radioButton1.Checked)
                {
                    // 工单查询
                    QueryWorkOrders();
                }
                else
                {
                    // 设备查询
                    QueryEquipment();
                }

                // 默认选中第一行
                SelectFirstRow();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"查询失败：{ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 恢复状态
                this.Cursor = Cursors.Default;
                button1.Enabled = true;
                button1.Text = "查询";
            }
        }

        /// <summary>
        /// 默认选中第一行
        /// </summary>
        private void SelectFirstRow()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.ClearSelection();
                dataGridView1.Rows[0].Selected = true;
                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];

                // 触发选择改变事件
                DataGridView1_SelectionChanged(dataGridView1, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 查询工单
        /// </summary>
        private void QueryWorkOrders()
        {
            try
            {
                // 获取查询条件
                string workOrderNo = textBox1.Text.Trim();
                string batchNo = textBox2.Text.Trim();
                string detailStationType = comboBox2.SelectedItem?.ToString();
                string operId = comboBox3.SelectedItem?.ToString();

                // 执行查询
                DataTable workOrderData = workOrderBLL.GetWorkOrderList();

                // 应用过滤条件
                if (!string.IsNullOrEmpty(workOrderNo))
                {
                    workOrderData = FilterDataTable(workOrderData, "work_order_id", workOrderNo);
                }

                currentWorkOrderData = workOrderData;

                // 绑定数据到第一个表格
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = currentWorkOrderData;

                // 设置列标题
                SetWorkOrderColumnHeaders();

                // 清空第二个表格
                dataGridView2.DataSource = null;

                // 显示查询结果统计
                UpdateStatusInfo($"查询到 {currentWorkOrderData.Rows.Count} 条工单记录");
            }
            catch (Exception ex)
            {
                throw new Exception($"查询工单失败：{ex.Message}", ex);
            }
        }

        /// <summary>
        /// 查询设备
        /// </summary>
        private void QueryEquipment()
        {
            try
            {
                // 获取查询条件
                string area = comboBoxArea.SelectedItem?.ToString();
                string equipmentNo = textBox1.Text.Trim();

                // 从数据库查询设备数据
                DataTable equipmentData = GetEquipmentDataFromDatabase(area, equipmentNo);

                currentEquipmentData = equipmentData;

                // 绑定数据到第一个表格
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = currentEquipmentData;

                // 设置设备列标题
                SetEquipmentColumnHeaders();

                // 清空第二个表格
                dataGridView2.DataSource = null;

                UpdateStatusInfo($"查询到 {currentEquipmentData.Rows.Count} 条设备记录");
            }
            catch (Exception ex)
            {
                throw new Exception($"查询设备失败：{ex.Message}", ex);
            }
        }

        /// <summary>
        /// 从数据库获取设备数据
        /// </summary>
        private DataTable GetEquipmentDataFromDatabase(string area, string equipmentNo)
        {
            DataTable equipmentData = new DataTable();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"SELECT 
                        device_id,
                        device_desc,
                        current_status,
                        lock_status,
                        device_type,
                        equipment_group,
                        equipment_model,
                        communication_status,
                        equipment_status,
                        manufacturing_qty,
                        alarm_qty,
                        product_desc
                    FROM equipment WHERE 1=1";

                    List<MySqlParameter> parameters = new List<MySqlParameter>();

                    if (area != "全部" && !string.IsNullOrEmpty(area))
                    {
                        sql += " AND equipment_group = @area";
                        parameters.Add(new MySqlParameter("@area", area));
                    }

                    if (!string.IsNullOrEmpty(equipmentNo))
                    {
                        sql += " AND device_id LIKE @equipmentNo";
                        parameters.Add(new MySqlParameter("@equipmentNo", $"%{equipmentNo}%"));
                    }

                    sql += " ORDER BY device_id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddRange(parameters.ToArray());

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(equipmentData);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"从数据库获取设备数据失败：{ex.Message}", ex);
            }

            return equipmentData;
        }

        /// <summary>
        /// 设置设备列标题
        /// </summary>
        private void SetEquipmentColumnHeaders()
        {
            if (dataGridView1.Columns.Count > 0)
            {
                var columnMappings = new Dictionary<string, string>
                {
                    {"device_id", "设备号"},
                    {"device_desc", "设备说明"},
                    {"current_status", "当前状态"},
                    {"lock_status", "锁定状态"},
                    {"device_type", "设备类型"},
                    {"equipment_group", "设备组"},
                    {"equipment_model", "设备型号"},
                    {"communication_status", "通信状态"},
                    {"equipment_status", "设备状态"},
                    {"manufacturing_qty", "制程数量"},
                    {"alarm_qty", "报警数量"},
                    {"product_desc", "产品说明"}
                };

                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    if (columnMappings.ContainsKey(column.Name))
                    {
                        column.HeaderText = columnMappings[column.Name];
                    }
                }
            }
        }

        /// <summary>
        /// 根据区域加载设备
        /// </summary>
        private void LoadEquipmentByArea()
        {
            if (radioButton2.Checked)
            {
                QueryEquipment();
            }
        }

        /// <summary>
        /// 加载工单数据
        /// </summary>
        private void LoadWorkOrderData()
        {
            try
            {
                currentWorkOrderData = workOrderBLL.GetWorkOrderList();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = currentWorkOrderData;
                SetWorkOrderColumnHeaders();

                // 清空第二个表格
                dataGridView2.DataSource = null;

                UpdateStatusInfo($"加载了 {currentWorkOrderData.Rows.Count} 条工单记录");

                // 默认选中第一行
                SelectFirstRow();
            }
            catch (Exception ex)
            {
                throw new Exception($"加载工单数据失败：{ex.Message}", ex);
            }
        }

        /// <summary>
        /// 加载设备数据
        /// </summary>
        private void LoadEquipmentData()
        {
            try
            {
                currentEquipmentData = GetEquipmentDataFromDatabase("全部", "");
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = currentEquipmentData;
                SetEquipmentColumnHeaders();

                // 清空第二个表格
                dataGridView2.DataSource = null;

                UpdateStatusInfo($"加载了 {currentEquipmentData.Rows.Count} 条设备记录");

                // 默认选中第一行
                SelectFirstRow();
            }
            catch (Exception ex)
            {
                throw new Exception($"加载设备数据失败：{ex.Message}", ex);
            }
        }

        /// <summary>
        /// 设置工单列标题
        /// </summary>
        private void SetWorkOrderColumnHeaders()
        {
            if (dataGridView1.Columns.Count > 0)
            {
                var columnMappings = new Dictionary<string, string>
                {
                    {"work_order_id", "工单号"},
                    {"work_order_type", "工单类型"},
                    {"work_order_description", "工单说明"},
                    {"product_id", "产品编号"},
                    {"product_description", "产品说明"},
                    {"planned_quantity", "计划数量"},
                    {"planned_start_date", "计划开始日期"},
                    {"planned_end_date", "计划结束日期"},
                    {"work_order_status", "工单状态"},
                    {"process_flow", "工艺流程"},
                    {"process_version", "工艺版本"}
                };

                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    if (columnMappings.ContainsKey(column.Name))
                    {
                        column.HeaderText = columnMappings[column.Name];
                    }
                }
            }
        }

        /// <summary>
        /// 第一个数据表格单元格点击事件
        /// </summary>
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView1.ClearSelection();
                dataGridView1.Rows[e.RowIndex].Selected = true;
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[0];
                DataGridView1_SelectionChanged(sender, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 第一个数据表格选择改变事件
        /// </summary>
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    if (radioButton1.Checked)
                    {
                        // 工单模式：加载批次流转信息
                        LoadBatchFlowForWorkOrder();
                    }
                    else
                    {
                        // 设备模式：加载设备的批次流转信息
                        LoadBatchFlowForEquipment();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载详细信息失败：{ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 为选中工单加载批次流转数据（BatchFlow表）
        /// </summary>
        private void LoadBatchFlowForWorkOrder()
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    string workOrderId = dataGridView1.SelectedRows[0].Cells["work_order_id"].Value?.ToString();

                    if (!string.IsNullOrEmpty(workOrderId))
                    {
                        DataTable batchFlowData = GetBatchFlowDataByWorkOrder(workOrderId);
                        currentBatchFlowData = batchFlowData;
                        dataGridView2.DataSource = null;
                        dataGridView2.DataSource = currentBatchFlowData;
                        SetBatchFlowColumnHeaders();

                        UpdateStatusInfo($"工单 {workOrderId} 包含 {batchFlowData.Rows.Count} 条批次流转记录");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"加载批次流转数据失败：{ex.Message}", ex);
            }
        }

        /// <summary>
        /// 为选中设备加载批次流转数据（BatchFlow表）
        /// </summary>
        private void LoadBatchFlowForEquipment()
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    string equipmentNo = dataGridView1.SelectedRows[0].Cells["device_id"].Value?.ToString();

                    if (!string.IsNullOrEmpty(equipmentNo))
                    {
                        DataTable batchFlowData = GetBatchFlowDataByEquipment(equipmentNo);
                        currentBatchFlowData = batchFlowData;
                        dataGridView2.DataSource = null;
                        dataGridView2.DataSource = currentBatchFlowData;
                        SetBatchFlowColumnHeaders();

                        UpdateStatusInfo($"设备 {equipmentNo} 当前处理 {batchFlowData.Rows.Count} 条批次流转记录");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"加载设备批次流转数据失败：{ex.Message}", ex);
            }
        }

        /// <summary>
        /// 根据工单号获取批次流转数据
        /// </summary>
        private DataTable GetBatchFlowDataByWorkOrder(string workOrderId)
        {
            DataTable batchFlowData = new DataTable();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"SELECT 
                        bf.batch_id,
                        bf.Qty,
                        bf.GoodQty,
                        bf.NGQty,
                        bf.BatchType,
                        bf.Unit,
                        bf.ProductID,
                        bf.oper_id,
                        bf.Description,
                        bf.DetailStationType,
                        bf.ProcessStatus,
                        bf.EquipmentNo,
                        bf.EquipmentStatus,
                        bf.LockStatus,
                        bf.ReworkStatus,
                        bf.Location,
                        bf.ProcessFlowNo,
                        bf.ProcessFlowVersion,
                        bf.StationVersion,
                        bf.Grade,
                        bf.ProductionStartDate,
                        bf.OutboundDate,
                        bf.CarrierNo,
                        bf.StationType
                    FROM batchflow bf
                    INNER JOIN batch b ON bf.batch_id = b.batch_id
                    WHERE b.WorkOrderNo = @workOrderId
                    ORDER BY bf.batch_id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@workOrderId", workOrderId);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(batchFlowData);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"获取工单批次流转数据失败：{ex.Message}", ex);
            }

            return batchFlowData;
        }

        /// <summary>
        /// 根据设备号获取批次流转数据
        /// </summary>
        private DataTable GetBatchFlowDataByEquipment(string equipmentNo)
        {
            DataTable batchFlowData = new DataTable();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"SELECT 
                        batch_id,
                        Qty,
                        GoodQty,
                        NGQty,
                        BatchType,
                        Unit,
                        ProductID,
                        oper_id,
                        Description,
                        DetailStationType,
                        ProcessStatus,
                        EquipmentNo,
                        EquipmentStatus,
                        LockStatus,
                        ReworkStatus,
                        Location,
                        ProcessFlowNo,
                        ProcessFlowVersion,
                        StationVersion,
                        Grade,
                        ProductionStartDate,
                        OutboundDate,
                        CarrierNo,
                        StationType
                    FROM batchflow 
                    WHERE EquipmentNo = @equipmentNo
                    ORDER BY batch_id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@equipmentNo", equipmentNo);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(batchFlowData);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"获取设备批次流转数据失败：{ex.Message}", ex);
            }

            return batchFlowData;
        }

        /// <summary>
        /// 设置批次流转列标题
        /// </summary>
        private void SetBatchFlowColumnHeaders()
        {
            if (dataGridView2.Columns.Count > 0)
            {
                var columnMappings = new Dictionary<string, string>
                {
                    {"batch_id", "批次号"},
                    {"Qty", "总数量"},
                    {"GoodQty", "良品数量"},
                    {"NGQty", "不良数量"},
                    {"BatchType", "批次类型"},
                    {"Unit", "单位"},
                    {"ProductID", "产品编号"},
                    {"oper_id", "工站号"},
                    {"Description", "描述"},
                    {"DetailStationType", "详细工站类型"},
                    {"ProcessStatus", "制程状态"},
                    {"EquipmentNo", "设备号"},
                    {"EquipmentStatus", "设备状态"},
                    {"LockStatus", "锁定状态"},
                    {"ReworkStatus", "返修状态"},
                    {"Location", "位置"},
                    {"ProcessFlowNo", "工艺流程号"},
                    {"ProcessFlowVersion", "工艺流程版本"},
                    {"StationVersion", "工站版本"},
                    {"Grade", "等级"},
                    {"ProductionStartDate", "投产时间"},
                    {"OutboundDate", "出站时间"},
                    {"CarrierNo", "载具号"},
                    {"StationType", "工站类型"}
                };

                foreach (DataGridViewColumn column in dataGridView2.Columns)
                {
                    if (columnMappings.ContainsKey(column.Name))
                    {
                        column.HeaderText = columnMappings[column.Name];
                    }
                }
            }
        }

        // 按钮事件处理方法
        private void Button_TrackIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.SelectedRows.Count == 0)
                {
                    MessageBox.Show("请选择要入站的批次流转记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show("确认要执行入站操作吗？", "确认",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    PerformTrackIn();
                    MessageBox.Show("入站操作成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"入站操作失败：{ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button_CancelTrackIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.SelectedRows.Count == 0)
                {
                    MessageBox.Show("请选择要取消入站的批次流转记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show("确认要取消入站操作吗？", "确认",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    PerformCancelTrackIn();
                    MessageBox.Show("取消入站操作成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"取消入站操作失败：{ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button_TrackOut_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.SelectedRows.Count == 0)
                {
                    MessageBox.Show("请选择要出站的批次流转记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show("确认要执行出站操作吗？", "确认",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    PerformTrackOut();
                    MessageBox.Show("出站操作成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"出站操作失败：{ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button_Unlock_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.SelectedRows.Count == 0)
                {
                    MessageBox.Show("请选择要解锁的批次流转记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show("确认要解锁选中的批次流转记录吗？", "确认",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    PerformUnlock();
                    MessageBox.Show("解锁操作成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"解锁操作失败：{ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button_Lock_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.SelectedRows.Count == 0)
                {
                    MessageBox.Show("请选择要锁定的批次流转记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show("确认要锁定选中的批次流转记录吗？", "确认",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    PerformLock();
                    MessageBox.Show("锁定操作成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"锁定操作失败：{ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 操作方法
        private void PerformTrackIn()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                        {
                            string batchId = row.Cells["batch_id"].Value?.ToString();
                            if (!string.IsNullOrEmpty(batchId))
                            {
                                string sql = @"UPDATE batchflow 
                                             SET ProcessStatus = 'InProcess',
                                                 ProductionStartDate = NOW()
                                             WHERE batch_id = @batchId";

                                MySqlCommand cmd = new MySqlCommand(sql, conn, transaction);
                                cmd.Parameters.AddWithValue("@batchId", batchId);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        private void PerformCancelTrackIn()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                        {
                            string batchId = row.Cells["batch_id"].Value?.ToString();
                            if (!string.IsNullOrEmpty(batchId))
                            {
                                string sql = @"UPDATE batchflow 
                                             SET ProcessStatus = 'Pending',
                                                 ProductionStartDate = NULL
                                             WHERE batch_id = @batchId";

                                MySqlCommand cmd = new MySqlCommand(sql, conn, transaction);
                                cmd.Parameters.AddWithValue("@batchId", batchId);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        private void PerformTrackOut()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                        {
                            string batchId = row.Cells["batch_id"].Value?.ToString();
                            if (!string.IsNullOrEmpty(batchId))
                            {
                                string sql = @"UPDATE batchflow 
                                             SET ProcessStatus = 'Completed',
                                                 OutboundDate = NOW()
                                             WHERE batch_id = @batchId";

                                MySqlCommand cmd = new MySqlCommand(sql, conn, transaction);
                                cmd.Parameters.AddWithValue("@batchId", batchId);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        private void PerformUnlock()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                        {
                            string batchId = row.Cells["batch_id"].Value?.ToString();
                            if (!string.IsNullOrEmpty(batchId))
                            {
                                string sql = @"UPDATE batchflow 
                                             SET LockStatus = 'Unlocked'
                                             WHERE batch_id = @batchId";

                                MySqlCommand cmd = new MySqlCommand(sql, conn, transaction);
                                cmd.Parameters.AddWithValue("@batchId", batchId);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        private void PerformLock()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                        {
                            string batchId = row.Cells["batch_id"].Value?.ToString();
                            if (!string.IsNullOrEmpty(batchId))
                            {
                                string sql = @"UPDATE batchflow 
                                             SET LockStatus = 'Locked'
                                             WHERE batch_id = @batchId";

                                MySqlCommand cmd = new MySqlCommand(sql, conn, transaction);
                                cmd.Parameters.AddWithValue("@batchId", batchId);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        public void RefreshData()
        {
            try
            {
                PerformQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"刷新数据失败：{ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 过滤数据表
        /// </summary>
        private DataTable FilterDataTable(DataTable sourceTable, string columnName, string filterValue)
        {
            DataTable filteredTable = sourceTable.Clone();

            foreach (DataRow row in sourceTable.Rows)
            {
                if (row[columnName].ToString().Contains(filterValue))
                {
                    filteredTable.ImportRow(row);
                }
            }

            return filteredTable;
        }

        /// <summary>
        /// 更新状态信息
        /// </summary>
        private void UpdateStatusInfo(string message)
        {
            this.Text = $"MDM 制造数据管理系统 - 主页面 - {message}";
        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("确定要关闭主页面吗？", "关闭确认",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }

            base.OnFormClosing(e);
        }
    }
}