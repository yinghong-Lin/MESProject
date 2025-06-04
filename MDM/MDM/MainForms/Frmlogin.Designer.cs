namespace MDM.UI.MainForms
{
    partial class Frmlogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmlogin));
            username = new TextBox();
            password = new TextBox();
            loginbutton = new Button();
            CancelButton = new Button();
            pictureBox1 = new PictureBox();
            FactorySelection = new ComboBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // username
            // 
            username.Font = new Font("Microsoft YaHei UI", 12F);
            username.Location = new Point(734, 252);
            username.Margin = new Padding(6, 5, 6, 5);
            username.Name = "username";
            username.PlaceholderText = "用户名";
            username.Size = new Size(362, 48);
            username.TabIndex = 1;
            username.TextChanged += username_TextChanged;
            // 
            // password
            // 
            password.Font = new Font("Microsoft YaHei UI", 12F);
            password.Location = new Point(734, 321);
            password.Margin = new Padding(6, 5, 6, 5);
            password.Name = "password";
            password.PlaceholderText = "密码";
            password.Size = new Size(362, 48);
            password.TabIndex = 2;
            password.UseSystemPasswordChar = true;
            password.TextChanged += password_TextChanged;
            // 
            // loginbutton
            // 
            loginbutton.Font = new Font("Microsoft YaHei UI", 12F);
            loginbutton.Location = new Point(940, 416);
            loginbutton.Margin = new Padding(6, 5, 6, 5);
            loginbutton.Name = "loginbutton";
            loginbutton.Size = new Size(160, 62);
            loginbutton.TabIndex = 4;
            loginbutton.Text = "登录";
            loginbutton.UseVisualStyleBackColor = true;
            loginbutton.Click += loginbutton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Font = new Font("Microsoft YaHei UI", 12F);
            CancelButton.Location = new Point(734, 416);
            CancelButton.Margin = new Padding(6, 5, 6, 5);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(160, 62);
            CancelButton.TabIndex = 3;
            CancelButton.Text = "取消";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Enabled = false;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(125, 109);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(491, 379);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // FactorySelection
            // 
            FactorySelection.Font = new Font("Microsoft YaHei UI", 12F);
            FactorySelection.FormattingEnabled = true;
            FactorySelection.Location = new Point(734, 173);
            FactorySelection.Margin = new Padding(6, 5, 6, 5);
            FactorySelection.Name = "FactorySelection";
            FactorySelection.Size = new Size(362, 49);
            FactorySelection.TabIndex = 0;
            FactorySelection.SelectedIndexChanged += FactorySelection_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("黑体", 25.875F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label1.Location = new Point(802, 67);
            label1.Name = "label1";
            label1.Size = new Size(210, 69);
            label1.TabIndex = 8;
            label1.Text = "Login";
            // 
            // Frmlogin
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1206, 677);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(CancelButton);
            Controls.Add(FactorySelection);
            Controls.Add(loginbutton);
            Controls.Add(password);
            Controls.Add(username);
            Margin = new Padding(6, 5, 6, 5);
            MaximizeBox = false;
            Name = "Frmlogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "登录";
            Load += Frmlogin_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox username;
        private TextBox password;
        private Button loginbutton;
        private Button CancelButton;
        private PictureBox pictureBox1;
        private ComboBox FactorySelection;
        private Label label1;
    }
}