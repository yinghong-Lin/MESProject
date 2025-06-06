// MDM.UI/Carr/FrmCarrier.Designer.cs

namespace MDM.UI.Carr
{
    partial class FrmCarrier
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dataGridViewCarriers = new DataGridView();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            txtDurableId = new TextBox();
            label2 = new Label();
            txtCarrierType = new TextBox();
            btnEdit = new Button();
            btnDelete = new Button();
            btnSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCarriers).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewCarriers
            // 
            dataGridViewCarriers.AllowUserToAddRows = false;
            dataGridViewCarriers.AllowUserToDeleteRows = false;
            dataGridViewCarriers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCarriers.Dock = DockStyle.Fill;
            dataGridViewCarriers.Location = new Point(0, 144);
            dataGridViewCarriers.Name = "dataGridViewCarriers";
            dataGridViewCarriers.ReadOnly = true;
            dataGridViewCarriers.RowHeadersWidth = 82;
            dataGridViewCarriers.RowTemplate.Height = 24;
            dataGridViewCarriers.Size = new Size(1345, 746);
            dataGridViewCarriers.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(txtDurableId);
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(txtCarrierType);
            flowLayoutPanel1.Controls.Add(btnEdit);
            flowLayoutPanel1.Controls.Add(btnDelete);
            flowLayoutPanel1.Controls.Add(btnSearch);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1345, 144);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 0);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(152, 36);
            label1.TabIndex = 8;
            label1.Text = "耐用品ID:";
            // 
            // txtDurableId
            // 
            txtDurableId.Location = new Point(167, 6);
            txtDurableId.Margin = new Padding(5, 6, 5, 6);
            txtDurableId.Name = "txtDurableId";
            txtDurableId.Size = new Size(172, 44);
            txtDurableId.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(349, 0);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(152, 36);
            label2.TabIndex = 9;
            label2.Text = "载具类型:";
            // 
            // txtCarrierType
            // 
            txtCarrierType.Location = new Point(511, 6);
            txtCarrierType.Margin = new Padding(5, 6, 5, 6);
            txtCarrierType.Name = "txtCarrierType";
            txtCarrierType.Size = new Size(172, 44);
            txtCarrierType.TabIndex = 5;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(693, 6);
            btnEdit.Margin = new Padding(5, 6, 5, 6);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(131, 48);
            btnEdit.TabIndex = 13;
            btnEdit.Text = "编辑";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(834, 6);
            btnDelete.Margin = new Padding(5, 6, 5, 6);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(131, 48);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "删除";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(975, 6);
            btnSearch.Margin = new Padding(5, 6, 5, 6);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(131, 48);
            btnSearch.TabIndex = 15;
            btnSearch.Text = "查询";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // FrmCarrier
            // 
            AutoScaleDimensions = new SizeF(18F, 36F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1345, 890);
            Controls.Add(dataGridViewCarriers);
            Controls.Add(flowLayoutPanel1);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5, 6, 5, 6);
            Name = "FrmCarrier";
            Text = "载具管理";
            ((System.ComponentModel.ISupportInitialize)dataGridViewCarriers).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dataGridViewCarriers;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox txtDurableId;
        private System.Windows.Forms.TextBox txtCarrierType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
    }
}