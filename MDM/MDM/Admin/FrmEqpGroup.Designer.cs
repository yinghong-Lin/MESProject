namespace MDM.UI.Admin
{
    partial class FrmEqpGroup
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
            panelGroupInfo = new Panel();
            EventType = new TextBox(); // 添加事件类型文本框
            label10 = new Label(); // 添加事件类型标签
            btnClearSelection = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            FactoryId = new TextBox();
            GroupDescription = new TextBox();
            GroupType = new TextBox();
            GroupId = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panelAddGroup = new Panel();
            EventTypeTextBox = new TextBox(); // 添加事件类型文本框
            label11 = new Label(); // 添加事件类型标签
            FactoryIdTextBox = new TextBox();
            GroupDescriptionTextBox = new TextBox();
            GroupTypeTextBox = new TextBox();
            GroupIdTextBox = new TextBox();
            Cancelbutton1 = new Button();
            Confirmbutton1 = new Button();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            btnToggleView = new Button();
            searchTypeComboBox = new ComboBox();
            label9 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panelGroupInfo.SuspendLayout();
            panelAddGroup.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(24, 85);
            dataGridView1.Margin = new Padding(6);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1100, 820);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            // 
            // SearchTextBox
            // 
            SearchTextBox.Location = new Point(304, 25);
            SearchTextBox.Margin = new Padding(6);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.Size = new Size(654, 38);
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
            // panelGroupInfo
            // 
            panelGroupInfo.Controls.Add(EventType); // 添加事件类型文本框
            panelGroupInfo.Controls.Add(label10); // 添加事件类型标签
            panelGroupInfo.Controls.Add(btnClearSelection);
            panelGroupInfo.Controls.Add(btnDelete);
            panelGroupInfo.Controls.Add(btnUpdate);
            panelGroupInfo.Controls.Add(FactoryId);
            panelGroupInfo.Controls.Add(GroupDescription);
            panelGroupInfo.Controls.Add(GroupType);
            panelGroupInfo.Controls.Add(GroupId);
            panelGroupInfo.Controls.Add(label4);
            panelGroupInfo.Controls.Add(label3);
            panelGroupInfo.Controls.Add(label2);
            panelGroupInfo.Controls.Add(label1);
            panelGroupInfo.Location = new Point(1136, 85);
            panelGroupInfo.Margin = new Padding(6);
            panelGroupInfo.Name = "panelGroupInfo";
            panelGroupInfo.Size = new Size(440, 820);
            panelGroupInfo.TabIndex = 3;
            panelGroupInfo.Paint += panelGroupInfo_Paint;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 362);
            label10.Margin = new Padding(6, 0, 6, 0);
            label10.Name = "label10";
            label10.Size = new Size(111, 31);
            label10.TabIndex = 11;
            label10.Text = "事件类型";
            // 
            // EventType
            // 
            EventType.Location = new Point(6, 399);
            EventType.Margin = new Padding(6);
            EventType.Name = "EventType";
            EventType.Size = new Size(424, 38);
            EventType.TabIndex = 12;
            // 
            // btnClearSelection
            // 
            btnClearSelection.Location = new Point(6, 761);
            btnClearSelection.Margin = new Padding(6);
            btnClearSelection.Name = "btnClearSelection";
            btnClearSelection.Size = new Size(428, 48);
            btnClearSelection.TabIndex = 10;
            btnClearSelection.Text = "清除选择";
            btnClearSelection.UseVisualStyleBackColor = true;
            btnClearSelection.Click += btnClearSelection_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(6, 701);
            btnDelete.Margin = new Padding(6);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(428, 48);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "删除设备组";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(6, 641);
            btnUpdate.Margin = new Padding(6);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(428, 48);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "更新设备组";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // FactoryId
            // 
            FactoryId.Location = new Point(6, 308);
            FactoryId.Margin = new Padding(6);
            FactoryId.Name = "FactoryId";
            FactoryId.Size = new Size(424, 38);
            FactoryId.TabIndex = 7;
            // 
            // GroupDescription
            // 
            GroupDescription.Location = new Point(6, 217);
            GroupDescription.Margin = new Padding(6);
            GroupDescription.Name = "GroupDescription";
            GroupDescription.Size = new Size(424, 38);
            GroupDescription.TabIndex = 6;
            // 
            // GroupType
            // 
            GroupType.Location = new Point(6, 126);
            GroupType.Margin = new Padding(6);
            GroupType.Name = "GroupType";
            GroupType.Size = new Size(424, 38);
            GroupType.TabIndex = 5;
            // 
            // GroupId
            // 
            GroupId.Location = new Point(6, 35);
            GroupId.Margin = new Padding(6);
            GroupId.Name = "GroupId";
            GroupId.Size = new Size(424, 38);
            GroupId.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 271);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(87, 31);
            label4.TabIndex = 3;
            label4.Text = "工厂ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 180);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(134, 31);
            label3.TabIndex = 2;
            label3.Text = "设备组描述";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 89);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(134, 31);
            label2.TabIndex = 1;
            label2.Text = "设备组类型";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, -2);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(111, 31);
            label1.TabIndex = 0;
            label1.Text = "设备组ID";
            // 
            // panelAddGroup
            // 
            panelAddGroup.Controls.Add(EventTypeTextBox); // 添加事件类型文本框
            panelAddGroup.Controls.Add(label11); // 添加事件类型标签
            panelAddGroup.Controls.Add(FactoryIdTextBox);
            panelAddGroup.Controls.Add(GroupDescriptionTextBox);
            panelAddGroup.Controls.Add(GroupTypeTextBox);
            panelAddGroup.Controls.Add(GroupIdTextBox);
            panelAddGroup.Controls.Add(Cancelbutton1);
            panelAddGroup.Controls.Add(Confirmbutton1);
            panelAddGroup.Controls.Add(label8);
            panelAddGroup.Controls.Add(label7);
            panelAddGroup.Controls.Add(label6);
            panelAddGroup.Controls.Add(label5);
            panelAddGroup.Location = new Point(1136, 85);
            panelAddGroup.Margin = new Padding(6);
            panelAddGroup.Name = "panelAddGroup";
            panelAddGroup.Size = new Size(440, 820);
            panelAddGroup.TabIndex = 4;
            panelAddGroup.Visible = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(6, 362);
            label11.Margin = new Padding(6, 0, 6, 0);
            label11.Name = "label11";
            label11.Size = new Size(111, 31);
            label11.TabIndex = 10;
            label11.Text = "事件类型";
            // 
            // EventTypeTextBox
            // 
            EventTypeTextBox.Location = new Point(6, 399);
            EventTypeTextBox.Margin = new Padding(6);
            EventTypeTextBox.Name = "EventTypeTextBox";
            EventTypeTextBox.Size = new Size(424, 38);
            EventTypeTextBox.TabIndex = 11;
            // 
            // FactoryIdTextBox
            // 
            FactoryIdTextBox.Location = new Point(6, 308);
            FactoryIdTextBox.Margin = new Padding(6);
            FactoryIdTextBox.Name = "FactoryIdTextBox";
            FactoryIdTextBox.Size = new Size(424, 38);
            FactoryIdTextBox.TabIndex = 9;
            // 
            // GroupDescriptionTextBox
            // 
            GroupDescriptionTextBox.Location = new Point(6, 217);
            GroupDescriptionTextBox.Margin = new Padding(6);
            GroupDescriptionTextBox.Name = "GroupDescriptionTextBox";
            GroupDescriptionTextBox.Size = new Size(424, 38);
            GroupDescriptionTextBox.TabIndex = 8;
            // 
            // GroupTypeTextBox
            // 
            GroupTypeTextBox.Location = new Point(6, 126);
            GroupTypeTextBox.Margin = new Padding(6);
            GroupTypeTextBox.Name = "GroupTypeTextBox";
            GroupTypeTextBox.Size = new Size(424, 38);
            GroupTypeTextBox.TabIndex = 7;
            // 
            // GroupIdTextBox
            // 
            GroupIdTextBox.Location = new Point(6, 35);
            GroupIdTextBox.Margin = new Padding(6);
            GroupIdTextBox.Name = "GroupIdTextBox";
            GroupIdTextBox.Size = new Size(424, 38);
            GroupIdTextBox.TabIndex = 6;
            // 
            // Cancelbutton1
            // 
            Cancelbutton1.Location = new Point(228, 500); // 调整位置
            Cancelbutton1.Margin = new Padding(6);
            Cancelbutton1.Name = "Cancelbutton1";
            Cancelbutton1.Size = new Size(206, 62);
            Cancelbutton1.TabIndex = 5;
            Cancelbutton1.Text = "取消";
            Cancelbutton1.UseVisualStyleBackColor = true;
            Cancelbutton1.Click += Cancelbutton1_Click;
            // 
            // Confirmbutton1
            // 
            Confirmbutton1.Location = new Point(6, 500); // 调整位置
            Confirmbutton1.Margin = new Padding(6);
            Confirmbutton1.Name = "Confirmbutton1";
            Confirmbutton1.Size = new Size(206, 62);
            Confirmbutton1.TabIndex = 4;
            Confirmbutton1.Text = "确认";
            Confirmbutton1.UseVisualStyleBackColor = true;
            Confirmbutton1.Click += Confirmbutton1_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 271);
            label8.Margin = new Padding(6, 0, 6, 0);
            label8.Name = "label8";
            label8.Size = new Size(87, 31);
            label8.TabIndex = 3;
            label8.Text = "工厂ID";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 180);
            label7.Margin = new Padding(6, 0, 6, 0);
            label7.Name = "label7";
            label7.Size = new Size(134, 31);
            label7.TabIndex = 2;
            label7.Text = "设备组描述";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 89);
            label6.Margin = new Padding(6, 0, 6, 0);
            label6.Name = "label6";
            label6.Size = new Size(134, 31);
            label6.TabIndex = 1;
            label6.Text = "设备组类型";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, -2);
            label5.Margin = new Padding(6, 0, 6, 0);
            label5.Name = "label5";
            label5.Size = new Size(111, 31);
            label5.TabIndex = 0;
            label5.Text = "设备组ID";
            // 
            // btnToggleView
            // 
            btnToggleView.Location = new Point(1136, 25);
            btnToggleView.Margin = new Padding(6);
            btnToggleView.Name = "btnToggleView";
            btnToggleView.Size = new Size(440, 48);
            btnToggleView.TabIndex = 5;
            btnToggleView.Text = "切换到添加设备组";
            btnToggleView.UseVisualStyleBackColor = true;
            btnToggleView.Click += btnToggleView_Click;
            // 
            // searchTypeComboBox
            // 
            searchTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            searchTypeComboBox.FormattingEnabled = true;
            searchTypeComboBox.Items.AddRange(new object[] { "设备组ID", "设备组类型" });
            searchTypeComboBox.Location = new Point(142, 25);
            searchTypeComboBox.Margin = new Padding(6);
            searchTypeComboBox.Name = "searchTypeComboBox";
            searchTypeComboBox.Size = new Size(146, 39);
            searchTypeComboBox.TabIndex = 6;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(24, 31);
            label9.Margin = new Padding(6, 0, 6, 0);
            label9.Name = "label9";
            label9.Size = new Size(110, 31);
            label9.TabIndex = 7;
            label9.Text = "搜索类型";
            // 
            // FrmEqpGroup
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1600, 930);
            Controls.Add(label9);
            Controls.Add(searchTypeComboBox);
            Controls.Add(btnToggleView);
            Controls.Add(SearchButton);
            Controls.Add(SearchTextBox);
            Controls.Add(dataGridView1);
            Controls.Add(panelGroupInfo);
            Controls.Add(panelAddGroup);
            Margin = new Padding(6);
            Name = "FrmEqpGroup";
            Text = "设备组管理";
            Load += FrmEqp_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panelGroupInfo.ResumeLayout(false);
            panelGroupInfo.PerformLayout();
            panelAddGroup.ResumeLayout(false);
            panelAddGroup.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox SearchTextBox;
        private Button SearchButton;
        private Panel panelGroupInfo;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Panel panelAddGroup;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Button btnToggleView;
        private TextBox FactoryId;
        private TextBox GroupDescription;
        private TextBox GroupType;
        private TextBox GroupId;
        private Button btnClearSelection;
        private Button btnDelete;
        private Button btnUpdate;
        private TextBox FactoryIdTextBox;
        private TextBox GroupDescriptionTextBox;
        private TextBox GroupTypeTextBox;
        private TextBox GroupIdTextBox;
        private Button Cancelbutton1;
        private Button Confirmbutton1;
        private ComboBox searchTypeComboBox;
        private Label label9;
        private TextBox EventType; // 添加事件类型文本框
        private Label label10; // 添加事件类型标签
        private TextBox EventTypeTextBox; // 添加事件类型文本框
        private Label label11; // 添加事件类型标签
    }
}
