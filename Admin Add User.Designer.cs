namespace Tracking_and_Queuing_System
{
    partial class AddUserForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUserForm));
            panel1 = new Panel();
            txtLastName = new TextBox();
            lblLastName = new Label();
            txtFirstName = new TextBox();
            lblFirstName = new Label();
            btnEdit = new Button();
            btnAddNew = new Button();
            btnClear = new Button();
            btnSave = new Button();
            btnDelete = new Button();
            dgUsers = new DataGridView();
            cmbRole = new ComboBox();
            label9 = new Label();
            lblEx = new Label();
            pictureBox2 = new PictureBox();
            chkCheckPass = new CheckBox();
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtUsername = new TextBox();
            lblUsername = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgUsers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(txtLastName);
            panel1.Controls.Add(lblLastName);
            panel1.Controls.Add(txtFirstName);
            panel1.Controls.Add(lblFirstName);
            panel1.Controls.Add(btnEdit);
            panel1.Controls.Add(btnAddNew);
            panel1.Controls.Add(btnClear);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(dgUsers);
            panel1.Controls.Add(cmbRole);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(lblEx);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(chkCheckPass);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(lblPassword);
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(lblUsername);
            panel1.Controls.Add(label1);
            panel1.Cursor = Cursors.Hand;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1158, 596);
            panel1.TabIndex = 1;
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Microsoft Sans Serif", 10F);
            txtLastName.Location = new Point(35, 199);
            txtLastName.Multiline = true;
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(305, 30);
            txtLastName.TabIndex = 21;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Microsoft Sans Serif", 10F);
            lblLastName.Location = new Point(31, 170);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(96, 20);
            lblLastName.TabIndex = 20;
            lblLastName.Text = "Last Name:";
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Microsoft Sans Serif", 10F);
            txtFirstName.Location = new Point(35, 125);
            txtFirstName.Multiline = true;
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(305, 30);
            txtFirstName.TabIndex = 19;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Microsoft Sans Serif", 10F);
            lblFirstName.Location = new Point(31, 96);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(97, 20);
            lblFirstName.TabIndex = 18;
            lblFirstName.Text = "First Name:";
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(0, 99, 177);
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatAppearance.MouseDownBackColor = Color.FromArgb(47, 126, 189);
            btnEdit.FlatAppearance.MouseOverBackColor = Color.FromArgb(47, 126, 189);
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 9F);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(35, 479);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(100, 35);
            btnEdit.TabIndex = 17;
            btnEdit.Text = "EDIT";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAddNew
            // 
            btnAddNew.BackColor = Color.FromArgb(0, 99, 177);
            btnAddNew.FlatAppearance.BorderSize = 0;
            btnAddNew.FlatAppearance.MouseDownBackColor = Color.FromArgb(47, 126, 189);
            btnAddNew.FlatAppearance.MouseOverBackColor = Color.FromArgb(47, 126, 189);
            btnAddNew.FlatStyle = FlatStyle.Flat;
            btnAddNew.Font = new Font("Segoe UI", 9F);
            btnAddNew.ForeColor = Color.White;
            btnAddNew.Location = new Point(239, 479);
            btnAddNew.Name = "btnAddNew";
            btnAddNew.Size = new Size(100, 35);
            btnAddNew.TabIndex = 16;
            btnAddNew.Text = "ADD NEW";
            btnAddNew.UseVisualStyleBackColor = false;
            btnAddNew.Click += btnAddNew_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(0, 99, 177);
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatAppearance.MouseDownBackColor = Color.FromArgb(47, 126, 189);
            btnClear.FlatAppearance.MouseOverBackColor = Color.FromArgb(47, 126, 189);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9F);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(239, 520);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(100, 35);
            btnClear.TabIndex = 15;
            btnClear.Text = "CLEAR";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 99, 177);
            btnSave.FlatAppearance.BorderColor = Color.Black;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatAppearance.MouseDownBackColor = Color.FromArgb(47, 126, 189);
            btnSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(47, 126, 189);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(35, 520);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 14;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Maroon;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatAppearance.MouseDownBackColor = Color.Red;
            btnDelete.FlatAppearance.MouseOverBackColor = Color.Red;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(989, 520);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(123, 35);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // dgUsers
            // 
            dgUsers.AllowUserToAddRows = false;
            dgUsers.AllowUserToDeleteRows = false;
            dgUsers.AllowUserToOrderColumns = true;
            dgUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.AppWorkspace;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgUsers.ColumnHeadersHeight = 55;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgUsers.DefaultCellStyle = dataGridViewCellStyle2;
            dgUsers.EnableHeadersVisualStyles = false;
            dgUsers.Location = new Point(369, 96);
            dgUsers.Name = "dgUsers";
            dgUsers.ReadOnly = true;
            dgUsers.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgUsers.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgUsers.Size = new Size(743, 358);
            dgUsers.TabIndex = 0;
            dgUsers.CellClick += dgUsers_CellClick;
            // 
            // cmbRole
            // 
            cmbRole.Font = new Font("Microsoft Sans Serif", 10F);
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "Admin Clerk", "Social Worker", "SDO" });
            cmbRole.Location = new Point(35, 426);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(305, 28);
            cmbRole.TabIndex = 11;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 10F);
            label9.Location = new Point(35, 399);
            label9.Name = "label9";
            label9.Size = new Size(48, 20);
            label9.TabIndex = 10;
            label9.Text = "Role:";
            // 
            // lblEx
            // 
            lblEx.AutoSize = true;
            lblEx.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEx.Location = new Point(1117, 20);
            lblEx.Name = "lblEx";
            lblEx.Size = new Size(20, 20);
            lblEx.TabIndex = 9;
            lblEx.Text = "X";
            lblEx.Click += lblEx_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(34, 45);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(25, 25);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // chkCheckPass
            // 
            chkCheckPass.AutoSize = true;
            chkCheckPass.BackColor = Color.Transparent;
            chkCheckPass.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkCheckPass.ForeColor = SystemColors.GrayText;
            chkCheckPass.Location = new Point(189, 380);
            chkCheckPass.Name = "chkCheckPass";
            chkCheckPass.Size = new Size(151, 24);
            chkCheckPass.TabIndex = 7;
            chkCheckPass.Text = "Show Password";
            chkCheckPass.UseVisualStyleBackColor = false;
            chkCheckPass.CheckedChanged += chkCheckPass_CheckedChanged;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Microsoft Sans Serif", 10F);
            txtPassword.Location = new Point(35, 344);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(305, 30);
            txtPassword.TabIndex = 5;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Microsoft Sans Serif", 10F);
            lblPassword.Location = new Point(31, 315);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(88, 20);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Password:";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Microsoft Sans Serif", 10F);
            txtUsername.Location = new Point(35, 271);
            txtUsername.Multiline = true;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(305, 30);
            txtUsername.TabIndex = 3;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Microsoft Sans Serif", 10F);
            lblUsername.Location = new Point(31, 242);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(91, 20);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Username:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MS UI Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(59, 46);
            label1.Name = "label1";
            label1.Size = new Size(108, 23);
            label1.TabIndex = 1;
            label1.Text = "Add User";
            // 
            // AddUserForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1158, 597);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddUserForm";
            StartPosition = FormStartPosition.CenterScreen;
            Load += AddUserForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgUsers).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblEx;
        private PictureBox pictureBox2;
        private CheckBox chkCheckPass;
        private TextBox txtPassword;
        private Label lblPassword;
        private TextBox txtUsername;
        private Label lblUsername;
        private Label label1;
        private ComboBox cmbRole;
        private Label label9;
        private DataGridView dgUsers;
        private Button btnClear;
        private Button btnSave;
        private Button btnDelete;
        private Button btnAddNew;
        private Button btnEdit;
        private TextBox txtLastName;
        private Label lblLastName;
        private TextBox txtFirstName;
        private Label lblFirstName;
    }
}