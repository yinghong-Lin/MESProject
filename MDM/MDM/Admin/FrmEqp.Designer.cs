namespace MDM.UI.Admin
{
    partial class FrmEqp
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
            lblEqpType = new Label();
            comboBoxEqpType = new ComboBox();
            lblEqpGroup = new Label();
            comboBoxEqpGroup = new ComboBox();
            btnSearch = new Button();
            dataGridViewEqp = new DataGridView();
            lblEqp = new Label();
            btnAddEqp = new Button();
            btnEditEqp = new Button();
            btnDeleteEqp = new Button();
            lblSubEqp = new Label();
            dataGridViewSubEqp = new DataGridView();
            btnAddSubEqp = new Button();
            btnEditSubEqp = new Button();
            btnDeleteSubEqp = new Button();
            lblPort = new Label();
            dataGridViewPort = new DataGridView();
            btnAddPort = new Button();
            btnEditPort = new Button();
            btnDeletePort = new Button();
            btnRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEqp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSubEqp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPort).BeginInit();
            SuspendLayout();
            // 
            // lblEqpType
            // 
            lblEqpType.AutoSize = true;
            lblEqpType.Location = new Point(24, 31);
            lblEqpType.Margin = new Padding(6, 0, 6, 0);
            lblEqpType.Name = "lblEqpType";
            lblEqpType.Size = new Size(110, 31);
            lblEqpType.TabIndex = 0;
            lblEqpType.Text = "设备类型";
            // 
            // comboBoxEqpType
            // 
            comboBoxEqpType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEqpType.FormattingEnabled = true;
            comboBoxEqpType.Location = new Point(148, 25);
            comboBoxEqpType.Margin = new Padding(6);
            comboBoxEqpType.Name = "comboBoxEqpType";
            comboBoxEqpType.Size = new Size(296, 39);
            comboBoxEqpType.TabIndex = 1;
            // 
            // lblEqpGroup
            // 
            lblEqpGroup.AutoSize = true;
            lblEqpGroup.Location = new Point(480, 31);
            lblEqpGroup.Margin = new Padding(6, 0, 6, 0);
            lblEqpGroup.Name = "lblEqpGroup";
            lblEqpGroup.Size = new Size(86, 31);
            lblEqpGroup.TabIndex = 2;
            lblEqpGroup.Text = "设备组";
            // 
            // comboBoxEqpGroup
            // 
            comboBoxEqpGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEqpGroup.FormattingEnabled = true;
            comboBoxEqpGroup.Location = new Point(580, 25);
            comboBoxEqpGroup.Margin = new Padding(6);
            comboBoxEqpGroup.Name = "comboBoxEqpGroup";
            comboBoxEqpGroup.Size = new Size(296, 39);
            comboBoxEqpGroup.TabIndex = 3;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(920, 25);
            btnSearch.Margin = new Padding(6);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(150, 48);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "搜索";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dataGridViewEqp
            // 
            dataGridViewEqp.AllowUserToAddRows = false;
            dataGridViewEqp.AllowUserToDeleteRows = false;
            dataGridViewEqp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEqp.Location = new Point(24, 145);
            dataGridViewEqp.Margin = new Padding(6);
            dataGridViewEqp.Name = "dataGridViewEqp";
            dataGridViewEqp.ReadOnly = true;
            dataGridViewEqp.RowHeadersWidth = 82;
            dataGridViewEqp.RowTemplate.Height = 25;
            dataGridViewEqp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewEqp.Size = new Size(1462, 403);
            dataGridViewEqp.TabIndex = 5;
            dataGridViewEqp.SelectionChanged += dataGridViewEqp_SelectionChanged;
            // 
            // lblEqp
            // 
            lblEqp.AutoSize = true;
            lblEqp.Location = new Point(24, 107);
            lblEqp.Margin = new Padding(6, 0, 6, 0);
            lblEqp.Name = "lblEqp";
            lblEqp.Size = new Size(62, 31);
            lblEqp.TabIndex = 6;
            lblEqp.Text = "设备";
            // 
            // btnAddEqp
            // 
            btnAddEqp.Location = new Point(939, 90);
            btnAddEqp.Margin = new Padding(6);
            btnAddEqp.Name = "btnAddEqp";
            btnAddEqp.Size = new Size(100, 48);
            btnAddEqp.TabIndex = 7;
            btnAddEqp.Text = "+";
            btnAddEqp.UseVisualStyleBackColor = true;
            btnAddEqp.Click += btnAddEqp_Click;
            // 
            // btnEditEqp
            // 
            btnEditEqp.Location = new Point(1051, 90);
            btnEditEqp.Margin = new Padding(6);
            btnEditEqp.Name = "btnEditEqp";
            btnEditEqp.Size = new Size(100, 48);
            btnEditEqp.TabIndex = 8;
            btnEditEqp.Text = "✎";
            btnEditEqp.UseVisualStyleBackColor = true;
            btnEditEqp.Click += btnEditEqp_Click;
            // 
            // btnDeleteEqp
            // 
            btnDeleteEqp.Location = new Point(1163, 90);
            btnDeleteEqp.Margin = new Padding(6);
            btnDeleteEqp.Name = "btnDeleteEqp";
            btnDeleteEqp.Size = new Size(100, 48);
            btnDeleteEqp.TabIndex = 9;
            btnDeleteEqp.Text = "✕";
            btnDeleteEqp.UseVisualStyleBackColor = true;
            btnDeleteEqp.Click += btnDeleteEqp_Click;
            // 
            // lblSubEqp
            // 
            lblSubEqp.AutoSize = true;
            lblSubEqp.Location = new Point(24, 583);
            lblSubEqp.Margin = new Padding(6, 0, 6, 0);
            lblSubEqp.Name = "lblSubEqp";
            lblSubEqp.Size = new Size(86, 31);
            lblSubEqp.TabIndex = 10;
            lblSubEqp.Text = "子设备";
            // 
            // dataGridViewSubEqp
            // 
            dataGridViewSubEqp.AllowUserToAddRows = false;
            dataGridViewSubEqp.AllowUserToDeleteRows = false;
            dataGridViewSubEqp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSubEqp.Location = new Point(24, 630);
            dataGridViewSubEqp.Margin = new Padding(6);
            dataGridViewSubEqp.Name = "dataGridViewSubEqp";
            dataGridViewSubEqp.ReadOnly = true;
            dataGridViewSubEqp.RowHeadersWidth = 82;
            dataGridViewSubEqp.RowTemplate.Height = 25;
            dataGridViewSubEqp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSubEqp.Size = new Size(973, 300);
            dataGridViewSubEqp.TabIndex = 11;
            // 
            // btnAddSubEqp
            // 
            btnAddSubEqp.Location = new Point(625, 570);
            btnAddSubEqp.Margin = new Padding(6);
            btnAddSubEqp.Name = "btnAddSubEqp";
            btnAddSubEqp.Size = new Size(100, 48);
            btnAddSubEqp.TabIndex = 12;
            btnAddSubEqp.Text = "+";
            btnAddSubEqp.UseVisualStyleBackColor = true;
            btnAddSubEqp.Click += btnAddSubEqp_Click;
            // 
            // btnEditSubEqp
            // 
            btnEditSubEqp.Location = new Point(737, 570);
            btnEditSubEqp.Margin = new Padding(6);
            btnEditSubEqp.Name = "btnEditSubEqp";
            btnEditSubEqp.Size = new Size(100, 48);
            btnEditSubEqp.TabIndex = 13;
            btnEditSubEqp.Text = "✎";
            btnEditSubEqp.UseVisualStyleBackColor = true;
            btnEditSubEqp.Click += btnEditSubEqp_Click;
            // 
            // btnDeleteSubEqp
            // 
            btnDeleteSubEqp.Location = new Point(849, 570);
            btnDeleteSubEqp.Margin = new Padding(6);
            btnDeleteSubEqp.Name = "btnDeleteSubEqp";
            btnDeleteSubEqp.Size = new Size(100, 48);
            btnDeleteSubEqp.TabIndex = 14;
            btnDeleteSubEqp.Text = "✕";
            btnDeleteSubEqp.UseVisualStyleBackColor = true;
            btnDeleteSubEqp.Click += btnDeleteSubEqp_Click;
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Location = new Point(1009, 583);
            lblPort.Margin = new Padding(6, 0, 6, 0);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(62, 31);
            lblPort.TabIndex = 15;
            lblPort.Text = "端口";
            // 
            // dataGridViewPort
            // 
            dataGridViewPort.AllowUserToAddRows = false;
            dataGridViewPort.AllowUserToDeleteRows = false;
            dataGridViewPort.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPort.Location = new Point(1009, 630);
            dataGridViewPort.Margin = new Padding(6);
            dataGridViewPort.Name = "dataGridViewPort";
            dataGridViewPort.ReadOnly = true;
            dataGridViewPort.RowHeadersWidth = 82;
            dataGridViewPort.RowTemplate.Height = 25;
            dataGridViewPort.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPort.Size = new Size(1034, 300);
            dataGridViewPort.TabIndex = 16;
            // 
            // btnAddPort
            // 
            btnAddPort.Location = new Point(1480, 570);
            btnAddPort.Margin = new Padding(6);
            btnAddPort.Name = "btnAddPort";
            btnAddPort.Size = new Size(100, 48);
            btnAddPort.TabIndex = 17;
            btnAddPort.Text = "+";
            btnAddPort.UseVisualStyleBackColor = true;
            btnAddPort.Click += btnAddPort_Click;
            // 
            // btnEditPort
            // 
            btnEditPort.Location = new Point(1592, 570);
            btnEditPort.Margin = new Padding(6);
            btnEditPort.Name = "btnEditPort";
            btnEditPort.Size = new Size(100, 48);
            btnEditPort.TabIndex = 18;
            btnEditPort.Text = "✎";
            btnEditPort.UseVisualStyleBackColor = true;
            btnEditPort.Click += btnEditPort_Click;
            // 
            // btnDeletePort
            // 
            btnDeletePort.Location = new Point(1704, 570);
            btnDeletePort.Margin = new Padding(6);
            btnDeletePort.Name = "btnDeletePort";
            btnDeletePort.Size = new Size(100, 48);
            btnDeletePort.TabIndex = 19;
            btnDeletePort.Text = "✕";
            btnDeletePort.UseVisualStyleBackColor = true;
            btnDeletePort.Click += btnDeletePort_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(1100, 25);
            btnRefresh.Margin = new Padding(6);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(150, 48);
            btnRefresh.TabIndex = 20;
            btnRefresh.Text = "刷新";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // FrmEqp
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2058, 1018);
            Controls.Add(btnRefresh);
            Controls.Add(btnDeletePort);
            Controls.Add(btnEditPort);
            Controls.Add(btnAddPort);
            Controls.Add(dataGridViewPort);
            Controls.Add(lblPort);
            Controls.Add(btnDeleteSubEqp);
            Controls.Add(btnEditSubEqp);
            Controls.Add(btnAddSubEqp);
            Controls.Add(dataGridViewSubEqp);
            Controls.Add(lblSubEqp);
            Controls.Add(btnDeleteEqp);
            Controls.Add(btnEditEqp);
            Controls.Add(btnAddEqp);
            Controls.Add(lblEqp);
            Controls.Add(dataGridViewEqp);
            Controls.Add(btnSearch);
            Controls.Add(comboBoxEqpGroup);
            Controls.Add(lblEqpGroup);
            Controls.Add(comboBoxEqpType);
            Controls.Add(lblEqpType);
            Margin = new Padding(6);
            Name = "FrmEqp";
            Text = "设备管理";
            Load += FrmEqp_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewEqp).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSubEqp).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPort).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEqpType;
        private ComboBox comboBoxEqpType;
        private Label lblEqpGroup;
        private ComboBox comboBoxEqpGroup;
        private Button btnSearch;
        private DataGridView dataGridViewEqp;
        private Label lblEqp;
        private Button btnAddEqp;
        private Button btnEditEqp;
        private Button btnDeleteEqp;
        private Label lblSubEqp;
        private DataGridView dataGridViewSubEqp;
        private Button btnAddSubEqp;
        private Button btnEditSubEqp;
        private Button btnDeleteSubEqp;
        private Label lblPort;
        private DataGridView dataGridViewPort;
        private Button btnAddPort;
        private Button btnEditPort;
        private Button btnDeletePort;
        private Button btnRefresh;
    }
}
