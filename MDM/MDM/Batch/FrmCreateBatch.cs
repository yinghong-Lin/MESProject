using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MDM.BLL.Batch; // 引用业务逻辑层
using MDM.Model.BatchEntities; // 引用数据模型

namespace MDM.UI.Batch
{
    public partial class FrmCreateBatch : Form
    {
        // 工单列表数据源
        private List<WorkOrderList> _workOrders = new List<WorkOrderList>();
        // 待创建的批次列表
        private List<MDM.Model.BatchEntities.Batch> _batchesToCreate = new List<MDM.Model.BatchEntities.Batch>();
        // 当前选中的工单
        private WorkOrderList _selectedWorkOrder;
        // 在类中添加连接字符串字段
        private readonly string _connectionString = "Server=localhost;Database=mesproject;Uid=root;Pwd=Lmi503606707;Port=3305;";
        // 在类中添加字段
        private bool _isBatchSelected = false;

        public FrmCreateBatch(string connectionString)
        {
            _connectionString = connectionString;
            InitializeComponent();

            // 初始化时设置DataGridView为空
            InitializeDataGridViews();
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            dataGridView2.SelectionChanged += dataGridView2_SelectionChanged;
        }

        public void InitializeDataGridViews()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // 设置工单列表数据源为空
            dataGridView1.DataSource = new List<WorkOrderList>();
            SetupDataGridViewColumns();
            // 设置批次列表数据源为空
            dataGridView2.DataSource = new List<MDM.Model.BatchEntities.Batch>();
            SetupDataGridViewColumns();
            // 初始禁用确定按钮
            button2.Enabled = false;
        }

        // 添加dataGridView2的选择事件
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            _isBatchSelected = dataGridView2.SelectedRows.Count >= 0;
            button2.Enabled = _isBatchSelected;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 验证是否已选择工单
            if (_selectedWorkOrder == null)
            {
                MessageBox.Show("请先选择工单");
                return;
            }

            // 验证输入的创建数量是否有效
            if (!int.TryParse(textBox2.Text, out int createQty) || createQty <= 0)
            {
                MessageBox.Show("请输入有效的创建数量");
                return;
            }

            // 计算剩余可创建数量 = 计划数量 - 已投入数量 - 已创建未投产数量
            int remainingQty = (int)(_selectedWorkOrder.PlannedQuantity -
                             (_selectedWorkOrder.InputNum ?? 0) -
                             (_selectedWorkOrder.CreatedNotProduceNum ?? 0));

            // 验证创建数量是否超过剩余数量
            if (createQty > remainingQty)
            {
                MessageBox.Show($"创建数量不能超过剩余数量{remainingQty}");
                return;
            }

            // 检查是否已存在相同工单的待创建批次
            if (_batchesToCreate.Any(b => b.WorkOrderNo == _selectedWorkOrder.WorkOrderId))
            {
                MessageBox.Show("该工单已有待创建的批次");
                return;
            }

            // 创建新的批次对象
            var newBatch = new MDM.Model.BatchEntities.Batch
            {
                BatchId = GenerateUniqueBatchId(), // 生成批次ID
                BatchType = "Normal", // 批次类型
                Unit = _selectedWorkOrder.Unit, // 单位
                DetailType = _selectedWorkOrder.DetailType, // 详细类型
                BatchQty = createQty, // 批次数量
                SubProductQty = 0, // 子产品数量
                WIPStatus = "Created", // 在制品状态
                LockStatus = "Unlocked", // 锁定状态
                WorkOrderNo = _selectedWorkOrder.WorkOrderId, // 关联工单号
                ProductId = _selectedWorkOrder.ProductId, // 产品编号
                ProcessFlowNo = _selectedWorkOrder.ProcessFlow, // 工艺流程号
                ProcessFlowVersion = "1.0", // 工艺流程版本
                StationNo = "START" // 起始工站
            };

