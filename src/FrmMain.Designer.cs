namespace MyCredVault
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            btnReset = new Button();
            btnSave = new Button();
            label2 = new Label();
            label1 = new Label();
            txtValue = new TextBox();
            txtKey = new TextBox();
            lblValue = new Label();
            lblName = new Label();
            bgList = new GroupBox();
            dgvItems = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Key = new DataGridViewTextBoxColumn();
            Value = new DataGridViewTextBoxColumn();
            btnSearch = new Button();
            txtSearch = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            bgList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(bgList, 0, 1);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 31.0035839F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 68.9964142F));
            tableLayoutPanel1.Size = new Size(846, 539);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightGray;
            panel1.Controls.Add(btnReset);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtValue);
            panel1.Controls.Add(txtKey);
            panel1.Controls.Add(lblValue);
            panel1.Controls.Add(lblName);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(836, 159);
            panel1.TabIndex = 0;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(276, 106);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(99, 35);
            btnReset.TabIndex = 7;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(136, 106);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(99, 35);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(119, 68);
            label2.Name = "label2";
            label2.Size = new Size(10, 15);
            label2.TabIndex = 5;
            label2.Text = ":";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(119, 22);
            label1.Name = "label1";
            label1.Size = new Size(10, 15);
            label1.TabIndex = 4;
            label1.Text = ":";
            // 
            // txtValue
            // 
            txtValue.Location = new Point(136, 65);
            txtValue.Name = "txtValue";
            txtValue.Size = new Size(240, 23);
            txtValue.TabIndex = 3;
            // 
            // txtKey
            // 
            txtKey.Location = new Point(136, 19);
            txtKey.Name = "txtKey";
            txtKey.Size = new Size(240, 23);
            txtKey.TabIndex = 2;
            // 
            // lblValue
            // 
            lblValue.Location = new Point(30, 68);
            lblValue.Name = "lblValue";
            lblValue.Size = new Size(100, 20);
            lblValue.TabIndex = 1;
            lblValue.Text = "Value";
            // 
            // lblName
            // 
            lblName.Location = new Point(30, 19);
            lblName.Name = "lblName";
            lblName.Size = new Size(83, 23);
            lblName.TabIndex = 0;
            lblName.Text = "Name";
            // 
            // bgList
            // 
            bgList.Controls.Add(dgvItems);
            bgList.Controls.Add(btnSearch);
            bgList.Controls.Add(txtSearch);
            bgList.Location = new Point(3, 170);
            bgList.Name = "bgList";
            bgList.Size = new Size(840, 366);
            bgList.TabIndex = 1;
            bgList.TabStop = false;
            // 
            // dgvItems
            // 
            dgvItems.AllowUserToAddRows = false;
            dgvItems.AllowUserToDeleteRows = false;
            dgvItems.BackgroundColor = SystemColors.Control;
            dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItems.Columns.AddRange(new DataGridViewColumn[] { Id, Key, Value });
            dgvItems.GridColor = SystemColors.Control;
            dgvItems.Location = new Point(5, 47);
            dgvItems.Margin = new Padding(3, 2, 3, 2);
            dgvItems.Name = "dgvItems";
            dgvItems.ReadOnly = true;
            dgvItems.RowHeadersWidth = 51;
            dgvItems.RowTemplate.Height = 29;
            dgvItems.Size = new Size(830, 315);
            dgvItems.TabIndex = 8;
            dgvItems.RowHeaderMouseDoubleClick += dgvItems_RowHeaderMouseDoubleClick;
            dgvItems.KeyDown += dgvItems_KeyDown;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Id";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Visible = false;
            Id.Width = 125;
            // 
            // Key
            // 
            Key.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Key.DataPropertyName = "Key";
            Key.FillWeight = 30F;
            Key.HeaderText = "Key";
            Key.MinimumWidth = 6;
            Key.Name = "Key";
            Key.ReadOnly = true;
            // 
            // Value
            // 
            Value.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Value.DataPropertyName = "Value";
            Value.FillWeight = 70F;
            Value.HeaderText = "Value";
            Value.MinimumWidth = 6;
            Value.Name = "Value";
            Value.ReadOnly = true;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(738, 21);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(96, 24);
            btnSearch.TabIndex = 7;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(6, 22);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(726, 23);
            txtSearch.TabIndex = 4;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(864, 556);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "My Credential Vault";
            Load += FrmMain_Load;
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            bgList.ResumeLayout(false);
            bgList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Label lblName;
        private Label lblValue;
        private TextBox txtValue;
        private TextBox txtKey;
        private Label label2;
        private Label label1;
        private Button btnReset;
        private Button btnSave;
        private GroupBox bgList;
        private Button btnSearch;
        private TextBox txtSearch;
        private DataGridView dgvItems;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Key;
        private DataGridViewTextBoxColumn Value;
    }
}