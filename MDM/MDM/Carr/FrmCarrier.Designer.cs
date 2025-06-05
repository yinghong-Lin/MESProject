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
            this.dataGridViewCarriers = new System.Windows.Forms.DataGridView();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtCarrierNo = new System.Windows.Forms.TextBox();
            this.txtCarrierType = new System.Windows.Forms.TextBox();
            this.txtDurableId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDurableType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCarriers)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCarriers
            // 
            this.dataGridViewCarriers.AllowUserToAddRows = false;
            this.dataGridViewCarriers.AllowUserToDeleteRows = false;
            this.dataGridViewCarriers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCarriers.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewCarriers.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewCarriers.Name = "dataGridViewCarriers";
            this.dataGridViewCarriers.ReadOnly = true;
            this.dataGridViewCarriers.RowHeadersWidth = 51;
            this.dataGridViewCarriers.RowTemplate.Height = 24;
            this.dataGridViewCarriers.Size = new System.Drawing.Size(800, 300);
            this.dataGridViewCarriers.TabIndex = 0;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(12, 306);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "新建";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(93, 306);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "编辑";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(174, 306);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(627, 335);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtCarrierNo
            // 
            this.txtCarrierNo.Location = new System.Drawing.Point(76, 335);
            this.txtCarrierNo.Name = "txtCarrierNo";
            this.txtCarrierNo.Size = new System.Drawing.Size(155, 25);
            this.txtCarrierNo.TabIndex = 5;
            // 
            // txtCarrierType
            // 
            this.txtCarrierType.Location = new System.Drawing.Point(244, 335);
            this.txtCarrierType.Name = "txtCarrierType";
            this.txtCarrierType.Size = new System.Drawing.Size(155, 25);
            this.txtCarrierType.TabIndex = 6;
            // 
            // txtDurableId
            // 
            this.txtDurableId.Location = new System.Drawing.Point(412, 335);
            this.txtDurableId.Name = "txtDurableId";
            this.txtDurableId.Size = new System.Drawing.Size(155, 25);
            this.txtDurableId.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 338);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "载具编号:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 338);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "载具类型:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(332, 338);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "耐用品ID:";
            // 
            // cmbDurableType
            // 
            this.cmbDurableType.FormattingEnabled = true;
            this.cmbDurableType.Location = new System.Drawing.Point(515, 335);
            this.cmbDurableType.Name = "cmbDurableType";
            this.cmbDurableType.Size = new System.Drawing.Size(106, 23);
            this.cmbDurableType.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(483, 338);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "类型:";
            // 
            // FrmCarrier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbDurableType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDurableId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCarrierType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCarrierNo);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.dataGridViewCarriers);
            this.Name = "FrmCarrier";
            this.Text = "载具管理";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCarriers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
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