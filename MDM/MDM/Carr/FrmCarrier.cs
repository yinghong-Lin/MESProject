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
        private BindingList<Durable> _durableBindingList;

        public FrmCarrier(ICarrierService carrierService)
        {
            InitializeComponent();
            _carrierService = carrierService;
            LoadCarriers();
            LoadDurables();
        }

        private void LoadCarriers()
        {
            var carriers = _carrierService.GetAllCarriers();
            _carrierBindingList = new BindingList<Carrier>(carriers);
            dataGridViewCarriers.DataSource = _carrierBindingList;
            dataGridViewCarriers.ScrollBars = ScrollBars.Both; // 添加滚动条设置

            SetDataGridViewColumnHeaders(dataGridViewCarriers, true);
        }

        private void LoadDurables()
        {
            var durables = _carrierService.GetDurableTypes();
            _durableBindingList = new BindingList<Durable>(durables);
            dataGridViewDurables.DataSource = _durableBindingList;
            dataGridViewDurables.ScrollBars = ScrollBars.Both; // 添加滚动条设置

            SetDataGridViewColumnHeaders(dataGridViewDurables, false);
        }

        private void SetDataGridViewColumnHeaders(DataGridView dataGridView, bool isCarrier)
        {
            if (dataGridView.Columns.Count > 0)
            {
                if (isCarrier)
                {
                    dataGridView.Columns["CarrierNo"].HeaderText = "载具编号";
                    dataGridView.Columns["CarrierType"].HeaderText = "载具类型";
                    dataGridView.Columns["CarrierDetailType"].HeaderText = "详细类型";
                    dataGridView.Columns["DurableId"].HeaderText = "耐用品ID";
                    dataGridView.Columns["HandlingStatus"].HeaderText = "载具状态";
                    dataGridView.Columns["CleaningStatus"].HeaderText = "清洗状态";
                    dataGridView.Columns["LockStatus"].HeaderText = "锁定状态";
                    dataGridView.Columns["BatchCapacity"].HeaderText = "批次容量";
                    dataGridView.Columns["CurrentQty"].HeaderText = "当前数量";
                    dataGridView.Columns["Location"].HeaderText = "位置";

                    dataGridView.Columns["LastMaintenanceDate"].HeaderText = "最后维护日期";

                }
                else
                {
                    dataGridView.Columns["DurableId"].HeaderText = "耐用品ID";
                    dataGridView.Columns["SpecDescription"].HeaderText = "规格说明";
                    dataGridView.Columns["DurableType"].HeaderText = "耐用品类型";
                    dataGridView.Columns["ExpectedLife"].HeaderText = "预期寿命(次)";
                    dataGridView.Columns["CurrentUsage"].HeaderText = "当前使用次数";

                    dataGridView.Columns["PurchaseDate"].HeaderText = "采购日期";


                    dataGridView.Columns["Supplier"].HeaderText = "供应商";

                }
            }
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



        private void btnEdit_Click_1(object sender, EventArgs e)
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

            _carrierBindingList = new BindingList<Carrier>(query.ToList());
            dataGridViewCarriers.DataSource = _carrierBindingList;
        }
    }
}