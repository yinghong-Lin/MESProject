using MDM.BLL.Equipment;
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
    public partial class FrmEqp : Form
    {
        private readonly IEqpService _eqpService;
        private string _selectedEqpId = null;
        private readonly string _currentUser = "系统"; // 默认用户，实际应用中应该从登录信息获取

        // 用于设备组ComboBox的自定义类
        public class EqpGroupItem
        {
            public string Id { get; set; }
            public string Description { get; set; }

            public EqpGroupItem(string id, string description = "")
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

        public FrmEqp(IEqpService eqpService)
        {
            InitializeComponent();
            _eqpService = eqpService;
            Debug.WriteLine("FrmEqp 已初始化");
        }

        private void FrmEqp_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("FrmEqp_Load 开始执行");

            try
            {
                // 初始化设备类型下拉框
                InitializeEqpTypeComboBox();

                // 初始化设备组下拉框
                InitializeEqpGroupComboBox();

                // 配置DataGridView
                ConfigureDataGridViews();

                // 加载设备数据
                LoadEqps();

                // 初始化按钮状态
                UpdateButtonStates();

                Debug.WriteLine("FrmEqp_Load 执行完成");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"FrmEqp_Load 发生异常: {ex.Message}");
                MessageBox.Show($"加载窗体时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeEqpTypeComboBox()
        {
            try
            {
                // 清空下拉框
                comboBoxEqpType.Items.Clear();

                // 添加"All"选项
                comboBoxEqpType.Items.Add("All");

                // 获取所有设备类型并添加到下拉框
                var eqpTypes = _eqpService.GetAllEqpTypes();
                foreach (var type in eqpTypes)
                {
                    comboBoxEqpType.Items.Add(type);
                }

                // 默认选择"All"
                if (comboBoxEqpType.Items.Count > 0)
                {
                    comboBoxEqpType.SelectedIndex = 0;
                }

                Debug.WriteLine($"设备类型下拉框初始化完成，共 {comboBoxEqpType.Items.Count} 项");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"初始化设备类型下拉框时发生异常: {ex.Message}");
                MessageBox.Show($"加载设备类型失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeEqpGroupComboBox()
        {
            try
            {
                comboBoxEqpGroup.Items.Clear();
                comboBoxEqpGroup.Items.Add(new EqpGroupItem("All"));

                // 获取所有设备组数据
                var eqpGroups = _eqpService.GetAllEqpGroups();
                Debug.WriteLine($"从服务获取到 {eqpGroups.Count} 条设备组记录");

                // 添加每个设备组到下拉框
                foreach (var group in eqpGroups)
                {
                    string description = string.IsNullOrEmpty(group.EqpGroupDescription)
                        ? "无描述"
                        : group.EqpGroupDescription;

                    comboBoxEqpGroup.Items.Add(new EqpGroupItem(
                        group.EqpGroupId,
                        description));
                }

                if (comboBoxEqpGroup.Items.Count > 0)
                {
                    comboBoxEqpGroup.SelectedIndex = 0;
                }
                Debug.WriteLine($"设备组下拉框初始化完成，共 {comboBoxEqpGroup.Items.Count} 项");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"初始化设备组下拉框时发生异常: {ex.Message}");
                MessageBox.Show($"加载设备组失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridViews()
        {
            // 配置主设备DataGridView
            ConfigureEqpDataGridView();

            // 配置子设备DataGridView
            ConfigureSubEqpDataGridView();

            // 配置端口DataGridView
            ConfigurePortDataGridView();
        }

        private void ConfigureEqpDataGridView()
        {
            dataGridViewEqp.AutoGenerateColumns = true;
            dataGridViewEqp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewEqp.MultiSelect = false;
            dataGridViewEqp.ReadOnly = true;
            dataGridViewEqp.AllowUserToAddRows = false;
            dataGridViewEqp.AllowUserToDeleteRows = false;
            dataGridViewEqp.AllowUserToResizeRows = false;
            dataGridViewEqp.RowHeadersVisible = false;
            dataGridViewEqp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ConfigureSubEqpDataGridView()
        {
            dataGridViewSubEqp.AutoGenerateColumns = true;
            dataGridViewSubEqp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSubEqp.MultiSelect = false;
            dataGridViewSubEqp.ReadOnly = true;
            dataGridViewSubEqp.AllowUserToAddRows = false;
            dataGridViewSubEqp.AllowUserToDeleteRows = false;
            dataGridViewSubEqp.AllowUserToResizeRows = false;
            dataGridViewSubEqp.RowHeadersVisible = false;
            dataGridViewSubEqp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ConfigurePortDataGridView()
        {
            dataGridViewPort.AutoGenerateColumns = true;
            dataGridViewPort.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPort.MultiSelect = false;
            dataGridViewPort.ReadOnly = true;
            dataGridViewPort.AllowUserToAddRows = false;
            dataGridViewPort.AllowUserToDeleteRows = false;
            dataGridViewPort.AllowUserToResizeRows = false;
            dataGridViewPort.RowHeadersVisible = false;
            dataGridViewPort.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadEqps()
        {
            try
            {
                // 获取选中的设备类型
                string selectedEqpType = comboBoxEqpType.SelectedItem?.ToString() ?? "All";

                // 获取选中的设备组
                string selectedEqpGroup = "All";
                if (comboBoxEqpGroup.SelectedItem is EqpGroupItem groupItem)
                {
                    selectedEqpGroup = groupItem.Id;
                }

                Debug.WriteLine($"正在加载设备数据，类型: {selectedEqpType}, 设备组: {selectedEqpGroup}");

                // 获取设备列表
                var eqps = _eqpService.GetEqpList(selectedEqpType, selectedEqpGroup);

                // 绑定到DataGridView
                dataGridViewEqp.DataSource = null; // 先清除数据源
                dataGridViewEqp.DataSource = new BindingList<Eqp>(eqps); // 使用BindingList提供更好的绑定支持

                // 设置列标题
                if (dataGridViewEqp.Columns.Count > 0)
                {
                    if (dataGridViewEqp.Columns.Contains("EqpId"))
                        dataGridViewEqp.Columns["EqpId"].HeaderText = "设备编号";

                    if (dataGridViewEqp.Columns.Contains("EqpType"))
                        dataGridViewEqp.Columns["EqpType"].HeaderText = "设备类型";

                    if (dataGridViewEqp.Columns.Contains("EqpDetailType"))
                        dataGridViewEqp.Columns["EqpDetailType"].HeaderText = "设备详细类型";

                    if (dataGridViewEqp.Columns.Contains("EqpDescription"))
                        dataGridViewEqp.Columns["EqpDescription"].HeaderText = "设备说明";

                    if (dataGridViewEqp.Columns.Contains("EqpGroupId"))
                        dataGridViewEqp.Columns["EqpGroupId"].HeaderText = "设备组";

                    if (dataGridViewEqp.Columns.Contains("EqpLevel"))
                        dataGridViewEqp.Columns["EqpLevel"].HeaderText = "设备层次";

                    if (dataGridViewEqp.Columns.Contains("ParentEqpId"))
                        dataGridViewEqp.Columns["ParentEqpId"].HeaderText = "上级设备号";

                    if (dataGridViewEqp.Columns.Contains("EventUser"))
                        dataGridViewEqp.Columns["EventUser"].HeaderText = "事件用户";

                    if (dataGridViewEqp.Columns.Contains("EventRemark"))
                        dataGridViewEqp.Columns["EventRemark"].HeaderText = "事件备注";

                    if (dataGridViewEqp.Columns.Contains("EditTime"))
                        dataGridViewEqp.Columns["EditTime"].HeaderText = "最后编辑时间";

                    if (dataGridViewEqp.Columns.Contains("CreateTime"))
                        dataGridViewEqp.Columns["CreateTime"].HeaderText = "创建时间";

                    if (dataGridViewEqp.Columns.Contains("EventType"))
                        dataGridViewEqp.Columns["EventType"].HeaderText = "事件";

                    if (dataGridViewEqp.Columns.Contains("FactoryId"))
                        dataGridViewEqp.Columns["FactoryId"].HeaderText = "工厂编号";
                }

                // 清空子设备和端口DataGridView
                dataGridViewSubEqp.DataSource = null;
                dataGridViewPort.DataSource = null;

                Debug.WriteLine($"成功加载了 {eqps.Count} 条设备记录");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"加载设备数据时发生异常: {ex.Message}");
                MessageBox.Show($"加载设备数据失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateButtonStates()
        {
            bool hasSelectedEqp = !string.IsNullOrEmpty(_selectedEqpId);

            // 设置子设备和端口按钮的启用状态
            btnAddSubEqp.Enabled = hasSelectedEqp;
            btnEditSubEqp.Enabled = hasSelectedEqp && dataGridViewSubEqp.SelectedRows.Count > 0;
            btnDeleteSubEqp.Enabled = hasSelectedEqp && dataGridViewSubEqp.SelectedRows.Count > 0;

            btnAddPort.Enabled = hasSelectedEqp;
            btnEditPort.Enabled = hasSelectedEqp && dataGridViewPort.SelectedRows.Count > 0;
            btnDeletePort.Enabled = hasSelectedEqp && dataGridViewPort.SelectedRows.Count > 0;

            // 设置主设备按钮的启用状态
            btnEditEqp.Enabled = dataGridViewEqp.SelectedRows.Count > 0;
            btnDeleteEqp.Enabled = dataGridViewEqp.SelectedRows.Count > 0;
        }

        private void DisplaySubEqp(string parentEqpId)
        {
            try
            {
                if (string.IsNullOrEmpty(parentEqpId))
                {
                    dataGridViewSubEqp.DataSource = null;
                    return;
                }

                Debug.WriteLine($"正在加载子设备数据，父设备ID: {parentEqpId}");

                // 获取子设备列表
                var subEqps = _eqpService.GetSubEqps(parentEqpId);

                // 绑定到DataGridView
                dataGridViewSubEqp.DataSource = null; // 先清除数据源
                dataGridViewSubEqp.DataSource = new BindingList<Eqp>(subEqps); // 使用BindingList提供更好的绑定支持

                // 设置列标题
                if (dataGridViewSubEqp.Columns.Count > 0)
                {
                    if (dataGridViewSubEqp.Columns.Contains("EqpId"))
                        dataGridViewSubEqp.Columns["EqpId"].HeaderText = "设备编号";

                    if (dataGridViewSubEqp.Columns.Contains("EqpType"))
                        dataGridViewSubEqp.Columns["EqpType"].HeaderText = "设备类型";

                    if (dataGridViewSubEqp.Columns.Contains("EqpDetailType"))
                        dataGridViewSubEqp.Columns["EqpDetailType"].HeaderText = "设备详细类型";

                    if (dataGridViewSubEqp.Columns.Contains("EqpDescription"))
                        dataGridViewSubEqp.Columns["EqpDescription"].HeaderText = "设备说明";

                    if (dataGridViewSubEqp.Columns.Contains("EqpGroupId"))
                        dataGridViewSubEqp.Columns["EqpGroupId"].HeaderText = "设备组";

                    if (dataGridViewSubEqp.Columns.Contains("ParentEqpId"))
                        dataGridViewSubEqp.Columns["ParentEqpId"].HeaderText = "父设备号";
                }

                Debug.WriteLine($"成功加载了 {subEqps.Count} 条子设备记录");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"加载子设备数据时发生异常: {ex.Message}");
                MessageBox.Show($"加载子设备数据失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayPort(string eqpId)
        {
            try
            {
                if (string.IsNullOrEmpty(eqpId))
                {
                    dataGridViewPort.DataSource = null;
                    return;
                }

                Debug.WriteLine($"正在加载端口数据，设备ID: {eqpId}");

                // 获取端口列表
                var ports = _eqpService.GetPorts(eqpId);

                // 绑定到DataGridView
                dataGridViewPort.DataSource = null; // 先清除数据源
                dataGridViewPort.DataSource = new BindingList<Port>(ports); // 使用BindingList提供更好的绑定支持

                // 设置列标题
                if (dataGridViewPort.Columns.Count > 0)
                {
                    if (dataGridViewPort.Columns.Contains("PortId"))
                        dataGridViewPort.Columns["PortId"].HeaderText = "端口号";

                    if (dataGridViewPort.Columns.Contains("PortType"))
                        dataGridViewPort.Columns["PortType"].HeaderText = "端口类型";

                    if (dataGridViewPort.Columns.Contains("PortDetailType"))
                        dataGridViewPort.Columns["PortDetailType"].HeaderText = "端口详细类型";

                    if (dataGridViewPort.Columns.Contains("PortDescription"))
                        dataGridViewPort.Columns["PortDescription"].HeaderText = "端口说明";

                    if (dataGridViewPort.Columns.Contains("EqpId"))
                        dataGridViewPort.Columns["EqpId"].HeaderText = "关联的设备号";
                }

                Debug.WriteLine($"成功加载了 {ports.Count} 条端口记录");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"加载端口数据时发生异常: {ex.Message}");
                MessageBox.Show($"加载端口数据失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadEqps();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                // 刷新所有数据
                InitializeEqpTypeComboBox();
                InitializeEqpGroupComboBox();
                LoadEqps();

                // 如果有选中的设备，刷新子设备和端口
                if (!string.IsNullOrEmpty(_selectedEqpId))
                {
                    DisplaySubEqp(_selectedEqpId);
                    DisplayPort(_selectedEqpId);
                }

                MessageBox.Show("数据已刷新", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"刷新数据时发生异常: {ex.Message}");
                MessageBox.Show($"刷新数据失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewEqp_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewEqp.SelectedRows.Count > 0)
                {
                    // 获取选中的设备
                    var selectedRow = dataGridViewEqp.SelectedRows[0];
                    if (selectedRow.DataBoundItem is Eqp selectedEqp)
                    {
                        _selectedEqpId = selectedEqp.EqpId;
                        Debug.WriteLine($"选中设备ID: {_selectedEqpId}");

                        // 显示子设备和端口
                        DisplaySubEqp(_selectedEqpId);
                        DisplayPort(_selectedEqpId);
                    }
                    else
                    {
                        Debug.WriteLine("选中行的数据不是Eqp类型");
                        _selectedEqpId = null;
                        dataGridViewSubEqp.DataSource = null;
                        dataGridViewPort.DataSource = null;
                    }
                }
                else
                {
                    Debug.WriteLine("未选中任何设备");
                    _selectedEqpId = null;
                    dataGridViewSubEqp.DataSource = null;
                    dataGridViewPort.DataSource = null;
                }

                // 更新按钮状态
                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"处理设备选择变更时发生异常: {ex.Message}");
                MessageBox.Show($"处理设备选择时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddEqp_Click(object sender, EventArgs e)
        {
            try
            {
                // 创建一个新的设备对象
                var newEqp = new Eqp
                {
                    EqpId = "",
                    EqpType = "",
                    EqpDetailType = "",
                    EqpDescription = "",
                    EqpGroupId = "",
                    EqpLevel = "MAIN", // 默认为主设备
                    EventUser = _currentUser,
                    EventType = "CREATE",
                    CreateTime = DateTime.Now,
                    EditTime = DateTime.Now
                };

                // 显示设备编辑窗体
                using (var frm = new FrmEqpEdit(newEqp, _eqpService, true))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        // 刷新设备列表
                        LoadEqps();
                        MessageBox.Show("设备添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"添加设备时发生异常: {ex.Message}");
                MessageBox.Show($"添加设备失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditEqp_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewEqp.SelectedRows.Count > 0)
                {
                    // 获取选中的设备
                    var selectedRow = dataGridViewEqp.SelectedRows[0];
                    if (selectedRow.DataBoundItem is Eqp selectedEqp)
                    {
                        // 创建设备编辑窗体
                        using (var frm = new FrmEqpEdit(selectedEqp, _eqpService, false))
                        {
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                // 刷新设备列表
                                LoadEqps();
                                MessageBox.Show("设备更新成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"编辑设备时发生异常: {ex.Message}");
                MessageBox.Show($"编辑设备失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteEqp_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewEqp.SelectedRows.Count > 0)
                {
                    // 获取选中的设备
                    var selectedRow = dataGridViewEqp.SelectedRows[0];
                    if (selectedRow.DataBoundItem is Eqp selectedEqp)
                    {
                        // 确认删除
                        var result = MessageBox.Show($"确定要删除设备 {selectedEqp.EqpId} 吗？", "确认删除",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            // 删除设备
                            if (_eqpService.DeleteEqp(selectedEqp.EqpId))
                            {
                                // 刷新设备列表
                                LoadEqps();
                                MessageBox.Show("设备删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("设备删除失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"删除设备时发生异常: {ex.Message}");
                MessageBox.Show($"删除设备失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddSubEqp_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(_selectedEqpId))
                {
                    // 创建一个新的子设备对象
                    var newSubEqp = new Eqp
                    {
                        EqpId = "",
                        EqpType = "",
                        EqpDetailType = "",
                        EqpDescription = "",
                        EqpGroupId = "", // 可以继承父设备的设备组
                        ParentEqpId = _selectedEqpId, // 设置父设备ID
                        EqpLevel = "SUB", // 子设备
                        EventUser = _currentUser,
                        EventType = "CREATE",
                        CreateTime = DateTime.Now,
                        EditTime = DateTime.Now
                    };

                    // 显示设备编辑窗体
                    using (var frm = new FrmEqpEdit(newSubEqp, _eqpService, true))
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            // 刷新子设备列表
                            DisplaySubEqp(_selectedEqpId);
                            MessageBox.Show("子设备添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"添加子设备时发生异常: {ex.Message}");
                MessageBox.Show($"添加子设备失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditSubEqp_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewSubEqp.SelectedRows.Count > 0)
                {
                    // 获取选中的子设备
                    var selectedRow = dataGridViewSubEqp.SelectedRows[0];
                    if (selectedRow.DataBoundItem is Eqp selectedSubEqp)
                    {
                        // 创建设备编辑窗体
                        using (var frm = new FrmEqpEdit(selectedSubEqp, _eqpService, false))
                        {
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                // 刷新子设备列表
                                DisplaySubEqp(_selectedEqpId);
                                MessageBox.Show("子设备更新成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"编辑子设备时发生异常: {ex.Message}");
                MessageBox.Show($"编辑子设备失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteSubEqp_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewSubEqp.SelectedRows.Count > 0)
                {
                    // 获取选中的子设备
                    var selectedRow = dataGridViewSubEqp.SelectedRows[0];
                    if (selectedRow.DataBoundItem is Eqp selectedSubEqp)
                    {
                        // 确认删除
                        var result = MessageBox.Show($"确定要删除子设备 {selectedSubEqp.EqpId} 吗？", "确认删除",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            // 删除子设备
                            if (_eqpService.DeleteEqp(selectedSubEqp.EqpId))
                            {
                                // 刷新子设备列表
                                DisplaySubEqp(_selectedEqpId);
                                MessageBox.Show("子设备删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("子设备删除失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"删除子设备时发生异常: {ex.Message}");
                MessageBox.Show($"删除子设备失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddPort_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(_selectedEqpId))
                {
                    // 创建一个新的端口对象
                    var newPort = new Port
                    {
                        PortId = "",
                        PortType = "",
                        PortDetailType = "",
                        PortDescription = "",
                        EqpId = _selectedEqpId, // 设置关联的设备ID
                        EventUser = _currentUser,
                        EventType = "CREATE",
                        CreateTime = DateTime.Now,
                        EditTime = DateTime.Now
                    };

                    // 显示端口编辑窗体
                    using (var frm = new FrmPortEdit(newPort, _eqpService, true))
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            // 刷新端口列表
                            DisplayPort(_selectedEqpId);
                            MessageBox.Show("端口添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"添加端口时发生异常: {ex.Message}");
                MessageBox.Show($"添加端口失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditPort_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewPort.SelectedRows.Count > 0)
                {
                    // 获取选中的端口
                    var selectedRow = dataGridViewPort.SelectedRows[0];
                    if (selectedRow.DataBoundItem is Port selectedPort)
                    {
                        // 创建端口编辑窗体
                        using (var frm = new FrmPortEdit(selectedPort, _eqpService, false))
                        {
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                // 刷新端口列表
                                DisplayPort(_selectedEqpId);
                                MessageBox.Show("端口更新成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"编辑端口时发生异常: {ex.Message}");
                MessageBox.Show($"编辑端口失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletePort_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewPort.SelectedRows.Count > 0)
                {
                    // 获取选中的端口
                    var selectedRow = dataGridViewPort.SelectedRows[0];
                    if (selectedRow.DataBoundItem is Port selectedPort)
                    {
                        // 确认删除
                        var result = MessageBox.Show($"确定要删除端口 {selectedPort.PortId} 吗？", "确认删除",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            // 删除端口
                            if (_eqpService.DeletePort(selectedPort.PortId))
                            {
                                // 刷新端口列表
                                DisplayPort(_selectedEqpId);
                                MessageBox.Show("端口删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("端口删除失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"删除端口时发生异常: {ex.Message}");
                MessageBox.Show($"删除端口失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
