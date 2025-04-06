namespace Abot_Kamay_Tracking_and_Queuing_System
{
    partial class SummaryDisbursementOfAICS
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
            dateFrom = new DateTimePicker();
            dateTo = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            BtnGenerate = new Button();
            SuspendLayout();
            // 
            // dateFrom
            // 
            dateFrom.Location = new Point(28, 49);
            dateFrom.Name = "dateFrom";
            dateFrom.Size = new Size(250, 27);
            dateFrom.TabIndex = 0;
            // 
            // dateTo
            // 
            dateTo.Location = new Point(28, 116);
            dateTo.Name = "dateTo";
            dateTo.Size = new Size(250, 27);
            dateTo.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(29, 19);
            label1.Name = "label1";
            label1.Size = new Size(52, 23);
            label1.TabIndex = 18;
            label1.Text = "From";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(29, 90);
            label2.Name = "label2";
            label2.Size = new Size(28, 23);
            label2.TabIndex = 19;
            label2.Text = "To";
            label2.Click += label2_Click;
            // 
            // BtnGenerate
            // 
            BtnGenerate.BackColor = SystemColors.Highlight;
            BtnGenerate.CausesValidation = false;
            BtnGenerate.FlatStyle = FlatStyle.Popup;
            BtnGenerate.ForeColor = SystemColors.Control;
            BtnGenerate.Location = new Point(29, 163);
            BtnGenerate.Name = "BtnGenerate";
            BtnGenerate.Size = new Size(249, 40);
            BtnGenerate.TabIndex = 20;
            BtnGenerate.Text = "Generate";
            BtnGenerate.UseVisualStyleBackColor = false;
            BtnGenerate.Click += button1_Click;
            // 
            // SummaryDisbursementOfAICS
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(309, 229);
            Controls.Add(BtnGenerate);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dateTo);
            Controls.Add(dateFrom);
            MaximizeBox = false;
            Name = "SummaryDisbursementOfAICS";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SummaryDisbursementOfAICS";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateFrom;
        private DateTimePicker dateTo;
        private Label label1;
        private Label label2;
        private Button BtnGenerate;
    }
}