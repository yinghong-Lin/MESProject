using MDM.BLL;
using MDM.DAL;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MDM.UI.WorkOrders
{
    public partial class FrmCreateWorkOrder : Form
    {
        // 添加一个静态列表来存储创建的工单
        public static List<DataGridViewRow> CreatedWorkOrders = new List<DataGridViewRow>();
        private readonly WorkOrderBLL _bll = new WorkOrderBLL();
        private DataTable _workOrderTypes;
        private DataTable _productList; // 新增产品列表字段
        private DataTable _displayTable;
        private bool _isWorkOrderTypeDropdownOpen = false;
        private bool _isProductCodeDropdownOpen = false;

        public FrmCreateWorkOrder()
        {
            InitializeComponent();
            // 初始化日期选择器
            dtpPlannedStartDate.Format = DateTimePickerFormat.Custom;
            dtpPlannedStartDate.CustomFormat = "yyyy-MM-dd";
            dtpPlannedEndDate.Format = DateTimePickerFormat.Custom;
            dtpPlannedEndDate.CustomFormat = "yyyy-MM-dd";

            ConfigureComboBox();
            LoadWorkOrderTypes();
            LoadProductList(); // 加载产品列表
            LoadDataGridView();
            // 添加按钮事件绑定
            btnAdd.Click += btnAdd_Click; // 确保按钮名称为btnAdd
            btnClear.Click += btnClear_Click; // 确保按钮名称为btnClear
        }

        private void ConfigureComboBox()
        {
            cbWorkOrderType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbWorkOrderType.DrawMode = DrawMode.OwnerDrawFixed;
            cbWorkOrderType.DrawItem += CbWorkOrderType_DrawItem;
            cbWorkOrderType.MeasureItem += CbWorkOrderType_MeasureItem;
            cbWorkOrderType.DropDownHeight = 300;
            cbWorkOrderType.DropDown += cbWorkOrderType_DropDown;
            cbWorkOrderType.DropDownClosed += cbWorkOrderType_DropDownClosed;
            cbWorkOrderType.SelectedIndexChanged += cbWorkOrderType_SelectedIndexChanged;

            // 产品编号下拉框配置
            cbProductCode.DropDownStyle = ComboBoxStyle.DropDownList;
            cbProductCode.DrawMode = DrawMode.OwnerDrawFixed;
            cbProductCode.DrawItem += CbProductCode_DrawItem;
            cbProductCode.MeasureItem += CbProductCode_MeasureItem;
            cbProductCode.DropDownHeight = 300;
            cbProductCode.DropDown += CbProductCode_DropDown;
            cbProductCode.DropDownClosed += CbProductCode_DropDownClosed;
            cbProductCode.SelectedIndexChanged += cbProductCode_SelectedIndexChanged;
        }

        private void LoadProductList()
        {
            try
            {
                _productList = _bll.GetProductList();

                // 创建显示用的数据表
                var productDisplayTable = new DataTable();
                productDisplayTable.Columns.Add("ProductCode", typeof(string));
                productDisplayTable.Columns.Add("ProductDescription", typeof(string));

                // 添加提示行
                var productPromptRow = productDisplayTable.NewRow();
                productPromptRow["ProductCode"] = "-- 请选择产品编号 --";
                productPromptRow["ProductDescription"] = "";
                productDisplayTable.Rows.Add(productPromptRow);

                // 绑定下拉框
                foreach (DataRow row in _productList.Rows)
                {
                    var newRow = productDisplayTable.NewRow();
                    newRow["ProductCode"] = row["ProductCode"];
                    newRow["ProductDescription"] = row["ProductDescription"];
                    productDisplayTable.Rows.Add(newRow);
                }

                cbProductCode.DataSource = productDisplayTable;
                cbProductCode.DisplayMember = "ProductCode";
                cbProductCode.ValueMember = "ProductCode";
                cbProductCode.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载产品列表失败: {ex.Message}", "错误",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CbProductCode_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 25;
        }

        private void CbProductCode_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            DataRowView row = (DataRowView)cbProductCode.Items[e.Index];
            string productCode = row["ProductCode"].ToString();
            string description = row["ProductDescription"].ToString();

            if (_isProductCodeDropdownOpen)
            {
                if (e.Index == 0)
                {
                    using (var headerFont = new Font(e.Font, FontStyle.Bold))
                    using (var brush = new SolidBrush(Color.Black))
                    {
                        e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds);
                        e.Graphics.DrawString("产品编号", headerFont, brush,
                            new Rectangle(e.Bounds.Left + 5, e.Bounds.Top, 100, e.Bounds.Height));
                        e.Graphics.DrawString("产品说明", headerFont, brush,
                            new Rectangle(e.Bounds.Left + 110, e.Bounds.Top, e.Bounds.Width - 115, e.Bounds.Height));
                        e.Graphics.DrawLine(Pens.DarkGray, e.Bounds.Left, e.Bounds.Bottom - 1,
                            e.Bounds.Right, e.Bounds.Bottom - 1);
                    }
                }
                else
                {
                    using (var brush = new SolidBrush(e.ForeColor))
                    {
                        e.Graphics.DrawString(productCode, e.Font, brush,
                            new Rectangle(e.Bounds.Left + 5, e.Bounds.Top, 100, e.Bounds.Height));
                        e.Graphics.DrawString(description, e.Font, brush,
                            new Rectangle(e.Bounds.Left + 110, e.Bounds.Top, e.Bounds.Width - 115, e.Bounds.Height));
                    }
                }
            }
            else
            {
                using (var brush = new SolidBrush(e.ForeColor))
                {
                    e.Graphics.DrawString(productCode, e.Font, brush, e.Bounds);
                }
            }

            e.DrawFocusRectangle();
        }

        private void cbProductCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProductCode.SelectedIndex == 0)
            {
                txtProductDescription.Text = "";
                txtProductType.Text = "";
                txtProductCategory.Text = "";
                txtProcessFlow.Text = "";
                txtBOM.Text = "";
                txtBOMVersion.Text = "";
                txtUnit.Text = "";
                txtPackagingForm.Text = "";
                txtProcessVersion.Text = ""; // 清空工艺版本文本框
                return;
            }

            DataRowView selectedRow = (DataRowView)cbProductCode.SelectedItem;
            string selectedCode = selectedRow["ProductCode"].ToString();

            try
            {
                DataTable productDetails = _bll.GetProductDetails(selectedCode);

                if (productDetails.Rows.Count > 0)
                {
                    DataRow row = productDetails.Rows[0];
                    txtProductDescription.Text = selectedRow["ProductDescription"].ToString();
                    txtProductType.Text = row["ProductType"].ToString();
                    txtProductCategory.Text = row["ProductCategory"].ToString();
                    txtProcessFlow.Text = row["ProcessFlow"].ToString();
                    txtBOM.Text = row["BOM"].ToString();
                    txtBOMVersion.Text = row["BOMVersion"].ToString();
                    txtUnit.Text = row["Unit"].ToString();
                    txtPackagingForm.Text = row["PackagingForm"].ToString();
                    txtProcessVersion.Text = row["ProcessVersion"].ToString(); // 填充工艺版本文本框
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"获取产品详细信息失败: {ex.Message}", "错误",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CbProductCode_DropDown(object sender, EventArgs e)
        {
            _isProductCodeDropdownOpen = true;

            DataTable newTable = new DataTable();
            newTable.Columns.Add("ProductCode", typeof(string));
            newTable.Columns.Add("ProductDescription", typeof(string));

            var headerRow = newTable.NewRow();
            headerRow["ProductCode"] = "产品编号";
            headerRow["ProductDescription"] = "产品说明";
            newTable.Rows.Add(headerRow);

            foreach (DataRow row in _productList.Rows)
            {
                var newRow = newTable.NewRow();
                newRow["ProductCode"] = row["ProductCode"];
                newRow["ProductDescription"] = row["ProductDescription"];
                newTable.Rows.Add(newRow);
            }

            cbProductCode.DataSource = newTable;
            cbProductCode.DisplayMember = "ProductCode";
            cbProductCode.ValueMember = "ProductCode";
            cbProductCode.SelectedIndex = 0;
        }

        private void CbProductCode_DropDownClosed(object sender, EventArgs e)
        {
            _isProductCodeDropdownOpen = false;

            if (cbProductCode.SelectedIndex > 0)
            {
                var selectedRow = (DataRowView)cbProductCode.SelectedItem;
                string selectedCode = selectedRow["ProductCode"].ToString();
                string description = selectedRow["ProductDescription"].ToString();

                DataTable newTable = new DataTable();
                newTable.Columns.Add("ProductCode", typeof(string));
                newTable.Columns.Add("ProductDescription", typeof(string));

                var promptRow = newTable.NewRow();
                promptRow["ProductCode"] = "-- 请选择产品编号 --";
                promptRow["ProductDescription"] = "";
                newTable.Rows.Add(promptRow);

                var dataRow = newTable.NewRow();
                dataRow["ProductCode"] = selectedCode;
                dataRow["ProductDescription"] = description;
                newTable.Rows.Add(dataRow);

                cbProductCode.DataSource = newTable;
                cbProductCode.DisplayMember = "ProductCode";
                cbProductCode.ValueMember = "ProductCode";
                cbProductCode.SelectedIndex = 1;
            }
            else
            {
                DataTable newTable = new DataTable();
                newTable.Columns.Add("ProductCode", typeof(string));
                newTable.Columns.Add("ProductDescription", typeof(string));

                var promptRow = newTable.NewRow();
                promptRow["ProductCode"] = "-- 请选择产品编号 --";
                promptRow["ProductDescription"] = "";
                newTable.Rows.Add(promptRow);

                cbProductCode.DataSource = newTable;
                cbProductCode.DisplayMember = "ProductCode";
                cbProductCode.ValueMember = "ProductCode";
                cbProductCode.SelectedIndex = 0;
            }
        }

        private void LoadWorkOrderTypes()
        {
            try
            {
                _workOrderTypes = _bll.GetDistinctWorkOrderTypes();

                // 创建显示用的数据表
                _displayTable = new DataTable();
                _displayTable.Columns.Add("TypeCode", typeof(string));
                _displayTable.Columns.Add("TypeDescription", typeof(string));
                _displayTable.Columns.Add("DetailType", typeof(string)); // 添加DetailType列

                // 添加提示行
                var promptRow = _displayTable.NewRow();
                promptRow["TypeCode"] = "-- 请选择工单类型 --";
                promptRow["TypeDescription"] = "";
                promptRow["DetailType"] = "";
                _displayTable.Rows.Add(promptRow);

                // 绑定下拉框
                foreach (DataRow row in _workOrderTypes.Rows)
                {
                    var newRow = _displayTable.NewRow();
                    newRow["TypeCode"] = row["TypeCode"];
                    newRow["TypeDescription"] = row["TypeDescription"];
                    newRow["DetailType"] = row["DetailType"]; // 复制DetailType值
                    _displayTable.Rows.Add(newRow);
                }

                cbWorkOrderType.DataSource = _displayTable;
                cbWorkOrderType.DisplayMember = "TypeCode";
                cbWorkOrderType.ValueMember = "TypeCode";
                cbWorkOrderType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载工单类型失败: {ex.Message}", "错误",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CbWorkOrderType_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 25;
        }

        private void CbWorkOrderType_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            DataRowView row = (DataRowView)cbWorkOrderType.Items[e.Index];
            string typeCode = row["TypeCode"].ToString();
            string description = row["TypeDescription"].ToString();

            if (_isWorkOrderTypeDropdownOpen)
            {
                if (e.Index == 0)
                {
                    using (var headerFont = new Font(e.Font, FontStyle.Bold))
                    using (var brush = new SolidBrush(Color.Black))
                    {
                        e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds);
                        e.Graphics.DrawString("工单类型", headerFont, brush,
                            new Rectangle(e.Bounds.X + 5, e.Bounds.Y, 100, e.Bounds.Height));
                        e.Graphics.DrawString("工单说明", headerFont, brush,
                            new Rectangle(e.Bounds.X + 110, e.Bounds.Y, e.Bounds.Width - 115, e.Bounds.Height));
                        e.Graphics.DrawLine(Pens.DarkGray, e.Bounds.X, e.Bounds.Bottom - 1,
                            e.Bounds.Right, e.Bounds.Bottom - 1);
                    }
                }
                else
                {
                    using (var brush = new SolidBrush(e.ForeColor))
                    {
                        e.Graphics.DrawString(typeCode, e.Font, brush,
                            new Rectangle(e.Bounds.X + 5, e.Bounds.Y, 100, e.Bounds.Height));
                        e.Graphics.DrawString(description, e.Font, brush,
                            new Rectangle(e.Bounds.X + 110, e.Bounds.Y, e.Bounds.Width - 115, e.Bounds.Height));
                    }
                }
            }
            else
            {
                using (var brush = new SolidBrush(e.ForeColor))
                {
                    e.Graphics.DrawString(typeCode, e.Font, brush, e.Bounds);
                }
            }

            e.DrawFocusRectangle();
        }

        private void cbWorkOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbWorkOrderType.SelectedIndex == 0)
            {
                txtDetailType.Text = "";
                return;
            }

            DataRowView selectedRow = (DataRowView)cbWorkOrderType.SelectedItem;
            string selectedType = selectedRow["TypeCode"].ToString();
            string description = selectedRow["TypeDescription"].ToString();

            // 获取详细类型并填充到文本框
            object detailTypeObj = selectedRow["DetailType"];
            string detailType = detailTypeObj != null ? detailTypeObj.ToString() : "";
            txtDetailType.Text = detailType;
        }

        private void cbWorkOrderType_DropDown(object sender, EventArgs e)
        {
            _isWorkOrderTypeDropdownOpen = true;

            DataTable newTable = new DataTable();
            newTable.Columns.Add("TypeCode", typeof(string));
            newTable.Columns.Add("TypeDescription", typeof(string));
            newTable.Columns.Add("DetailType", typeof(string)); // 添加DetailType列

            var headerRow = newTable.NewRow();
            headerRow["TypeCode"] = "工单类型";
            headerRow["TypeDescription"] = "工单说明";
            headerRow["DetailType"] = "";
            newTable.Rows.Add(headerRow);

            foreach (DataRow row in _workOrderTypes.Rows)
            {
                var newRow = newTable.NewRow();
                newRow["TypeCode"] = row["TypeCode"];
                newRow["TypeDescription"] = row["TypeDescription"];
                newRow["DetailType"] = row["DetailType"]; // 复制DetailType值
                newTable.Rows.Add(newRow);
            }

            cbWorkOrderType.DataSource = newTable;
            cbWorkOrderType.DisplayMember = "TypeCode";
            cbWorkOrderType.ValueMember = "TypeCode";
            cbWorkOrderType.SelectedIndex = 0;
        }

        private void cbWorkOrderType_DropDownClosed(object sender, EventArgs e)
        {
            _isWorkOrderTypeDropdownOpen = false;

            if (cbWorkOrderType.SelectedIndex > 0)
            {
                var selectedRow = (DataRowView)cbWorkOrderType.SelectedItem;
                string selectedType = selectedRow["TypeCode"].ToString();
                string description = selectedRow["TypeDescription"].ToString();
                string detailType = selectedRow["DetailType"].ToString(); // 获取DetailType

                DataTable newTable = new DataTable();
                newTable.Columns.Add("TypeCode", typeof(string));
                newTable.Columns.Add("TypeDescription", typeof(string));
                newTable.Columns.Add("DetailType", typeof(string)); // 添加DetailType列

                var promptRow = newTable.NewRow();
                promptRow["TypeCode"] = "-- 请选择工单类型 --";
                promptRow["TypeDescription"] = "";
                promptRow["DetailType"] = "";
                newTable.Rows.Add(promptRow);

                var dataRow = newTable.NewRow();
                dataRow["TypeCode"] = selectedType;
                dataRow["TypeDescription"] = description;
                dataRow["DetailType"] = detailType; // 保存DetailType
                newTable.Rows.Add(dataRow);

                cbWorkOrderType.DataSource = newTable;
                cbWorkOrderType.DisplayMember = "TypeCode";
                cbWorkOrderType.ValueMember = "TypeCode";
                cbWorkOrderType.SelectedIndex = 1;
            }
            else
            {
                DataTable newTable = new DataTable();
                newTable.Columns.Add("TypeCode", typeof(string));
                newTable.Columns.Add("TypeDescription", typeof(string));
                newTable.Columns.Add("DetailType", typeof(string)); // 添加DetailType列

                var promptRow = newTable.NewRow();
                promptRow["TypeCode"] = "-- 请选择工单类型 --";
                promptRow["TypeDescription"] = "";
                promptRow["DetailType"] = "";
                newTable.Rows.Add(promptRow);

                cbWorkOrderType.DataSource = newTable;
                cbWorkOrderType.DisplayMember = "TypeCode";
                cbWorkOrderType.ValueMember = "TypeCode";
                cbWorkOrderType.SelectedIndex = 0;
            }
        }

        private void btnConfirm_Click_1(object sender, EventArgs e)
        {
            // 1. 检查用户编号和备注是否已填写
            if (string.IsNullOrWhiteSpace(txtUserNumber.Text))
            {
                MessageBox.Show("用户号未填写，请填写用户号后再试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtRemark.Text))
            {
                MessageBox.Show("备注未填写，请填写备注后再试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. 验证用户是否存在
            if (!_bll.CheckUserExists(txtUserNumber.Text))
            {
                MessageBox.Show("用户ID无效，请检查！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. 检查DataGridView中是否有数据（排除新行）
            if (dataGridView1.Rows.Count == 0 ||
                dataGridView1.Rows.Cast<DataGridViewRow>().All(row => row.IsNewRow))
            {
                MessageBox.Show("请选择需要操作的数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. 添加确认提示框
            DialogResult result = MessageBox.Show("确定要创建这个工单吗？", "确认创建工单",
                                                MessageBoxButtons.OKCancel,
                                                MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                try
                {
                    // 5. 创建工单
                    CreateWorkOrders();

                    // 6. 创建成功后清空DataGridView
                    dataGridView1.Rows.Clear();

                    MessageBox.Show("工单创建成功！", "成功",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"工单创建失败: {ex.Message}", "错误",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 修改后的创建工单方法（移除了 userNumber 和 remark 参数）
        private void CreateWorkOrders()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // 跳过空行
                if (row.IsNewRow) continue;

                // 获取工单数据
                string workOrderId = row.Cells[1].Value?.ToString();
                string workOrderType = row.Cells[2].Value?.ToString();
                string workOrderDescription = row.Cells[3].Value?.ToString();
                string finishedWorkOrderNo = row.Cells[4].Value?.ToString();
                string bom = row.Cells[5].Value?.ToString();
                string bomVersion = row.Cells[6].Value?.ToString();
                string productType = row.Cells[7].Value?.ToString();
                string detailType = row.Cells[8].Value?.ToString();
                string productId = row.Cells[9].Value?.ToString();
                string processFlow = row.Cells[10].Value?.ToString();
                string plannedQuantity = row.Cells[11].Value?.ToString();
                string testProgram = row.Cells[12].Value?.ToString();
                string companyCode = row.Cells[13].Value?.ToString();
                // 确保日期格式正确
                string plannedStartDate = row.Cells[14].Value != null
                    ? DateTime.Parse(row.Cells[14].Value.ToString()).ToString("yyyy-MM-dd")
                    : "";

                string plannedEndDate = row.Cells[15].Value != null
                    ? DateTime.Parse(row.Cells[15].Value.ToString()).ToString("yyyy-MM-dd")
                    : "";
                string customerLotNo = row.Cells[16].Value?.ToString();
                string productCategory = row.Cells[17].Value?.ToString();
                string unit = row.Cells[18].Value?.ToString();
                string filmThickness = row.Cells[19].Value?.ToString();
                string packageForm = row.Cells[20].Value?.ToString();
                string workOrderStatus = row.Cells[21].Value?.ToString();
                string productDescription = row.Cells[22].Value?.ToString();
                string processVersion = row.Cells[23].Value?.ToString(); // 新增工艺版本字段

                new WorkOrderDAL().InsertWorkOrder(
                    workOrderId,
                    workOrderType,
                    workOrderDescription,
                    finishedWorkOrderNo,
                    bom,
                    bomVersion,
                    productType,
                    detailType,
                    productId,
                    processFlow,
                    plannedQuantity,
                    testProgram,
                    companyCode,
                    plannedStartDate,
                    plannedEndDate,
                    customerLotNo,
                    productCategory,
                    unit,
                    filmThickness,
                    packageForm,
                    workOrderStatus,
                    productDescription,
                    processVersion // 新增工艺版本参数
                );

                // 将创建的工单添加到静态列表中
                CreatedWorkOrders.Add(row);
            }
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
                DataPropertyName = "work_order_id"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "工单类型",
                DataPropertyName = "work_order_type"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "工单说明",
                DataPropertyName = "work_order_description"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "成品工单号",
                DataPropertyName = "finished_work_order_no"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "BOM编码",
                DataPropertyName = "bom"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "BOM版本号",
                DataPropertyName = "bom_version"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "产品类型",
                DataPropertyName = "product_type"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "详细类型",
                DataPropertyName = "detail_type"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "产品编号",
                DataPropertyName = "product_id"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "工艺流程号",
                DataPropertyName = "process_flow"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "计划生产数量",
                DataPropertyName = "planned_quantity"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "测试程序号",
                DataPropertyName = "test_program"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "公司号",
                DataPropertyName = "company_code"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "计划开始日期",
                DataPropertyName = "planned_start_date"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "计划结束日期",
                DataPropertyName = "planned_end_date"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "客户批次号",
                DataPropertyName = "customer_lot_no"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "产品类别",
                DataPropertyName = "product_category"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "单位",
                DataPropertyName = "unit"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "膜片厚度",
                DataPropertyName = "film_thickness"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "封装形式",
                DataPropertyName = "package_form"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "工单状态",
                DataPropertyName = "work_order_status"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "产品说明",
                DataPropertyName = "product_description"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "工艺版本",
                DataPropertyName = "process_version" // 新增工艺版本列
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

        // 在类中添加生成工单号的方法
        private string GenerateWorkOrderId()
        {
            // 使用时间戳生成唯一工单号（格式：WO + 年月日时分秒毫秒）
            return "WO" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }

        // 修改添加按钮事件处理
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 验证必填字段
            if (cbWorkOrderType.SelectedIndex == 0)
            {
                MessageBox.Show("请选择工单类型！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbWorkOrderType.Focus();
                return;
            }

            if (cbProductCode.SelectedIndex == 0)
            {
                MessageBox.Show("请选择产品编号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbProductCode.Focus();
                return;
            }

            // 获取工单类型数据
            DataRowView workOrderTypeRow = (DataRowView)cbWorkOrderType.SelectedItem;
            string workOrderType = workOrderTypeRow["TypeCode"].ToString();
            string workOrderDescription = workOrderTypeRow["TypeDescription"].ToString();
            string detailType = txtDetailType.Text;

            // 获取产品数据
            DataRowView productRow = (DataRowView)cbProductCode.SelectedItem;
            string productCode = productRow["ProductCode"].ToString();
            string productDescription = txtProductDescription.Text;

            // 创建新行
            DataGridViewRow newRow = new DataGridViewRow();
            newRow.CreateCells(dataGridView1);

            // 生成工单号
            string workOrderId = GenerateWorkOrderId();

            // 设置单元格值
            newRow.Cells[0].Value = false; // 复选框列（未选中）
            newRow.Cells[1].Value = workOrderId; // 工单号（自动生成）
            newRow.Cells[2].Value = workOrderType;
            newRow.Cells[3].Value = workOrderDescription;
            newRow.Cells[4].Value = txtFinishedWorkOrderNo.Text; // 成品工单号
            newRow.Cells[5].Value = txtBOM.Text;
            newRow.Cells[6].Value = txtBOMVersion.Text;
            newRow.Cells[7].Value = txtProductType.Text;
            newRow.Cells[8].Value = detailType;
            newRow.Cells[9].Value = productCode;
            newRow.Cells[10].Value = txtProcessFlow.Text;
            newRow.Cells[11].Value = txtPlannedQuantity.Text; // 计划生产数量（从文本框获取）
            newRow.Cells[12].Value = ""; // 测试程序号
            newRow.Cells[13].Value = ""; // 公司号
            newRow.Cells[14].Value = dtpPlannedStartDate.Value.ToString("yyyy-MM-dd"); // 计划开始日期
            newRow.Cells[15].Value = dtpPlannedEndDate.Value.ToString("yyyy-MM-dd");   // 计划结束日期

            newRow.Cells[16].Value = txtCustomerLotNo.Text; // 客户批次号（从文本框获取）
            newRow.Cells[17].Value = txtProductCategory.Text;
            newRow.Cells[18].Value = txtUnit.Text;
            newRow.Cells[19].Value = txtFilmThickness.Text; // 膜片厚度（从文本框获取）
            newRow.Cells[20].Value = txtPackagingForm.Text;
            newRow.Cells[21].Value = ""; // 工单状态
            newRow.Cells[22].Value = productDescription;
            newRow.Cells[23].Value = txtProcessVersion.Text; // 工艺版本

            // 添加到DataGridView
            dataGridView1.Rows.Add(newRow);

            // 清空表单（可选）
            ClearFormFields();
        }

        private void ClearFormFields()
        {
            cbWorkOrderType.SelectedIndex = 0;
            cbProductCode.SelectedIndex = 0;
            txtDetailType.Clear();
            txtProductDescription.Clear();
            txtProductType.Clear();
            txtProductCategory.Clear();
            txtProcessFlow.Clear();
            txtBOM.Clear();
            txtBOMVersion.Clear();
            txtUnit.Clear();
            txtPackagingForm.Clear();
            txtPlannedQuantity.Clear();
            txtCustomerLotNo.Clear();
            txtWorkOrderDescription.Clear();
            txtFinishedWorkOrderNo.Clear();
            txtFilmThickness.Clear();
            txtProcessVersion.Clear(); // 清空工艺版本文本框

            // 清空新增字段
            txtFinishedWorkOrderNo.Clear();
            dtpPlannedStartDate.Value = DateTime.Today;
            dtpPlannedEndDate.Value = DateTime.Today.AddDays(1);
        }

        // 清空按钮点击事件
        private void btnClear_Click(object sender, EventArgs e)
        {
            // 清空DataGridView中的所有行
            dataGridView1.Rows.Clear();
        }
    }
}