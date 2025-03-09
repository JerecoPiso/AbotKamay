namespace Abot_Kamay_Tracking_and_Queuing_System
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panelBlue = new Panel();
            pictureBox1 = new PictureBox();
            minExPanel = new Panel();
            close = new PictureBox();
            minimize = new PictureBox();
            label6 = new Label();
            mainPanel = new Panel();
            menuStripSettings = new MenuStrip();
            profileToolStripMenuItem = new ToolStripMenuItem();
            addUserToolStripMenuItem = new ToolStripMenuItem();
            recordToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            createToolStripMenuItem = new ToolStripMenuItem();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnHome = new Button();
            btnQueue = new Button();
            btnSettings = new Button();
            btnLogout = new Button();
            panel6 = new Panel();
            lblTimenow = new Label();
            lblDate = new Label();
            lblTime = new Label();
            timeDateTimer = new System.Windows.Forms.Timer(components);
            panel2 = new Panel();
            lblUser = new Label();
            userButton = new PictureBox();
            panelSideBar = new Panel();
            panelBlue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            minExPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)close).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minimize).BeginInit();
            menuStripSettings.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel6.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)userButton).BeginInit();
            panelSideBar.SuspendLayout();
            SuspendLayout();
            // 
            // panelBlue
            // 
            panelBlue.BackColor = Color.FromArgb(47, 126, 189);
            panelBlue.Controls.Add(pictureBox1);
            panelBlue.Controls.Add(minExPanel);
            panelBlue.Controls.Add(label6);
            panelBlue.Dock = DockStyle.Top;
            panelBlue.Location = new Point(0, 0);
            panelBlue.Name = "panelBlue";
            panelBlue.Size = new Size(1920, 105);
            panelBlue.TabIndex = 5;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(9, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(107, 96);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 22;
            pictureBox1.TabStop = false;
            // 
            // minExPanel
            // 
            minExPanel.Controls.Add(close);
            minExPanel.Controls.Add(minimize);
            minExPanel.Location = new Point(1828, 12);
            minExPanel.Name = "minExPanel";
            minExPanel.Size = new Size(80, 49);
            minExPanel.TabIndex = 11;
            // 
            // close
            // 
            close.Image = (Image)resources.GetObject("close.Image");
            close.Location = new Point(43, 2);
            close.Name = "close";
            close.Size = new Size(36, 37);
            close.SizeMode = PictureBoxSizeMode.StretchImage;
            close.TabIndex = 2;
            close.TabStop = false;
            close.Click += close_Click;
            // 
            // minimize
            // 
            minimize.Image = (Image)resources.GetObject("minimize.Image");
            minimize.Location = new Point(6, 3);
            minimize.Name = "minimize";
            minimize.Size = new Size(38, 35);
            minimize.SizeMode = PictureBoxSizeMode.StretchImage;
            minimize.TabIndex = 0;
            minimize.TabStop = false;
            minimize.Click += minimize_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tahoma", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(132, 34);
            label6.Name = "label6";
            label6.Size = new Size(527, 41);
            label6.TabIndex = 10;
            label6.Text = "Tracking and Queuing System";
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(206, 206, 206);
            mainPanel.BackgroundImage = (Image)resources.GetObject("mainPanel.BackgroundImage");
            mainPanel.Font = new Font("Arial Rounded MT Bold", 18F);
            mainPanel.ForeColor = SystemColors.ControlText;
            mainPanel.Location = new Point(389, 156);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1531, 925);
            mainPanel.TabIndex = 6;
            // 
            // menuStripSettings
            // 
            menuStripSettings.Dock = DockStyle.None;
            menuStripSettings.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuStripSettings.ImageScalingSize = new Size(20, 20);
            menuStripSettings.Items.AddRange(new ToolStripItem[] { profileToolStripMenuItem, recordToolStripMenuItem });
            menuStripSettings.Location = new Point(3, 0);
            menuStripSettings.Name = "menuStripSettings";
            menuStripSettings.Padding = new Padding(6, 10, 0, 10);
            menuStripSettings.Size = new Size(191, 49);
            menuStripSettings.TabIndex = 0;
            // 
            // profileToolStripMenuItem
            // 
            profileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addUserToolStripMenuItem });
            profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            profileToolStripMenuItem.Size = new Size(90, 29);
            profileToolStripMenuItem.Text = "Profile";
            // 
            // addUserToolStripMenuItem
            // 
            addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
            addUserToolStripMenuItem.Size = new Size(263, 30);
            addUserToolStripMenuItem.Text = "Add/Delete User";
            addUserToolStripMenuItem.Click += addUserToolStripMenuItem_Click;
            // 
            // recordToolStripMenuItem
            // 
            recordToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { viewToolStripMenuItem, createToolStripMenuItem });
            recordToolStripMenuItem.Name = "recordToolStripMenuItem";
            recordToolStripMenuItem.Size = new Size(93, 29);
            recordToolStripMenuItem.Text = "Report";
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(165, 30);
            viewToolStripMenuItem.Text = "View";
            // 
            // createToolStripMenuItem
            // 
            createToolStripMenuItem.Name = "createToolStripMenuItem";
            createToolStripMenuItem.Size = new Size(165, 30);
            createToolStripMenuItem.Text = "Create";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.Transparent;
            flowLayoutPanel1.Controls.Add(btnHome);
            flowLayoutPanel1.Controls.Add(btnQueue);
            flowLayoutPanel1.Controls.Add(btnSettings);
            flowLayoutPanel1.Controls.Add(btnLogout);
            flowLayoutPanel1.Location = new Point(3, 163);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(386, 276);
            flowLayoutPanel1.TabIndex = 26;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.FromArgb(45, 45, 45);
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatAppearance.MouseDownBackColor = SystemColors.WindowFrame;
            btnHome.FlatAppearance.MouseOverBackColor = SystemColors.Highlight;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.ForeColor = Color.White;
            btnHome.Image = (Image)resources.GetObject("btnHome.Image");
            btnHome.ImageAlign = ContentAlignment.MiddleLeft;
            btnHome.Location = new Point(3, 3);
            btnHome.Name = "btnHome";
            btnHome.Padding = new Padding(15, 0, 0, 0);
            btnHome.Size = new Size(380, 62);
            btnHome.TabIndex = 244;
            btnHome.Text = "         HOME";
            btnHome.TextAlign = ContentAlignment.MiddleLeft;
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            // 
            // btnQueue
            // 
            btnQueue.BackColor = Color.FromArgb(45, 45, 45);
            btnQueue.FlatAppearance.BorderSize = 0;
            btnQueue.FlatAppearance.MouseDownBackColor = SystemColors.WindowFrame;
            btnQueue.FlatAppearance.MouseOverBackColor = SystemColors.Highlight;
            btnQueue.FlatStyle = FlatStyle.Flat;
            btnQueue.ForeColor = Color.White;
            btnQueue.Image = (Image)resources.GetObject("btnQueue.Image");
            btnQueue.ImageAlign = ContentAlignment.MiddleLeft;
            btnQueue.Location = new Point(3, 71);
            btnQueue.Name = "btnQueue";
            btnQueue.Padding = new Padding(15, 0, 0, 0);
            btnQueue.Size = new Size(380, 62);
            btnQueue.TabIndex = 246;
            btnQueue.Text = "         Queue";
            btnQueue.TextAlign = ContentAlignment.MiddleLeft;
            btnQueue.UseVisualStyleBackColor = false;
            btnQueue.Click += btnQueue_Click_1;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.FromArgb(45, 45, 45);
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatAppearance.MouseDownBackColor = SystemColors.WindowFrame;
            btnSettings.FlatAppearance.MouseOverBackColor = SystemColors.Highlight;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.ForeColor = Color.White;
            btnSettings.ImageAlign = ContentAlignment.MiddleLeft;
            btnSettings.Location = new Point(3, 139);
            btnSettings.Name = "btnSettings";
            btnSettings.Padding = new Padding(15, 0, 0, 0);
            btnSettings.Size = new Size(380, 62);
            btnSettings.TabIndex = 247;
            btnSettings.Text = "         Settings";
            btnSettings.TextAlign = ContentAlignment.MiddleLeft;
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(45, 45, 45);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatAppearance.MouseDownBackColor = SystemColors.WindowFrame;
            btnLogout.FlatAppearance.MouseOverBackColor = SystemColors.Highlight;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = Color.White;
            btnLogout.Image = (Image)resources.GetObject("btnLogout.Image");
            btnLogout.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogout.Location = new Point(3, 207);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(15, 0, 0, 0);
            btnLogout.Size = new Size(380, 62);
            btnLogout.TabIndex = 245;
            btnLogout.Text = "         Log out";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(233, 233, 233);
            panel6.Controls.Add(menuStripSettings);
            panel6.Controls.Add(lblTimenow);
            panel6.Controls.Add(lblDate);
            panel6.Controls.Add(lblTime);
            panel6.Location = new Point(389, 105);
            panel6.Name = "panel6";
            panel6.Size = new Size(1531, 51);
            panel6.TabIndex = 21;
            // 
            // lblTimenow
            // 
            lblTimenow.AutoSize = true;
            lblTimenow.Font = new Font("Microsoft YaHei UI", 10.2F);
            lblTimenow.ForeColor = Color.FromArgb(64, 64, 64);
            lblTimenow.Location = new Point(1390, 15);
            lblTimenow.Name = "lblTimenow";
            lblTimenow.Size = new Size(119, 23);
            lblTimenow.TabIndex = 49;
            lblTimenow.Text = "Time:________";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Microsoft YaHei UI", 10.2F);
            lblDate.ForeColor = Color.FromArgb(64, 64, 64);
            lblDate.Location = new Point(1124, 15);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(124, 23);
            lblDate.TabIndex = 48;
            lblDate.Text = "Date:_________";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Microsoft Sans Serif", 12F);
            lblTime.ForeColor = Color.FromArgb(64, 64, 64);
            lblTime.Location = new Point(1765, 13);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(117, 25);
            lblTime.TabIndex = 47;
            lblTime.Text = "Time:_____";
            // 
            // timeDateTimer
            // 
            timeDateTimer.Tick += timeDateTimer_Tick;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblUser);
            panel2.Controls.Add(userButton);
            panel2.Location = new Point(3, 32);
            panel2.Name = "panel2";
            panel2.Size = new Size(394, 91);
            panel2.TabIndex = 2;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.BackColor = Color.Transparent;
            lblUser.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUser.ForeColor = Color.White;
            lblUser.Location = new Point(77, 26);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(75, 38);
            lblUser.TabIndex = 2;
            lblUser.Text = "User";
            // 
            // userButton
            // 
            userButton.Cursor = Cursors.Hand;
            userButton.Image = (Image)resources.GetObject("userButton.Image");
            userButton.Location = new Point(28, 32);
            userButton.Name = "userButton";
            userButton.Size = new Size(33, 31);
            userButton.SizeMode = PictureBoxSizeMode.StretchImage;
            userButton.TabIndex = 0;
            userButton.TabStop = false;
            // 
            // panelSideBar
            // 
            panelSideBar.BackColor = Color.FromArgb(45, 45, 45);
            panelSideBar.Controls.Add(panel2);
            panelSideBar.Controls.Add(flowLayoutPanel1);
            panelSideBar.Font = new Font("Arial Rounded MT Bold", 18F);
            panelSideBar.Location = new Point(0, 105);
            panelSideBar.Name = "panelSideBar";
            panelSideBar.Size = new Size(389, 976);
            panelSideBar.TabIndex = 22;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1920, 1080);
            Controls.Add(panelSideBar);
            Controls.Add(panel6);
            Controls.Add(mainPanel);
            Controls.Add(panelBlue);
            FormBorderStyle = FormBorderStyle.None;
            MainMenuStrip = menuStripSettings;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            Load += MainForm_Load;
            Shown += MainForm_Shown;
            panelBlue.ResumeLayout(false);
            panelBlue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            minExPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)close).EndInit();
            ((System.ComponentModel.ISupportInitialize)minimize).EndInit();
            menuStripSettings.ResumeLayout(false);
            menuStripSettings.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)userButton).EndInit();
            panelSideBar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBlue;
        private PictureBox pictureBox1;
        private Panel minExPanel;
        private PictureBox minimize;
        private Label label6;
        private Panel mainPanel;
        private Panel panel6;
        private Label lblDate;
        private Label lblTime;
        private System.Windows.Forms.Timer timeDateTimer;
        private PictureBox close;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel2;
        private PictureBox userButton;
        private Button btnHome;
        private Panel panelSideBar;
        private Button btnLogout;
        private Label lblTimenow;
        private Button btnQueue;
        private Label lblUser;
        private Button btnSettings;
        private MenuStrip menuStripSettings;
        private ToolStripMenuItem profileToolStripMenuItem;
        private ToolStripMenuItem addUserToolStripMenuItem;
        private ToolStripMenuItem recordToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem createToolStripMenuItem;
    }
}