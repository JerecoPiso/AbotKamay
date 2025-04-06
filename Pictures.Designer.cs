namespace Abot_Kamay_Tracking_and_Queuing_System
{
    partial class Pictures
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
            label2 = new Label();
            label1 = new Label();
            btnAddNew = new Button();
            date_to = new DateTimePicker();
            date_from = new DateTimePicker();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(23, 89);
            label2.Name = "label2";
            label2.Size = new Size(28, 23);
            label2.TabIndex = 24;
            label2.Text = "To";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(23, 18);
            label1.Name = "label1";
            label1.Size = new Size(52, 23);
            label1.TabIndex = 23;
            label1.Text = "From";
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
            btnAddNew.Location = new Point(22, 163);
            btnAddNew.Name = "btnAddNew";
            btnAddNew.Size = new Size(250, 35);
            btnAddNew.TabIndex = 22;
            btnAddNew.Text = "GENERATE";
            btnAddNew.UseVisualStyleBackColor = false;
            btnAddNew.Click += btnAddNew_Click;
            // 
            // date_to
            // 
            date_to.Location = new Point(22, 115);
            date_to.Name = "date_to";
            date_to.Size = new Size(250, 27);
            date_to.TabIndex = 21;
            // 
            // date_from
            // 
            date_from.Location = new Point(22, 48);
            date_from.Name = "date_from";
            date_from.Size = new Size(250, 27);
            date_from.TabIndex = 20;
            // 
            // Pictures
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(292, 219);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnAddNew);
            Controls.Add(date_to);
            Controls.Add(date_from);
            Name = "Pictures";
            Text = "Pictures";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label label1;
        private Button btnAddNew;
        private DateTimePicker date_to;
        private DateTimePicker date_from;
    }
}