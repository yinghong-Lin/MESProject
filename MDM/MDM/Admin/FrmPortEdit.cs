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
    public partial class FrmPortEdit : Form
    {
        private readonly Port _port;
        private readonly IEqpService _eqpService;
        private readonly bool _isNew;
        private readonly string _currentUser = "系统"; // 默认用户，实际应用中应该从登录信息获取

        public FrmPortEdit(Port port, IEqpService eqpService, bool isNew)
        {
            InitializeComponent();
            _port = port;
            _eqpService = eqpService;
            _isNew = isNew;
        }

        private void FrmPortEdit_Load(object sender, EventArgs e)
        {
            try
            {
                // 设置窗体标题
                this.Text = _isNew ? "添加端口" : "编辑端口";

                // 初始化端口类型下拉框
                InitializePortTypeComboBox();

                // 如果是编辑模式，加载端口数据
                if (!_isNew)
                {
                    LoadPortData();
                }

                // 设置关联的设备ID
                if (!string.IsNullOrEmpty(_port.EqpId))
                {
                    txtEqpId.Text = _port.EqpId;
                    txtEqpId.ReadOnly = true;
                }

                // 设置事件用户
                txtEventUser.Text = _currentUser;
                txtEventUser.ReadOnly = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"FrmPortEdit_Load 发生异常: {ex.Message}");
                MessageBox.Show($"加载窗体时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializePortTypeComboBox()
        {
            try
            {
                cmbPortType.Items.Clear();
                cmbPortType.Items.Add("INPUT");
                cmbPortType.Items.Add("OUTPUT");
                cmbPortType.Items.Add("BOTH");
                cmbPortType.Items.Add("OTHER");

                // 如果是编辑模式且有端口类型，选择对应的端口类型
                if (!_isNew && !string.IsNullOrEmpty(_port.PortType))
                {
                    cmbPortType.Text = _port.PortType;
                }
                else
                {
                    // 默认选择INPUT
                    cmbPortType.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"初始化端口类型下拉框时发生异常: {ex.Message}");
                MessageBox.Show($"加载端口类型失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPortData()
        {
            try
            {
                // 设置端口ID
                txtPortId.Text = _port.PortId;
                txtPortId.ReadOnly = true; // 编辑模式下端口ID不可修改

                // 设置端口详细类型
                txtPortDetailType.Text = _port.PortDetailType;

                // 设置端口描述
                txtPortDescription.Text = _port.PortDescription;

                // 设置事件备注
                txtEventRemark.Text = _port.EventRemark;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"加载端口数据时发生异常: {ex.Message}");
                MessageBox.Show($"加载端口数据失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // 验证必填字段
                if (string.IsNullOrEmpty(txtPortId.Text))
                {
                    MessageBox.Show("端口ID不能为空", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPortId.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(cmbPortType.Text))
                {
                    MessageBox.Show("端口类型不能为空", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbPortType.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtPortDetailType.Text))
                {
                    MessageBox.Show("端口详细类型不能为空", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPortDetailType.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtEqpId.Text))
                {
                    MessageBox.Show("关联的设备ID不能为空", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEqpId.Focus();
                    return;
                }

                // 更新端口对象
                _port.PortId = txtPortId.Text;
                _port.PortType = cmbPortType.Text;
                _port.PortDetailType = txtPortDetailType.Text;
                _port.PortDescription = txtPortDescription.Text;
                _port.EqpId = txtEqpId.Text;
                _port.EventUser = txtEventUser.Text;
                _port.EventRemark = txtEventRemark.Text;
                _port.EditTime = DateTime.Now;
                _port.EventType = _isNew ? "CREATE" : "UPDATE";

                // 保存端口
                bool success = _isNew ?
                    _eqpService.AddPort(_port) :
                    _eqpService.UpdatePort(_port);

                if (success)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("保存端口失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"保存端口时发生异���: {ex.Message}");
                MessageBox.Show($"保存端口失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
