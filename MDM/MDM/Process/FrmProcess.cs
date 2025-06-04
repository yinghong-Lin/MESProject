using MDM.BLL.Process;
using MDM.Model.UserEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace MDM.UI.Process
{
    public partial class FrmProcess : Form
    {
        private readonly IProcessService _processService;
        private int _selectedPrpId = 0;
        private int _selectedFlowId = 0;
        private readonly string _currentFactoryId = null;

        // 用于产品组ComboBox的自定义类
        public class ProductGroupItem
        {
            public string Id { get; set; }
            public string Description { get; set; }

            public ProductGroupItem(string id, string description = "")
            {
                Id = id;
                Description = description;
            }

            public override string ToString()
            {
                if (Id == "All")
                    return "All";
                else
                    return $"{Id} - {Description}";
            }
        }

        // 用于产品ComboBox的自定义类
        public class ProductItem
        {
            public string Id { get; set; }
            public string Description { get; set; }

            public ProductItem(string id, string description = "")
            {
                Id = id;
                Description = description;
            }

            public override string ToString()
            {
                if (Id == "All")
                    return "All";
                else
                    return $"{Id} - {Description}";
            }
        }

        public FrmProcess(IProcessService processService, string factoryId = null)
        {
            InitializeComponent();
            _processService = processService;
            _currentFactoryId = factoryId;
            Debug.WriteLine($"FrmProcess 已初始化，工厂ID: {_currentFactoryId}");
        }

        private void FrmProcess_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("FrmProcess_Load 开始执行");

            try
            {
                // 初始化产品组下拉框
                InitializeProductGroupComboBox();

                // 初始化产品下拉框
                InitializeProductComboBox();

                // 配置DataGridView
                ConfigureDataGridViews();

                // 加载工艺包数据
                LoadPrps();

                // Add event handlers for cell formatting
                dataGridViewPrp.CellFormatting += DataGridView_CellFormatting;
                dataGridViewFlow.CellFormatting += DataGridView_CellFormatting;
                dataGridViewOper.CellFormatting += DataGridView_CellFormatting;

                Debug.WriteLine("FrmProcess_Load 执行完成");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"FrmProcess_Load 发生异常: {ex.Message}");
                MessageBox.Show($"加载窗体时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeProductGroupComboBox()
        {
            try
            {
                comboBoxProductGroup.Items.Clear();
                comboBoxProductGroup.Items.Add(new ProductGroupItem("All"));

                // 获取所有产品组数据
                var productGroups = _processService.GetAllProductGroups(_currentFactoryId);
                Debug.WriteLine($"从服务获取到 {productGroups.Count} 条产品组记录");

                // 添加每个产品组到下拉框
                foreach (var group in productGroups)
                {
                    string description = string.IsNullOrEmpty(group.ProductGroupDescription)
                        ? "无描述"
                        : group.ProductGroupDescription;

                    comboBoxProductGroup.Items.Add(new ProductGroupItem(
                        group.ProductGroupId,
                        description));
                }

                if (comboBoxProductGroup.Items.Count > 0)
                {
                    comboBoxProductGroup.SelectedIndex = 0;
                }
                Debug.WriteLine($"产品组下拉框初始化完成，共 {comboBoxProductGroup.Items.Count} 项");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"初始化产品组下拉框时发生异常: {ex.Message}");
                MessageBox.Show($"加载产品组失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeProductComboBox()
        {
            try
            {
                comboBoxProduct.Items.Clear();
                comboBoxProduct.Items.Add(new ProductItem("All"));

                // 获取选中的产品组
                string selectedProductGroup = "All";
                if (comboBoxProductGroup.SelectedItem is ProductGroupItem groupItem)
                {
                    selectedProductGroup = groupItem.Id;
                }

                // 获取所有产品数据
                var products = _processService.GetAllProducts(_currentFactoryId, selectedProductGroup == "All" ? null : selectedProductGroup);
                Debug.WriteLine($"从服务获取到 {products.Count} 条产品记录");

                // 添加每个产品到下拉框
                foreach (var product in products)
                {
                    string description = string.IsNullOrEmpty(product.ProductDescription)
                        ? "无描述"
                        : product.ProductDescription;

                    comboBoxProduct.Items.Add(new ProductItem(
                        product.ProductId,
                        description));
                }

                if (comboBoxProduct.Items.Count > 0)
                {
                    comboBoxProduct.SelectedIndex = 0;
                }
                Debug.WriteLine($"产品下拉框初始化完成，共 {comboBoxProduct.Items.Count} 项");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"初始化产品下拉框时发生异常: {ex.Message}");
                MessageBox.Show($"加载产品失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridViews()
        {
            // 配置工艺包DataGridView
            ConfigurePrpDataGridView();

            // 配置工艺流程DataGridView
            ConfigureFlowDataGridView();

            // 配置工站DataGridView
            ConfigureOperDataGridView();
        }

        private void ConfigurePrpDataGridView()
        {
            dataGridViewPrp.AutoGenerateColumns = false;
            dataGridViewPrp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPrp.MultiSelect = false;
            dataGridViewPrp.ReadOnly = true;
            dataGridViewPrp.AllowUserToAddRows = false;
            dataGridViewPrp.AllowUserToDeleteRows = false;
            dataGridViewPrp.AllowUserToResizeRows = false;
            dataGridViewPrp.RowHeadersVisible = false;
            dataGridViewPrp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 清除现有列
            dataGridViewPrp.Columns.Clear();

            // Add horizontal scrolling support
            dataGridViewPrp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridViewPrp.ScrollBars = ScrollBars.Both;
            dataGridViewPrp.AllowUserToResizeColumns = true;

            // 添加列
            dataGridViewPrp.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductId",
                HeaderText = "产品编号",
                Name = "ProductId"
            });

            dataGridViewPrp.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PrpVersion",
                HeaderText = "工艺包版本",
                Name = "PrpVersion"
            });

            dataGridViewPrp.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MainFlow",
                HeaderText = "主工艺流程",
                Name = "MainFlow"
            });

            var isActiveColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IsActive",
                HeaderText = "是否激活",
                Name = "IsActive"
            };
            dataGridViewPrp.Columns.Add(isActiveColumn);

            dataGridViewPrp.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PrpDescription",
                HeaderText = "工艺包说明",
                Name = "PrpDescription"
            });

            dataGridViewPrp.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ReleaseState",
                HeaderText = "发行状态",
                Name = "ReleaseState"
            });

            dataGridViewPrp.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PrpType",
                HeaderText = "工艺包类型",
                Name = "PrpType"
            });
        }

        private void ConfigureFlowDataGridView()
        {
            dataGridViewFlow.AutoGenerateColumns = false;
            dataGridViewFlow.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewFlow.MultiSelect = false;
            dataGridViewFlow.ReadOnly = true;
            dataGridViewFlow.AllowUserToAddRows = false;
            dataGridViewFlow.AllowUserToDeleteRows = false;
            dataGridViewFlow.AllowUserToResizeRows = false;
            dataGridViewFlow.RowHeadersVisible = false;

            // Add horizontal and vertical scrolling support
            dataGridViewFlow.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridViewFlow.ScrollBars = ScrollBars.Both;
            dataGridViewFlow.AllowUserToResizeColumns = true;

            // 清除现有列
            dataGridViewFlow.Columns.Clear();

            // 添加列 (保持原有的列定义)
            dataGridViewFlow.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FlowId",
                HeaderText = "工艺流程号",
                Name = "FlowId"
            });

            dataGridViewFlow.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FlowVersion",
                HeaderText = "工艺流程版本",
                Name = "FlowVersion"
            });

            dataGridViewFlow.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FlowDescription",
                HeaderText = "工艺流程描述",
                Name = "FlowDescription"
            });

            var flowIsActiveColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IsActive",
                HeaderText = "是否激活",
                Name = "IsActive"
            };
            dataGridViewFlow.Columns.Add(flowIsActiveColumn);

            dataGridViewFlow.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FlowType",
                HeaderText = "工艺流程类型",
                Name = "FlowType"
            });

            dataGridViewFlow.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ReleaseState",
                HeaderText = "发行状态",
                Name = "ReleaseState"
            });
        }

        private void ConfigureOperDataGridView()
        {
            dataGridViewOper.AutoGenerateColumns = false;
            dataGridViewOper.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewOper.MultiSelect = false;
            dataGridViewOper.ReadOnly = true;
            dataGridViewOper.AllowUserToAddRows = false;
            dataGridViewOper.AllowUserToDeleteRows = false;
            dataGridViewOper.AllowUserToResizeRows = false;
            dataGridViewOper.RowHeadersVisible = false;

            // Add horizontal and vertical scrolling support
            dataGridViewOper.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridViewOper.ScrollBars = ScrollBars.Both;
            dataGridViewOper.AllowUserToResizeColumns = true;

            // 清除现有列
            dataGridViewOper.Columns.Clear();

            dataGridViewOper.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OperId",
                HeaderText = "工站号",
                Name = "OperId",
                Width = 120
            });

            dataGridViewOper.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OperVersion",
                HeaderText = "工站版本",
                Name = "OperVersion",
                Width = 100
            });

            var operIsActiveColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IsActive",
                HeaderText = "是否激活",
                Name = "IsActive",
                Width = 80
            };
            dataGridViewOper.Columns.Add(operIsActiveColumn);

            dataGridViewOper.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OperDescription",
                HeaderText = "工站说明",
                Name = "OperDescription",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dataGridViewOper.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OperType",
                HeaderText = "工站类型",
                Name = "OperType",
                Width = 100
            });

            dataGridViewOper.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ReleaseState",
                HeaderText = "发行状态",
                Name = "ReleaseState",
                Width = 100
            });

            var isTrackinColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IsTrackin",
                HeaderText = "是否TrackIn",
                Name = "IsTrackin",
                Width = 100
            };
            dataGridViewOper.Columns.Add(isTrackinColumn);

            dataGridViewOper.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OperHour",
                HeaderText = "标准工时(分)",
                Name = "OperHour",
                Width = 120
            });
        }

        private void LoadPrps()
        {
            try
            {
                Debug.WriteLine($"正在加载工艺包数据，工厂ID: {_currentFactoryId}");

                // 获取工艺包列表
                var prps = _processService.GetAllPrps(_currentFactoryId);

                // 绑定到DataGridView
                dataGridViewPrp.DataSource = null;
                dataGridViewPrp.DataSource = new BindingList<Prp>(prps);

                // 清空工艺流程和工站DataGridView
                dataGridViewFlow.DataSource = null;
                dataGridViewOper.DataSource = null;

                // 清除选中的工艺包ID
                _selectedPrpId = 0;
                _selectedFlowId = 0;

                Debug.WriteLine($"成功加载了 {prps.Count} 条工艺包记录");

                // 如果有数据，选中第一行
                if (prps.Count > 0)
                {
                    dataGridViewPrp.Rows[0].Selected = true;
                    dataGridViewPrp_SelectionChanged(dataGridViewPrp, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"加载工艺包数据时发生异常: {ex.Message}");
                MessageBox.Show($"加载工艺包数据失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayFlows(int prpId)
        {
            try
            {
                if (prpId <= 0)
                {
                    dataGridViewFlow.DataSource = null;
                    return;
                }

                Debug.WriteLine($"正在加载工艺流程数据，工艺包ID: {prpId}");

                // 获取工艺流程列表
                var flows = _processService.GetFlowsByPrpId(prpId);

                // 绑定到DataGridView
                dataGridViewFlow.DataSource = null;
                dataGridViewFlow.DataSource = new BindingList<Flow>(flows);

                Debug.WriteLine($"成功加载了 {flows.Count} 条工艺流程记录");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"加载工艺流程数据时发生异常: {ex.Message}");
                MessageBox.Show($"加载工艺流程数据失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayOpers(int flowId)
        {
            try
            {
                if (flowId <= 0)
                {
                    dataGridViewOper.DataSource = null;
                    return;
                }

                Debug.WriteLine($"正在加载工站数据，工艺流程ID: {flowId}");

                // 获取工站列表
                var opers = _processService.GetOpersByFlowId(flowId);

                // 绑定到DataGridView
                dataGridViewOper.DataSource = null;
                dataGridViewOper.DataSource = new BindingList<Oper>(opers);

                Debug.WriteLine($"成功加载了 {opers.Count} 条工站记录");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"加载工站数据时发生异常: {ex.Message}");
                MessageBox.Show($"加载工站数据失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadPrps();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                // 刷新所有数据
                InitializeProductGroupComboBox();
                InitializeProductComboBox();
                LoadPrps();

                // 如果有选中的工艺包，刷新工艺流程和工站
                if (_selectedPrpId > 0)
                {
                    DisplayFlows(_selectedPrpId);
                    if (_selectedFlowId > 0)
                    {
                        DisplayOpers(_selectedFlowId);
                    }
                }

                MessageBox.Show("数据已刷新", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"刷新数据时发生异常: {ex.Message}");
                MessageBox.Show($"刷新数据失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewPrp_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                // Clear flow and operation data first
                dataGridViewFlow.DataSource = null;
                dataGridViewOper.DataSource = null;
                _selectedFlowId = 0;

                if (dataGridViewPrp.SelectedRows.Count > 0)
                {
                    // 获取选中的工艺包
                    var selectedRow = dataGridViewPrp.SelectedRows[0];
                    if (selectedRow.DataBoundItem is Prp selectedPrp)
                    {
                        _selectedPrpId = selectedPrp.Id;
                        Debug.WriteLine($"选中工艺包ID: {_selectedPrpId}, 产品ID: {selectedPrp.ProductId}");

                        // 显示工艺流程
                        DisplayFlows(_selectedPrpId);
                    }
                    else
                    {
                        Debug.WriteLine("选中行的数据不是Prp类型");
                        _selectedPrpId = 0;
                    }
                }
                else
                {
                    Debug.WriteLine("未选中任何工艺包");
                    _selectedPrpId = 0;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"处理工艺包选择变更时发生异常: {ex.Message}");
                MessageBox.Show($"处理工艺包选择时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewFlow_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                // Clear operation data first
                dataGridViewOper.DataSource = null;

                if (dataGridViewFlow.SelectedRows.Count > 0)
                {
                    // 获取选中的工艺流程
                    var selectedRow = dataGridViewFlow.SelectedRows[0];
                    if (selectedRow.DataBoundItem is Flow selectedFlow)
                    {
                        _selectedFlowId = selectedFlow.Id;
                        Debug.WriteLine($"选中工艺流程ID: {_selectedFlowId}, 流程号: {selectedFlow.FlowId}");

                        // 显示工站
                        DisplayOpers(_selectedFlowId);
                    }
                    else
                    {
                        Debug.WriteLine("选中行的数据不是Flow类型");
                        _selectedFlowId = 0;
                    }
                }
                else
                {
                    Debug.WriteLine("未选中任何工艺流程");
                    _selectedFlowId = 0;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"处理工艺流程选择变更时发生异常: {ex.Message}");
                MessageBox.Show($"处理工艺流程选择时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null) return;

            // Check if the column is IsActive or IsTrackin
            if (dgv.Columns[e.ColumnIndex].Name == "IsActive" ||
                dgv.Columns[e.ColumnIndex].Name == "IsTrackin")
            {
                if (e.Value != null)
                {
                    if (e.Value is bool boolValue)
                    {
                        e.Value = boolValue ? "Y" : "N";
                        e.FormattingApplied = true;
                    }
                    else if (e.Value is int intValue)
                    {
                        e.Value = intValue == 1 ? "Y" : "N";
                        e.FormattingApplied = true;
                    }
                    else if (e.Value.ToString() == "1" || e.Value.ToString().ToLower() == "true")
                    {
                        e.Value = "Y";
                        e.FormattingApplied = true;
                    }
                    else if (e.Value.ToString() == "0" || e.Value.ToString().ToLower() == "false")
                    {
                        e.Value = "N";
                        e.FormattingApplied = true;
                    }
                }
            }
        }


        private void btnEditRoute_Click_1(object sender, EventArgs e)
        {
            try
            {
                // 检查是否选中了工艺流程
                if (dataGridViewFlow.SelectedRows.Count == 0)
                {
                    MessageBox.Show("请先选择一个工艺流程", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 获取选中的工艺流程
                var selectedRow = dataGridViewFlow.SelectedRows[0];
                if (selectedRow.DataBoundItem is Flow selectedFlow)
                {
                    Debug.WriteLine($"打开工艺路线编辑窗体，工艺流程ID: {selectedFlow.Id}, 流程号: {selectedFlow.FlowId}");

                    // 创建并显示工艺路线编辑窗体
                    var editForm = new FrmProcessRouteEdit(_processService, _selectedFlowId);

                    // 设置为模态对话框
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        // 如果编辑成功，刷新当前显示的工站数据
                        DisplayOpers(_selectedFlowId);
                        MessageBox.Show("工艺路线编辑完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("无法获取选中的工艺流程信息", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"打开工艺路线编辑窗体时发生异常: {ex.Message}");
                MessageBox.Show($"打开工艺路线编辑窗体失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
