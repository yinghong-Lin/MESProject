using Org.BouncyCastle.Asn1.Crmf;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Printing;
using System.Xml.Linq;

namespace MDM.UI.Process
{
    partial class FrmProcessRoute
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
            lblProductGroup = new Label();
            comboBoxProductGroup = new ComboBox();
            lblProduct = new Label();
            comboBoxProduct = new ComboBox();
            btnSearch = new Button();
            btnRefresh = new Button();
            lblPrp = new Label();
            dataGridViewPrp = new DataGridView();
            lblFlow = new Label();
            dataGridViewFlow = new DataGridView();
            lblOper = new Label();
            dataGridViewOper = new DataGridView();
            btnEditRoute = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPrp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFlow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOper).BeginInit();
            SuspendLayout();
            // 
            // lblProductGroup
            // 
            lblProductGroup.AutoSize = true;
            lblProductGroup.Location = new Point(24, 31);
            lblProductGroup.Margin = new Padding(6, 0, 6, 0);
            lblProductGroup.Name = "lblProductGroup";
            lblProductGroup.Size = new Size(86, 31);
            lblProductGroup.TabIndex = 0;
            lblProductGroup.Text = "产品组";
            // 
            // comboBoxProductGroup
            // 
            comboBoxProductGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProductGroup.FormattingEnabled = true;
            comboBoxProductGroup.Location = new Point(124, 25);
            comboBoxProductGroup.Margin = new Padding(6);
            comboBoxProductGroup.Name = "comboBoxProductGroup";
            comboBoxProductGroup.Size = new Size(296, 39);
            comboBoxProductGroup.TabIndex = 1;
            // 
            // lblProduct
            // 
            lblProduct.AutoSize = true;
            lblProduct.Location = new Point(456, 31);
            lblProduct.Margin = new Padding(6, 0, 6, 0);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(62, 31);
            lblProduct.TabIndex = 2;
            lblProduct.Text = "产品";
            // 
            // comboBoxProduct
            // 
            comboBoxProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProduct.FormattingEnabled = true;
            comboBoxProduct.Location = new Point(532, 25);
            comboBoxProduct.Margin = new Padding(6);
            comboBoxProduct.Name = "comboBoxProduct";
            comboBoxProduct.Size = new Size(296, 39);
            comboBoxProduct.TabIndex = 3;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(872, 25);
            btnSearch.Margin = new Padding(6);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(150, 48);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "搜索";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(1052, 25);
            btnRefresh.Margin = new Padding(6);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(150, 48);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "刷新";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblPrp
            // 
            lblPrp.AutoSize = true;
            lblPrp.Location = new Point(1325, 106);
            lblPrp.Margin = new Padding(6, 0, 6, 0);
            lblPrp.Name = "lblPrp";
            lblPrp.Size = new Size(86, 31);
            lblPrp.TabIndex = 6;
            lblPrp.Text = "工艺包";
            lblPrp.Visible = false;
            // 
            // dataGridViewPrp
            // 
            dataGridViewPrp.AllowUserToAddRows = false;
            dataGridViewPrp.AllowUserToDeleteRows = false;
            dataGridViewPrp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPrp.Location = new Point(1325, 144);
            dataGridViewPrp.Margin = new Padding(6);
            dataGridViewPrp.Name = "dataGridViewPrp";
            dataGridViewPrp.ReadOnly = true;
            dataGridViewPrp.RowHeadersWidth = 82;
            dataGridViewPrp.RowTemplate.Height = 25;
            dataGridViewPrp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPrp.Size = new Size(590, 798);
            dataGridViewPrp.TabIndex = 7;
            dataGridViewPrp.Visible = false;
            dataGridViewPrp.SelectionChanged += dataGridViewPrp_SelectionChanged;
            // 
            // lblFlow
            // 
            lblFlow.AutoSize = true;
            lblFlow.Location = new Point(33, 93);
            lblFlow.Margin = new Padding(6, 0, 6, 0);
            lblFlow.Name = "lblFlow";
            lblFlow.Size = new Size(110, 31);
            lblFlow.TabIndex = 8;
            lblFlow.Text = "工艺流程";
            // 
            // dataGridViewFlow
            // 
            dataGridViewFlow.AllowUserToAddRows = false;
            dataGridViewFlow.AllowUserToDeleteRows = false;
            dataGridViewFlow.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewFlow.Location = new Point(33, 143);
            dataGridViewFlow.Margin = new Padding(6);
            dataGridViewFlow.Name = "dataGridViewFlow";
            dataGridViewFlow.ReadOnly = true;
            dataGridViewFlow.RowHeadersWidth = 82;
            dataGridViewFlow.RowTemplate.Height = 25;
            dataGridViewFlow.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewFlow.Size = new Size(603, 812);
            dataGridViewFlow.TabIndex = 9;
            dataGridViewFlow.SelectionChanged += dataGridViewFlow_SelectionChanged;
            // 
            // lblOper
            // 
            lblOper.AutoSize = true;
            lblOper.Location = new Point(669, 106);
            lblOper.Margin = new Padding(6, 0, 6, 0);
            lblOper.Name = "lblOper";
            lblOper.Size = new Size(110, 31);
            lblOper.TabIndex = 10;
            lblOper.Text = "工艺路线";
            // 
            // dataGridViewOper
            // 
            dataGridViewOper.AllowUserToAddRows = false;
            dataGridViewOper.AllowUserToDeleteRows = false;
            dataGridViewOper.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewOper.Location = new Point(669, 143);
            dataGridViewOper.Margin = new Padding(6);
            dataGridViewOper.Name = "dataGridViewOper";
            dataGridViewOper.ReadOnly = true;
            dataGridViewOper.RowHeadersWidth = 82;
            dataGridViewOper.RowTemplate.Height = 25;
            dataGridViewOper.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewOper.Size = new Size(603, 812);
            dataGridViewOper.TabIndex = 11;
            // 
            // btnEditRoute
            // 
            btnEditRoute.BackColor = Color.LightGreen;
            btnEditRoute.Font = new System.Drawing.Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point, 134);
            btnEditRoute.Location = new Point(1353, 25);
            btnEditRoute.Margin = new Padding(7, 8, 7, 8);
            btnEditRoute.Name = "btnEditRoute";
            btnEditRoute.Size = new Size(58, 65);
            btnEditRoute.TabIndex = 12;
            btnEditRoute.Text = "+";
            btnEditRoute.UseVisualStyleBackColor = false;
            btnEditRoute.Click += btnEditRoute_Click_1;
            // 
            // FrmProcess
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1960, 1018);
            Controls.Add(btnEditRoute);
            Controls.Add(dataGridViewOper);
            Controls.Add(lblOper);
            Controls.Add(dataGridViewFlow);
            Controls.Add(lblFlow);
            Controls.Add(dataGridViewPrp);
            Controls.Add(lblPrp);
            Controls.Add(btnRefresh);
            Controls.Add(btnSearch);
            Controls.Add(comboBoxProduct);
            Controls.Add(lblProduct);
            Controls.Add(comboBoxProductGroup);
            Controls.Add(lblProductGroup);
            Margin = new Padding(6);
            Name = "FrmProcess";
            Text = "工艺路线";
            Load += FrmProcess_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewPrp).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFlow).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOper).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblProductGroup;
        private ComboBox comboBoxProductGroup;
        private Label lblProduct;
        private ComboBox comboBoxProduct;
        private Button btnSearch;
        private Button btnRefresh;
        private Label lblPrp;
        private DataGridView dataGridViewPrp;
        private Label lblFlow;
        private DataGridView dataGridViewFlow;
        private Label lblOper;
        private DataGridView dataGridViewOper;
        private Button btnEditRoute;
    }
}
