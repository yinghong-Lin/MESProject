using MDM.BLL.Carr;
using MDM.Model.UserEntities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace MDM.UI.Carr
{
    public partial class FrmCreateCarrier : Form
    {
        private readonly ICarrierService _carrierService;
        private BindingList<Durable> _durableBindingList;
        private BindingList<Carrier> _carrierBindingList;

        public FrmCreateCarrier(ICarrierService carrierService)
        {
            InitializeComponent();
            _carrierService = carrierService;
            LoadDurables();
        }

        private void LoadDurables()
        {
            var durables = _carrierService.GetAllDurables();
            _durableBindingList = new BindingList<Durable>(durables);
            dataGridViewDurables.DataSource = _durableBindingList;
        }

        private void LoadCarriers(string durableId)
        {
            var carriers = _carrierService.GetCarriersByDurableId(durableId);
            _carrierBindingList = new BindingList<Carrier>(carriers);
            dataGridViewCarriers.DataSource = _carrierBindingList;
        }

        private void dataGridViewDurables_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewDurables.CurrentRow != null)
            {
                var selectedDurable = _durableBindingList[dataGridViewDurables.CurrentRow.Index];
                txtDurableId.Text = selectedDurable.DurableId;
                LoadCarriers(selectedDurable.DurableId);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
