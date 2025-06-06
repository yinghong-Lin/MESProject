// MDM.UI/Carr/FrmCarrier.cs

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
        }

        private void LoadCarriers()
        {
            var carriers = _carrierService.GetAllCarriers();
            _carrierBindingList = new BindingList<Carrier>(carriers);
            dataGridViewCarriers.DataSource = _carrierBindingList;

            SetDataGridViewColumnHeaders(dataGridViewCarriers);
        }

        private void SetDataGridViewColumnHeaders(DataGridView dataGridView)
        {
            if (dataGridView.Columns.Count > 0)
            {
                dataGridView.Columns["CarrierNo"].HeaderText = "载具编号";
                dataGridView.Columns["CarrierType"].HeaderText = "载具类型";
                dataGridView.Columns["DurableId"].HeaderText = "耐用品ID";
                dataGridView.Columns["HandlingStatus"].HeaderText = "载具状态";
                dataGridView.Columns["CleaningStatus"].HeaderText = "清洗状态";
                dataGridView.Columns["LockStatus"].HeaderText = "锁定状态";
                dataGridView.Columns["BatchCapacity"].HeaderText = "批次容量";
                dataGridView.Columns["CurrentQty"].HeaderText = "当前数量";
                dataGridView.Columns["Location"].HeaderText = "位置";
                dataGridView.Columns["LastMaintenanceDate"].HeaderText = "最后维护日期";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var query = _carrierService.GetAllCarriers().AsQueryable();

            if (!string.IsNullOrEmpty(txtDurableId.Text))
                query = query.Where(c => c.DurableId.Contains(txtDurableId.Text));

            if (!string.IsNullOrEmpty(txtCarrierType.Text))
                query = query.Where(c => c.CarrierType.Contains(txtCarrierType.Text));

            _carrierBindingList = new BindingList<Carrier>(query.ToList());
            dataGridViewCarriers.DataSource = _carrierBindingList;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewCarriers.CurrentRow == null)
                return;

            var carrier = _carrierBindingList[dataGridViewCarriers.CurrentRow.Index];
            using (var frm = new FrmEditCarrier(_carrierService, carrier))
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
    }
}