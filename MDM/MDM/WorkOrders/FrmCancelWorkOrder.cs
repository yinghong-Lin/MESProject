using MDM.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDM.UI.WorkOrders
{
    public partial class FrmCancelWorkOrder : Form
    {
        private CancelWorkOrderBLL bll = new CancelWorkOrderBLL(); // 确保已经定义了bll变量

        public FrmCancelWorkOrder()
        {
            InitializeComponent();
            LoadDataGridView();

            btnQuery.Click += btnQuery_Click;
            btnConfirm.Click += btnConfirm_Click;
        }

        private void LoadDataGridView()
        {
            // 清除现有列
            dataGridView1.Columns.Clear();

            // 设置不自动生成列
            dataGridView1.AutoGenerateColumns = false;

            // 添加全选列
            var checkBoxColumn = new DataGridViewCheckBoxColumn
            {
                HeaderText = "全选",
                Name = "CheckBoxColumn",
                Width = 50,
                FlatStyle = FlatStyle.Standard
            };
            dataGridView1.Columns.Add(checkBoxColumn);

            // 手动添加需要显示的中文列
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "工单号",
                DataPropertyName = "work_order_id", // 确保列名与数据库中的列名一致
                Name = "work_order_id" // 设置列的名称
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "工单类型",
                DataPropertyName = "work_order_type",
                Name = "work_order_type"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "工单说明",
                DataPropertyName = "work_order_description",
                Name = "work_order_description"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "成品工单号",
                DataPropertyName = "finished_work_order_no",
                Name = "finished_work_order_no"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "BOM编码",
                DataPropertyName = "bom",
                Name = "bom"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "BOM版本号",
                DataPropertyName = "bom_version",
                Name = "bom_version"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "产品类型",
                DataPropertyName = "product_type",
                Name = "product_type"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "详细类型",
                DataPropertyName = "detail_type",
                Name = "detail_type"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "产品编号",
                DataPropertyName = "product_id",
                Name = "product_id"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "工艺流程号",
                DataPropertyName = "process_flow",
                Name = "process_flow"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "计划生产数量",
                DataPropertyName = "planned_quantity",
                Name = "planned_quantity"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "测试程序号",
                DataPropertyName = "test_program",
                Name = "test_program"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "公司号",
                DataPropertyName = "company_code",
                Name = "company_code"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "计划开始日期",
                DataPropertyName = "planned_start_date",
                Name = "planned_start_date"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "计划结束日期",
                DataPropertyName = "planned_end_date",
                Name = "planned_end_date"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "客户批次号",
                DataPropertyName = "customer_lot_no",
                Name = "customer_lot_no"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "产品类别",
                DataPropertyName = "product_category",
                Name = "product_category"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "单位",
                DataPropertyName = "unit",
                Name = "unit"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "膜片厚度",
                DataPropertyName = "film_thickness",
                Name = "film_thickness"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "封装形式",
                DataPropertyName = "package_form",
                Name = "package_form"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "工单状态",
                DataPropertyName = "work_order_status",
                Name = "work_order_status"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "产品说明",
                DataPropertyName = "product_description",
                Name = "product_description"
            });

            // 新增“工艺版本”列
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "工艺版本",
                DataPropertyName = "process_version",
                Name = "process_version"
            });

            // 不绑定任何数据源 - 只显示空表头
            dataGridView1.DataSource = null;

            // 添加全选框事件处理
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex == -1) // 点击的是列头（全选）
            {
                bool isChecked = false;
                if (dataGridView1.Rows.Count > 0)
                {
                    // 获取当前全选列头的值（如果未设置则默认为false）
                    var headerCell = dataGridView1.Rows[0].Cells[0] as DataGridViewCheckBoxCell;
                    if (headerCell != null)
                    {
                        isChecked = true.Equals(headerCell.Value);
                    }

                    // 切换所有行的选择状态
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        row.Cells[0].Value = !isChecked;
                    }
                }
                dataGridView1.RefreshEdit();
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                // 获取创建工单界面创建的工单
                var createdWorkOrders = FrmCreateWorkOrder.CreatedWorkOrders;

                if (createdWorkOrders.Count == 0)
                {
                    MessageBox.Show("没有找到最近创建的工单");
                    return;
                }

                // 创建数据表
                DataTable dt = new DataTable();

                // 添加列（与创建工单界面的DataGridView列对应）
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    dt.Columns.Add(col.DataPropertyName, typeof(string));
                }

                // 添加行数据
                foreach (DataGridViewRow row in createdWorkOrders)
                {
                    DataRow newRow = dt.NewRow();
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        // 正确使用空值合并运算符（??）
                        newRow[i] = row.Cells[i].Value?.ToString() ?? (object)DBNull.Value;
                    }
                    dt.Rows.Add(newRow);
                }
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"查询失败：{ex.Message}", "错误",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // 获取用户输入的备注和用户编号
            string remark = txtRemark.Text.Trim();
            string userId = txtUserNumber.Text.Trim();

            // 检查备注和用户编号是否为空
            if (string.IsNullOrEmpty(remark) || string.IsNullOrEmpty(userId))
            {
                MessageBox.Show("备注和用户编号不能为空", "错误",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 检查用户是否存在
            if (!bll.CheckUserExists(userId))
            {
                MessageBox.Show("用户ID无效", "错误",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 获取选中的工单ID
            List<string> selectedWorkOrderIds = new List<string>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["CheckBoxColumn"].Value != null && (bool)row.Cells["CheckBoxColumn"].Value)
                {
                    selectedWorkOrderIds.Add(row.Cells["work_order_id"].Value.ToString());
                }
            }

            // 检查是否有选中的工单
            if (selectedWorkOrderIds.Count == 0)
            {
                MessageBox.Show("请至少选择一个工单", "错误",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 弹出确认框
            DialogResult result = MessageBox.Show("确定要取消选中的工单吗？", "确认",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    // 删除工单
                    bll.DeleteWorkOrders(selectedWorkOrderIds);
                    MessageBox.Show("工单已成功取消", "成功",
                                     MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 刷新数据
                    LoadDataGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"取消工单失败：{ex.Message}", "错误",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}