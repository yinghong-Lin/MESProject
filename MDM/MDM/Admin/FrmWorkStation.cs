using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDM.UI.Admin
{
    public partial class FrmWorkStation : Form
    {
        public FrmWorkStation()
        {
            InitializeComponent();
            // 动态创建 DataGridView 控件
            var dataGridView = new DataGridView();
            dataGridView.Dock = DockStyle.Fill;
            panel2.Controls.Add(dataGridView);

            // 模拟数据
            var bomItems = new List<BomItem>
            {
                new BomItem
                {
                    Id = 1,
                    MaterialNo = "MAT-001",
                    MaterialName = "Example Material 1",
                    MaterialType = "Type A",
                    DetailedMaterialType = "Subtype A1",
                    ConsumptionQuantity = 10,
                    MaterialUnit = "pcs",
                    BomNo = "BOM-001",
                    MaterialBatchQuantity = 100
                },
                new BomItem
                {
                    Id = 2,
                    MaterialNo = "MAT-002",
                    MaterialName = "Example Material 2",
                    MaterialType = "Type B",
                    DetailedMaterialType = "Subtype B1",
                    ConsumptionQuantity = 5,
                    MaterialUnit = "kg",
                    BomNo = "BOM-001",
                    MaterialBatchQuantity = 50
                }
            };

            // 设置 DataGridView 的数据源
            dataGridView.DataSource = bomItems;
        }

        private void FrmWorkStation_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmWorkStation_Load_1(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    public class BomItem
    {
        public int Id { get; set; }
        public string MaterialNo { get; set; } // 物料号
        public string MaterialName { get; set; } // 物料名
        public string MaterialType { get; set; } // 物料类型
        public string DetailedMaterialType { get; set; } // 详细物料类型
        public int ConsumptionQuantity { get; set; } // 消耗数量
        public string MaterialUnit { get; set; } // 物料单位
        public string BomNo { get; set; } // BOM编号
        public int MaterialBatchQuantity { get; set; } // 物料批次数量
    }
}