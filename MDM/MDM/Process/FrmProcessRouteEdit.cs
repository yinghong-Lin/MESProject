using MDM.BLL.Process;
using MDM.Model.UserEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MDM.UI.Process
{
    public partial class FrmProcessRouteEdit : Form
    {
        private readonly IProcessService _processService;
        private readonly int _flowId;
        private List<Oper> _availableOpers;
        private List<Oper> _currentRouteOpers;

        public FrmProcessRouteEdit(IProcessService processService, int flowId)
        {
            _processService = processService;
            _flowId = flowId;
            _availableOpers = new List<Oper>();
            _currentRouteOpers = new List<Oper>();

            InitializeComponent();
            ConfigureDataGridViews();
            LoadData();
        }

        private void ConfigureDataGridViews()
        {
            // Configure Available Operations DataGridView
            dataGridViewAvailable.AutoGenerateColumns = false;
            dataGridViewAvailable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewAvailable.MultiSelect = true;
            dataGridViewAvailable.ReadOnly = true;
            dataGridViewAvailable.AllowUserToAddRows = false;
            dataGridViewAvailable.AllowUserToDeleteRows = false;
            dataGridViewAvailable.RowHeadersVisible = false;
            dataGridViewAvailable.ScrollBars = ScrollBars.Both;

            dataGridViewAvailable.Columns.Clear();
            dataGridViewAvailable.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OperId",
                HeaderText = "工站号",
                Name = "OperId",
                Width = 100
            });
            dataGridViewAvailable.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OperVersion",
                HeaderText = "工站版本",
                Name = "OperVersion",
                Width = 80
            });
            dataGridViewAvailable.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OperDescription",
                HeaderText = "工站说明",
                Name = "OperDescription",
                Width = 200
            });
            dataGridViewAvailable.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ReleaseState",
                HeaderText = "发行状态",
                Name = "ReleaseState",
                Width = 80
            });

            // Configure Current Route DataGridView
            dataGridViewRoute.AutoGenerateColumns = false;
            dataGridViewRoute.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewRoute.MultiSelect = true;
            dataGridViewRoute.ReadOnly = true;
            dataGridViewRoute.AllowUserToAddRows = false;
            dataGridViewRoute.AllowUserToDeleteRows = false;
            dataGridViewRoute.RowHeadersVisible = false;
            dataGridViewRoute.ScrollBars = ScrollBars.Both;

            dataGridViewRoute.Columns.Clear();
            dataGridViewRoute.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OperId",
                HeaderText = "工站号",
                Name = "OperId",
                Width = 100
            });
            dataGridViewRoute.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OperVersion",
                HeaderText = "工站版本",
                Name = "OperVersion",
                Width = 80
            });
            dataGridViewRoute.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OperDescription",
                HeaderText = "工站说明",
                Name = "OperDescription",
                Width = 200
            });
            dataGridViewRoute.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OpSeq",
                HeaderText = "工站序列",
                Name = "OpSeq",
                Width = 80
            });
            dataGridViewRoute.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ReleaseState",
                HeaderText = "发行状态",
                Name = "ReleaseState",
                Width = 80
            });
        }

         private void LoadData()
    {
        try
        {
            // 获取当前流程已关联的工站
            _currentRouteOpers = _processService.GetOpersByFlowId(_flowId);
            
            // 获取未关联的可用工站
            _availableOpers = _processService.GetNonOperListByFId(_flowId.ToString());

            // 绑定数据到DataGridView
            RefreshDataGridViews();

            Debug.WriteLine($"可用工站数量: {_availableOpers.Count}, 当前路线工站数量: {_currentRouteOpers.Count}");
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"LoadData 发生异常: {ex.Message}");
            MessageBox.Show($"加载数据失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

        private void btnAddToRoute_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewAvailable.SelectedRows.Count == 0)
                {
                    MessageBox.Show("请选择要添加的工站", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Add selected operations to route
                foreach (DataGridViewRow row in dataGridViewAvailable.SelectedRows)
                {
                    if (row.DataBoundItem is Oper oper)
                    {
                        _currentRouteOpers.Add(oper);
                        _availableOpers.Remove(oper);
                    }
                }

                RefreshDataGridViews();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"btnAddToRoute_Click 发生异常: {ex.Message}");
                MessageBox.Show($"添加工站失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveFromRoute_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewRoute.SelectedRows.Count == 0)
                {
                    MessageBox.Show("请选择要移除的工站", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Remove selected operations from route
                var itemsToRemove = new List<object>();
                foreach (DataGridViewRow row in dataGridViewRoute.SelectedRows)
                {
                    itemsToRemove.Add(row.DataBoundItem);
                }

                foreach (var item in itemsToRemove)
                {
                    var operProperty = item.GetType().GetProperty("OriginalOper");
                    if (operProperty != null)
                    {
                        var oper = operProperty.GetValue(item) as Oper;
                        if (oper != null)
                        {
                            _availableOpers.Add(oper);
                            _currentRouteOpers.Remove(oper);
                        }
                    }
                }

                RefreshDataGridViews();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"btnRemoveFromRoute_Click 发生异常: {ex.Message}");
                MessageBox.Show($"移除工站失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewRoute.SelectedRows.Count != 1)
                {
                    MessageBox.Show("请选择一个工站进行移动", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int selectedIndex = dataGridViewRoute.SelectedRows[0].Index;
                if (selectedIndex > 0)
                {
                    var temp = _currentRouteOpers[selectedIndex];
                    _currentRouteOpers[selectedIndex] = _currentRouteOpers[selectedIndex - 1];
                    _currentRouteOpers[selectedIndex - 1] = temp;

                    RefreshDataGridViews();
                    dataGridViewRoute.Rows[selectedIndex - 1].Selected = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"btnMoveUp_Click 发生异常: {ex.Message}");
                MessageBox.Show($"向上移动失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewRoute.SelectedRows.Count != 1)
                {
                    MessageBox.Show("请选择一个工站进行移动", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int selectedIndex = dataGridViewRoute.SelectedRows[0].Index;
                if (selectedIndex < _currentRouteOpers.Count - 1)
                {
                    var temp = _currentRouteOpers[selectedIndex];
                    _currentRouteOpers[selectedIndex] = _currentRouteOpers[selectedIndex + 1];
                    _currentRouteOpers[selectedIndex + 1] = temp;

                    RefreshDataGridViews();
                    dataGridViewRoute.Rows[selectedIndex + 1].Selected = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"btnMoveDown_Click 发生异常: {ex.Message}");
                MessageBox.Show($"向下移动失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshDataGridViews()
        {
            // Refresh available operations
            dataGridViewAvailable.DataSource = null;
            dataGridViewAvailable.DataSource = new BindingList<Oper>(_availableOpers);

            // Refresh current route
            var routeItems = _currentRouteOpers.Select((oper, index) => new
            {
                OperId = oper.OperId,
                OperVersion = oper.OperVersion,
                OperDescription = oper.OperDescription,
                OpSeq = (index + 1) * 100,
                ReleaseState = oper.ReleaseState,
                OriginalOper = oper
            }).ToList();

            dataGridViewRoute.DataSource = null;
            dataGridViewRoute.DataSource = new BindingList<object>(routeItems.Cast<object>().ToList());
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                // Here you would save the route changes to the database
                // For now, just close with OK result
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"btnOK_Click 发生异常: {ex.Message}");
                MessageBox.Show($"保存失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
