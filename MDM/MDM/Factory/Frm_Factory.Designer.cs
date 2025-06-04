namespace MDM.UI.Factory
{
    partial class Frm_Factory
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
            listView1 = new ListView();
            FactoryProfileTitle = new Label();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Location = new Point(53, 80);
            listView1.Name = "listView1";
            listView1.Size = new Size(769, 631);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // FactoryProfileTitle
            // 
            FactoryProfileTitle.AutoSize = true;
            FactoryProfileTitle.Font = new Font("宋体", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            FactoryProfileTitle.Location = new Point(53, 27);
            FactoryProfileTitle.Margin = new Padding(6, 0, 6, 0);
            FactoryProfileTitle.Name = "FactoryProfileTitle";
            FactoryProfileTitle.Size = new Size(173, 38);
            FactoryProfileTitle.TabIndex = 1;
            FactoryProfileTitle.Text = "工厂信息";
            // 
            // Frm_Factory
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1356, 821);
            Controls.Add(FactoryProfileTitle);
            Controls.Add(listView1);
            Name = "Frm_Factory";
            Text = "Frm_Factory";
            Load += Frm_Factory_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private Label FactoryProfileTitle;
    }
}