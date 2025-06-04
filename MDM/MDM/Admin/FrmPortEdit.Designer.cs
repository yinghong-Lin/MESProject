namespace MDM.UI.Admin
{
    partial class FrmPortEdit
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
            lblPortId = new Label();
            txtPortId = new TextBox();
            lblPortType = new Label();
            cmbPortType = new ComboBox();
            lblPortDetailType = new Label();
            txtPortDetailType = new TextBox();
            lblPortDescription = new Label();
            txtPortDescription = new TextBox();
            lblEqpId = new Label();
            txtEqpId = new TextBox();
            lblEventUser = new Label();
            txtEventUser = new TextBox();
            lblEventRemark = new Label();
            txtEventRemark = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblPortId
            // 
            lblPortId.AutoSize = true;
            lblPortId.Location = new Point(24, 31);
            lblPortId.Margin = new Padding(6, 0, 6, 0);
            lblPortId.Name = "lblPortId";
            lblPortId.Size = new Size(86, 31);
            lblPortId.TabIndex = 0;
            lblPortId.Text = "端口ID";
            // 
            // txtPortId
            // 
            txtPortId.Location = new Point(200, 25);
            txtPortId.Margin = new Padding(6);
            txtPortId.Name = "txtPortId";
            txtPortId.Size = new Size(400, 38);
            txtPortId.TabIndex = 1;
            // 
            // lblPortType
            // 
            lblPortType.AutoSize = true;
            lblPortType.Location = new Point(24, 81);
            lblPortType.Margin = new Padding(6, 0, 6, 0);
            lblPortType.Name = "lblPortType";
            lblPortType.Size = new Size(110, 31);
            lblPortType.TabIndex = 2;
            lblPortType.Text = "端口类型";
            // 
            // cmbPortType
            // 
            cmbPortType.FormattingEnabled = true;
            cmbPortType.Location = new Point(200, 75);
            cmbPortType.Margin = new Padding(6);
            cmbPortType.Name = "cmbPortType";
            cmbPortType.Size = new Size(400, 39);
            cmbPortType.TabIndex = 3;
            // 
            // lblPortDetailType
            // 
            lblPortDetailType.AutoSize = true;
            lblPortDetailType.Location = new Point(24, 131);
            lblPortDetailType.Margin = new Padding(6, 0, 6, 0);
            lblPortDetailType.Name = "lblPortDetailType";
            lblPortDetailType.Size = new Size(158, 31);
            lblPortDetailType.TabIndex = 4;
            lblPortDetailType.Text = "端口详细类型";
            // 
            // txtPortDetailType
            // 
            txtPortDetailType.Location = new Point(200, 125);
            txtPortDetailType.Margin = new Padding(6);
            txtPortDetailType.Name = "txtPortDetailType";
            txtPortDetailType.Size = new Size(400, 38);
            txtPortDetailType.TabIndex = 5;
            // 
            // lblPortDescription
            // 
            lblPortDescription.AutoSize = true;
            lblPortDescription.Location = new Point(24, 181);
            lblPortDescription.Margin = new Padding(6, 0, 6, 0);
            lblPortDescription.Name = "lblPortDescription";
            lblPortDescription.Size = new Size(110, 31);
            lblPortDescription.TabIndex = 6;
            lblPortDescription.Text = "端口描述";
            // 
            // txtPortDescription
            // 
            txtPortDescription.Location = new Point(200, 175);
            txtPortDescription.Margin = new Padding(6);
            txtPortDescription.Multiline = true;
            txtPortDescription.Name = "txtPortDescription";
            txtPortDescription.Size = new Size(400, 100);
            txtPortDescription.TabIndex = 7;
            // 
            // lblEqpId
            // 
            lblEqpId.AutoSize = true;
            lblEqpId.Location = new Point(24, 287);
            lblEqpId.Margin = new Padding(6, 0, 6, 0);
            lblEqpId.Name = "lblEqpId";
            lblEqpId.Size = new Size(158, 31);
            lblEqpId.TabIndex = 8;
            lblEqpId.Text = "关联的设备ID";
            // 
            // txtEqpId
            // 
            txtEqpId.Location = new Point(200, 281);
            txtEqpId.Margin = new Padding(6);
            txtEqpId.Name = "txtEqpId";
            txtEqpId.Size = new Size(400, 38);
            txtEqpId.TabIndex = 9;
            // 
            // lblEventUser
            // 
            lblEventUser.AutoSize = true;
            lblEventUser.Location = new Point(24, 337);
            lblEventUser.Margin = new Padding(6, 0, 6, 0);
            lblEventUser.Name = "lblEventUser";
            lblEventUser.Size = new Size(110, 31);
            lblEventUser.TabIndex = 10;
            lblEventUser.Text = "操作用户";
            // 
            // txtEventUser
            // 
            txtEventUser.Location = new Point(200, 331);
            txtEventUser.Margin = new Padding(6);
            txtEventUser.Name = "txtEventUser";
            txtEventUser.Size = new Size(400, 38);
            txtEventUser.TabIndex = 11;
            // 
            // lblEventRemark
            // 
            lblEventRemark.AutoSize = true;
            lblEventRemark.Location = new Point(24, 387);
            lblEventRemark.Margin = new Padding(6, 0, 6, 0);
            lblEventRemark.Name = "lblEventRemark";
            lblEventRemark.Size = new Size(110, 31);
            lblEventRemark.TabIndex = 12;
            lblEventRemark.Text = "操作备注";
            // 
            // txtEventRemark
            // 
            txtEventRemark.Location = new Point(200, 381);
            txtEventRemark.Margin = new Padding(6);
            txtEventRemark.Multiline = true;
            txtEventRemark.Name = "txtEventRemark";
            txtEventRemark.Size = new Size(400, 100);
            txtEventRemark.TabIndex = 13;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(200, 493);
            btnSave.Margin = new Padding(6);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 48);
            btnSave.TabIndex = 14;
            btnSave.Text = "保存";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(450, 493);
            btnCancel.Margin = new Padding(6);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 48);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // FrmPortEdit
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 561);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtEventRemark);
            Controls.Add(lblEventRemark);
            Controls.Add(txtEventUser);
            Controls.Add(lblEventUser);
            Controls.Add(txtEqpId);
            Controls.Add(lblEqpId);
            Controls.Add(txtPortDescription);
            Controls.Add(lblPortDescription);
            Controls.Add(txtPortDetailType);
            Controls.Add(lblPortDetailType);
            Controls.Add(cmbPortType);
            Controls.Add(lblPortType);
            Controls.Add(txtPortId);
            Controls.Add(lblPortId);
            Margin = new Padding(6);
            Name = "FrmPortEdit";
            StartPosition = FormStartPosition.CenterParent;
            Text = "端口编辑";
            Load += FrmPortEdit_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPortId;
        private TextBox txtPortId;
        private Label lblPortType;
        private ComboBox cmbPortType;
        private Label lblPortDetailType;
        private TextBox txtPortDetailType;
        private Label lblPortDescription;
        private TextBox txtPortDescription;
        private Label lblEqpId;
        private TextBox txtEqpId;
        private Label lblEventUser;
        private TextBox txtEventUser;
        private Label lblEventRemark;
        private TextBox txtEventRemark;
        private Button btnSave;
        private Button btnCancel;
    }
}
