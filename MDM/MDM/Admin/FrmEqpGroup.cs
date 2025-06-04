using MDM.BLL.Equipment;
using MDM.DAL.Equipment;
using MDM.Model.UserEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDM.UI.Admin
{
    public partial class FrmEqpGroup : Form
    {
        private readonly IEqpGroupService _service;
        private readonly EqpGroupRepository _repository;
        private bool isGroupInfoVisible = true; // 用于标记当前显示的是设备组信息还是添加设备组界面
        private EqpGroup _selectedGroup = null; // 跟踪当前选中的设备组

        // 在类的顶部添加一个图标字段
        private readonly Image _historyIcon = Properties.Resources.history_icon;

        public FrmEqpGroup(IEqpGroupService service, EqpGroupRepository repository)
        {
            InitializeComponent();
            _service = service;
            _repository = repository;

            // 初始化面板状态
            panelAddGroup.Visible = false;
            panelGroupInfo.Visible = true;

            Debug.WriteLine("FrmEqpGroup 已初始化");
        }

        private void FrmEqp_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("FrmEqpGroup_Load 开始执行");

            // 设置初始面板可见性
            panelGroupInfo.Visible = true;
            panelAddGroup.Visible = false;
            isGroupInfoVisible = true;

            // 设置DataGridView属性
            ConfigureDataGridView();

            // 设置默认搜索类型
            if (searchTypeComboBox.Items.Count > 0 && searchTypeComboBox.SelectedIndex == -1)
            {
                searchTypeComboBox.SelectedIndex = 0;
            }

            // 加载设备组数据
            LoadGroups();

            // 初始化按钮状态
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            Debug.WriteLine("FrmEqpGroup_Load 执行完成");
        }

        // 修改 ConfigureDataGridView 方法，添加历史记录图标列
        private void ConfigureDataGridView()
        {
            // 设置DataGridView的属性，使其更适合显示设备组数据
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 创建自定义列
            DataGridViewImageColumn customColumn = new DataGridViewImageColumn();
            customColumn.HeaderText = "";
            customColumn.Name = "imagecol";
            customColumn.Image = _historyIcon;

            // 将自定义列插入到第一列
            dataGridView1.Columns.Insert(0, customColumn);
            dataGridView1.Columns["imagecol"].Width = 30;

            // 为 CellContentClick 事件添加处理程序
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;

            Debug.WriteLine("DataGridView 配置完成");
        }

        // 添加 CellContentClick 事件处理方法
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 检查点击的是否为自定义列
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                // 获取当前所选行第二列的值（设备组ID）
                string eqpGroupId = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                // 打开新窗体并传递值
                FrmEqpGroupHis frm = new FrmEqpGroupHis(_service, eqpGroupId);
                frm.ShowDialog();
            }
        }

        // 在LoadGroups方法中，修改列标题设置部分，确保所有列标题都是中文
        private void LoadGroups()
        {
            try
            {
                Debug.WriteLine("LoadGroups 开始执行");

                // 获取所有设备组列表
                var groups = _service.GetAllEqpGroups();
                Debug.WriteLine($"从服务获取到 {groups.Count} 条设备组记录");

                // 如果列表为空，显示消息
                if (groups.Count == 0)
                {
                    Debug.WriteLine("没有找到设备组数据");
                    MessageBox.Show("没有找到设备组数据。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // 创建一个BindingList作为DataGridView的数据源
                BindingList<EqpGroup> bindingList = new BindingList<EqpGroup>(groups);
                dataGridView1.DataSource = bindingList;
                Debug.WriteLine($"DataGridView 数据源已设置，行数: {dataGridView1.Rows.Count}");

                // 如果有数据，设置列标题
                if (dataGridView1.Columns.Count > 0)
                {
                    if (dataGridView1.Columns.Contains("EqpGroupId"))
                    {
                        dataGridView1.Columns["EqpGroupId"].HeaderText = "设备组ID";
                        Debug.WriteLine("设置列标题: EqpGroupId -> 设备组ID");
                    }

                    if (dataGridView1.Columns.Contains("EqpGroupType"))
                    {
                        dataGridView1.Columns["EqpGroupType"].HeaderText = "设备组类型";
                        Debug.WriteLine("设置列标题: EqpGroupType -> 设备组类型");
                    }

                    if (dataGridView1.Columns.Contains("EqpGroupDescription"))
                    {
                        dataGridView1.Columns["EqpGroupDescription"].HeaderText = "设备组描述";
                        Debug.WriteLine("设置列标题: EqpGroupDescription -> 设备组描述");
                    }

                    if (dataGridView1.Columns.Contains("FactoryId"))
                    {
                        dataGridView1.Columns["FactoryId"].HeaderText = "工厂ID";
                        Debug.WriteLine("设置列标题: FactoryId -> 工厂ID");
                    }

                    if (dataGridView1.Columns.Contains("EventUser"))
                    {
                        dataGridView1.Columns["EventUser"].HeaderText = "操作用户";
                        Debug.WriteLine("设置列标题: EventUser -> 操作用户");
                    }

                    if (dataGridView1.Columns.Contains("EventRemark"))
                    {
                        dataGridView1.Columns["EventRemark"].HeaderText = "操作备注";
                        Debug.WriteLine("设置列标题: EventRemark -> 操作备注");
                    }

                    if (dataGridView1.Columns.Contains("EditTime"))
                    {
                        dataGridView1.Columns["EditTime"].HeaderText = "编辑时间";
                        Debug.WriteLine("设置列标题: EditTime -> 编辑时间");
                    }

                    if (dataGridView1.Columns.Contains("CreateTime"))
                    {
                        dataGridView1.Columns["CreateTime"].HeaderText = "创建时间";
                        Debug.WriteLine("设置列标题: CreateTime -> 创建时间");
                    }

                    if (dataGridView1.Columns.Contains("EventType"))
                    {
                        dataGridView1.Columns["EventType"].HeaderText = "事件类型";
                        Debug.WriteLine("设置列标题: EventType -> 事件类型");
                    }
                }
                else
                {
                    Debug.WriteLine("警告: DataGridView 没有列");
                }

                Debug.WriteLine("LoadGroups 执行完成");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"LoadGroups 发生异常: {ex.Message}");
                MessageBox.Show($"加载设备组数据失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ToggleView()
        {
            isGroupInfoVisible = !isGroupInfoVisible;

            // 确保一次只有一个面板可见
            panelGroupInfo.Visible = isGroupInfoVisible;
            panelAddGroup.Visible = !isGroupInfoVisible;

            if (isGroupInfoVisible)
            {
                btnToggleView.Text = "切换到添加设备组";
                LoadGroups(); // 切换回显示设备组信息界面时重新加载数据
            }
            else
            {
                btnToggleView.Text = "切换到显示设备组";
                ClearInputs(); // 清空添加设备组的输入框

                // 重置选中的设备组
                _selectedGroup = null;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        // 修改ClearInputs方法，添加事件类型的清除
        private void ClearInputs()
        {
            // 清空添加设备组面板的输入框
            GroupIdTextBox.Clear();
            GroupTypeTextBox.Clear();
            GroupDescriptionTextBox.Clear();
            FactoryIdTextBox.Clear();
            EventTypeTextBox.Clear(); // 清除事件类型
        }

        // 修改ClearGroupInfoPanel方法，添加事件类型的清除
        private void ClearGroupInfoPanel()
        {
            // 清空设备组信息面板
            GroupId.Text = string.Empty;
            GroupType.Text = string.Empty;
            GroupDescription.Text = string.Empty;
            FactoryId.Text = string.Empty;
            EventType.Text = string.Empty; // 清除事件类型
        }

        private void Cancelbutton1_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        // 修改Confirmbutton1_Click方法，添加事件类型的设置
        private void Confirmbutton1_Click(object sender, EventArgs e)
        {
            try
            {
                string groupId = GroupIdTextBox.Text.Trim();
                string groupType = GroupTypeTextBox.Text.Trim();
                string groupDescription = GroupDescriptionTextBox.Text.Trim();
                string factoryId = FactoryIdTextBox.Text.Trim();
                string eventType = EventTypeTextBox.Text.Trim(); // 获取事件类型

                if (string.IsNullOrEmpty(groupId))
                {
                    MessageBox.Show("设备组编号是必填项！");
                    GroupIdTextBox.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(groupType))
                {
                    MessageBox.Show("设备组类型是必填项！");
                    GroupTypeTextBox.Focus();
                    return;
                }

                EqpGroup group = new EqpGroup
                {
                    EqpGroupId = groupId,
                    EqpGroupType = groupType,
                    EqpGroupDescription = groupDescription,
                    FactoryId = factoryId,
                    EventType = eventType, // 设置事件类型
                    EventUser = "当前用户", // 这里可以设置为当前登录用户
                    EditTime = DateTime.Now,
                    CreateTime = DateTime.Now
                };

                if (_service.CreateEqpGroup(group))
                {
                    MessageBox.Show("设备组创建成功！");
                    ClearInputs();
                    LoadGroups();
                    ToggleView(); // 切换回显示设备组信息界面
                }
                else
                {
                    MessageBox.Show("设备组创建失败！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"系统错误：{ex.Message}");
            }
        }

        private void btnToggleView_Click(object sender, EventArgs e)
        {
            ToggleView();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string searchQuery = SearchTextBox.Text.Trim(); // 获取搜索关键词

            try
            {
                // 获取所有设备组
                var allGroups = _service.GetAllEqpGroups();
                List<EqpGroup> filteredGroups;

                if (string.IsNullOrEmpty(searchQuery))
                {
                    // 搜索框为空时显示所有设备组
                    filteredGroups = allGroups;
                }
                else
                {
                    // 根据选择的搜索类型进行过滤
                    if (searchTypeComboBox.SelectedIndex == 0) // 按设备组ID搜索
                    {
                        filteredGroups = allGroups
                            .Where(g => g.EqpGroupId.Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
                            .ToList();
                    }
                    else // 按设备组类型搜索
                    {
                        filteredGroups = allGroups
                            .Where(g => g.EqpGroupType.Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
                            .ToList();
                    }

                    // 显示搜索结果数量
                    if (filteredGroups.Count == 0)
                    {
                        MessageBox.Show("未找到匹配的设备组。", "搜索结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                // 更新DataGridView
                dataGridView1.DataSource = new BindingList<EqpGroup>(filteredGroups);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"SearchButton_Click 发生异常: {ex.Message}");
                MessageBox.Show($"搜索设备组时发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 修改dataGridView1_CellClick方法，添加事件类型的显示
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && isGroupInfoVisible) // 只有在显示设备组信息界面时才处理行点击事件
            {
                try
                {
                    // 获取选中行的设备组数据
                    _selectedGroup = (EqpGroup)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                    // 显示设备组数据到右边的控件
                    GroupId.Text = _selectedGroup.EqpGroupId;
                    GroupType.Text = _selectedGroup.EqpGroupType;
                    GroupDescription.Text = _selectedGroup.EqpGroupDescription ?? string.Empty;
                    FactoryId.Text = _selectedGroup.FactoryId ?? string.Empty;
                    EventType.Text = _selectedGroup.EventType ?? string.Empty; // 添加事件类型显示

                    // 启用更新和删除按钮
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"dataGridView1_CellClick 发生异常: {ex.Message}");
                    MessageBox.Show($"选择设备组时发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 修改btnUpdate_Click方法，添加事件类型的更新
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedGroup == null)
            {
                MessageBox.Show("请先选择要更新的设备组！");
                return;
            }

            try
            {
                // 从右侧面板获取值
                string groupId = GroupId.Text.Trim();
                string groupType = GroupType.Text.Trim();
                string groupDescription = GroupDescription.Text.Trim();
                string factoryId = FactoryId.Text.Trim();
                string eventType = EventType.Text.Trim(); // 获取事件类型

                // 验证必填字段
                if (string.IsNullOrEmpty(groupId) || string.IsNullOrEmpty(groupType))
                {
                    MessageBox.Show("设备组ID和设备组类型是必填项！");
                    return;
                }

                // 创建更新的设备组对象
                EqpGroup updatedGroup = new EqpGroup
                {
                    EqpGroupId = groupId,
                    EqpGroupType = groupType,
                    EqpGroupDescription = groupDescription,
                    FactoryId = factoryId,
                    EventType = eventType, // 设置事件类型
                    EventUser = "当前用户", // 这里可以设置为当前登录用户
                    EditTime = DateTime.Now,
                    CreateTime = _selectedGroup.CreateTime
                };

                // 调用仓储更新设备组
                if (_service.UpdateEqpGroup(updatedGroup))
                {
                    MessageBox.Show("设备组更新成功！");
                    LoadGroups(); // 重新加载设备组列表
                    _selectedGroup = null; // 清除选择
                    ClearGroupInfoPanel(); // 清空右侧面板
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                }
                else
                {
                    MessageBox.Show("设备组更新失败！");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"btnUpdate_Click 发生异常: {ex.Message}");
                MessageBox.Show($"更新设备组时发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedGroup == null)
            {
                MessageBox.Show("请先选择要删除的设备组！");
                return;
            }

            // 确认删除
            DialogResult result = MessageBox.Show($"确定要删除设备组 {_selectedGroup.EqpGroupId} 吗？", "确认删除",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // 调用仓储删除设备组
                    if (_service.DeleteEqpGroup(_selectedGroup.EqpGroupId))
                    {
                        MessageBox.Show("设备组删除成功！");
                        LoadGroups(); // 重新加载设备组列表
                        _selectedGroup = null; // 清除选择
                        ClearGroupInfoPanel(); // 清空右侧面板
                        btnUpdate.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("设备组删除失败！");
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"btnDelete_Click 发生异常: {ex.Message}");
                    MessageBox.Show($"删除设备组时发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            _selectedGroup = null;
            ClearGroupInfoPanel();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelGroupInfo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
