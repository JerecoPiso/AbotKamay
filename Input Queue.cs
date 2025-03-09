using Abot_Kamay_Tracking_and_Queuing_System.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Runtime.CompilerServices;
using System.Diagnostics;


namespace Abot_Kamay_Tracking_and_Queuing_System
{
    public partial class InputQueueForm : Form
    {

        // This static flag will be used to track if QueueForm is open
        public static bool isQueueFormOpen = false;

        private static System.Timers.Timer queueUpdateTimer;

        public InputQueueForm()
        {
            InitializeComponent();

            queueUpdateTimer = new System.Timers.Timer(1000); // Update every 2 second
            queueUpdateTimer.Elapsed += (sender, e) => LoadQueueNumbers();
            queueUpdateTimer.AutoReset = true;
            queueUpdateTimer.Enabled = true;
        }

        private void LoadQueueNumbers()
        {
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = "SELECT queue_number FROM Queue WHERE step = 2 AND status = 'Waiting' ORDER BY queue_number ASC LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                object result = cmd.ExecuteScalar();

                if (lblNumInput.InvokeRequired)
                {
                    lblNumInput.Invoke(new Action(() => lblNumInput.Text = result?.ToString() ?? "-"));
                }
                else
                {
                    lblNumInput.Text = result?.ToString() ?? "-";
                }
            }
        }
        

        private void btnAddQueue_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtInputNum.Text, out int queueNumber) || queueNumber <= 0)
            {
                MessageBox.Show("Enter a valid queue number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                string insertQuery = "INSERT INTO Queue (queue_number, step, status) VALUES (@queueNumber, 2, 'Waiting')";
                MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@queueNumber", queueNumber);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show($"Queue number {queueNumber} added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtInputNum.Clear();
            LoadQueueNumbers();  // Refresh queue display
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                string deleteQuery = "DELETE FROM Queue WHERE step = 2 AND status = 'Waiting' ORDER BY queue_id DESC LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(deleteQuery, conn);
                int affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    MessageBox.Show("Last queue number removed.", "Undo Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No queue numbers to remove.", "Undo Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            LoadQueueNumbers();  // Refresh queue display
        }

        private void btnQueueDisplay_Click(object sender, EventArgs e)
        {
            if (!isQueueFormOpen)
            {
                QueueForm queueForm = new QueueForm();
                queueForm.FormClosed += QueueForm_FormClosed;
                queueForm.Show();
                isQueueFormOpen = true;
            }
            else
            {
                MessageBox.Show("Queue display is already open.", "Queue", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Event handler to track when QueueForm is closed
        private void QueueForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            isQueueFormOpen = false; // Reset the flag when QueueForm is closed
        }


    }
}
