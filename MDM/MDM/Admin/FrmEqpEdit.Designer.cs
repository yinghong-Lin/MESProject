namespace MDM.UI.Admin
{
    partial class FrmEqpEdit
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
            lblEqpId = new Label();
            txtEqpId = new TextBox();
            lblEqpType = new Label();
            cmbEqpType = new ComboBox();
            lblEqpDetailType = new Label();
            txtEqpDetailType = new TextBox();
            lblEqpDescription = new Label();
            txtEqpDescription = new TextBox();
            lblEqpGroup = new Label();
            cmbEqpGroup = new ComboBox();
            lblEqpLevel = new Label();
            cmbEqpLevel = new ComboBox();
            lblParentEqpId = new Label();
            txtParentEqpId = new TextBox();
            lblEventUser = new Label();
            txtEventUser = new TextBox();
            lblEventRemark = new Label();
            txtEventRemark = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblEqpId
            // 
            lblEqpId.AutoSize = true;
            lblEqpId.Location = new Point(24, 31);
            lblEqpId.Margin = new Padding(6, 0, 6, 0);
            lblEqpId.Name = "lblEqpId";
            lblEqpId.Size = new Size(86, 31);
            lblEqpId.TabIndex = 0;
            lblEqpId.Text = "设备ID";
            // 
            // txtEqpId
            // 
            txtEqpId.Location = new Point(200, 25);
            txtEqpId.Margin = new Padding(6);
            txtEqpId.Name = "txtEqpId";
            txtEqpId.Size = new Size(400, 38);
            txtEqpId.TabIndex = 1;
            // 
            // lblEqpType
            // 
            lblEqpType.AutoSize = true;
            lblEqpType.Location = new Point(24, 81);
            lblEqpType.Margin = new Padding(6, 0, 6, 0);
            lblEqpType.Name = "lblEqpType";
            lblEqpType.Size = new Size(110, 31);
            lblEqpType.TabIndex = 2;
            lblEqpType.Text = "设备类型";
            // 
            // cmbEqpType
            // 
            cmbEqpType.FormattingEnabled = true;
            cmbEqpType.Location = new Point(200, 75);
            cmbEqpType.Margin = new Padding(6);
            cmbEqpType.Name = "cmbEqpType";
            cmbEqpType.Size = new Size(400, 39);
            cmbEqpType.TabIndex = 3;
            // 
            // lblEqpDetailType
            // 
            lblEqpDetailType.AutoSize = true;
            lblEqpDetailType.Location = new Point(24, 131);
            lblEqpDetailType.Margin = new Padding(6, 0, 6, 0);
            lblEqpDetailType.Name = "lblEqpDetailType";
            lblEqpDetailType.Size = new Size(158, 31);
            lblEqpDetailType.TabIndex = 4;
            lblEqpDetailType.Text = "设备详细类型";
            // 
            // txtEqpDetailType
            // 
            txtEqpDetailType.Location = new Point(200, 125);
            txtEqpDetailType.Margin = new Padding(6);
            txtEqpDetailType.Name = "txtEqpDetailType";
            txtEqpDetailType.Size = new Size(400, 38);
            txtEqpDetailType.TabIndex = 5;
            // 
            // lblEqpDescription
            // 
            lblEqpDescription.AutoSize = true;
            lblEqpDescription.Location = new Point(24, 181);
            lblEqpDescription.Margin = new Padding(6, 0, 6, 0);
            lblEqpDescription.Name = "lblEqpDescription";
            lblEqpDescription.Size = new Size(110, 31);
            lblEqpDescription.TabIndex = 6;
            lblEqpDescription.Text = "设备描述";
            // 
            // txtEqpDescription
            // 
            txtEqpDescription.Location = new Point(200, 175);
            txtEqpDescription.Margin = new Padding(6);
            txtEqpDescription.Multiline = true;
            txtEqpDescription.Name = "txtEqpDescription";
            txtEqpDescription.Size = new Size(400, 100);
            txtEqpDescription.TabIndex = 7;
            // 
            // lblEqpGroup
            // 
            lblEqpGroup.AutoSize = true;
            lblEqpGroup.Location = new Point(24, 287);
            lblEqpGroup.Margin = new Padding(6, 0, 6, 0);
            lblEqpGroup.Name = "lblEqpGroup";
            lblEqpGroup.Size = new Size(86, 31);
            lblEqpGroup.TabIndex = 8;
            lblEqpGroup.Text = "设备组";
            // 
            // cmbEqpGroup
            // 
            cmbEqpGroup.FormattingEnabled = true;
            cmbEqpGroup.Location = new Point(200, 281);
            cmbEqpGroup.Margin = new Padding(6);
            cmbEqpGroup.Name = "cmbEqpGroup";
            cmbEqpGroup.Size = new Size(400, 39);
            cmbEqpGroup.TabIndex = 9;
            // 
            // lblEqpLevel
            // 
            lblEqpLevel.AutoSize = true;
            lblEqpLevel.Location = new Point(24, 337);
            lblEqpLevel.Margin = new Padding(6, 0, 6, 0);
            lblEqpLevel.Name = "lblEqpLevel";
            lblEqpLevel.Size = new Size(110, 31);
            lblEqpLevel.TabIndex = 10;
            lblEqpLevel.Text = "设备层次";
            // 
            // cmbEqpLevel
            // 
            cmbEqpLevel.FormattingEnabled = true;
            cmbEqpLevel.Location = new Point(200, 331);
            cmbEqpLevel.Margin = new Padding(6);
            cmbEqpLevel.Name = "cmbEqpLevel";
            cmbEqpLevel.Size = new Size(400, 39);
            cmbEqpLevel.TabIndex = 11;
            // 
            // lblParentEqpId
            // 
            lblParentEqpId.AutoSize = true;
            lblParentEqpId.Location = new Point(24, 387);
            lblParentEqpId.Margin = new Padding(6, 0, 6, 0);
            lblParentEqpId.Name = "lblParentEqpId";
            lblParentEqpId.Size = new Size(110, 31);
            lblParentEqpId.TabIndex = 12;
            lblParentEqpId.Text = "父设备ID";
            // 
            // txtParentEqpId
            // 
            txtParentEqpId.Location = new Point(200, 381);
            txtParentEqpId.Margin = new Padding(6);
            txtParentEqpId.Name = "txtParentEqpId";
            txtParentEqpId.Size = new Size(400, 38);
            txtParentEqpId.TabIndex = 13;
            // 
            // lblEventUser
            // 
            lblEventUser.AutoSize = true;
            lblEventUser.Location = new Point(24, 437);
            lblEventUser.Margin = new Padding(6, 0, 6, 0);
            lblEventUser.Name = "lblEventUser";
            lblEventUser.Size = new Size(110, 31);
            lblEventUser.TabIndex = 14;
            lblEventUser.Text = "操作用户";
            // 
            // txtEventUser
            // 
            txtEventUser.Location = new Point(200, 431);
            txtEventUser.Margin = new Padding(6);
            txtEventUser.Name = "txtEventUser";
            txtEventUser.Size = new Size(400, 38);
            txtEventUser.TabIndex = 15;
            // 
            // lblEventRemark
            // 
            lblEventRemark.AutoSize = true;
            lblEventRemark.Location = new Point(24, 487);
            lblEventRemark.Margin = new Padding(6, 0, 6, 0);
            lblEventRemark.Name = "lblEventRemark";
            lblEventRemark.Size = new Size(110, 31);
            lblEventRemark.TabIndex = 16;
            lblEventRemark.Text = "操作备注";
            // 
            // txtEventRemark
            // 
            txtEventRemark.Location = new Point(200, 481);
            txtEventRemark.Margin = new Padding(6);
            txtEventRemark.Multiline = true;
            txtEventRemark.Name = "txtEventRemark";
            txtEventRemark.Size = new Size(400, 100);
            txtEventRemark.TabIndex = 17;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(200, 593);
            btnSave.Margin = new Padding(6);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 48);
            btnSave.TabIndex = 18;
            btnSave.Text = "保存";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(450, 593);
            btnCancel.Margin = new Padding(6);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 48);
            btnCancel.TabIndex = 19;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // FrmEqpEdit
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 661);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtEventRemark);
            Controls.Add(lblEventRemark);
            Controls.Add(txtEventUser);
            Controls.Add(lblEventUser);
            Controls.Add(txtParentEqpId);
            Controls.Add(lblParentEqpId);
            Controls.Add(cmbEqpLevel);
            Controls.Add(lblEqpLevel);
            Controls.Add(cmbEqpGroup);
            Controls.Add(lblEqpGroup);
            Controls.Add(txtEqpDescription);
            Controls.Add(lblEqpDescription);
            Controls.Add(txtEqpDetailType);
            Controls.Add(lblEqpDetailType);
            Controls.Add(cmbEqpType);
            Controls.Add(lblEqpType);
            Controls.Add(txtEqpId);
            Controls.Add(lblEqpId);
            Margin = new Padding(6);
            Name = "FrmEqpEdit";
            StartPosition = FormStartPosition.CenterParent;
            Text = "设备编辑";
            Load += FrmEqpEdit_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEqpId;
        private TextBox txtEqpId;
        private Label lblEqpType;
        private ComboBox cmbEqpType;
        private Label lblEqpDetailType;
        private TextBox txtEqpDetailType;
        private Label lblEqpDescription;
        private TextBox txtEqpDescription;
        private Label lblEqpGroup;
        private ComboBox cmbEqpGroup;
        private Label lblEqpLevel;
        private ComboBox cmbEqpLevel;
        private Label lblParentEqpId;
        private TextBox txtParentEqpId;
        private Label lblEventUser;
        private TextBox txtEventUser;
        private Label lblEventRemark;
        private TextBox txtEventRemark;
        private Button btnSave;
        private Button btnCancel;
    }
}
