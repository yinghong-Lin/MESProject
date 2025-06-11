using MDM.BLL;
using MDM.Model;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MDM.UI.WorkOrders
{
    public partial class FrmDispatchWorkOrder : Form
    {
        private readonly DispatchWorkOrderBLL _dispatchWorkOrderBll = new DispatchWorkOrderBLL();
        private bool _isProcessFlowDropdownOpen = false; // 跟踪下拉框状态
        private DataTable _originalProcessFlowTable; // 保存原始工艺流程数据
        private string _currentSelectedProcessFlow = string.Empty; // 新增字段
        private string _currentSelectedProcessVersion = string.Empty; // 新增字段
        private string _currentWorkOrderId = string.Empty; // 新增字段

        public FrmDispatchWorkOrder()
        {
            InitializeComponent();
            ConfigureDataGridView();
            ConfigureDateControls();
            LoadProcessFlows(); // 先加载工艺流程数据
        }

        private void ConfigureDateControls()
        {
            dtpStartDate.Value = DateTime.Today;
        }

        private void ConfigureDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            AddColumn("工单号", "WorkOrderId", 100);
            AddColumn("工单类型", "WorkOrderType", 100);
            AddColumn("工单说明", "WorkOrderDescription", 100);
            AddColumn("成品工单号", "FinishedWorkOrderNo", 100);
            AddColumn("BOM编码", "Bom", 100);
            AddColumn("BOM版本", "BomVersion", 100);
            AddColumn("产品类型", "ProductType", 100);
            AddColumn("详细类型", "DetailType", 100);
            AddColumn("产品编号", "ProductId", 100);
            AddColumn("工艺流程号", "ProcessFlow", 100);
            AddColumn("工艺版本", "ProcessVersion", 100);
            AddColumn("计划数量", "PlannedQuantity", 100);
            AddColumn("测试程序号", "TestProgram", 100);
            AddColumn("公司号", "CompanyCode", 100);
            AddColumn("计划开始日期", "PlannedStartDate", 100);
            AddColumn("计划结束日期", "PlannedEndDate", 100);
            AddColumn("客户批次号", "CustomerLotNo", 100);
            AddColumn("产品类别", "ProductCategory", 100);
            AddColumn("单位", "Unit", 100);
            AddColumn("膜片厚度", "FilmThickness", 100);
            AddColumn("封装形式", "PackageForm", 100);
            AddColumn("工单状态", "WorkOrderStatus", 100);
            AddColumn("产品说明", "ProductDescription", 100);

            // 添加 CellClick 事件处理器
            dataGridView1.CellClick += DataGridView1_CellClick;

            // 添加变更工艺流按钮
            btnChangeProcessFlow.Click += BtnChangeProcessFlow_Click;
        }

        private void AddColumn(string headerText, string dataPropertyName, int width)
        {
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = headerText,
                DataPropertyName = dataPropertyName,
                Name = dataPropertyName,
                Width = width
            });
        }

        private void btnQuery_Click_1(object sender, EventArgs e)
        {
            LoadWorkOrdersByStartDate();
        }

        private void LoadWorkOrdersByStartDate()
        {
            try
            {
                DateTime? startDate = dtpStartDate.Checked ? dtpStartDate.Value.Date : (DateTime?)null;

                var workOrders = _dispatchWorkOrderBll.GetWorkOrdersByStartDate(startDate);

                dataGridView1.DataSource = new BindingList<WorkOrder>(workOrders);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"查询失败: {ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProcessFlows()
        {
            try
            {
                var processFlows = _dispatchWorkOrderBll.GetProcessFlows();

                // 创建数据表
                _originalProcessFlowTable = new DataTable();
                _originalProcessFlowTable.Columns.Add("ProcessFlow", typeof(string));
                _originalProcessFlowTable.Columns.Add("ProcessVersion", typeof(string));

                // 添加提示行
                var promptRow = _originalProcessFlowTable.NewRow();
                promptRow["ProcessFlow"] = "-- 请选择工艺流程号 --";
                promptRow["ProcessVersion"] = "";
                _originalProcessFlowTable.Rows.Add(promptRow);

                // 添加数据行
                foreach (var processFlow in processFlows)
                {
                    var row = _originalProcessFlowTable.NewRow();
                    row["ProcessFlow"] = processFlow.ProcessFlow;
                    row["ProcessVersion"] = processFlow.ProcessVersion;
                    _originalProcessFlowTable.Rows.Add(row);
                }

                // 初始数据源（非下拉状态）
                comboBoxProcessFlow.DataSource = _originalProcessFlowTable;
                comboBoxProcessFlow.DisplayMember = "ProcessFlow";
                comboBoxProcessFlow.ValueMember = "ProcessFlow";
                comboBoxProcessFlow.SelectedIndex = 0;

                // 配置下拉框样式
                comboBoxProcessFlow.DrawMode = DrawMode.OwnerDrawFixed;
                comboBoxProcessFlow.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBoxProcessFlow.DrawItem += ComboBoxProcessFlow_DrawItem;
                comboBoxProcessFlow.MeasureItem += ComboBoxProcessFlow_MeasureItem;
                comboBoxProcessFlow.DropDown += ComboBoxProcessFlow_DropDown;
                comboBoxProcessFlow.DropDownClosed += ComboBoxProcessFlow_DropDownClosed;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载工艺流程失败: {ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dataGridView1.Rows[e.RowIndex];
                var workOrder = (WorkOrder)selectedRow.DataBoundItem;

                // 保存当前行的工艺流程信息
                _currentSelectedProcessFlow = workOrder.ProcessFlow;
                _currentSelectedProcessVersion = workOrder.ProcessVersion;
                _currentWorkOrderId = workOrder.WorkOrderId;

                textBoxWorkOrderId.Text = workOrder.WorkOrderId;
                textBoxWorkOrderVersion.Text = workOrder.BomVersion;
                textBoxProcessVersion.Text = workOrder.ProcessVersion;

                // 重置下拉框到原始数据源并选择当前项
                ResetProcessFlowComboBox(workOrder.ProcessFlow);
            }
        }

        private void ComboBoxProcessFlow_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 25;
        }

        private void ComboBoxProcessFlow_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            DataRowView row = (DataRowView)comboBoxProcessFlow.Items[e.Index];
            string processFlow = row["ProcessFlow"].ToString();
            string processVersion = row["ProcessVersion"].ToString();

            if (_isProcessFlowDropdownOpen)
            {
                if (e.Index == 0)
                {
                    // 绘制表头
                    using (var headerFont = new Font(e.Font, FontStyle.Bold))
                    using (var brush = new SolidBrush(Color.Black))
                    {
                        e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds);
                        e.Graphics.DrawString("工艺流程号", headerFont, brush,
                            new Rectangle(e.Bounds.Left + 5, e.Bounds.Top, 100, e.Bounds.Height));
                        e.Graphics.DrawString("工艺版本", headerFont, brush,
                            new Rectangle(e.Bounds.Left + 110, e.Bounds.Top, e.Bounds.Width - 115, e.Bounds.Height));
                        e.Graphics.DrawLine(Pens.DarkGray, e.Bounds.Left, e.Bounds.Bottom - 1,
                            e.Bounds.Right, e.Bounds.Bottom - 1);
                    }
                }
                else
                {
                    using (var brush = new SolidBrush(e.ForeColor))
                    {
                        e.Graphics.DrawString(processFlow, e.Font, brush,
                            new Rectangle(e.Bounds.Left + 5, e.Bounds.Top, 100, e.Bounds.Height));
                        e.Graphics.DrawString(processVersion, e.Font, brush,
                            new Rectangle(e.Bounds.Left + 110, e.Bounds.Top, e.Bounds.Width - 115, e.Bounds.Height));
                    }
                }
            }
            else
            {
                // 非下拉状态，只显示工艺流程号
                using (var brush = new SolidBrush(e.ForeColor))
                {
                    e.Graphics.DrawString(processFlow, e.Font, brush, e.Bounds);
                }
            }

            e.DrawFocusRectangle();
        }

        private void ComboBoxProcessFlow_DropDown(object sender, EventArgs e)
        {
            _isProcessFlowDropdownOpen = true;

            // 重新绑定数据源，包含表头
            DataTable newTable = new DataTable();
            newTable.Columns.Add("ProcessFlow", typeof(string));
            newTable.Columns.Add("ProcessVersion", typeof(string));

            // 添加表头行
            var headerRow = newTable.NewRow();
            headerRow["ProcessFlow"] = "工艺流程号";
            headerRow["ProcessVersion"] = "工艺版本";
            newTable.Rows.Add(headerRow);

            // 添加数据行（跳过原始数据源的第一行提示行）
            for (int i = 1; i < _originalProcessFlowTable.Rows.Count; i++)
            {
                DataRow row = _originalProcessFlowTable.Rows[i];
                var newRow = newTable.NewRow();
                newRow["ProcessFlow"] = row["ProcessFlow"];
                newRow["ProcessVersion"] = row["ProcessVersion"];
                newTable.Rows.Add(newRow);
            }

            comboBoxProcessFlow.DataSource = newTable;
            comboBoxProcessFlow.DisplayMember = "ProcessFlow";
            comboBoxProcessFlow.ValueMember = "ProcessFlow";
            comboBoxProcessFlow.SelectedIndex = 0; // 默认选择表头行
        }

        private void ComboBoxProcessFlow_DropDownClosed(object sender, EventArgs e)
        {
            _isProcessFlowDropdownOpen = false;

            if (comboBoxProcessFlow.SelectedIndex == 0) // 表头行
            {
                // 恢复原始数据源
                comboBoxProcessFlow.DataSource = _originalProcessFlowTable;
                comboBoxProcessFlow.DisplayMember = "ProcessFlow";
                comboBoxProcessFlow.ValueMember = "ProcessFlow";
                comboBoxProcessFlow.SelectedIndex = 0;
            }
            else
            {
                DataRowView selectedRow = (DataRowView)comboBoxProcessFlow.SelectedItem;
                string selectedProcessFlow = selectedRow["ProcessFlow"].ToString();
                string selectedProcessVersion = selectedRow["ProcessVersion"].ToString();

                // 更新当前选中的工艺流程信息
                _currentSelectedProcessFlow = selectedProcessFlow;
                _currentSelectedProcessVersion = selectedProcessVersion;

                // 创建简化数据源
                DataTable newTable = new DataTable();
                newTable.Columns.Add("ProcessFlow", typeof(string));
                newTable.Columns.Add("ProcessVersion", typeof(string));

                var promptRow = newTable.NewRow();
                promptRow["ProcessFlow"] = "-- 请选择工艺流程号 --";
                promptRow["ProcessVersion"] = "";
                newTable.Rows.Add(promptRow);

                var dataRow = newTable.NewRow();
                dataRow["ProcessFlow"] = selectedProcessFlow;
                dataRow["ProcessVersion"] = selectedProcessVersion;
                newTable.Rows.Add(dataRow);

                comboBoxProcessFlow.DataSource = newTable;
                comboBoxProcessFlow.DisplayMember = "ProcessFlow";
                comboBoxProcessFlow.ValueMember = "ProcessFlow";
                comboBoxProcessFlow.SelectedIndex = 1;

                // 更新版本文本框
                textBoxProcessVersion.Text = selectedProcessVersion;
            }
        }

        private void ResetProcessFlowComboBox(string processFlow)
        {
            // 重置为原始数据源
            comboBoxProcessFlow.DataSource = _originalProcessFlowTable;
            comboBoxProcessFlow.DisplayMember = "ProcessFlow";
            comboBoxProcessFlow.ValueMember = "ProcessFlow";

            // 查找并选中当前工艺流程号
            if (!string.IsNullOrEmpty(processFlow))
            {
                int index = -1;
                for (int i = 0; i < _originalProcessFlowTable.Rows.Count; i++)
                {
                    if (_originalProcessFlowTable.Rows[i]["ProcessFlow"].ToString() == processFlow)
                    {
                        index = i;
                        break;
                    }
                }
                comboBoxProcessFlow.SelectedIndex = index >= 0 ? index : 0;
            }
            else
            {
                comboBoxProcessFlow.SelectedIndex = 0;
            }
        }

        private void BtnChangeProcessFlow_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentWorkOrderId))
            {
                MessageBox.Show("请先选择一个工单", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxProcessFlow.SelectedIndex <= 0)
            {
                MessageBox.Show("请选择一个有效的工艺流程号", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 获取选中的工艺流程号和版本
            DataRowView selectedRow = (DataRowView)comboBoxProcessFlow.SelectedItem;
            string newProcessFlow = selectedRow["ProcessFlow"].ToString();
            string newProcessVersion = selectedRow["ProcessVersion"].ToString();

            // 弹出确认提示框
            DialogResult result = MessageBox.Show($"你确定要修改这个工艺流吗？\n新工艺流程号: {newProcessFlow}\n新工艺版本: {newProcessVersion}",
                "确认修改", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // 更新数据库
                    _dispatchWorkOrderBll.UpdateProcessFlow(_currentWorkOrderId, newProcessFlow, newProcessVersion);

                    // 更新界面
                    MessageBox.Show("工艺流修改成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadWorkOrdersByStartDate(); // 刷新数据
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"修改失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}