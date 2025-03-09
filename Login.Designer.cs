namespace Abot_Kamay_Tracking_and_Queuing_System
{
    partial class LoginForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            panelWhite = new Panel();
            chkViewPass = new CheckBox();
            btnLogin = new Button();
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtUsername = new TextBox();
            lblUsername = new Label();
            pictureBox2 = new PictureBox();
            lblEx = new Label();
            panelBlue = new Panel();
            label6 = new Label();
            timeDateTimer = new System.Windows.Forms.Timer(components);
            pictureBox1 = new PictureBox();
            pictureBox5 = new PictureBox();
            lblDate = new Label();
            lblTime = new Label();
            pictureBox3 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            panelWhite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panelBlue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelWhite
            // 
            panelWhite.BackColor = Color.FromArgb(233, 233, 233);
            panelWhite.Controls.Add(chkViewPass);
            panelWhite.Controls.Add(btnLogin);
            panelWhite.Controls.Add(txtPassword);
            panelWhite.Controls.Add(lblPassword);
            panelWhite.Controls.Add(txtUsername);
            panelWhite.Controls.Add(lblUsername);
            panelWhite.Cursor = Cursors.Hand;
            panelWhite.Location = new Point(148, 332);
            panelWhite.Name = "panelWhite";
            panelWhite.Size = new Size(407, 337);
            panelWhite.TabIndex = 1;
            // 
            // chkViewPass
            // 
            chkViewPass.AutoSize = true;
            chkViewPass.BackColor = Color.Transparent;
            chkViewPass.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkViewPass.ForeColor = SystemColors.GrayText;
            chkViewPass.Location = new Point(205, 195);
            chkViewPass.Name = "chkViewPass";
            chkViewPass.Size = new Size(151, 24);
            chkViewPass.TabIndex = 10;
            chkViewPass.Text = "Show Password";
            chkViewPass.UseVisualStyleBackColor = false;
            chkViewPass.CheckedChanged += chkViewPass_CheckedChanged;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(0, 99, 177);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(47, 126, 189);
            btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(47, 126, 189);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(150, 258);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(100, 35);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(51, 158);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(305, 30);
            txtPassword.TabIndex = 5;
            txtPassword.KeyDown += txtPassword_KeyDown;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Microsoft Sans Serif", 10F);
            lblPassword.ForeColor = Color.FromArgb(45, 45, 45);
            lblPassword.Location = new Point(47, 129);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(88, 20);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Password:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(51, 85);
            txtUsername.Multiline = true;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(305, 30);
            txtUsername.TabIndex = 3;
            txtUsername.TextChanged += txtUsername_TextChanged;
            txtUsername.KeyPress += txtUsername_KeyPress;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Microsoft Sans Serif", 10F);
            lblUsername.ForeColor = Color.FromArgb(45, 45, 45);
            lblUsername.Location = new Point(47, 56);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(91, 20);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Username:";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.ErrorImage = (Image)resources.GetObject("pictureBox2.ErrorImage");
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(130, 33);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(39, 33);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // lblEx
            // 
            lblEx.AutoSize = true;
            lblEx.BackColor = Color.Transparent;
            lblEx.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEx.ForeColor = Color.WhiteSmoke;
            lblEx.Location = new Point(660, 9);
            lblEx.Name = "lblEx";
            lblEx.Size = new Size(20, 20);
            lblEx.TabIndex = 9;
            lblEx.Text = "X";
            lblEx.Click += lblEx_Click;
            // 
            // panelBlue
            // 
            panelBlue.BackColor = Color.FromArgb(47, 126, 189);
            panelBlue.Controls.Add(label6);
            panelBlue.Controls.Add(pictureBox2);
            panelBlue.Location = new Point(148, 240);
            panelBlue.Name = "panelBlue";
            panelBlue.Size = new Size(407, 95);
            panelBlue.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(235, 235, 235);
            label6.Location = new Point(175, 38);
            label6.Name = "label6";
            label6.Size = new Size(75, 24);
            label6.TabIndex = 3;
            label6.Text = "Log In";
            // 
            // timeDateTimer
            // 
            timeDateTimer.Tick += timeDateTimer_Tick;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(361, 211);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(21, 16);
            pictureBox1.TabIndex = 54;
            pictureBox1.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.Transparent;
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(158, 211);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(23, 16);
            pictureBox5.TabIndex = 53;
            pictureBox5.TabStop = false;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.BackColor = Color.Transparent;
            lblDate.Font = new Font("MS UI Gothic", 9F);
            lblDate.ForeColor = Color.FromArgb(233, 233, 233);
            lblDate.Location = new Point(388, 210);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(140, 15);
            lblDate.TabIndex = 52;
            lblDate.Text = "Date:____________________";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.BackColor = Color.Transparent;
            lblTime.Font = new Font("MS UI Gothic", 9F);
            lblTime.ForeColor = Color.FromArgb(233, 233, 233);
            lblTime.Location = new Point(185, 210);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(66, 15);
            lblTime.TabIndex = 51;
            lblTime.Text = "Time:_____";
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(96, 38);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(122, 106);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 56;
            pictureBox3.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Tahoma", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(224, 97);
            label1.Name = "label1";
            label1.Size = new Size(360, 28);
            label1.TabIndex = 55;
            label1.Text = "Tracking and Queuing System";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Tahoma", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(224, 59);
            label2.Name = "label2";
            label2.Size = new Size(238, 28);
            label2.TabIndex = 57;
            label2.Text = "Abot Kamay Center";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(47, 126, 189);
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblEx);
            panel1.Location = new Point(-3, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(693, 184);
            panel1.TabIndex = 9;
            panel1.Paint += panel1_Paint;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(689, 757);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox5);
            Controls.Add(lblDate);
            Controls.Add(lblTime);
            Controls.Add(panelWhite);
            Controls.Add(panelBlue);
            ForeColor = Color.FromArgb(233, 233, 233);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += LoginForm_Load;
            KeyDown += LoginForm_KeyDown;
            panelWhite.ResumeLayout(false);
            panelWhite.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panelBlue.ResumeLayout(false);
            panelBlue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelWhite;
        private Label lblEx;
        private PictureBox pictureBox2;
        private TextBox txtPassword;
        private Label lblPassword;
        private TextBox txtUsername;
        private Label lblUsername;
        private Panel panelBlue;
        private Button btnLogin;
        private CheckBox chkViewPass;
        private System.Windows.Forms.Timer timeDateTimer;
        private Label label6;
        private PictureBox pictureBox1;
        private PictureBox pictureBox5;
        private Label lblDate;
        private Label lblTime;
        private PictureBox pictureBox3;
        private Label label1;
        private Label label2;
        private Panel panel1;
    }
}
