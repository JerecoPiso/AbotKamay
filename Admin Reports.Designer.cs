namespace Abot_Kamay_Tracking_and_Queuing_System
{
    partial class ReportsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportsForm));
            panel1 = new Panel();
            groupBox1 = new GroupBox();
            txtFirstName = new TextBox();
            label6 = new Label();
            lblLastName = new Label();
            txtLastname = new TextBox();
            button3 = new Button();
            panelBlue = new Panel();
            minExPanel = new Panel();
            close = new PictureBox();
            minimize = new PictureBox();
            groupBox2 = new GroupBox();
            dateTimePicker2 = new DateTimePicker();
            label3 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label2 = new Label();
            label1 = new Label();
            comboBox1 = new ComboBox();
            label4 = new Label();
            lblCurrentQueue = new Label();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            panelBlue.SuspendLayout();
            minExPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)close).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minimize).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(panelBlue);
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(lblCurrentQueue);
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(-2, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1341, 736);
            panel1.TabIndex = 7;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtFirstName);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(lblLastName);
            groupBox1.Controls.Add(txtLastname);
            groupBox1.Font = new Font("Arial", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = SystemColors.ControlDarkDark;
            groupBox1.Location = new Point(596, 148);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(424, 126);
            groupBox1.TabIndex = 41;
            groupBox1.TabStop = false;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(195, 34);
            txtFirstName.Multiline = true;
            txtFirstName.Name = "txtFirstName";
            txtFirstName.ReadOnly = true;
            txtFirstName.Size = new Size(205, 30);
            txtFirstName.TabIndex = 28;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 10F);
            label6.ForeColor = SystemColors.ActiveCaptionText;
            label6.Image = (Image)resources.GetObject("label6.Image");
            label6.ImageAlign = ContentAlignment.MiddleRight;
            label6.Location = new Point(58, 40);
            label6.Name = "label6";
            label6.Size = new Size(129, 20);
            label6.TabIndex = 27;
            label6.Text = "Total Budget:    ";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Microsoft Sans Serif", 10F);
            lblLastName.ForeColor = SystemColors.ActiveCaptionText;
            lblLastName.Image = (Image)resources.GetObject("lblLastName.Image");
            lblLastName.ImageAlign = ContentAlignment.MiddleRight;
            lblLastName.Location = new Point(17, 76);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(171, 20);
            lblLastName.TabIndex = 27;
            lblLastName.Text = "Remaining Budget:    ";
            // 
            // txtLastname
            // 
            txtLastname.Location = new Point(195, 70);
            txtLastname.Multiline = true;
            txtLastname.Name = "txtLastname";
            txtLastname.ReadOnly = true;
            txtLastname.Size = new Size(205, 30);
            txtLastname.TabIndex = 28;
            // 
            // button3
            // 
            button3.BackColor = Color.Navy;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Arial Rounded MT Bold", 9F);
            button3.ForeColor = Color.White;
            button3.Location = new Point(804, 674);
            button3.Name = "button3";
            button3.Size = new Size(192, 35);
            button3.TabIndex = 44;
            button3.Text = "GENERATE REPORT";
            button3.UseVisualStyleBackColor = false;
            // 
            // panelBlue
            // 
            panelBlue.BackColor = Color.MidnightBlue;
            panelBlue.Controls.Add(minExPanel);
            panelBlue.Location = new Point(-1, 737);
            panelBlue.Name = "panelBlue";
            panelBlue.Size = new Size(1070, 28);
            panelBlue.TabIndex = 31;
            // 
            // minExPanel
            // 
            minExPanel.Controls.Add(close);
            minExPanel.Controls.Add(minimize);
            minExPanel.Location = new Point(1280, -7);
            minExPanel.Name = "minExPanel";
            minExPanel.Size = new Size(63, 34);
            minExPanel.TabIndex = 11;
            // 
            // close
            // 
            close.Image = (Image)resources.GetObject("close.Image");
            close.Location = new Point(38, -2);
            close.Name = "close";
            close.Size = new Size(18, 22);
            close.TabIndex = 1;
            close.TabStop = false;
            // 
            // minimize
            // 
            minimize.Image = (Image)resources.GetObject("minimize.Image");
            minimize.Location = new Point(3, -7);
            minimize.Name = "minimize";
            minimize.Size = new Size(18, 22);
            minimize.TabIndex = 0;
            minimize.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dateTimePicker2);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(dateTimePicker1);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(comboBox1);
            groupBox2.Controls.Add(label4);
            groupBox2.Font = new Font("Arial", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox2.ForeColor = SystemColors.ControlDarkDark;
            groupBox2.Location = new Point(80, 99);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(474, 175);
            groupBox2.TabIndex = 26;
            groupBox2.TabStop = false;
            groupBox2.Text = "Filters: ";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Font = new Font("Microsoft Sans Serif", 10F);
            dateTimePicker2.Location = new Point(340, 40);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(100, 26);
            dateTimePicker2.TabIndex = 36;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 10F);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(311, 44);
            label3.Name = "label3";
            label3.Size = new Size(28, 20);
            label3.TabIndex = 35;
            label3.Text = "To";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Microsoft Sans Serif", 10F);
            dateTimePicker1.Location = new Point(205, 40);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(100, 26);
            dateTimePicker1.TabIndex = 34;
            dateTimePicker1.Value = new DateTime(2024, 3, 19, 10, 37, 0, 0);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 10F);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(156, 44);
            label2.Name = "label2";
            label2.Size = new Size(48, 20);
            label2.TabIndex = 32;
            label2.Text = "From";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10F);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(34, 44);
            label1.Name = "label1";
            label1.Size = new Size(103, 20);
            label1.TabIndex = 31;
            label1.Text = "Date Range:";
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Microsoft Sans Serif", 10F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "All", "Hospital Bill", "Laboratory Tests", "Prescription", "Hemodialysis", "Chemotherapy", "Burial Cost" });
            comboBox1.Location = new Point(204, 84);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(235, 28);
            comboBox1.TabIndex = 30;
            comboBox1.Text = "Select";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 10F);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(34, 87);
            label4.Name = "label4";
            label4.Size = new Size(157, 20);
            label4.TabIndex = 29;
            label4.Text = "Type of Assistance:";
            // 
            // lblCurrentQueue
            // 
            lblCurrentQueue.AutoSize = true;
            lblCurrentQueue.Font = new Font("Arial", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCurrentQueue.ForeColor = Color.Black;
            lblCurrentQueue.Location = new Point(71, 45);
            lblCurrentQueue.Name = "lblCurrentQueue";
            lblCurrentQueue.Size = new Size(231, 21);
            lblCurrentQueue.TabIndex = 25;
            lblCurrentQueue.Text = "Financial Assistance Report";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(80, 312);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(916, 344);
            dataGridView1.TabIndex = 17;
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1093, 750);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ReportsForm";
            Text = "Reports";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panelBlue.ResumeLayout(false);
            minExPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)close).EndInit();
            ((System.ComponentModel.ISupportInitialize)minimize).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Panel panelBlue;
        private Panel minExPanel;
        private PictureBox close;
        private PictureBox minimize;
        private GroupBox groupBox2;
        private ComboBox comboBox1;
        private Label label4;
        private TextBox txtLastname;
        private Label lblLastName;
        private TextBox txtFirstName;
        private Label label6;
        private Label lblCurrentQueue;
        private DataGridView dataGridView1;
        private Button button3;
        private Label label2;
        private Label label1;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label label3;
        private GroupBox groupBox1;
    }
}