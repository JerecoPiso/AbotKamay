namespace Abot_Kamay_Tracking_and_Queuing_System
{
    partial class CounterQueueForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CounterQueueForm));
            groupBox1 = new GroupBox();
            panelQueue = new Panel();
            panel8 = new Panel();
            lblStep = new Label();
            lblNumThree = new Label();
            btnPrevious = new Button();
            btnNext = new Button();
            groupBox1.SuspendLayout();
            panelQueue.SuspendLayout();
            panel8.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(panelQueue);
            groupBox1.Controls.Add(btnPrevious);
            groupBox1.Controls.Add(btnNext);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.Gray;
            groupBox1.Location = new Point(23, 18);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(363, 416);
            groupBox1.TabIndex = 228;
            groupBox1.TabStop = false;
            groupBox1.UseWaitCursor = true;
            // 
            // panelQueue
            // 
            panelQueue.BackColor = Color.FromArgb(216, 216, 216);
            panelQueue.Controls.Add(panel8);
            panelQueue.Controls.Add(lblNumThree);
            panelQueue.ForeColor = Color.FromArgb(216, 216, 216);
            panelQueue.Location = new Point(15, 30);
            panelQueue.Name = "panelQueue";
            panelQueue.Size = new Size(336, 304);
            panelQueue.TabIndex = 44;
            panelQueue.UseWaitCursor = true;
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(47, 126, 189);
            panel8.Controls.Add(lblStep);
            panel8.Location = new Point(1, 1);
            panel8.Name = "panel8";
            panel8.Size = new Size(335, 55);
            panel8.TabIndex = 20;
            panel8.UseWaitCursor = true;
            // 
            // lblStep
            // 
            lblStep.Anchor = AnchorStyles.Bottom;
            lblStep.AutoSize = true;
            lblStep.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStep.ForeColor = Color.White;
            lblStep.Location = new Point(114, 6);
            lblStep.Name = "lblStep";
            lblStep.Size = new Size(101, 41);
            lblStep.TabIndex = 229;
            lblStep.Text = "Step _";
            lblStep.UseWaitCursor = true;
            // 
            // lblNumThree
            // 
            lblNumThree.Anchor = AnchorStyles.Bottom;
            lblNumThree.AutoSize = true;
            lblNumThree.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNumThree.ForeColor = Color.FromArgb(47, 126, 189);
            lblNumThree.Location = new Point(143, 138);
            lblNumThree.Name = "lblNumThree";
            lblNumThree.Size = new Size(42, 62);
            lblNumThree.TabIndex = 228;
            lblNumThree.Text = "I";
            lblNumThree.UseWaitCursor = true;
            // 
            // btnPrevious
            // 
            btnPrevious.BackColor = Color.FromArgb(0, 99, 177);
            btnPrevious.FlatAppearance.BorderSize = 0;
            btnPrevious.FlatStyle = FlatStyle.Flat;
            btnPrevious.Font = new Font("Arial Rounded MT Bold", 9F);
            btnPrevious.ForeColor = Color.White;
            btnPrevious.Image = (Image)resources.GetObject("btnPrevious.Image");
            btnPrevious.ImageAlign = ContentAlignment.MiddleLeft;
            btnPrevious.Location = new Point(16, 362);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(137, 36);
            btnPrevious.TabIndex = 43;
            btnPrevious.Text = "   PREVIOUS";
            btnPrevious.UseVisualStyleBackColor = false;
            btnPrevious.UseWaitCursor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.FromArgb(0, 99, 177);
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Font = new Font("Arial Rounded MT Bold", 9F);
            btnNext.ForeColor = Color.White;
            btnNext.Image = (Image)resources.GetObject("btnNext.Image");
            btnNext.ImageAlign = ContentAlignment.MiddleRight;
            btnNext.Location = new Point(236, 362);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(115, 36);
            btnNext.TabIndex = 41;
            btnNext.Text = "NEXT   ";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.UseWaitCursor = true;
            btnNext.Click += btnNext_Click;
            // 
            // CounterQueueForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(233, 233, 233);
            ClientSize = new Size(409, 460);
            Controls.Add(groupBox1);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "CounterQueueForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Current Queue";
            UseWaitCursor = true;
            Load += CounterQueueForm_Load;
            groupBox1.ResumeLayout(false);
            panelQueue.ResumeLayout(false);
            panelQueue.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Panel panelQueue;
        private Panel panel8;
        private Label lblNumThree;
        private Button btnPrevious;
        private Button btnNext;
        private Label lblStep;
    }
}