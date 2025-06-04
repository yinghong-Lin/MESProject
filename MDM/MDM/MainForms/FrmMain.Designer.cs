namespace MDM.UI.MainForms
{
    partial class FrmMain
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
            menuStrip1 = new MenuStrip();
            tabControl1 = new TabControl();
            BtnLogout = new Button();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.Control;
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(12, 4, 0, 4);
            menuStrip1.Size = new Size(2110, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // tabControl1
            // 
            tabControl1.HotTrack = true;
            tabControl1.Location = new Point(0, 145);
            tabControl1.Margin = new Padding(6, 5, 6, 5);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(2110, 1000);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabIndex = 1;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // BtnLogout
            // 
            BtnLogout.Location = new Point(1546, 47);
            BtnLogout.Name = "BtnLogout";
            BtnLogout.Size = new Size(185, 57);
            BtnLogout.TabIndex = 2;
            BtnLogout.Text = "登出";
            BtnLogout.UseVisualStyleBackColor = true;
            BtnLogout.Click += BtnLogout_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(2110, 1135);
            Controls.Add(BtnLogout);
            Controls.Add(tabControl1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(6, 5, 6, 5);
            Name = "FrmMain";
            Text = "FrmMain";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private TabControl tabControl1;
        private Button BtnLogout;
    }
}