namespace MDM.UI.Carr
{
    partial class FrmCreateCarrier
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            dataGridViewDurables = new DataGridView();
            dataGridViewCarriers = new DataGridView();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            txtCarrierNo = new TextBox();
            label2 = new Label();
            txtCarrierType = new TextBox();
            label3 = new Label();
            txtDurableId = new TextBox();
            btnNew = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDurables).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCarriers).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(48, 189);
            splitContainer1.Margin = new Padding(5, 6, 5, 6);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dataGridViewDurables);
            splitContainer1.Panel1.RightToLeft = RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dataGridViewCarriers);
            splitContainer1.Size = new Size(1399, 793);
            splitContainer1.SplitterDistance = 524;
            splitContainer1.SplitterWidth = 7;
            splitContainer1.TabIndex = 0;
            // 
            // dataGridViewDurables
            // 
            dataGridViewDurables.AllowUserToAddRows = false;
            dataGridViewDurables.AllowUserToDeleteRows = false;
            dataGridViewDurables.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDurables.Dock = DockStyle.Top;
            dataGridViewDurables.Location = new Point(0, 0);
            dataGridViewDurables.Margin = new Padding(5, 6, 5, 6);
            dataGridViewDurables.Name = "dataGridViewDurables";
            dataGridViewDurables.ReadOnly = true;
            dataGridViewDurables.RowHeadersWidth = 51;
            dataGridViewDurables.RowTemplate.Height = 24;
            dataGridViewDurables.Size = new Size(524, 738);
            dataGridViewDurables.TabIndex = 0;
            dataGridViewDurables.SelectionChanged += dataGridViewDurables_SelectionChanged;
            // 
            // dataGridViewCarriers
            // 
            dataGridViewCarriers.AllowUserToAddRows = false;
            dataGridViewCarriers.AllowUserToDeleteRows = false;
            dataGridViewCarriers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCarriers.Dock = DockStyle.Top;
            dataGridViewCarriers.Location = new Point(0, 0);
            dataGridViewCarriers.Name = "dataGridViewCarriers";
            dataGridViewCarriers.ReadOnly = true;
            dataGridViewCarriers.RowHeadersWidth = 51;
            dataGridViewCarriers.RowTemplate.Height = 24;
            dataGridViewCarriers.Size = new Size(868, 738);
            dataGridViewCarriers.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(txtCarrierNo);
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(txtCarrierType);
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Controls.Add(txtDurableId);
            flowLayoutPanel1.Controls.Add(btnNew);
            flowLayoutPanel1.Controls.Add(btnEdit);
            flowLayoutPanel1.Controls.Add(btnDelete);
            flowLayoutPanel1.Controls.Add(btnSearch);
            flowLayoutPanel1.Location = new Point(48, 15);
            flowLayoutPanel1.Margin = new Padding(5, 6, 5, 6);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1003, 136);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 0);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(116, 31);
            label1.TabIndex = 8;
            label1.Text = "载具编号:";
            // 
            // txtCarrierNo
            // 
            txtCarrierNo.Location = new Point(131, 6);
            txtCarrierNo.Margin = new Padding(5, 6, 5, 6);
            txtCarrierNo.Name = "txtCarrierNo";
            txtCarrierNo.Size = new Size(172, 38);
            txtCarrierNo.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(313, 0);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(116, 31);
            label2.TabIndex = 9;
            label2.Text = "载具类型:";
            // 
            // txtCarrierType
            // 
            txtCarrierType.Location = new Point(439, 6);
            txtCarrierType.Margin = new Padding(5, 6, 5, 6);
            txtCarrierType.Name = "txtCarrierType";
            txtCarrierType.Size = new Size(172, 38);
            txtCarrierType.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(621, 0);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(117, 31);
            label3.TabIndex = 17;
            label3.Text = "耐用品ID:";
            // 
            // txtDurableId
            // 
            txtDurableId.Location = new Point(748, 6);
            txtDurableId.Margin = new Padding(5, 6, 5, 6);
            txtDurableId.Name = "txtDurableId";
            txtDurableId.ReadOnly = true;
            txtDurableId.Size = new Size(172, 38);
            txtDurableId.TabIndex = 16;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(5, 56);
            btnNew.Margin = new Padding(5, 6, 5, 6);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(131, 48);
            btnNew.TabIndex = 12;
            btnNew.Text = "新建";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(146, 56);
            btnEdit.Margin = new Padding(5, 6, 5, 6);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(131, 48);
            btnEdit.TabIndex = 13;
            btnEdit.Text = "编辑";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click_1;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(287, 56);
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
            btnSearch.Location = new Point(428, 56);
            btnSearch.Margin = new Padding(5, 6, 5, 6);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(131, 48);
            btnSearch.TabIndex = 15;
            btnSearch.Text = "查询";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // FrmCreateCarrier
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1548, 1080);
            Controls.Add(splitContainer1);
            Controls.Add(flowLayoutPanel1);
            Margin = new Padding(5, 6, 5, 6);
            Name = "FrmCreateCarrier";
            Text = "载具管理";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewDurables).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCarriers).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridViewCarriers;
        private System.Windows.Forms.DataGridView dataGridViewDurables;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox txtCarrierNo;
        private System.Windows.Forms.TextBox txtCarrierType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtDurableId;
        private System.Windows.Forms.Label label3;
    }
}