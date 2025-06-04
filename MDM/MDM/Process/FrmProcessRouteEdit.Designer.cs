namespace MDM.UI.Process
{
    partial class FrmProcessRouteEdit
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
            leftPanel = new Panel();
            dataGridViewAvailable = new DataGridView();
            lblAvailable = new Label();
            middlePanel = new Panel();
            btnMoveDown = new Button();
            btnMoveUp = new Button();
            btnRemoveFromRoute = new Button();
            btnAddToRoute = new Button();
            rightPanel = new Panel();
            dataGridViewRoute = new DataGridView();
            lblRoute = new Label();
            bottomPanel = new Panel();
            btnCancel = new Button();
            btnOK = new Button();
            leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAvailable).BeginInit();
            middlePanel.SuspendLayout();
            rightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRoute).BeginInit();
            bottomPanel.SuspendLayout();
            SuspendLayout();
            // 
            // leftPanel
            // 
            leftPanel.BorderStyle = BorderStyle.FixedSingle;
            leftPanel.Controls.Add(dataGridViewAvailable);
            leftPanel.Controls.Add(lblAvailable);
            leftPanel.Dock = DockStyle.Left;
            leftPanel.Location = new Point(0, 0);
            leftPanel.Margin = new Padding(7, 8, 7, 8);
            leftPanel.Name = "leftPanel";
            leftPanel.Size = new Size(711, 777);
            leftPanel.TabIndex = 0;
            // 
            // dataGridViewAvailable
            // 
            dataGridViewAvailable.AllowUserToAddRows = false;
            dataGridViewAvailable.AllowUserToDeleteRows = false;
            dataGridViewAvailable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewAvailable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAvailable.Location = new Point(23, 90);
            dataGridViewAvailable.Margin = new Padding(7, 8, 7, 8);
            dataGridViewAvailable.Name = "dataGridViewAvailable";
            dataGridViewAvailable.ReadOnly = true;
            dataGridViewAvailable.RowHeadersVisible = false;
            dataGridViewAvailable.RowHeadersWidth = 82;
            dataGridViewAvailable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewAvailable.Size = new Size(624, 651);
            dataGridViewAvailable.TabIndex = 1;
            // 
            // lblAvailable
            // 
            lblAvailable.AutoSize = true;
            lblAvailable.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            lblAvailable.Location = new Point(23, 26);
            lblAvailable.Margin = new Padding(7, 0, 7, 0);
            lblAvailable.Name = "lblAvailable";
            lblAvailable.Size = new Size(62, 31);
            lblAvailable.TabIndex = 0;
            lblAvailable.Text = "工站";
            // 
            // middlePanel
            // 
            middlePanel.Controls.Add(btnRemoveFromRoute);
            middlePanel.Controls.Add(btnAddToRoute);
            middlePanel.Dock = DockStyle.Left;
            middlePanel.Location = new Point(711, 0);
            middlePanel.Margin = new Padding(7, 8, 7, 8);
            middlePanel.Name = "middlePanel";
            middlePanel.Size = new Size(243, 777);
            middlePanel.TabIndex = 1;
            // 
            // btnMoveDown
            // 
            btnMoveDown.Location = new Point(492, 16);
            btnMoveDown.Margin = new Padding(7, 8, 7, 8);
            btnMoveDown.Name = "btnMoveDown";
            btnMoveDown.Size = new Size(117, 55);
            btnMoveDown.TabIndex = 3;
            btnMoveDown.Text = "向下";
            btnMoveDown.UseVisualStyleBackColor = true;
            btnMoveDown.Click += btnMoveDown_Click;
            // 
            // btnMoveUp
            // 
            btnMoveUp.Location = new Point(361, 16);
            btnMoveUp.Margin = new Padding(7, 8, 7, 8);
            btnMoveUp.Name = "btnMoveUp";
            btnMoveUp.Size = new Size(117, 55);
            btnMoveUp.TabIndex = 2;
            btnMoveUp.Text = "向上";
            btnMoveUp.UseVisualStyleBackColor = true;
            btnMoveUp.Click += btnMoveUp_Click;
            // 
            // btnRemoveFromRoute
            // 
            btnRemoveFromRoute.Location = new Point(73, 402);
            btnRemoveFromRoute.Margin = new Padding(7, 8, 7, 8);
            btnRemoveFromRoute.Name = "btnRemoveFromRoute";
            btnRemoveFromRoute.Size = new Size(117, 78);
            btnRemoveFromRoute.TabIndex = 1;
            btnRemoveFromRoute.Text = "←";
            btnRemoveFromRoute.UseVisualStyleBackColor = true;
            btnRemoveFromRoute.Click += btnRemoveFromRoute_Click;
            // 
            // btnAddToRoute
            // 
            btnAddToRoute.Location = new Point(73, 273);
            btnAddToRoute.Margin = new Padding(7, 8, 7, 8);
            btnAddToRoute.Name = "btnAddToRoute";
            btnAddToRoute.Size = new Size(117, 78);
            btnAddToRoute.TabIndex = 0;
            btnAddToRoute.Text = "→";
            btnAddToRoute.UseVisualStyleBackColor = true;
            btnAddToRoute.Click += btnAddToRoute_Click;
            // 
            // rightPanel
            // 
            rightPanel.BorderStyle = BorderStyle.FixedSingle;
            rightPanel.Controls.Add(btnMoveDown);
            rightPanel.Controls.Add(dataGridViewRoute);
            rightPanel.Controls.Add(btnMoveUp);
            rightPanel.Controls.Add(lblRoute);
            rightPanel.Dock = DockStyle.Fill;
            rightPanel.Location = new Point(954, 0);
            rightPanel.Margin = new Padding(7, 8, 7, 8);
            rightPanel.Name = "rightPanel";
            rightPanel.Size = new Size(728, 777);
            rightPanel.TabIndex = 2;
            // 
            // dataGridViewRoute
            // 
            dataGridViewRoute.AllowUserToAddRows = false;
            dataGridViewRoute.AllowUserToDeleteRows = false;
            dataGridViewRoute.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewRoute.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRoute.Location = new Point(50, 96);
            dataGridViewRoute.Margin = new Padding(7, 8, 7, 8);
            dataGridViewRoute.Name = "dataGridViewRoute";
            dataGridViewRoute.ReadOnly = true;
            dataGridViewRoute.RowHeadersVisible = false;
            dataGridViewRoute.RowHeadersWidth = 82;
            dataGridViewRoute.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewRoute.Size = new Size(586, 651);
            dataGridViewRoute.TabIndex = 1;
            // 
            // lblRoute
            // 
            lblRoute.AutoSize = true;
            lblRoute.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            lblRoute.Location = new Point(23, 26);
            lblRoute.Margin = new Padding(7, 0, 7, 0);
            lblRoute.Name = "lblRoute";
            lblRoute.Size = new Size(110, 31);
            lblRoute.TabIndex = 0;
            lblRoute.Text = "工艺路线";
            // 
            // bottomPanel
            // 
            bottomPanel.Controls.Add(btnCancel);
            bottomPanel.Controls.Add(btnOK);
            bottomPanel.Dock = DockStyle.Bottom;
            bottomPanel.Location = new Point(0, 777);
            bottomPanel.Margin = new Padding(7, 8, 7, 8);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Size = new Size(1682, 127);
            bottomPanel.TabIndex = 3;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(1276, 16);
            btnCancel.Margin = new Padding(7, 8, 7, 8);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(175, 78);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(1042, 16);
            btnOK.Margin = new Padding(7, 8, 7, 8);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(175, 78);
            btnOK.TabIndex = 0;
            btnOK.Text = "确定";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // FrmProcessRouteEdit
            // 
            AcceptButton = btnOK;
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(1682, 904);
            Controls.Add(rightPanel);
            Controls.Add(middlePanel);
            Controls.Add(leftPanel);
            Controls.Add(bottomPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(7, 8, 7, 8);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmProcessRouteEdit";
            StartPosition = FormStartPosition.CenterParent;
            Text = "修改工艺路线";
            leftPanel.ResumeLayout(false);
            leftPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAvailable).EndInit();
            middlePanel.ResumeLayout(false);
            rightPanel.ResumeLayout(false);
            rightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRoute).EndInit();
            bottomPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.DataGridView dataGridViewAvailable;
        private System.Windows.Forms.Label lblAvailable;
        private System.Windows.Forms.Panel middlePanel;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnRemoveFromRoute;
        private System.Windows.Forms.Button btnAddToRoute;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.DataGridView dataGridViewRoute;
        private System.Windows.Forms.Label lblRoute;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}
