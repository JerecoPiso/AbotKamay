namespace Abot_Kamay_Tracking_and_Queuing_System
{
    partial class Step5Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Step5Form));
            panel1 = new Panel();
            panel2 = new Panel();
            pbCamera = new PictureBox();
            btnPreview = new Button();
            btnBack = new Button();
            btnCapture = new Button();
            cmbCameras = new ComboBox();
            timeDateTimer = new System.Windows.Forms.Timer(components);
            label6 = new Label();
            lblGetName = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbCamera).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(206, 206, 206);
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.Controls.Add(lblGetName);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(cmbCameras);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1530, 926);
            panel1.TabIndex = 39;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(216, 216, 216);
            panel2.Controls.Add(pbCamera);
            panel2.Controls.Add(btnPreview);
            panel2.Controls.Add(btnBack);
            panel2.Controls.Add(btnCapture);
            panel2.Location = new Point(129, 86);
            panel2.Name = "panel2";
            panel2.Size = new Size(1282, 767);
            panel2.TabIndex = 241;
            // 
            // pbCamera
            // 
            pbCamera.BackColor = SystemColors.WindowText;
            pbCamera.ImageLocation = "";
            pbCamera.Location = new Point(86, 28);
            pbCamera.Name = "pbCamera";
            pbCamera.Size = new Size(1115, 649);
            pbCamera.TabIndex = 236;
            pbCamera.TabStop = false;
            // 
            // btnPreview
            // 
            btnPreview.BackColor = Color.FromArgb(0, 99, 177);
            btnPreview.FlatAppearance.BorderSize = 0;
            btnPreview.FlatStyle = FlatStyle.Flat;
            btnPreview.Font = new Font("Microsoft Sans Serif", 13.8F);
            btnPreview.ForeColor = Color.White;
            btnPreview.Image = (Image)resources.GetObject("btnPreview.Image");
            btnPreview.ImageAlign = ContentAlignment.MiddleLeft;
            btnPreview.Location = new Point(87, 697);
            btnPreview.Name = "btnPreview";
            btnPreview.Size = new Size(158, 45);
            btnPreview.TabIndex = 235;
            btnPreview.Text = "   PREVIEW";
            btnPreview.UseVisualStyleBackColor = false;
            btnPreview.Click += btnPreview_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(0, 99, 177);
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Microsoft Sans Serif", 13.8F);
            btnBack.ForeColor = Color.White;
            btnBack.Image = (Image)resources.GetObject("btnBack.Image");
            btnBack.ImageAlign = ContentAlignment.MiddleLeft;
            btnBack.Location = new Point(1056, 697);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(145, 45);
            btnBack.TabIndex = 238;
            btnBack.Text = "   BACK";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // btnCapture
            // 
            btnCapture.BackColor = Color.FromArgb(0, 99, 177);
            btnCapture.FlatAppearance.BorderSize = 0;
            btnCapture.FlatStyle = FlatStyle.Flat;
            btnCapture.Font = new Font("Microsoft Sans Serif", 13.8F);
            btnCapture.ForeColor = Color.White;
            btnCapture.Image = (Image)resources.GetObject("btnCapture.Image");
            btnCapture.ImageAlign = ContentAlignment.MiddleLeft;
            btnCapture.Location = new Point(260, 697);
            btnCapture.Name = "btnCapture";
            btnCapture.Size = new Size(158, 45);
            btnCapture.TabIndex = 237;
            btnCapture.Text = "   CAPTURE";
            btnCapture.UseVisualStyleBackColor = false;
            btnCapture.Click += btnCapture_Click;
            // 
            // cmbCameras
            // 
            cmbCameras.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCameras.Font = new Font("Microsoft Sans Serif", 13.8F);
            cmbCameras.FormattingEnabled = true;
            cmbCameras.Items.AddRange(new object[] { "Internal Camera", "External Camera" });
            cmbCameras.Location = new Point(1034, 43);
            cmbCameras.Name = "cmbCameras";
            cmbCameras.Size = new Size(377, 37);
            cmbCameras.TabIndex = 239;
            cmbCameras.SelectedIndexChanged += cmbCameras_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.White;
            label6.Font = new Font("Tahoma", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(686, 25);
            label6.Name = "label6";
            label6.Size = new Size(178, 28);
            label6.TabIndex = 40;
            label6.Text = "DISBURSEMENT";
            // 
            // lblGetName
            // 
            lblGetName.AutoSize = true;
            lblGetName.BackColor = Color.White;
            lblGetName.Font = new Font("Verdana", 12F);
            lblGetName.ForeColor = SystemColors.ActiveCaptionText;
            lblGetName.Location = new Point(128, 43);
            lblGetName.Name = "lblGetName";
            lblGetName.Size = new Size(148, 25);
            lblGetName.TabIndex = 271;
            lblGetName.Text = "Name______";
            // 
            // Step5Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1531, 925);
            Controls.Add(label6);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Step5Form";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += Step5Form_FormClosing;
            Load += Step5Form_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbCamera).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private Button btnPreview;
        private PictureBox pbCamera;
        private Button btnCapture;
        private Button btnBack;
        private ComboBox cmbCameras;
        private System.Windows.Forms.Timer timeDateTimer;
        private Panel panel2;
        private Label label6;
        private Label lblGetName;
    }
}