namespace Abot_Kamay_Tracking_and_Queuing_System
{
    partial class InputQueueForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputQueueForm));
            btnQueueDisplay = new Button();
            lblDisplayCamera = new Label();
            panel2 = new Panel();
            txtInputNum = new TextBox();
            panelQueue = new Panel();
            lblNumInput = new Label();
            panel8 = new Panel();
            lblWaiting = new Label();
            panel1 = new Panel();
            label1 = new Label();
            btnAddQueue = new Button();
            btnUndo = new Button();
            panel2.SuspendLayout();
            panelQueue.SuspendLayout();
            panel8.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnQueueDisplay
            // 
            btnQueueDisplay.BackColor = Color.FromArgb(0, 99, 177);
            btnQueueDisplay.FlatAppearance.BorderSize = 0;
            btnQueueDisplay.FlatAppearance.MouseDownBackColor = Color.Blue;
            btnQueueDisplay.FlatAppearance.MouseOverBackColor = Color.Blue;
            btnQueueDisplay.FlatStyle = FlatStyle.Flat;
            btnQueueDisplay.Font = new Font("Arial Rounded MT Bold", 9F);
            btnQueueDisplay.ForeColor = Color.White;
            btnQueueDisplay.Image = (Image)resources.GetObject("btnQueueDisplay.Image");
            btnQueueDisplay.ImageAlign = ContentAlignment.MiddleLeft;
            btnQueueDisplay.Location = new Point(383, 31);
            btnQueueDisplay.Name = "btnQueueDisplay";
            btnQueueDisplay.Size = new Size(32, 28);
            btnQueueDisplay.TabIndex = 244;
            btnQueueDisplay.UseVisualStyleBackColor = false;
            btnQueueDisplay.Click += btnQueueDisplay_Click;
            // 
            // lblDisplayCamera
            // 
            lblDisplayCamera.AutoSize = true;
            lblDisplayCamera.BackColor = Color.Transparent;
            lblDisplayCamera.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblDisplayCamera.ForeColor = Color.FromArgb(64, 64, 64);
            lblDisplayCamera.Location = new Point(253, 35);
            lblDisplayCamera.Name = "lblDisplayCamera";
            lblDisplayCamera.Size = new Size(124, 20);
            lblDisplayCamera.TabIndex = 243;
            lblDisplayCamera.Text = "Display Queue:";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(216, 216, 216);
            panel2.Controls.Add(txtInputNum);
            panel2.Location = new Point(42, 88);
            panel2.Name = "panel2";
            panel2.Size = new Size(277, 245);
            panel2.TabIndex = 257;
            panel2.UseWaitCursor = true;
            // 
            // txtInputNum
            // 
            txtInputNum.Font = new Font("Verdana", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtInputNum.ForeColor = Color.FromArgb(47, 126, 189);
            txtInputNum.Location = new Point(32, 106);
            txtInputNum.Multiline = true;
            txtInputNum.Name = "txtInputNum";
            txtInputNum.Size = new Size(216, 86);
            txtInputNum.TabIndex = 208;
            txtInputNum.TextAlign = HorizontalAlignment.Center;
            txtInputNum.UseWaitCursor = true;
            // 
            // panelQueue
            // 
            panelQueue.BackColor = Color.FromArgb(216, 216, 216);
            panelQueue.Controls.Add(panel8);
            panelQueue.Controls.Add(lblNumInput);
            panelQueue.ForeColor = Color.FromArgb(216, 216, 216);
            panelQueue.Location = new Point(352, 88);
            panelQueue.Name = "panelQueue";
            panelQueue.Size = new Size(289, 304);
            panelQueue.TabIndex = 44;
            panelQueue.UseWaitCursor = true;
            // 
            // lblNumInput
            // 
            lblNumInput.Anchor = AnchorStyles.Bottom;
            lblNumInput.AutoSize = true;
            lblNumInput.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNumInput.ForeColor = Color.FromArgb(47, 126, 189);
            lblNumInput.Location = new Point(125, 131);
            lblNumInput.Name = "lblNumInput";
            lblNumInput.Size = new Size(42, 62);
            lblNumInput.TabIndex = 228;
            lblNumInput.Text = "I";
            lblNumInput.UseWaitCursor = true;
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(47, 126, 189);
            panel8.Controls.Add(lblWaiting);
            panel8.Location = new Point(1, 1);
            panel8.Name = "panel8";
            panel8.Size = new Size(288, 56);
            panel8.TabIndex = 20;
            panel8.UseWaitCursor = true;
            // 
            // lblWaiting
            // 
            lblWaiting.Anchor = AnchorStyles.Bottom;
            lblWaiting.AutoSize = true;
            lblWaiting.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWaiting.ForeColor = Color.White;
            lblWaiting.Location = new Point(79, 8);
            lblWaiting.Name = "lblWaiting";
            lblWaiting.Size = new Size(154, 41);
            lblWaiting.TabIndex = 229;
            lblWaiting.Text = "Waiting...";
            lblWaiting.UseWaitCursor = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(47, 126, 189);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(42, 88);
            panel1.Name = "panel1";
            panel1.Size = new Size(277, 56);
            panel1.TabIndex = 230;
            panel1.UseWaitCursor = true;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(41, 11);
            label1.Name = "label1";
            label1.Size = new Size(208, 38);
            label1.TabIndex = 229;
            label1.Text = "Input number:";
            label1.UseWaitCursor = true;
            // 
            // btnAddQueue
            // 
            btnAddQueue.BackColor = Color.FromArgb(0, 99, 177);
            btnAddQueue.FlatAppearance.BorderSize = 0;
            btnAddQueue.FlatStyle = FlatStyle.Flat;
            btnAddQueue.Font = new Font("Arial Rounded MT Bold", 9F);
            btnAddQueue.ForeColor = Color.White;
            btnAddQueue.Image = (Image)resources.GetObject("btnAddQueue.Image");
            btnAddQueue.ImageAlign = ContentAlignment.MiddleRight;
            btnAddQueue.Location = new Point(203, 356);
            btnAddQueue.Name = "btnAddQueue";
            btnAddQueue.Size = new Size(116, 36);
            btnAddQueue.TabIndex = 255;
            btnAddQueue.Text = "ADD";
            btnAddQueue.UseVisualStyleBackColor = false;
            btnAddQueue.UseWaitCursor = true;
            btnAddQueue.Click += btnAddQueue_Click;
            // 
            // btnUndo
            // 
            btnUndo.BackColor = Color.FromArgb(0, 99, 177);
            btnUndo.FlatAppearance.BorderSize = 0;
            btnUndo.FlatStyle = FlatStyle.Flat;
            btnUndo.Font = new Font("Arial Rounded MT Bold", 9F);
            btnUndo.ForeColor = Color.White;
            btnUndo.Image = (Image)resources.GetObject("btnUndo.Image");
            btnUndo.ImageAlign = ContentAlignment.MiddleLeft;
            btnUndo.Location = new Point(42, 356);
            btnUndo.Name = "btnUndo";
            btnUndo.Size = new Size(115, 36);
            btnUndo.TabIndex = 256;
            btnUndo.Text = "   UNDO";
            btnUndo.UseVisualStyleBackColor = false;
            btnUndo.UseWaitCursor = true;
            btnUndo.Click += btnUndo_Click;
            // 
            // InputQueueForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(678, 434);
            Controls.Add(btnUndo);
            Controls.Add(btnQueueDisplay);
            Controls.Add(btnAddQueue);
            Controls.Add(lblDisplayCamera);
            Controls.Add(panel1);
            Controls.Add(panelQueue);
            Controls.Add(panel2);
            Name = "InputQueueForm";
            StartPosition = FormStartPosition.CenterScreen;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panelQueue.ResumeLayout(false);
            panelQueue.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnQueueDisplay;
        private Label lblDisplayCamera;
        private Panel panel2;
        private TextBox txtInputNum;
        private Panel panelQueue;
        private Panel panel8;
        private Label lblWaiting;
        private Label lblNumInput;
        private Panel panel1;
        private Label label1;
        private Button btnAddQueue;
        private Button btnUndo;
    }
}