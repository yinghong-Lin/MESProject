using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

using MDM.BLL.Batch;

namespace MDM.UI.Batch
{
    public partial class FrmCancelCreateBatch : Form
    {
        private readonly string _connectionString = "Server=localhost;Database=mesproject;Uid=root;Pwd=Lmi503606707;Port=3305;";

        public FrmCancelCreateBatch()
        {
            InitializeComponent();
            // 为DateTimePicker添加ValueChanged事件处理程序
            dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
            dateTimePicker2.ValueChanged += DateTimePicker2_ValueChanged;

            // 为DataGridView的CellClick事件添加处理逻辑
            dataGridView1.CellClick += DataGridView1_CellClick;
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            dataGridView1.CurrentCellDirtyStateChanged += DataGridView1_CurrentCellDirtyStateChanged;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect; // 或 FullRowSelect
            dataGridView1.MultiSelect = false; // 禁用多选
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter; // 根据需要设置编辑模式
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value >= dateTimePicker2.Value)
            {
                dateTimePicker2.Value = dateTimePicker1.Value.AddDays(1);
            }
        }

        private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker2.Value <= dateTimePicker1.Value)
            {
                dateTimePicker1.Value = dateTimePicker2.Value.AddDays(-1);
            }
        }

        private void DataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty &&
                dataGridView1.CurrentCell is DataGridViewCheckBoxCell)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // 如果是复选框列
            {
                var headerCell = dataGridView1.Columns[0].HeaderCell as DataGridViewCheckBoxHeaderCell;
                if (headerCell != null)
                {
                    headerCell.UpdateCheckState();
                }
                // 更新textbox2和textbox3的值
                UpdateTextBox2AndTextBox3();
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 只允许通过复选框列选中行
            if (e.RowIndex >= 0 && e.ColumnIndex == 0) // 假设复选框列是第一列(索引0)
            {
                // 切换复选框状态
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.Value = cell.Value == null || !(bool)cell.Value;

                // 更新头部复选框状态
                var headerCell = dataGridView1.Columns[0].HeaderCell as DataGridViewCheckBoxHeaderCell;
                if (headerCell != null)
                {
                    headerCell.UpdateCheckState();
                }

                // 提交更改
                dataGridView1.EndEdit();

                // 更新textbox2和textbox3的值
                UpdateTextBox2AndTextBox3();
            }
            else if (e.RowIndex >= 0)
            {
                // 对于非复选框列的点击，取消选中状态
                dataGridView1.ClearSelection();
            }

            // 处理头部复选框点击
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
            {
                var headerCell = dataGridView1.Columns[0].HeaderCell as DataGridViewCheckBoxHeaderCell;
                if (headerCell != null)
                {
                    bool newState = !headerCell.IsAllChecked();
                    headerCell.Checked = newState;

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[0] is DataGridViewCheckBoxCell checkBoxCell)
                        {
                            checkBoxCell.Value = newState;
                        }
                    }
                    dataGridView1.EndEdit();

                    // 更新textbox2和textbox3的值
                    UpdateTextBox2AndTextBox3();
                }
            }
        }

        public class DataGridViewCheckBoxHeaderCell : DataGridViewColumnHeaderCell
        {
            private bool _checked = false;
            private Point _checkBoxLocation;
            private Size _checkBoxSize;

            public bool Checked
            {
                get { return _checked; }
                set
                {
                    if (_checked != value)
                    {
                        _checked = value;
                        if (DataGridView != null)
                        {
                            DataGridView.InvalidateCell(this);
                        }
                    }
                }
            }

            protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
            {
                Point location = e.Location;
                Rectangle cellBounds = this.DataGridView.GetCellDisplayRectangle(this.ColumnIndex, -1, false);

                _checkBoxSize = new Size(16, 16);
                _checkBoxLocation = new Point(
                    cellBounds.X + (cellBounds.Width - _checkBoxSize.Width) / 2,
                    cellBounds.Y + (cellBounds.Height - _checkBoxSize.Height) / 2);

                Rectangle checkBoxBounds = new Rectangle(_checkBoxLocation, _checkBoxSize);
                if (checkBoxBounds.Contains(location))
                {
                    bool newCheckedState = !IsAllChecked();
                    Checked = newCheckedState;

                    foreach (DataGridViewRow row in DataGridView.Rows)
                    {
                        if (row.Cells[this.ColumnIndex] is DataGridViewCheckBoxCell checkBoxCell)
                        {
                            checkBoxCell.Value = newCheckedState;
                        }
                    }
                    DataGridView.EndEdit();
                }

                base.OnMouseClick(e);
            }

            // 检查所有行是否都被选中
            public bool IsAllChecked()
            {
                if (DataGridView == null || DataGridView.Rows.Count == 0)
                    return false;

                foreach (DataGridViewRow row in DataGridView.Rows)
                {
                    if (row.Cells[this.ColumnIndex] is DataGridViewCheckBoxCell checkBoxCell)
                    {
                        if (!(checkBoxCell.Value is bool) || !(bool)checkBoxCell.Value)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }

            // 检查是否有任何行被选中
            private bool IsAnyChecked()
            {
                if (DataGridView == null || DataGridView.Rows.Count == 0)
                    return false;

                foreach (DataGridViewRow row in DataGridView.Rows)
                {
                    if (row.Cells[this.ColumnIndex] is DataGridViewCheckBoxCell checkBoxCell)
                    {
                        if (checkBoxCell.Value is bool && (bool)checkBoxCell.Value)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }

            // 更新头部复选框状态
            public void UpdateCheckState()
            {
                if (IsAllChecked())
                {
                    Checked = true;
                }
                else if (IsAnyChecked())
                {
                    Checked = false; // 部分选中时显示未选中状态
                }
                else
                {
                    Checked = false;
                }
            }

            protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
                DataGridViewElementStates dataGridViewElementState, object value,
                object formattedValue, string errorText, DataGridViewCellStyle cellStyle,
                DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
            {
                base.Paint(graphics, clipBounds, cellBounds, rowIndex,
                    dataGridViewElementState, value, formattedValue, errorText,
                    cellStyle, advancedBorderStyle, paintParts);

                _checkBoxSize = new Size(16, 16);
                _checkBoxLocation = new Point(
                    cellBounds.X + (cellBounds.Width - _checkBoxSize.Width) / 2,
                    cellBounds.Y + (cellBounds.Height - _checkBoxSize.Height) / 2);

                CheckBoxState state = Checked ? CheckBoxState.CheckedNormal : CheckBoxState.UncheckedNormal;
                CheckBoxRenderer.DrawCheckBox(graphics, _checkBoxLocation, state);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void FrmCancelCreateBatch_Load(object sender, EventArgs e)
        {
            // 初始化窗体时设置DataGridView为空
            dataGridView1.DataSource = new List<MDM.Model.BatchEntities.Batch>();

            // 设置表格列标题
            SetupDataGridViewColumns();

            // 初始化textbox2和textbox3
            textBox2.Text = "0";
            textBox3.Text = "0";
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            // 清除任何非复选框引起的选择
            if (dataGridView1.SelectedCells.Count > 0 &&
                dataGridView1.SelectedCells[0].ColumnIndex != 0) // 假设复选框列是第一列
            {
                dataGridView1.ClearSelection();
            }
        }

        private void SetupDataGridViewColumns()
        {
            // 设置批次表格列
            dataGridView1.AutoGenerateColumns = false; // 禁用自动生成列
            dataGridView1.Columns.Clear(); // 清空现有列

            // 添加复选框列
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
            {
                Width = 50,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                HeaderCell = new DataGridViewCheckBoxHeaderCell() // 使用自定义的HeaderCell
            };

            dataGridView1.Columns.Add(checkBoxColumn);

            //添加批次号列
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "BatchId",
                HeaderText = "批次号",
                Width = 150
            });

            //添加批次类型列
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "BatchType",
                HeaderText = "批次类型",
                Width = 100
            });

            //添加单位列
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Unit",
                HeaderText = "单位",
                Width = 100
            });

            // 添加批次数量列
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "BatchQty",
                HeaderText = "批次数量",
                Width = 100
            });

            //添加子产品信息列
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "SubProductQty",
                HeaderText = "子产品数量",
                Width = 100
            });

            //添加在制品状态列
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "WIPStatus",
                HeaderText = "在制品状态",
                Width = 100
            });

            //添加锁定状态列
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "LockStatus",
                HeaderText = "锁定状态",
                Width = 100
            });

            //添加产品编号列
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ProductId",
                HeaderText = "产品编号",
                Width = 100
            });

            //添加工艺流程号列
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ProcessFlowNo",
                HeaderText = "工艺流程号",
                Width = 100
            });

            //添加工站号列
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "StationNo",
                HeaderText = "工站号",
                Width = 100
            });

            //添加工单号列
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "WorkOrderNo",
                HeaderText = "工单号",
                Width = 100
            });

            //添加工艺流程版本列
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ProcessFlowVersion",
                HeaderText = "工艺流程版本",
                Width = 100
            });

            //添加创建时间列
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "CreateTime",
                HeaderText = "创建时间",
                Width = 150
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string batchId = textBox1.Text.Trim();

            // 获取日期范围
            DateTime startDate = dateTimePicker1.Value.Date;
            DateTime endDate = dateTimePicker2.Value.Date;

            // 如果输入为空，则查询全部批次信息
            if (string.IsNullOrEmpty(batchId))
            {
                using (var batchService = new BatchService(_connectionString))
                {
                    List<MDM.Model.BatchEntities.Batch> batches = batchService.GetAllBatches();
                    dataGridView1.DataSource = batches;
                }
            }
            else
            {
                try
                {
                    using (var batchService = new BatchService(_connectionString))
                    {
                        List<MDM.Model.BatchEntities.Batch> batches;

                        if (string.IsNullOrEmpty(batchId))
                        {
                            // 查询全部批次信息，并筛选创建时间在指定范围内的批次
                            batches = batchService.GetAllBatches().Where(b => b.CreateTime >= startDate && b.CreateTime <= endDate).ToList();
                        }
                        else
                        {
                            // 查询指定批次号的批次信息，并筛选创建时间在指定范围内的批次
                            batches = batchService.GetBatchesByBatchId(batchId).Where(b => b.CreateTime >= startDate && b.CreateTime <= endDate).ToList();
                        }

                        if (batches.Count == 0)
                        {
                            MessageBox.Show("没有找到匹配的批次信息");
                            dataGridView1.DataSource = new List<MDM.Model.BatchEntities.Batch>();
                            return;
                        }
                        dataGridView1.DataSource = batches;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"查询批次信息时出错: {ex.Message}");
                }
            }
            // 更新textbox2和textbox3的值
            UpdateTextBox2AndTextBox3();
        }

        private void UpdateTextBox2AndTextBox3()
        {
            int selectedCount = 0;
            int totalBatchQty = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0] is DataGridViewCheckBoxCell checkBoxCell &&
                    checkBoxCell.Value is bool &&
                    (bool)checkBoxCell.Value)
                {
                    selectedCount++;
                    var batch = row.DataBoundItem as MDM.Model.BatchEntities.Batch;
                    if (batch != null)
                    {
                        totalBatchQty += batch.BatchQty;
                    }
                }
            }

            textBox3.Text = selectedCount.ToString();
            textBox2.Text = totalBatchQty.ToString();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            // 获取所有选中的行
            List<int> selectedRows = new List<int>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0] is DataGridViewCheckBoxCell checkBoxCell &&
                    checkBoxCell.Value is bool &&
                    (bool)checkBoxCell.Value)
                {
                    selectedRows.Add(row.Index);
                }
            }

            if (selectedRows.Count == 0)
            {
                MessageBox.Show("请至少选择一个批次进行取消创建");
                return;
            }

            try
            {
                using (var batchService = new BatchService(_connectionString))
                {
                    foreach (int rowIndex in selectedRows)
                    {
                        var batch = dataGridView1.Rows[rowIndex].DataBoundItem as MDM.Model.BatchEntities.Batch;
                        if (batch != null)
                        {
                            // 从数据库中删除批次
                            bool success = batchService.DeleteBatch(batch.BatchId);
                            if (!success)
                            {
                                MessageBox.Show($"删除批次 {batch.BatchId} 失败: {batchService.GetLastError()}");
                                return;
                            }
                        }
                    }

                    // 重新加载数据
                    RefreshDataGridView();
                    MessageBox.Show("成功选中的批次已取消创建");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"删除批次时出错: {ex.Message}");
            }
            // 更新textbox2和textbox3的值
            UpdateTextBox2AndTextBox3();
        }

        private void RefreshDataGridView()
        {
            using (var batchService = new BatchService(_connectionString))
            {
                dataGridView1.DataSource = batchService.GetAllBatches();
            }
        }
    }
}