namespace MDM.UI.Carr
{
    partial class FrmEditCarrier
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
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            txtCarrierNo = new TextBox();
            label2 = new Label();
            txtCarrierType = new TextBox();
            label3 = new Label();
            txtDetailType = new TextBox();
            label4 = new Label();
            txtDurableId = new TextBox();
            label5 = new Label();
            cmbDurableType = new ComboBox();
            label6 = new Label();
            txtBatchCapacity = new TextBox();
            label7 = new Label();
            txtCurrentQty = new TextBox();
            label8 = new Label();
            cmbLocation = new ComboBox();
            label9 = new Label();
            dtpLastMaintenance = new DateTimePicker();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnOK = new Button();
            btnCancel = new Button();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 175F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(txtCarrierNo, 1, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(txtCarrierType, 1, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(txtDetailType, 1, 2);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(txtDurableId, 1, 3);
            tableLayoutPanel1.Controls.Add(label5, 0, 4);
            tableLayoutPanel1.Controls.Add(cmbDurableType, 1, 4);
            tableLayoutPanel1.Controls.Add(label6, 0, 5);
            tableLayoutPanel1.Controls.Add(txtBatchCapacity, 1, 5);
            tableLayoutPanel1.Controls.Add(label7, 0, 6);
            tableLayoutPanel1.Controls.Add(txtCurrentQty, 1, 6);
            tableLayoutPanel1.Controls.Add(label8, 0, 7);
            tableLayoutPanel1.Controls.Add(cmbLocation, 1, 7);
            tableLayoutPanel1.Controls.Add(label9, 0, 8);
            tableLayoutPanel1.Controls.Add(dtpLastMaintenance, 1, 8);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(5, 6, 5, 6);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 9;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1400, 930);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(54, 15);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(116, 31);
            label1.TabIndex = 0;
            label1.Text = "载具编号:";
            // 
            // txtCarrierNo
            // 
            txtCarrierNo.Dock = DockStyle.Fill;
            txtCarrierNo.Location = new Point(180, 6);
            txtCarrierNo.Margin = new Padding(5, 6, 5, 6);
            txtCarrierNo.Name = "txtCarrierNo";
            txtCarrierNo.Size = new Size(1215, 38);
            txtCarrierNo.TabIndex = 1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(54, 77);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(116, 31);
            label2.TabIndex = 2;
            label2.Text = "载具类型:";
            // 
            // txtCarrierType
            // 
            txtCarrierType.Dock = DockStyle.Fill;
            txtCarrierType.Location = new Point(180, 68);
            txtCarrierType.Margin = new Padding(5, 6, 5, 6);
            txtCarrierType.Name = "txtCarrierType";
            txtCarrierType.Size = new Size(1215, 38);
            txtCarrierType.TabIndex = 3;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(54, 139);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(116, 31);
            label3.TabIndex = 4;
            label3.Text = "详细类型:";
            // 
            // txtDetailType
            // 
            txtDetailType.Dock = DockStyle.Fill;
            txtDetailType.Location = new Point(180, 130);
            txtDetailType.Margin = new Padding(5, 6, 5, 6);
            txtDetailType.Name = "txtDetailType";
            txtDetailType.Size = new Size(1215, 38);
            txtDetailType.TabIndex = 5;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(53, 201);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(117, 31);
            label4.TabIndex = 6;
            label4.Text = "耐用品ID:";
            // 
            // txtDurableId
            // 
            txtDurableId.Dock = DockStyle.Fill;
            txtDurableId.Location = new Point(180, 192);
            txtDurableId.Margin = new Padding(5, 6, 5, 6);
            txtDurableId.Name = "txtDurableId";
            txtDurableId.Size = new Size(1215, 38);
            txtDurableId.TabIndex = 7;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(30, 263);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(140, 31);
            label5.TabIndex = 8;
            label5.Text = "耐用品类型:";
            // 
            // cmbDurableType
            // 
            cmbDurableType.Dock = DockStyle.Fill;
            cmbDurableType.FormattingEnabled = true;
            cmbDurableType.Location = new Point(180, 254);
            cmbDurableType.Margin = new Padding(5, 6, 5, 6);
            cmbDurableType.Name = "cmbDurableType";
            cmbDurableType.Size = new Size(1215, 39);
            cmbDurableType.TabIndex = 9;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(54, 325);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(116, 31);
            label6.TabIndex = 10;
            label6.Text = "批次容量:";
            // 
            // txtBatchCapacity
            // 
            txtBatchCapacity.Dock = DockStyle.Fill;
            txtBatchCapacity.Location = new Point(180, 316);
            txtBatchCapacity.Margin = new Padding(5, 6, 5, 6);
            txtBatchCapacity.Name = "txtBatchCapacity";
            txtBatchCapacity.Size = new Size(1215, 38);
            txtBatchCapacity.TabIndex = 11;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(54, 387);
            label7.Margin = new Padding(5, 0, 5, 0);
            label7.Name = "label7";
            label7.Size = new Size(116, 31);
            label7.TabIndex = 12;
            label7.Text = "当前数量:";
            // 
            // txtCurrentQty
            // 
            txtCurrentQty.Dock = DockStyle.Fill;
            txtCurrentQty.Location = new Point(180, 378);
            txtCurrentQty.Margin = new Padding(5, 6, 5, 6);
            txtCurrentQty.Name = "txtCurrentQty";
            txtCurrentQty.Size = new Size(1215, 38);
            txtCurrentQty.TabIndex = 13;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new Point(102, 449);
            label8.Margin = new Padding(5, 0, 5, 0);
            label8.Name = "label8";
            label8.Size = new Size(68, 31);
            label8.TabIndex = 14;
            label8.Text = "位置:";
            // 
            // cmbLocation
            // 
            cmbLocation.Dock = DockStyle.Fill;
            cmbLocation.FormattingEnabled = true;
            cmbLocation.Location = new Point(180, 440);
            cmbLocation.Margin = new Padding(5, 6, 5, 6);
            cmbLocation.Name = "cmbLocation";
            cmbLocation.Size = new Size(1215, 39);
            cmbLocation.TabIndex = 15;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new Point(6, 697);
            label9.Margin = new Padding(5, 0, 5, 0);
            label9.Name = "label9";
            label9.Size = new Size(164, 31);
            label9.TabIndex = 16;
            label9.Text = "最后维护日期:";
            // 
            // dtpLastMaintenance
            // 
            dtpLastMaintenance.Dock = DockStyle.Fill;
            dtpLastMaintenance.Location = new Point(180, 502);
            dtpLastMaintenance.Margin = new Padding(5, 6, 5, 6);
            dtpLastMaintenance.Name = "dtpLastMaintenance";
            dtpLastMaintenance.Size = new Size(1215, 38);
            dtpLastMaintenance.TabIndex = 17;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnOK);
            flowLayoutPanel1.Controls.Add(btnCancel);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.Location = new Point(0, 930);
            flowLayoutPanel1.Margin = new Padding(5, 6, 5, 6);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1400, 103);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(5, 6);
            btnOK.Margin = new Padding(5, 6, 5, 6);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(131, 48);
            btnOK.TabIndex = 0;
            btnOK.Text = "确定";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(146, 6);
            btnCancel.Margin = new Padding(5, 6, 5, 6);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(131, 48);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // FrmEditCarrier
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 1033);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(flowLayoutPanel1);
            Margin = new Padding(5, 6, 5, 6);
            Name = "FrmEditCarrier";
            Text = "创建/编辑载具";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCarrierNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCarrierType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDetailType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDurableId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbDurableType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBatchCapacity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCurrentQty;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpLastMaintenance;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}