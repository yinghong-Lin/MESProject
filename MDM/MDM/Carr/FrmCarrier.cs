using MDM.BLL.Carr;
using MDM.Model.UserEntities;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MDM.UI.Carr
{
    public partial class FrmCarrier : Form
    {
        private readonly ICarrierService _carrierService;
        private BindingList<Carrier> _carrierBindingList;

        public FrmCarrier(ICarrierService carrierService)
        {
            InitializeComponent();
            _carrierService = carrierService;
            LoadCarriers();
            LoadDurableTypes();
        }

        private void LoadCarriers()
        {
            var carriers = _carrierService.GetAllCarriers();
            _carrierBindingList = new BindingList<Carrier>(carriers);
            dataGridViewCarriers.DataSource = _carrierBindingList;
        }

        private void LoadDurableTypes()
        {
            // 这里应该从数据库加载耐用品类型
            cmbDurableType.Items.Add("Magazine");
            cmbDurableType.Items.Add("HighTemp");
            cmbDurableType.Items.Add("ESD");
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmCreateCarrier(_carrierService))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var newCarrier = frm.Carrier;
                    _carrierBindingList.Add(newCarrier);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewCarriers.CurrentRow == null)
                return;

            var carrier = _carrierBindingList[dataGridViewCarriers.CurrentRow.Index];
            using (var frm = new FrmCreateCarrier(_carrierService, carrier))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _carrierBindingList.ResetBindings();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewCarriers.CurrentRow == null)
                return;

            var carrier = _carrierBindingList[dataGridViewCarriers.CurrentRow.Index];
            if (MessageBox.Show($"确定要删除载具 {carrier.CarrierNo} 吗？", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _carrierService.DeleteCarrier(carrier.CarrierNo);
                _carrierBindingList.Remove(carrier);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var query = _carrierService.GetAllCarriers().AsQueryable();

            if (!string.IsNullOrEmpty(txtCarrierNo.Text))
                query = query.Where(c => c.CarrierNo.Contains(txtCarrierNo.Text));

            if (!string.IsNullOrEmpty(txtCarrierType.Text))
                query = query.Where(c => c.CarrierType.Contains(txtCarrierType.Text));

            if (!string.IsNullOrEmpty(txtDurableId.Text))
                query = query.Where(c => c.DurableId.Contains(txtDurableId.Text));

            _carrierBindingList = new BindingList<Carrier>(query.ToList());
            dataGridViewCarriers.DataSource = _carrierBindingList;
        }
    }
}