namespace MDM.UI.Admin
{
    partial class Frm_User
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
            dataGridView1 = new DataGridView();
            SearchTextBox = new TextBox();
            SearchButton = new Button();
            panelUserInfo = new Panel();
            UserPassword = new TextBox();
            label16 = new Label();
            btnClearSelection = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            EventRemark = new TextBox();
            EventUser = new TextBox();
            DisplayLanguage = new TextBox();
            UserEnglishName = new TextBox();
            UserName = new TextBox();
            UserType = new TextBox();
            UserID = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panelAddUser = new Panel();
            EventRemarkTextBox = new TextBox();
            EventUserTextBox = new TextBox();
            DisplayLanguageTextBox = new TextBox();
            UserEnglishNameTextBox = new TextBox();
            UserPasswordTextBox = new TextBox();
            UserNameTextBox = new TextBox();
            UserTypeTextBox = new TextBox();
            UserIDTextBox = new TextBox();
            Cancelbutton1 = new Button();
            Confirmbutton1 = new Button();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            btnToggleView = new Button();
            label17 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panelUserInfo.SuspendLayout();
            panelAddUser.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(24, 85);
            dataGridView1.Margin = new Padding(6);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1100, 820);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // SearchTextBox
            // 
            SearchTextBox.Location = new Point(146, 31);
            SearchTextBox.Margin = new Padding(6);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.Size = new Size(797, 38);
            SearchTextBox.TabIndex = 1;
            // 
            // SearchButton
            // 
            SearchButton.Location = new Point(974, 25);
            SearchButton.Margin = new Padding(6);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(150, 48);
            SearchButton.TabIndex = 2;
            SearchButton.Text = "搜索";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // panelUserInfo
            // 
            panelUserInfo.Controls.Add(UserPassword);
            panelUserInfo.Controls.Add(label16);
            panelUserInfo.Controls.Add(btnClearSelection);
            panelUserInfo.Controls.Add(btnDelete);
            panelUserInfo.Controls.Add(btnUpdate);
            panelUserInfo.Controls.Add(EventRemark);
            panelUserInfo.Controls.Add(EventUser);
            panelUserInfo.Controls.Add(DisplayLanguage);
            panelUserInfo.Controls.Add(UserEnglishName);
            panelUserInfo.Controls.Add(UserName);
            panelUserInfo.Controls.Add(UserType);
            panelUserInfo.Controls.Add(UserID);
            panelUserInfo.Controls.Add(label7);
            panelUserInfo.Controls.Add(label6);
            panelUserInfo.Controls.Add(label5);
            panelUserInfo.Controls.Add(label4);
            panelUserInfo.Controls.Add(label3);
            panelUserInfo.Controls.Add(label2);
            panelUserInfo.Controls.Add(label1);
            panelUserInfo.Location = new Point(1136, 85);
            panelUserInfo.Margin = new Padding(6);
            panelUserInfo.Name = "panelUserInfo";
            panelUserInfo.Size = new Size(440, 820);
            panelUserInfo.TabIndex = 3;
            // 
            // UserPassword
            // 
            UserPassword.Location = new Point(6, 297);
            UserPassword.Margin = new Padding(6);
            UserPassword.Name = "UserPassword";
            UserPassword.PasswordChar = '*';
            UserPassword.Size = new Size(424, 38);
            UserPassword.TabIndex = 18;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(7, 260);
            label16.Margin = new Padding(6, 0, 6, 0);
            label16.Name = "label16";
            label16.Size = new Size(110, 31);
            label16.TabIndex = 17;
            label16.Text = "用户密码";
            // 
            // btnClearSelection
            // 
            btnClearSelection.Location = new Point(6, 761);
            btnClearSelection.Margin = new Padding(6);
            btnClearSelection.Name = "btnClearSelection";
            btnClearSelection.Size = new Size(428, 48);
            btnClearSelection.TabIndex = 16;
            btnClearSelection.Text = "清除选择";
            btnClearSelection.UseVisualStyleBackColor = true;
            btnClearSelection.Click += btnClearSelection_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(215, 701);
            btnDelete.Margin = new Padding(6);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(219, 48);
            btnDelete.TabIndex = 15;
            btnDelete.Text = "删除用户";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(7, 701);
            btnUpdate.Margin = new Padding(6);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(196, 48);
            btnUpdate.TabIndex = 14;
            btnUpdate.Text = "更新用户";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // EventRemark
            // 
            EventRemark.Location = new Point(7, 651);
            EventRemark.Margin = new Padding(6);
            EventRemark.Name = "EventRemark";
            EventRemark.Size = new Size(424, 38);
            EventRemark.TabIndex = 13;
            // 
            // EventUser
            // 
            EventUser.Location = new Point(7, 560);
            EventUser.Margin = new Padding(6);
            EventUser.Name = "EventUser";
            EventUser.ReadOnly = true;
            EventUser.Size = new Size(424, 38);
            EventUser.TabIndex = 12;
            // 
            // DisplayLanguage
            // 
            DisplayLanguage.Location = new Point(7, 469);
            DisplayLanguage.Margin = new Padding(6);
            DisplayLanguage.Name = "DisplayLanguage";
            DisplayLanguage.Size = new Size(424, 38);
            DisplayLanguage.TabIndex = 11;
            // 
            // UserEnglishName
            // 
            UserEnglishName.Location = new Point(7, 378);
            UserEnglishName.Margin = new Padding(6);
            UserEnglishName.Name = "UserEnglishName";
            UserEnglishName.Size = new Size(424, 38);
            UserEnglishName.TabIndex = 10;
            // 
            // UserName
            // 
            UserName.Location = new Point(6, 217);
            UserName.Margin = new Padding(6);
            UserName.Name = "UserName";
            UserName.Size = new Size(424, 38);
            UserName.TabIndex = 9;
            // 
            // UserType
            // 
            UserType.Location = new Point(6, 126);
            UserType.Margin = new Padding(6);
            UserType.Name = "UserType";
            UserType.Size = new Size(424, 38);
            UserType.TabIndex = 8;
            // 
            // UserID
            // 
            UserID.Location = new Point(7, 35);
            UserID.Margin = new Padding(6);
            UserID.Name = "UserID";
            UserID.Size = new Size(424, 38);
            UserID.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(7, 614);
            label7.Margin = new Padding(6, 0, 6, 0);
            label7.Name = "label7";
            label7.Size = new Size(110, 31);
            label7.TabIndex = 6;
            label7.Text = "操作备注";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(7, 523);
            label6.Margin = new Padding(6, 0, 6, 0);
            label6.Name = "label6";
            label6.Size = new Size(110, 31);
            label6.TabIndex = 5;
            label6.Text = "操作用户";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 432);
            label5.Margin = new Padding(6, 0, 6, 0);
            label5.Name = "label5";
            label5.Size = new Size(110, 31);
            label5.TabIndex = 4;
            label5.Text = "显示语言";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 341);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(110, 31);
            label4.TabIndex = 3;
            label4.Text = "英文名称";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 180);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(86, 31);
            label3.TabIndex = 2;
            label3.Text = "用户名";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 89);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(110, 31);
            label2.TabIndex = 1;
            label2.Text = "用户类型";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, -2);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(87, 31);
            label1.TabIndex = 0;
            label1.Text = "用户ID";
            // 
            // panelAddUser
            // 
            panelAddUser.Controls.Add(EventRemarkTextBox);
            panelAddUser.Controls.Add(EventUserTextBox);
            panelAddUser.Controls.Add(DisplayLanguageTextBox);
            panelAddUser.Controls.Add(UserEnglishNameTextBox);
            panelAddUser.Controls.Add(UserPasswordTextBox);
            panelAddUser.Controls.Add(UserNameTextBox);
            panelAddUser.Controls.Add(UserTypeTextBox);
            panelAddUser.Controls.Add(UserIDTextBox);
            panelAddUser.Controls.Add(Cancelbutton1);
            panelAddUser.Controls.Add(Confirmbutton1);
            panelAddUser.Controls.Add(label15);
            panelAddUser.Controls.Add(label14);
            panelAddUser.Controls.Add(label13);
            panelAddUser.Controls.Add(label12);
            panelAddUser.Controls.Add(label11);
            panelAddUser.Controls.Add(label10);
            panelAddUser.Controls.Add(label9);
            panelAddUser.Controls.Add(label8);
            panelAddUser.Location = new Point(1136, 85);
            panelAddUser.Margin = new Padding(6);
            panelAddUser.Name = "panelAddUser";
            panelAddUser.Size = new Size(440, 820);
            panelAddUser.TabIndex = 4;
            panelAddUser.Visible = false;
            // 
            // EventRemarkTextBox
            // 
            EventRemarkTextBox.Location = new Point(7, 682);
            EventRemarkTextBox.Margin = new Padding(6);
            EventRemarkTextBox.Name = "EventRemarkTextBox";
            EventRemarkTextBox.Size = new Size(424, 38);
            EventRemarkTextBox.TabIndex = 17;
            // 
            // EventUserTextBox
            // 
            EventUserTextBox.Location = new Point(7, 591);
            EventUserTextBox.Margin = new Padding(6);
            EventUserTextBox.Name = "EventUserTextBox";
            EventUserTextBox.ReadOnly = true;
            EventUserTextBox.Size = new Size(424, 38);
            EventUserTextBox.TabIndex = 16;
            // 
            // DisplayLanguageTextBox
            // 
            DisplayLanguageTextBox.Location = new Point(7, 500);
            DisplayLanguageTextBox.Margin = new Padding(6);
            DisplayLanguageTextBox.Name = "DisplayLanguageTextBox";
            DisplayLanguageTextBox.Size = new Size(424, 38);
            DisplayLanguageTextBox.TabIndex = 15;
            // 
            // UserEnglishNameTextBox
            // 
            UserEnglishNameTextBox.Location = new Point(7, 409);
            UserEnglishNameTextBox.Margin = new Padding(6);
            UserEnglishNameTextBox.Name = "UserEnglishNameTextBox";
            UserEnglishNameTextBox.Size = new Size(424, 38);
            UserEnglishNameTextBox.TabIndex = 14;
            // 
            // UserPasswordTextBox
            // 
            UserPasswordTextBox.Location = new Point(7, 318);
            UserPasswordTextBox.Margin = new Padding(6);
            UserPasswordTextBox.Name = "UserPasswordTextBox";
            UserPasswordTextBox.PasswordChar = '*';
            UserPasswordTextBox.Size = new Size(424, 38);
            UserPasswordTextBox.TabIndex = 13;
            // 
            // UserNameTextBox
            // 
            UserNameTextBox.Location = new Point(7, 227);
            UserNameTextBox.Margin = new Padding(6);
            UserNameTextBox.Name = "UserNameTextBox";
            UserNameTextBox.Size = new Size(424, 38);
            UserNameTextBox.TabIndex = 12;
            // 
            // UserTypeTextBox
            // 
            UserTypeTextBox.Location = new Point(6, 137);
            UserTypeTextBox.Margin = new Padding(6);
            UserTypeTextBox.Name = "UserTypeTextBox";
            UserTypeTextBox.Size = new Size(424, 38);
            UserTypeTextBox.TabIndex = 11;
            // 
            // UserIDTextBox
            // 
            UserIDTextBox.Location = new Point(6, 35);
            UserIDTextBox.Margin = new Padding(6);
            UserIDTextBox.Name = "UserIDTextBox";
            UserIDTextBox.Size = new Size(424, 38);
            UserIDTextBox.TabIndex = 10;
            // 
            // Cancelbutton1
            // 
            Cancelbutton1.Location = new Point(229, 742);
            Cancelbutton1.Margin = new Padding(6);
            Cancelbutton1.Name = "Cancelbutton1";
            Cancelbutton1.Size = new Size(206, 62);
            Cancelbutton1.TabIndex = 9;
            Cancelbutton1.Text = "取消";
            Cancelbutton1.UseVisualStyleBackColor = true;
            Cancelbutton1.Click += Cancelbutton1_Click;
            // 
            // Confirmbutton1
            // 
            Confirmbutton1.Location = new Point(7, 742);
            Confirmbutton1.Margin = new Padding(6);
            Confirmbutton1.Name = "Confirmbutton1";
            Confirmbutton1.Size = new Size(206, 62);
            Confirmbutton1.TabIndex = 8;
            Confirmbutton1.Text = "确认";
            Confirmbutton1.UseVisualStyleBackColor = true;
            Confirmbutton1.Click += Confirmbutton1_Click;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(7, 645);
            label15.Margin = new Padding(6, 0, 6, 0);
            label15.Name = "label15";
            label15.Size = new Size(110, 31);
            label15.TabIndex = 7;
            label15.Text = "操作备注";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(7, 554);
            label14.Margin = new Padding(6, 0, 6, 0);
            label14.Name = "label14";
            label14.Size = new Size(110, 31);
            label14.TabIndex = 6;
            label14.Text = "操作用户";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(7, 463);
            label13.Margin = new Padding(6, 0, 6, 0);
            label13.Name = "label13";
            label13.Size = new Size(110, 31);
            label13.TabIndex = 5;
            label13.Text = "显示语言";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(7, 372);
            label12.Margin = new Padding(6, 0, 6, 0);
            label12.Name = "label12";
            label12.Size = new Size(110, 31);
            label12.TabIndex = 4;
            label12.Text = "英文名称";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(7, 281);
            label11.Margin = new Padding(6, 0, 6, 0);
            label11.Name = "label11";
            label11.Size = new Size(62, 31);
            label11.TabIndex = 3;
            label11.Text = "密码";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(7, 190);
            label10.Margin = new Padding(6, 0, 6, 0);
            label10.Name = "label10";
            label10.Size = new Size(86, 31);
            label10.TabIndex = 2;
            label10.Text = "用户名";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 100);
            label9.Margin = new Padding(6, 0, 6, 0);
            label9.Name = "label9";
            label9.Size = new Size(110, 31);
            label9.TabIndex = 1;
            label9.Text = "用户类型";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, -2);
            label8.Margin = new Padding(6, 0, 6, 0);
            label8.Name = "label8";
            label8.Size = new Size(87, 31);
            label8.TabIndex = 0;
            label8.Text = "用户ID";
            // 
            // btnToggleView
            // 
            btnToggleView.Location = new Point(1136, 25);
            btnToggleView.Margin = new Padding(6);
            btnToggleView.Name = "btnToggleView";
            btnToggleView.Size = new Size(440, 48);
            btnToggleView.TabIndex = 5;
            btnToggleView.Text = "切换到添加用户";
            btnToggleView.UseVisualStyleBackColor = true;
            btnToggleView.Click += btnToggleView_Click_1;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(24, 34);
            label17.Margin = new Padding(6, 0, 6, 0);
            label17.Name = "label17";
            label17.Size = new Size(87, 31);
            label17.TabIndex = 19;
            label17.Text = "用户ID";
            // 
            // Frm_User
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1600, 930);
            Controls.Add(label17);
            Controls.Add(btnToggleView);
            Controls.Add(SearchButton);
            Controls.Add(SearchTextBox);
            Controls.Add(dataGridView1);
            Controls.Add(panelUserInfo);
            Controls.Add(panelAddUser);
            Margin = new Padding(6);
            Name = "Frm_User";
            Text = "用户管理";
            Load += Frm_User_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panelUserInfo.ResumeLayout(false);
            panelUserInfo.PerformLayout();
            panelAddUser.ResumeLayout(false);
            panelAddUser.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox SearchTextBox;
        private Button SearchButton;
        private Panel panelUserInfo;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Panel panelAddUser;
        private Button Cancelbutton1;
        private Button Confirmbutton1;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Button btnToggleView;
        private TextBox EventRemark;
        private TextBox EventUser;
        private TextBox DisplayLanguage;
        private TextBox UserEnglishName;
        private TextBox UserName;
        private TextBox UserType;
        private TextBox UserID;
        private TextBox EventRemarkTextBox;
        private TextBox EventUserTextBox;
        private TextBox DisplayLanguageTextBox;
        private TextBox UserEnglishNameTextBox;
        private TextBox UserPasswordTextBox;
        private TextBox UserNameTextBox;
        private TextBox UserTypeTextBox;
        private TextBox UserIDTextBox;
        private Button btnClearSelection;
        private Button btnDelete;
        private Button btnUpdate;
        private TextBox UserPassword;
        private Label label16;
        private Label label17;
    }
}
