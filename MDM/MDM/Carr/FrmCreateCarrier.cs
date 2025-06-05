using MDM.BLL.Carr;
using MDM.Model.UserEntities;
using System;
using System.Windows.Forms;

namespace MDM.UI.Carr
{
    public partial class FrmCreateCarrier : Form
    {
        private readonly ICarrierService _carrierService;
        private Carrier _carrier;

        public FrmCreateCarrier(ICarrierService carrierService, Carrier carrier = null)
        {
            InitializeComponent();
            _carrierService = carrierService;
            _carrier = carrier ?? new Carrier();
            LoadDurableTypes();
            LoadLocations();
            BindData();
        }

        public Carrier Carrier => _carrier;

        private void LoadDurableTypes()
        {
            // Load durable types from database or hardcode for simplicity
            cmbDurableType.Items.Add("Magazine");
            cmbDurableType.Items.Add("HighTemp");
            cmbDurableType.Items.Add("ESD");
        }

        private void LoadLocations()
        {
            // Load locations from database or hardcode for simplicity
            cmbLocation.Items.Add("Bank");
            cmbLocation.Items.Add("Equipment");
            cmbLocation.Items.Add("Port");
        }

        private void BindData()
        {
            txtCarrierNo.Text = _carrier.CarrierNo;
            txtCarrierType.Text = _carrier.CarrierType;
            txtDetailType.Text = _carrier.CarrierDetailType;
            txtDurableId.Text = _carrier.DurableId;
            cmbDurableType.Text = _carrier.Durable?.DurableType ?? string.Empty;
            txtBatchCapacity.Text = _carrier.BatchCapacity.ToString();
            txtCurrentQty.Text = _carrier.CurrentQty.ToString();
            cmbLocation.Text = _carrier.Location ?? string.Empty;
            dtpLastMaintenance.Value = _carrier.LastMaintenanceDate ?? DateTime.Now;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (SaveCarrier())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private bool SaveCarrier()
        {
            try
            {
                if (string.IsNullOrEmpty(txtCarrierNo.Text))
                {
                    MessageBox.Show("载具编号不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (string.IsNullOrEmpty(txtCarrierType.Text))
                {
                    MessageBox.Show("载具类型不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (string.IsNullOrEmpty(txtDetailType.Text))
                {
                    MessageBox.Show("详细类型不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (!int.TryParse(txtBatchCapacity.Text, out var batchCapacity) || batchCapacity <= 0)
                {
                    MessageBox.Show("批次容量必须为大于0的整数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (!int.TryParse(txtCurrentQty.Text, out var currentQty) || currentQty < 0)
                {
                    MessageBox.Show("当前数量必须为非负整数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                _carrier.CarrierNo = txtCarrierNo.Text;
                _carrier.CarrierType = txtCarrierType.Text;
                _carrier.CarrierDetailType = txtDetailType.Text;
                _carrier.DurableId = txtDurableId.Text;
                _carrier.BatchCapacity = batchCapacity;
                _carrier.CurrentQty = currentQty;
                _carrier.Location = cmbLocation.Text;
                _carrier.LastMaintenanceDate = dtpLastMaintenance.Value;

                if (string.IsNullOrEmpty(_carrier.CarrierNo))
                {
                    if (_carrierService.InsertCarrier(_carrier))
                    {
                        MessageBox.Show("载具创建成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("载具创建失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    if (_carrierService.UpdateCarrier(_carrier))
                    {
                        MessageBox.Show("载具更新成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("载具更新失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存载具时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}