using MDM.BLL.Equipment;
using MDM.Model.UserEntities;
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
    public partial class FrmEqpGroupHis : Form
    {
        private readonly IEqpGroupService _service;
        private readonly string _eqpGroupId;

        public FrmEqpGroupHis(IEqpGroupService service, string eqpGroupId)
        {
            InitializeComponent();
            _service = service;
            _eqpGroupId = eqpGroupId;
        }

        private void FrmEqpGroupHis_Load(object sender, EventArgs e)
        {
            // 设置窗体标题
            this.Text = $"设备组 {_eqpGroupId} 的历史记录";

            // 加载历史记录
            LoadHistory();
        }

        private void LoadHistory()
        {
            try
            {
                // 获取历史记录
                var history = _service.GetEqpGroupHistory(_eqpGroupId);

                // 绑定到DataGridView
                dataGridViewHistory.DataSource = history;

                // 设置列标题
                if (dataGridViewHistory.Columns.Count > 0)
                {
                    if (dataGridViewHistory.Columns.Contains("Id"))
                        dataGridViewHistory.Columns["Id"].HeaderText = "记录ID";

                    if (dataGridViewHistory.Columns.Contains("EqpGroupId"))
                        dataGridViewHistory.Columns["EqpGroupId"].HeaderText = "设备组ID";

                    if (dataGridViewHistory.Columns.Contains("EqpGroupType"))
                        dataGridViewHistory.Columns["EqpGroupType"].HeaderText = "设备组类型";

                    if (dataGridViewHistory.Columns.Contains("EqpGroupDescription"))
                        dataGridViewHistory.Columns["EqpGroupDescription"].HeaderText = "设备组描述";

                    if (dataGridViewHistory.Columns.Contains("FactoryId"))
                        dataGridViewHistory.Columns["FactoryId"].HeaderText = "工厂ID";

                    if (dataGridViewHistory.Columns.Contains("EventUser"))
                        dataGridViewHistory.Columns["EventUser"].HeaderText = "操作用户";

                    if (dataGridViewHistory.Columns.Contains("EventRemark"))
                        dataGridViewHistory.Columns["EventRemark"].HeaderText = "操作备注";

                    if (dataGridViewHistory.Columns.Contains("EditTime"))
                        dataGridViewHistory.Columns["EditTime"].HeaderText = "编辑时间";

                    if (dataGridViewHistory.Columns.Contains("CreateTime"))
                        dataGridViewHistory.Columns["CreateTime"].HeaderText = "创建时间";

                    if (dataGridViewHistory.Columns.Contains("EventType"))
                        dataGridViewHistory.Columns["EventType"].HeaderText = "操作类型";
                }

                // 设置标签显示记录数量
                lblRecordCount.Text = $"共 {history.Count} 条历史记录";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载历史记录失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
