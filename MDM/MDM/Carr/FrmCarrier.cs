// MDM.UI/Carr/FrmCarrier.cs

using MDM.BLL.Carr;
using MDM.Model.UserEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
            InitializeComboBoxes();
        }

        private void LoadCarriers()
        {
            var carriers = _carrierService.GetAllCarriers();
            _carrierBindingList = new BindingList<Carrier>(carriers);
            dataGridViewCarriers.DataSource = _carrierBindingList;
        }

        private void InitializeComboBoxes()
        {
            // 初始化容量状态下拉框
            comboBoxCapacityStatus.Items.Add("All");
            comboBoxCapacityStatus.Items.Add("Empty");
            comboBoxCapacityStatus.Items.Add("Full");
            comboBoxCapacityStatus.Items.Add("Partial");
            comboBoxCapacityStatus.SelectedIndex = 0;

            // 初始化清洗状态下拉框
            comboBoxCleaningStatus.Items.Add("All");
            comboBoxCleaningStatus.Items.Add("Clean");
            comboBoxCleaningStatus.Items.Add("Dirty");
            comboBoxCleaningStatus.SelectedIndex = 0;

            // 初始化载具状态 下拉框
            comboBoxCarrierStatus.Items.Add("All");
            comboBoxCarrierStatus.Items.Add("Released");
            comboBoxCarrierStatus.Items.Add("InUse");
            comboBoxCarrierStatus.Items.Add("Maintenance");
            comboBoxCarrierStatus.SelectedIndex = 0;

            // 初始化载具类型下拉框（从数据库获取）
            var carriers = _carrierService.GetAllCarriers();
            var carrierTypes = carriers.Select(c => c.CarrierType).Distinct().ToList();
            comboBoxCarrierType.Items.Add("All");
            comboBoxCarrierType.Items.AddRange(carrierTypes.ToArray());
            comboBoxCarrierType.SelectedIndex = 0;

            // 初始化耐用品规格号下拉框（从数据库获取）
            var durables = _carrierService.GetAllDurables();
            var durableIds = durables.Select(d => d.DurableId).Distinct().ToList();
            comboBoxDurableItemSpec.Items.Add("All");
            comboBoxDurableItemSpec.Items.AddRange(durableIds.ToArray());
            comboBoxDurableItemSpec.SelectedIndex = 0;
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            var query = _carrierService.GetAllCarriers().AsQueryable();

            // 载具类型筛选
            if (comboBoxCarrierType.SelectedItem.ToString() != "All")
            {
                query = query.Where(c => c.CarrierType == comboBoxCarrierType.SelectedItem.ToString());
            }

            // 耐用品规格号筛选
            if (comboBoxDurableItemSpec.SelectedItem.ToString() != "All")
            {
                query = query.Where(c => c.DurableId == comboBoxDurableItemSpec.SelectedItem.ToString());
            }

            // 容量状态筛选
            if (comboBoxCapacityStatus.SelectedItem.ToString() != "All")
            {
                query = query.Where(c => c.CapacityStatus == comboBoxCapacityStatus.SelectedItem.ToString());
            }

            // 清洗状态筛选
            if (comboBoxCleaningStatus.SelectedItem.ToString() != "All")
            {
                query = query.Where(c => c.CleaningStatus == comboBoxCleaningStatus.SelectedItem.ToString());
            }

            // 载具状态筛选
            if (comboBoxCarrierStatus.SelectedItem.ToString() != "All")
            {
                query = query.Where(c => c.CarrierStatus == comboBoxCarrierStatus.SelectedItem.ToString());
            }

            // 载具号筛选
            if (!string.IsNullOrEmpty(txtCarrierNumber.Text))
            {
                query = query.Where(c => c.CarrierNo.Contains(txtCarrierNumber.Text));
            }

            _carrierBindingList = new BindingList<Carrier>(query.ToList());
            dataGridViewCarriers.DataSource = _carrierBindingList;
        }
    }
}