            // 添加到待创建批次列表
            _batchesToCreate.Add(newBatch);
            // 刷新批次列表显示
            RefreshBatchList();
            // 更新数量显示
            UpdateQuantityDisplay();
        }

        // 刷新批次列表显示
        private void RefreshBatchList()
        {
            // 先清空数据源
            dataGridView2.DataSource = null;
            // 重新绑定数据源
            dataGridView2.DataSource = _batchesToCreate;
        }

        // 窗体加载事件
        private void FrmCreateBatch_Load(object sender, EventArgs e)
        {
            // 初始化时设置空数据源
            dataGridView1.DataSource = new List<WorkOrderList>();
            dataGridView2.DataSource = new List<MDM.Model.BatchEntities.Batch>();

            // 设置表格列标题
            SetupDataGridViewColumns();
        }

        // 设置DataGridView列
        private void SetupDataGridViewColumns()
        {
            // 设置工单清单表格列
            dataGridView1.AutoGenerateColumns = false; // 禁用自动生成列
            dataGridView1.Columns.Clear(); // 清空现有列

            // 添加工单号列
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "WorkOrderId", HeaderText = "工单号"
            });
            // 添加BOM编号
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Bom", HeaderText = "BOM编号"
            });
            // 添加工单类型
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "WorkOrderType",
                HeaderText = "工单类型"
            });
            // 详细产品类型
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ProductDetailType",
                HeaderText = "详细产品类型"
            });
            // 添加计划数量
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "PlannedQuantity",
                HeaderText = "计划数量",
                Width = 100
            });
            // 添加单位
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Unit",
                HeaderText = "单位"
            });
            // 添加产品编号
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ProductId",
                HeaderText = "产品编号"
            });
            // 添加工艺流程号
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ProcessFlow",
                HeaderText = "工艺流程号"
            });
            // 添加详细类型
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "DetailType",
                HeaderText = "详细类型"
            });
            // 添加工单状态
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "WorkOrderStatus",
                HeaderText = "工单状态"
            });
            // 添加成品工单号
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "FinishedWorkOrderNo",
                HeaderText = "成品工单号"
            });
            // 添加封装形式
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "PackageForm",
                HeaderText = "封装形式"
            });
            // 添加工单说明
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "WorkOrderDescription",
                HeaderText = "工单说明"
            });
            // 添加投入数量
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "InputNum",
                HeaderText = "投入数量",
                Width = 100
            });
            // 添加产出数量
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "OnputNum",
                HeaderText = "产出数量",
                Width = 100
            });
            // 添加报废数量
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "DestroyNum",
                HeaderText = "报废数量",
                Width = 100
            });
            // 添加公司号
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "CompanyCode",
                HeaderText = "公司号"
            });
            // 添加计划开始日期
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "PlannedStartDate",
                HeaderText = "计划开始日期",
                Width = 150
            });
            // 添加计划结束日期
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "PlannedEndDate",
                HeaderText = "计划结束日期",
                Width = 150
            });
            // 添加BOM版本
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "BomVersion",
                HeaderText = "BOM版本"
            });

            // 设置批次列表表格列
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.Columns.Clear();

            // 添加批次号列
            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "BatchId",
                HeaderText = "批次号",
                Width = 250
            });

            // 添加批次数量列
            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "BatchQty",
                HeaderText = "批次数量",
                Width = 250
            });
        }

        // "查询"按钮点击事件
        private void button1_Click(object sender, EventArgs e)
        {
            string workOrderId = textBox1.Text.Trim();

            // 如果输入为空，则查询全部工单
            if (string.IsNullOrEmpty(workOrderId))
            {
                using (var batchService = new BatchService(_connectionString))
                {
                    _workOrders = batchService.GetWorkOrdersById(null);
                    dataGridView1.DataSource = _workOrders;
                }
            }
            else
            {
                try
                {
                    using (var batchService = new BatchService(_connectionString))
                    {
                        _workOrders = batchService.GetWorkOrdersById(workOrderId);

                        if (_workOrders.Count == 0)
                        {
                            MessageBox.Show("没有找到匹配的工单");
                            dataGridView1.DataSource = new List<WorkOrderList>();
                            return;
                        }

                        dataGridView1.DataSource = _workOrders;

                        // 默认选择第一条工单
                        if (_workOrders.Count > 0)
                        {
                            dataGridView1.Rows[0].Selected = true;
                            _selectedWorkOrder = _workOrders[0];
                            UpdateQuantityDisplay(); // 更新数量显示
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"查询工单时出错: {ex.Message}");
                }
            }
        }

        // 更新数量显示
        private void UpdateQuantityDisplay()
        {
            if (_selectedWorkOrder != null)
            {
                // 剩余数量 = 计划数量 - 已投入数量 - 已创建未投产数量
                int remainingQty = (int)(_selectedWorkOrder.PlannedQuantity -
                                        (_selectedWorkOrder.InputNum ?? 0) -
                                        (_selectedWorkOrder.CreatedNotProduceNum ?? 0));

                textBox3.Text = remainingQty.ToString();
                textBox4.Text = (_selectedWorkOrder.CreatedNotProduceNum ?? 0).ToString();
            }
            else
            {
                textBox3.Text = "0";
                textBox4.Text = "0";
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0 &&
                    dataGridView1.SelectedRows[0].Index >= 0 &&
                    _workOrders != null &&
                    dataGridView1.SelectedRows[0].Index < _workOrders.Count)
                {
                    int index = dataGridView1.SelectedRows[0].Index;
                    _selectedWorkOrder = _workOrders[index];
                    UpdateQuantityDisplay(); // 更新数量显示
                }
            }
            catch (Exception ex)
            {
                // 记录错误日志
                Console.WriteLine($"选择行时出错: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 检查是否有选中行
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先在批次列表中选择要创建的批次");
                return;
            }

            // 获取选中的批次
            var selectedRow = dataGridView2.SelectedRows[0];
            var selectedBatch = selectedRow.DataBoundItem as MDM.Model.BatchEntities.Batch;

            if (selectedBatch == null)
            {
                MessageBox.Show("获取批次数据失败");
                return;
            }

            try
            {
                using (var batchService = new BatchService(_connectionString))
                {
                    // 设置创建时间
                    selectedBatch.CreateTime = DateTime.Now;

                    // 1. 创建批次
                    bool createBatchSuccess = batchService.CreateBatch(selectedBatch);

                    if (createBatchSuccess)
                    {
                        // 2. 更新工单的 CreatedNotProduceNum（累加批次数量）
                        bool updateWorkOrderSuccess = batchService.UpdateWorkOrder(_selectedWorkOrder, selectedBatch.BatchQty);

                        if (updateWorkOrderSuccess)
                        {
                            // 3. 重新查询工单数据，确保本地 _selectedWorkOrder 是最新的
                            var updatedWorkOrders = batchService.GetWorkOrdersById(_selectedWorkOrder.WorkOrderId);
                            if (updatedWorkOrders.Count > 0)
                            {
                                _selectedWorkOrder = updatedWorkOrders[0];
                            }

                            // 4. 从待创建列表中移除批次
                            _batchesToCreate.Remove(selectedBatch);

                            // 5. 刷新界面
                            RefreshBatchList();
                            UpdateQuantityDisplay();

                            MessageBox.Show($"批次创建成功！批次号：{selectedBatch.BatchId}");
                        }
                        else
                        {
                            MessageBox.Show("更新工单失败：" + batchService.GetLastError());
                        }
                    }
                    else
                    {
                        MessageBox.Show("批次创建失败：" + batchService.GetLastError());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存批次时出错：{ex.Message}");
            }
        }

        // "取消创建批次"按钮点击事件
        private void button3_Click(object sender, EventArgs e)
        {
            // 当有选中批次时
            if (dataGridView2.SelectedRows.Count > 0)
            {
                // 获取选中行的索引
                int index = dataGridView2.SelectedRows[0].Index;
                // 从列表中移除该批次
                _batchesToCreate.RemoveAt(index);
                // 刷新显示
                RefreshBatchList();
                // 更新数量显示
                UpdateQuantityDisplay();
            }
        }

        // 生成不重复的批次号
        private string GenerateUniqueBatchId()
        {
            int retryCount = 0;
            while (retryCount < 3)
            {
                try
                {
                    using (var batchService = new BatchService(_connectionString))
                    {
                        return batchService.GenerateNextBatchId();
                    }
                }
                catch (Exception ex)
                {
                    retryCount++;
                    if (retryCount >= 3)
                    {
                        MessageBox.Show($"生成批次号失败: {ex.Message}");
                        return $"TEMP-{DateTime.Now:yyyyMMddHHmmss}";
                    }
                    System.Threading.Thread.Sleep(100);
                }
            }
            return $"TEMP-{DateTime.Now:yyyyMMddHHmmss}";
        }
     }
}