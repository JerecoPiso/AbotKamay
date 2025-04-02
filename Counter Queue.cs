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
               
                string query = "SELECT queue_number FROM Queue WHERE step = @step AND status = '"+(StepNumber == 3 ? "Waiting" : "Completed") +"' AND hold = 0 AND done = 0 ORDER BY queue_number ASC LIMIT 1";
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
                if (!lblNumThree.Text.Equals("-"))
                {
                    string updateQuery = "UPDATE Queue SET status = 'Serving', hold = 1 WHERE queue_number = @queue_number AND status = '"+(StepNumber == 3 ? "Waiting" : "Completed") +"' ORDER BY queue_number ASC LIMIT 1";
                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@queue_number", Int32.Parse(lblNumThree.Text));
                        updateCmd.ExecuteNonQuery();
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

                if (!lblNumThree.Text.Equals("-"))
                {
                    string completeQuery = "";
                    // 1️⃣ Mark the current "Serving" number as "Completed"
                    if (StepNumber == 5)
                    {
                         completeQuery = "UPDATE Queue SET status = 'Completed', hold = 0, done = 1 +, step = step + 1 WHERE queue_number = @queue_number AND done = 0 AND status = 'Serving' ORDER BY queue_number ASC LIMIT 1";
                         using (MySqlCommand completeCmd = new MySqlCommand(completeQuery, conn))
                         {  completeCmd.Parameters.AddWithValue("@queue_number", Int32.Parse(lblNumThree.Text));
                            completeCmd.ExecuteNonQuery();
                         }
                    }
                    else
                    {
                        completeQuery = "UPDATE Queue SET status = 'Completed', hold = 0, step = step + 1 WHERE queue_number = @queue_number AND status = 'Serving' ORDER BY queue_number ASC LIMIT 1";
                        using (MySqlCommand completeCmd = new MySqlCommand(completeQuery, conn))
                        {
                            completeCmd.Parameters.AddWithValue("@queue_number", Int32.Parse(lblNumThree.Text));
                            completeCmd.ExecuteNonQuery();
                        }
                    }
                  
                }
               

                // 2️⃣ Move the next "Waiting" queue number to "Serving"
                string updateQuery = "UPDATE Queue SET status = 'Serving', hold = 1 WHERE step = @step AND status = '"+(StepNumber == 3 ? "Waiting" : "Completed") +"' ORDER BY queue_number ASC LIMIT 1";
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
            if (!lblNumThree.Text.Equals("-"))
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string updateQuery = "UPDATE Queue SET step = step - 1 WHERE queue_number = @queue_number AND status = '" + (StepNumber == 3 ? "Waiting" : "Completed") + "' ORDER BY queue_number DESC LIMIT 1";
                    MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@step", Int32.Parse(lblNumThree.Text));
                    cmd.ExecuteNonQuery();
                }
            }
            LoadQueue();

            if (Application.OpenForms["QueueForm"] is QueueForm queueForm)
            {
                queueForm.UpdateQueueNumbers();
            }
        }
    }
}
