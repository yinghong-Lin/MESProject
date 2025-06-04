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
    public partial class FrmEqpEdit : Form
    {
        private readonly Eqp _eqp;
        private readonly IEqpService _eqpService;
        private readonly bool _isNew;
        private readonly string _currentUser = "系统"; // 默认用户，实际应用中应该从登录信息获取

        public FrmEqpEdit(Eqp eqp, IEqpService eqpService, bool isNew)
        {
            InitializeComponent();
            _eqp = eqp;
            _eqpService = eqpService;
            _isNew = isNew;
        }

        private void FrmEqpEdit_Load(object sender, EventArgs e)
        {
            try
            {
                // 设置窗体标题
                this.Text = _isNew ? "添加设备" : "编辑设备";

                // 初始化设备组下拉框
                InitializeEqpGroupComboBox();

                // 初始化设备类型下拉框
                InitializeEqpTypeComboBox();

                // 初始化设备层次下拉框
                InitializeEqpLevelComboBox();

                // 如果是编辑模式，加载设备数据
                if (!_isNew)
                {
                    LoadEqpData();
                }

                // 如果是子设备，禁用父设备ID字段
                if (!string.IsNullOrEmpty(_eqp.ParentEqpId))
                {
                    txtParentEqpId.Text = _eqp.ParentEqpId;
                    txtParentEqpId.ReadOnly = true;
                }

                // 设置事件用户
                txtEventUser.Text = _currentUser;
                txtEventUser.ReadOnly = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"FrmEqpEdit_Load 发生异常: {ex.Message}");
                MessageBox.Show($"加载窗体时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeEqpGroupComboBox()
        {
            try
            {
                cmbEqpGroup.Items.Clear();
                cmbEqpGroup.Items.Add(""); // 空选项

                // 获取所有设备组
                var eqpGroups = _eqpService.GetAllEqpGroups();

                // 添加每个设备组到下拉框
                foreach (var group in eqpGroups)
                {
                    string description = string.IsNullOrEmpty(group.EqpGroupDescription)
                        ? "无描述"
                        : group.EqpGroupDescription;

                    cmbEqpGroup.Items.Add($"{group.EqpGroupId} - {description}");
                }

                // 如果是编辑模式且有设备组，选择对应的设备组
                if (!_isNew && !string.IsNullOrEmpty(_eqp.EqpGroupId))
                {
                    for (int i = 0; i < cmbEqpGroup.Items.Count; i++)
                    {
                        string item = cmbEqpGroup.Items[i].ToString();
                        if (item.StartsWith(_eqp.EqpGroupId + " -"))
                        {
                            cmbEqpGroup.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"初始化设备组下拉框时发生异常: {ex.Message}");
                MessageBox.Show($"加载设备组失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeEqpTypeComboBox()
        {
            try
            {
                cmbEqpType.Items.Clear();

                // 获取所有设备类型
                var eqpTypes = _eqpService.GetAllEqpTypes();

                // 添加每个设备类型到下拉框
                foreach (var type in eqpTypes)
                {
                    cmbEqpType.Items.Add(type);
                }

                // 如果是编辑模式且有设备类型，选择对应的设备类型
                if (!_isNew && !string.IsNullOrEmpty(_eqp.EqpType))
                {
                    cmbEqpType.Text = _eqp.EqpType;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"初始化设备类型下拉框时发生异常: {ex.Message}");
                MessageBox.Show($"加载设备类型失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeEqpLevelComboBox()
        {
            try
            {
                cmbEqpLevel.Items.Clear();
                cmbEqpLevel.Items.Add("MAIN"); // 主设备
                cmbEqpLevel.Items.Add("SUB"); // 子设备

                // 如果是编辑模式且有设备层次，选择对应的设备层次
                if (!_isNew && !string.IsNullOrEmpty(_eqp.EqpLevel))
                {
                    cmbEqpLevel.Text = _eqp.EqpLevel;
                }
                else
                {
                    // 默认选择主设备
                    cmbEqpLevel.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"初始化设备层次下拉框时发生异常: {ex.Message}");
                MessageBox.Show($"加载设备层次失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadEqpData()
        {
            try
            {
                // 设置设备ID
                txtEqpId.Text = _eqp.EqpId;
                txtEqpId.ReadOnly = true; // 编辑模式下设备ID不可修改

                // 设置设备详细类型
                txtEqpDetailType.Text = _eqp.EqpDetailType;

                // 设置设备描述
                txtEqpDescription.Text = _eqp.EqpDescription;

                // 设置父设备ID
                txtParentEqpId.Text = _eqp.ParentEqpId;

                // 设置事件备注
                txtEventRemark.Text = _eqp.EventRemark;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"加载设备数据时发生异常: {ex.Message}");
                MessageBox.Show($"加载设备数据失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // 验证必填字段
                if (string.IsNullOrEmpty(txtEqpId.Text))
                {
                    MessageBox.Show("设备ID不能为空", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEqpId.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(cmbEqpType.Text))
                {
                    MessageBox.Show("设备类型不能为空", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbEqpType.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtEqpDetailType.Text))
                {
                    MessageBox.Show("设备详细类型不能为空", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEqpDetailType.Focus();
                    return;
                }

                // 获取设备组ID
                string eqpGroupId = "";
                if (cmbEqpGroup.SelectedIndex > 0)
                {
                    string selectedGroup = cmbEqpGroup.SelectedItem.ToString();
                    eqpGroupId = selectedGroup.Split('-')[0].Trim();
                }

                // 更新设备对象
                _eqp.EqpId = txtEqpId.Text;
                _eqp.EqpType = cmbEqpType.Text;
                _eqp.EqpDetailType = txtEqpDetailType.Text;
                _eqp.EqpDescription = txtEqpDescription.Text;
                _eqp.EqpGroupId = eqpGroupId;
                _eqp.EqpLevel = cmbEqpLevel.Text;
                _eqp.ParentEqpId = txtParentEqpId.Text;
                _eqp.EventUser = txtEventUser.Text;
                _eqp.EventRemark = txtEventRemark.Text;
                _eqp.EditTime = DateTime.Now;
                _eqp.EventType = _isNew ? "CREATE" : "UPDATE";

                // 保存设备
                bool success = _isNew ?
                    _eqpService.AddEqp(_eqp) :
                    _eqpService.UpdateEqp(_eqp);

                if (success)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("保存设备失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"保存设备时发生异常: {ex.Message}");
                MessageBox.Show($"保存设备失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
