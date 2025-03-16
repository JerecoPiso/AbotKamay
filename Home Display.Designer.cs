namespace Abot_Kamay_Tracking_and_Queuing_System
{
    partial class HomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            mainPanel = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnRefresh = new Button();
            btnAddNew = new Button();
            lblClient = new Label();
            lblBenef = new Label();
            dgClient = new DataGridView();
            dgBenef = new DataGridView();
            pictureBox2 = new PictureBox();
            txtSearch = new TextBox();
            mainPanel.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgClient).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgBenef).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(206, 206, 206);
            mainPanel.BackgroundImage = (Image)resources.GetObject("mainPanel.BackgroundImage");
            mainPanel.Controls.Add(flowLayoutPanel1);
            mainPanel.Controls.Add(lblClient);
            mainPanel.Controls.Add(lblBenef);
            mainPanel.Controls.Add(dgClient);
            mainPanel.Controls.Add(dgBenef);
            mainPanel.Controls.Add(pictureBox2);
            mainPanel.Controls.Add(txtSearch);
            mainPanel.Font = new Font("Arial Rounded MT Bold", 18F);
            mainPanel.ForeColor = SystemColors.ControlText;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1531, 926);
            mainPanel.TabIndex = 7;
            mainPanel.Paint += mainPanel_Paint;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.Transparent;
            flowLayoutPanel1.Controls.Add(btnRefresh);
            flowLayoutPanel1.Controls.Add(btnAddNew);
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(1171, 95);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(289, 44);
            flowLayoutPanel1.TabIndex = 256;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(0, 99, 177);
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Arial Rounded MT Bold", 9F);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Image = (Image)resources.GetObject("btnRefresh.Image");
            btnRefresh.ImageAlign = ContentAlignment.MiddleRight;
            btnRefresh.Location = new Point(153, 3);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(133, 40);
            btnRefresh.TabIndex = 256;
            btnRefresh.Text = "REFRESH  ";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.UseWaitCursor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnAddNew
            // 
            btnAddNew.BackColor = Color.FromArgb(0, 99, 177);
            btnAddNew.FlatAppearance.BorderSize = 0;
            btnAddNew.FlatStyle = FlatStyle.Flat;
            btnAddNew.Font = new Font("Arial Rounded MT Bold", 9F);
            btnAddNew.ForeColor = Color.White;
            btnAddNew.Image = (Image)resources.GetObject("btnAddNew.Image");
            btnAddNew.ImageAlign = ContentAlignment.MiddleRight;
            btnAddNew.Location = new Point(14, 3);
            btnAddNew.Name = "btnAddNew";
            btnAddNew.Size = new Size(133, 40);
            btnAddNew.TabIndex = 255;
            btnAddNew.Text = "ADD NEW  ";
            btnAddNew.UseVisualStyleBackColor = false;
            btnAddNew.UseWaitCursor = true;
            btnAddNew.Click += btnAddNew_Click;
            // 
            // lblClient
            // 
            lblClient.AutoSize = true;
            lblClient.BackColor = Color.Transparent;
            lblClient.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblClient.ForeColor = Color.FromArgb(64, 64, 64);
            lblClient.Location = new Point(76, 119);
            lblClient.Name = "lblClient";
            lblClient.Size = new Size(84, 20);
            lblClient.TabIndex = 249;
            lblClient.Text = "CLIENTS:";
            // 
            // lblBenef
            // 
            lblBenef.AutoSize = true;
            lblBenef.BackColor = Color.Transparent;
            lblBenef.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblBenef.ForeColor = Color.FromArgb(64, 64, 64);
            lblBenef.Location = new Point(76, 520);
            lblBenef.Name = "lblBenef";
            lblBenef.Size = new Size(139, 20);
            lblBenef.TabIndex = 248;
            lblBenef.Text = "BENEFICIARIES:";
            // 
            // dgClient
            // 
            dgClient.AllowUserToAddRows = false;
            dgClient.AllowUserToDeleteRows = false;
            dgClient.AllowUserToResizeColumns = false;
            dgClient.AllowUserToResizeRows = false;
            dgClient.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgClient.BorderStyle = BorderStyle.Fixed3D;
            dgClient.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.PaleGreen;
            dataGridViewCellStyle1.Font = new Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new Padding(0, 24, 0, 24);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgClient.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgClient.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgClient.DefaultCellStyle = dataGridViewCellStyle2;
            dgClient.Location = new Point(74, 152);
            dgClient.MultiSelect = false;
            dgClient.Name = "dgClient";
            dgClient.ReadOnly = true;
            dgClient.RowHeadersWidth = 51;
            dgClient.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgClient.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgClient.Size = new Size(1386, 351);
            dgClient.TabIndex = 247;
            dgClient.CellClick += dgClient_CellClick;
            dgClient.CellContentClick += dgClient_CellContentClick;
            dgClient.CellDoubleClick += dgClient_CellDoubleClick;
            // 
            // dgBenef
            // 
            dgBenef.AllowUserToAddRows = false;
            dgBenef.AllowUserToDeleteRows = false;
            dgBenef.AllowUserToResizeColumns = false;
            dgBenef.AllowUserToResizeRows = false;
            dgBenef.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgBenef.BorderStyle = BorderStyle.Fixed3D;
            dgBenef.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.PaleGreen;
            dataGridViewCellStyle3.Font = new Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new Padding(0, 24, 0, 24);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgBenef.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgBenef.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgBenef.DefaultCellStyle = dataGridViewCellStyle4;
            dgBenef.Location = new Point(76, 552);
            dgBenef.MultiSelect = false;
            dgBenef.Name = "dgBenef";
            dgBenef.ReadOnly = true;
            dgBenef.RowHeadersWidth = 51;
            dgBenef.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgBenef.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgBenef.Size = new Size(1386, 309);
            dgBenef.TabIndex = 246;
            dgBenef.CellClick += dgBenef_CellClick;
            dgBenef.CellContentClick += dgBenef_CellContentClick;
            dgBenef.CellFormatting += dgBenef_CellFormatting;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.Window;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(977, 68);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(32, 32);
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 24;
            pictureBox2.TabStop = false;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(539, 64);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(475, 42);
            txtSearch.TabIndex = 20;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1531, 926);
            Controls.Add(mainPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "HomeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Load += HomeForm_Load;
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgClient).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgBenef).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel mainPanel;
        private PictureBox pictureBox2;
        private TextBox txtSearch;
        private DataGridView dgBenef;
        private Label lblBenef;
        private DataGridView dgClient;
        private Label lblClient;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnRefresh;
        public Button btnAddNew;
    }
}