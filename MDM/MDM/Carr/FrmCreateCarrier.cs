using MDM.BLL.Carr;
using MDM.Model.UserEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
            InitializeComboBoxes();
            LoadDurables();
        }

        private void InitializeComboBoxes()
        {
            // 初始化载具类型下拉框（从数据库获取）
            var carrierTypes = _carrierService.GetAllCarriers()
                .Select(c => c.CarrierType)
                .Distinct()
                .ToList();
            comboBoxType.Items.AddRange(carrierTypes.ToArray());
            comboBoxType.SelectedIndex = 0;

            // 初始化耐用品规格号下拉框（从数据库获取）
            var durableIds = _carrierService.GetAllDurables()
                .Select(d => d.DurableId)
                .Distinct()
                .ToList();
            comboBoxDurableId.Items.AddRange(durableIds.ToArray());
            comboBoxDurableId.SelectedIndex = 0;

            // 初始化位置号下拉框（从数据库获取或硬编码）
            var locations = _carrierService.GetAllCarriers()
                .Select(c => c.Location)
                .Distinct()
                .Where(l => !string.IsNullOrEmpty(l))
                .ToList();
            comboBoxLocation.Items.Add("请选择位置");
            comboBoxLocation.Items.AddRange(locations.ToArray());
            comboBoxLocation.SelectedIndex = 0;
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var query = _carrierService.GetAllCarriers().AsQueryable();

            // 根据载具类型筛选
            if (comboBoxType.SelectedItem.ToString() != "All")
            {
                query = query.Where(c => c.CarrierType == comboBoxType.SelectedItem.ToString());
            }

            // 根据耐用品规格号筛选
            if (comboBoxDurableId.SelectedItem.ToString() != "All")
            {
                query = query.Where(c => c.DurableId == comboBoxDurableId.SelectedItem.ToString());
            }

            _carrierBindingList = new BindingList<Carrier>(query.ToList());
            dataGridViewCarriers.DataSource = _carrierBindingList;
        }

        private void dataGridViewDurables_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewDurables.CurrentRow != null)
            {
                var selectedDurable = _durableBindingList[dataGridViewDurables.CurrentRow.Index];

                // 在创建面板中显示选中的耐用品信息
                txtDurableId.Text = selectedDurable.DurableId; // 耐用品规格号
                txtcarrierType.Text = selectedDurable.DurableType; // 载具类型
                comboBoxLocation.Text = selectedDurable.FactoryId; // 位置号
                txtMaxUsage.Text = selectedDurable.ExpectedLife.ToString(); // 最大使用次数
                txtMaxClean.Text = selectedDurable.MaxUsageDays.ToString(); // 最大清洗次数
                txtCapacity.Text = selectedDurable.DurableCapacity.ToString(); // 容量
                txtCarrierId.Text = Guid.NewGuid().ToString("N").Substring(0, 8); // 自动生成载具号前缀
            }
        }

        private void createbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDurableId.Text))
            {
                MessageBox.Show("请选择耐用品规格号", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtcarrierType.Text))
            {
                MessageBox.Show("请选择载具类型", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(comboBoxLocation.Text))
            {
                MessageBox.Show("请选择位置号", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtMaxUsage.Text, out int maxUsage) || maxUsage <= 0)
            {
                MessageBox.Show("最大使用次数必须为大于0的整数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtMaxClean.Text, out int maxClean) || maxClean <= 0)
            {
                MessageBox.Show("最大清洗次数必须为大于0的整数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtCapacity.Text, out int capacity) || capacity <= 0)
            {
                MessageBox.Show("容量必须为大于0的整数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int createQuantity = (int)numericUpDown1.Value;

            for (int i = 0; i < createQuantity; i++)
            {
                var newCarrier = new Carrier
                {
                    CarrierNo = $"{txtCarrierId.Text}-{i + 1}",
                    CarrierType = txtcarrierType.Text,
                    DurableId = txtDurableId.Text,
                    Location = comboBoxLocation.Text,
                    BatchCapacity = capacity,
                    CurrentQty = 0,
                    CapacityStatus = "Empty",
                    CarrierStatus = "Released",
                    CleaningStatus = "Clean",
                    LastMaintenanceDate = DateTime.Now
                };

                _carrierService.InsertCarrier(newCarrier);
            }

            MessageBox.Show($"成功创建 {createQuantity} 个载具", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadCarriers(txtDurableId.Text);
        }
    }
}