namespace MDM.UI.Carr
{
    partial class FrmCarrier
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
            dataGridViewCarriers = new DataGridView();
            btnNew = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnSearch = new Button();
            txtCarrierNo = new TextBox();
            txtCarrierType = new TextBox();
            txtDurableId = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            cmbDurableType = new ComboBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCarriers).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewCarriers
            // 
            dataGridViewCarriers.AllowUserToAddRows = false;
            dataGridViewCarriers.AllowUserToDeleteRows = false;
            dataGridViewCarriers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCarriers.Dock = DockStyle.Top;
            dataGridViewCarriers.Location = new Point(0, 0);
            dataGridViewCarriers.Margin = new Padding(5, 6, 5, 6);
            dataGridViewCarriers.Name = "dataGridViewCarriers";
            dataGridViewCarriers.ReadOnly = true;
            dataGridViewCarriers.RowHeadersWidth = 51;
            dataGridViewCarriers.RowTemplate.Height = 24;
            dataGridViewCarriers.Size = new Size(1608, 620);
            dataGridViewCarriers.TabIndex = 0;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(21, 632);
            btnNew.Margin = new Padding(5, 6, 5, 6);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(131, 48);
            btnNew.TabIndex = 1;
            btnNew.Text = "新建";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(163, 632);
            btnEdit.Margin = new Padding(5, 6, 5, 6);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(131, 48);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "编辑";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(304, 632);
            btnDelete.Margin = new Padding(5, 6, 5, 6);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(131, 48);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "删除";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(1411, 682);
            btnSearch.Margin = new Padding(5, 6, 5, 6);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(131, 48);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "查询";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtCarrierNo
            // 
            txtCarrierNo.Location = new Point(133, 692);
            txtCarrierNo.Margin = new Padding(5, 6, 5, 6);
            txtCarrierNo.Name = "txtCarrierNo";
            txtCarrierNo.Size = new Size(268, 38);
            txtCarrierNo.TabIndex = 5;
            // 
            // txtCarrierType
            // 
            txtCarrierType.Location = new Point(427, 692);
            txtCarrierType.Margin = new Padding(5, 6, 5, 6);
            txtCarrierType.Name = "txtCarrierType";
            txtCarrierType.Size = new Size(268, 38);
            txtCarrierType.TabIndex = 6;
            // 
            // txtDurableId
            // 
            txtDurableId.Location = new Point(832, 692);
            txtDurableId.Margin = new Padding(5, 6, 5, 6);
            txtDurableId.Name = "txtDurableId";
            txtDurableId.Size = new Size(268, 38);
            txtDurableId.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 699);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(116, 31);
            label1.TabIndex = 8;
            label1.Text = "载具编号:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(299, 699);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(116, 31);
            label2.TabIndex = 9;
            label2.Text = "载具类型:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(705, 699);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(117, 31);
            label3.TabIndex = 10;
            label3.Text = "耐用品ID:";
            // 
            // cmbDurableType
            // 
            cmbDurableType.FormattingEnabled = true;
            cmbDurableType.Location = new Point(1197, 691);
            cmbDurableType.Margin = new Padding(5, 6, 5, 6);
            cmbDurableType.Name = "cmbDurableType";
            cmbDurableType.Size = new Size(182, 39);
            cmbDurableType.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1119, 699);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(68, 31);
            label4.TabIndex = 12;
            label4.Text = "类型:";
            // 
            // FrmCarrier
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1608, 930);
            Controls.Add(label4);
            Controls.Add(cmbDurableType);
            Controls.Add(label3);
            Controls.Add(txtDurableId);
            Controls.Add(label2);
            Controls.Add(txtCarrierType);
            Controls.Add(label1);
            Controls.Add(txtCarrierNo);
            Controls.Add(btnSearch);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnNew);
            Controls.Add(dataGridViewCarriers);
            Margin = new Padding(5, 6, 5, 6);
            Name = "FrmCarrier";
            Text = "载具管理";
            ((System.ComponentModel.ISupportInitialize)dataGridViewCarriers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCarriers;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtCarrierNo;
        private System.Windows.Forms.TextBox txtCarrierType;
        private System.Windows.Forms.TextBox txtDurableId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDurableType;
        private System.Windows.Forms.Label label4;
    }
}