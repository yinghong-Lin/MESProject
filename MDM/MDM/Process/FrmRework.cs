using System;
using System.Data;
using System.Windows.Forms;
using MDM.BLL.Process;

namespace MDM.UI.Process
{
    public partial class FrmRework : Form
    {
        private ReworkService _reworkService;
        private DataRow _currentBatchData; // 保存当前批次数据

        public FrmRework(ReworkService reworkService)
        {
            InitializeComponent();

            _reworkService = reworkService ?? throw new ArgumentNullException(nameof(reworkService));

            // 绑定查询按钮事件
            button3.Click += Button3_Click;

            // 绑定确认按钮事件
            button1.Click += Button1_Click;

            // 绑定退出按钮事件
            button2.Click += Button2_Click;

            // 初始化下拉框
            InitializeComboBoxes();
        }

        public FrmRework()
        {
            InitializeComponent();

            // 在设计器模式下也绑定事件
            this.Load += FrmRework_Load;
        }

        private void FrmRework_Load(object sender, EventArgs e)
        {
            if (_reworkService != null)
            {
                // 初始化下拉框
                InitializeComboBoxes();

                // 加载下拉框数据
                LoadDropdownData();
            }
        }

        private void InitializeComboBoxes()
        {
            try
            {
                // 设置下拉框的显示和值成员 - 显示第一个字段
                comboBox1.DisplayMember = "flow_id";  // 显示流程号
                comboBox1.ValueMember = "flow_id";

                comboBox2.DisplayMember = "product_id";  // 显示产品号
                comboBox2.ValueMember = "product_id";

                comboBox3.DisplayMember = "flow_id";  // 显示流程号
                comboBox3.ValueMember = "flow_id";

                comboBox4.DisplayMember = "oper_id";  // 显示工站号
                comboBox4.ValueMember = "oper_id";

                comboBox5.DisplayMember = "reason_code";  // 显示原因代码
                comboBox5.ValueMember = "reason_code";

                // 绑定下拉框选择变化事件
                comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
                comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
                comboBox4.SelectedIndexChanged += ComboBox4_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"初始化下拉框失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDropdownData()
        {
            try
            {
                // 加载返修流程选项
                DataTable reworkFlowOptions = _reworkService.GetReworkFlowOptions();
                comboBox1.DataSource = reworkFlowOptions;

                // 加载返修工艺选项
                DataTable reworkProcessOptions = _reworkService.GetReworkProcessOptions();
                comboBox2.DataSource = reworkProcessOptions;

                // 加载返回工站选项
                DataTable returnStationOptions = _reworkService.GetReturnStationOptions();
                comboBox4.DataSource = returnStationOptions;

                // 加载原因代码选项
                DataTable reasonCodeOptions = _reworkService.GetReasonCodeOptions();
                comboBox5.DataSource = reasonCodeOptions;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载下拉框数据失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (_reworkService == null)
                {
                    MessageBox.Show("返修服务未初始化，请通过主程序打开此窗体", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string batchId = lblBatchId.Text.Trim();

                if (string.IsNullOrEmpty(batchId))
                {
                    MessageBox.Show("请输入批次号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.Cursor = Cursors.WaitCursor;

                DataTable dt = _reworkService.GetBatchFlowDataByBatchId(batchId);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    _currentBatchData = row; // 保存当前批次数据

                    PopulateFields(row);
                    PopulateComboBoxes(row); // 填充下拉框

                    MessageBox.Show("查询成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("未找到对应的批次信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAllFields();
                    ClearComboBoxes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"查询失败: {ex.Message}\n\n详细信息: {ex.InnerException?.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (_reworkService == null)
                {
                    MessageBox.Show("返修服务未初始化，请通过主程序打开此窗体", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string batchId = lblBatchId.Text.Trim();

                if (string.IsNullOrEmpty(batchId))
                {
                    MessageBox.Show("请输入批次号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 验证必填字段
                if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null ||
                    comboBox3.SelectedItem == null || comboBox4.SelectedItem == null ||
                    comboBox5.SelectedItem == null)
                {
                    MessageBox.Show("请选择所有必填项", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.Cursor = Cursors.WaitCursor;

                // 获取选中的值
                DataRowView reworkFlowRow = (DataRowView)comboBox1.SelectedItem;
                string reworkFlowId = reworkFlowRow["flow_id"].ToString();
                string reworkFlowVersion = reworkFlowRow["flow_version"].ToString();

                DataRowView reworkProcessRow = (DataRowView)comboBox2.SelectedItem;
                string reworkProcessId = reworkProcessRow["product_id"].ToString();
                string reworkProcessVersion = reworkProcessRow["prp_version"].ToString();

                DataRowView returnStationRow = (DataRowView)comboBox4.SelectedItem;
                string returnStationId = returnStationRow["oper_id"].ToString();
                string returnStationVersion = returnStationRow["oper_version"].ToString();

                DataRowView reasonCodeRow = (DataRowView)comboBox5.SelectedItem;
                string reasonCode = reasonCodeRow["reason_code"].ToString();

                string remark = textBox35.Text.Trim();

                // 调用服务更新批次返修信息
                bool result = _reworkService.UpdateBatchReworkInfo(
                    batchId,
                    reworkFlowId,
                    reworkFlowVersion,
                    reworkProcessId,
                    reworkProcessVersion,
                    returnStationId,
                    returnStationVersion,
                    reasonCode,
                    remark);

                if (result)
                {
                    MessageBox.Show("批次返修信息更新成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 重新查询批次信息以刷新显示
                    DataTable dt = _reworkService.GetBatchFlowDataByBatchId(batchId);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        _currentBatchData = row;
                        PopulateFields(row);
                    }
                }
                else
                {
                    MessageBox.Show("批次返修信息更新失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"更新失败: {ex.Message}\n\n详细信息: {ex.InnerException?.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // 退出按钮
            this.Close();
        }

        private void PopulateComboBoxes(DataRow batchData)
        {
            try
            {
                // 1. 返修流程号 - 获取所有可用的工艺流程
                DataTable reworkFlowOptions = _reworkService.GetReworkFlowOptions();
                comboBox1.DataSource = reworkFlowOptions;

                // 2. 返修工艺号 - 获取所有可用的工艺包
                DataTable reworkProcessOptions = _reworkService.GetReworkProcessOptions();
                comboBox2.DataSource = reworkProcessOptions;

                // 3. 返回工艺流程号 - 固定内容：该批次的工艺流程号，版本，描述
                DataTable returnFlowOptions = new DataTable();
                returnFlowOptions.Columns.Add("flow_id", typeof(string));
                returnFlowOptions.Columns.Add("flow_version", typeof(string));
                returnFlowOptions.Columns.Add("flow_description", typeof(string));
                returnFlowOptions.Columns.Add("DisplayText", typeof(string));

                string currentFlowId = GetSafeString(batchData, "ProcessFlowNo");
                string currentFlowVersion = GetSafeString(batchData, "ProcessFlowVersion");
                string currentFlowDescription = GetSafeString(batchData, "ProcessFlowDescription");
                string currentFlowDisplay = $"{currentFlowId} - {currentFlowVersion} - {currentFlowDescription}";

                returnFlowOptions.Rows.Add(currentFlowId, currentFlowVersion, currentFlowDescription, currentFlowDisplay);
                comboBox3.DataSource = returnFlowOptions;
                comboBox3.SelectedIndex = 0; // 默认选中

                // 4. 返回工站号 - 获取所有可用的工站
                DataTable returnStationOptions = _reworkService.GetReturnStationOptions();
                comboBox4.DataSource = returnStationOptions;

                // 5. 原因代码 - 获取所有原因代码
                DataTable reasonCodeOptions = _reworkService.GetReasonCodeOptions();
                comboBox5.DataSource = reasonCodeOptions;

                // 填充对应的文本框
                PopulateReworkTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"填充下拉框失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateReworkTextBoxes()
        {
            try
            {
                if (_currentBatchData != null)
                {
                    // 填充返回工艺流程号的相关文本框（固定内容）
                    lblProcessFlowdes1.Text = GetSafeString(_currentBatchData, "ProcessFlowDescription");
                    lblProcessFlowVersion1.Text = GetSafeString(_currentBatchData, "ProcessFlowVersion");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"填充返修文本框失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 下拉框选择变化事件处理
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)comboBox1.SelectedItem;
                // 返修流程号的三个文本框分别显示：流程号、版本、描述
                // 假设对应的文本框是 txProcessFlowdes, txProcessFlowVersion
                // 根据您的Designer文件，应该是这些文本框
                txProcessFlowVersion.Text = GetSafeString(selectedRow, "flow_version");
                txProcessFlowdes.Text = GetSafeString(selectedRow, "flow_description");
            }
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)comboBox2.SelectedItem;
                // 返修工艺号的三个文本框分别显示：产品号、版本、描述
                txprpversion.Text = GetSafeString(selectedRow, "prp_version");
                txprpdes.Text = GetSafeString(selectedRow, "prp_description");
            }
        }

        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)comboBox4.SelectedItem;
                // 返回工站号的三个文本框分别显示：工站号、版本、描述
                txStationVersion.Text = GetSafeString(selectedRow, "oper_version");
                txStationdes.Text = GetSafeString(selectedRow, "oper_description");
            }
        }

        // 安全获取DataRowView字符串值的辅助方法
        private string GetSafeString(DataRowView rowView, string columnName)
        {
            try
            {
                return rowView.Row.Table.Columns.Contains(columnName) ? (rowView[columnName]?.ToString() ?? "") : "";
            }
            catch
            {
                return "";
            }
        }

        private void ClearComboBoxes()
        {
            comboBox1.DataSource = null;
            comboBox2.DataSource = null;
            comboBox3.DataSource = null;
            comboBox4.DataSource = null;
            comboBox5.DataSource = null;

            // 清空相关文本框
            txProcessFlowdes.Text = "";
            txProcessFlowVersion.Text = "";
            lblProcessFlowdes1.Text = "";
            lblProcessFlowVersion1.Text = "";
            txprpdes.Text = "";
            txprpversion.Text = "";
            txStationdes.Text = "";
            txStationVersion.Text = "";
        }

        private void PopulateFields(DataRow row)
        {
            try
            {
                // 填充批次信息
                lblBatchType.Text = GetSafeString(row, "BatchType");
                lblProductID.Text = GetSafeString(row, "ProductID");
                lblProcessFlowNo.Text = GetSafeString(row, "ProcessFlowNo");
                lblProcessFlowVersion.Text = GetSafeString(row, "ProcessFlowVersion");
                lblProcessFlowdes.Text = GetSafeString(row, "ProcessFlowDescription");
                lblstationNo.Text = GetSafeString(row, "oper_id");
                lblStationVersion.Text = GetSafeString(row, "StationVersion");
                lblStationdes.Text = GetSafeString(row, "OperDescription");
                lblDetailstationType.Text = GetSafeString(row, "DetailStationType");
                lblWorkOrderNo.Text = GetSafeString(row, "WorkOrderNo");

                // 数量信息
                lblBatchQty.Text = GetSafeString(row, "Qty");
                lblsubProductQty.Text = GetSafeString(row, "SubProductQty");
                lblGoodQty.Text = GetSafeString(row, "GoodQty");
                lblNGQty.Text = GetSafeString(row, "NGQty");

                // 设备和状态信息
                lblEquipmentNo.Text = GetSafeString(row, "EquipmentNo");
                lblunit.Text = GetSafeString(row, "Unit");
                lblWIPStatus.Text = GetSafeString(row, "WIPStatus");

                // 工艺状态绑定到PrpReleaseState字段
                lblprpstate.Text = GetSafeString(row, "PrpReleaseState");

                lblLockstatus.Text = GetSafeString(row, "LockStatus");
                lblReworkStatus.Text = GetSafeString(row, "ReworkStatus");
                lblParentBatch.Text = GetSafeString(row, "ParentBatch");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"填充数据时出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 安全获取字符串值的辅助方法
        private string GetSafeString(DataRow row, string columnName)
        {
            try
            {
                return row.Table.Columns.Contains(columnName) ? (row[columnName]?.ToString() ?? "") : "";
            }
            catch
            {
                return "";
            }
        }

        private void ClearAllFields()
        {
            lblBatchType.Text = "";
            lblProductID.Text = "";
            lblProcessFlowNo.Text = "";
            lblProcessFlowVersion.Text = "";
            lblProcessFlowdes.Text = "";
            lblstationNo.Text = "";
            lblStationVersion.Text = "";
            lblStationdes.Text = "";
            lblDetailstationType.Text = "";
            lblWorkOrderNo.Text = "";
            lblBatchQty.Text = "";
            lblsubProductQty.Text = "";
            lblGoodQty.Text = "";
            lblNGQty.Text = "";
            lblEquipmentNo.Text = "";
            lblunit.Text = "";
            lblWIPStatus.Text = "";
            lblprpstate.Text = "";
            lblLockstatus.Text = "";
            lblReworkStatus.Text = "";
            lblParentBatch.Text = "";
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            // 保留原有的事件处理器
        }
    }
}
