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

namespace Abot_Kamay_Tracking_and_Queuing_System
{
    public partial class CounterQueueForm : Form
    {
        public int StepNumber { get; set; } // Step number for the current role

        public CounterQueueForm(int step)
        {
            InitializeComponent();
            StepNumber = step;
            lblStep.Text = $"Step {StepNumber}";
            LoadQueue();
        }

        private void LoadQueue()
        {
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                //conn.Open();

                string query = "SELECT queue_number FROM Queue WHERE step = @step AND status = 'Serving' ORDER BY queue_number ASC LIMIT 1";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@step", StepNumber);
                    object result = cmd.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                    {
                        MessageBox.Show("No queue numbers found for this step.", "Queue Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblNumThree.Text = "-";
                    }
                    else
                    {
                        lblNumThree.Text = result.ToString();
                    }
                }
            }
        }


        private void CounterQueueForm_Load(object sender, EventArgs e)
        {
            lblStep.Text = $"Step {StepNumber}";
            //UpdateQueueNumber();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {

                // 1️⃣ Mark the current "Serving" number as "Completed"
                string completeQuery = "UPDATE Queue SET status = 'Completed' WHERE step = @step AND status = 'Serving' ORDER BY queue_number ASC LIMIT 1";
                using (MySqlCommand completeCmd = new MySqlCommand(completeQuery, conn))
                {
                    completeCmd.Parameters.AddWithValue("@step", StepNumber);
                    completeCmd.ExecuteNonQuery();
                }

                // 2️⃣ Move the next "Waiting" queue number to "Serving"
                string updateQuery = "UPDATE Queue SET status = 'Serving' WHERE step = @step AND status = 'Waiting' ORDER BY queue_number ASC LIMIT 1";
                using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn))
                {
                    updateCmd.Parameters.AddWithValue("@step", StepNumber);
                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    // If no new number moved to "Serving", show a message
                    if (rowsAffected == 0)
                    {
                        MessageBox.Show("No more waiting queue numbers for this step.", "Queue Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            // Refresh the queue display
            LoadQueue();

            // Update QueueForm if it's open
            if (Application.OpenForms["QueueForm"] is QueueForm queueForm)
            {
                queueForm.UpdateQueueNumbers();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                string updateQuery = "UPDATE Queue SET step = step - 1 WHERE step = @step AND status = 'Waiting' ORDER BY queue_number DESC LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@step", StepNumber);
                cmd.ExecuteNonQuery();
            }

            LoadQueue();

            if (Application.OpenForms["QueueForm"] is QueueForm queueForm)
            {
                queueForm.UpdateQueueNumbers();
            }
        }




    }
}
