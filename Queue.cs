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
using System.Diagnostics;

namespace Abot_Kamay_Tracking_and_Queuing_System
{
    public partial class QueueForm : Form
    {
        private static System.Timers.Timer queueUpdateTimer;

        public Point mouseLocation;
        private ToolTip dragToolTip;
        public QueueForm()
        {
            InitializeComponent();

            queueUpdateTimer = new System.Timers.Timer(2000); // Refresh queue numbers every 2 seconds
            queueUpdateTimer.Elapsed += (sender, e) => LoadQueueNumbers();
            queueUpdateTimer.AutoReset = true;
            queueUpdateTimer.Enabled = true;

            dragToolTip = new ToolTip();
            dragToolTip.IsBalloon = true; // Optional: Set it as a balloon tooltip
            dragToolTip.ShowAlways = true; // Ensure it stays visible while dragging

            LoadQueueNumbers();
        }

        // Load queue numbers from database
        private void LoadQueueNumbers()
        {
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                // Query for serving queue numbers (Steps 3-5)
                string queryServing = "SELECT step, queue_number FROM Queue WHERE status = 'Serving' AND step BETWEEN 3 AND 5 ORDER BY step ASC, queue_number ASC";
                MySqlCommand cmdServing = new MySqlCommand(queryServing, conn);
                MySqlDataAdapter adapterServing = new MySqlDataAdapter(cmdServing);
                DataTable dtServing = new DataTable();
                adapterServing.Fill(dtServing);

                // Query for waiting queue (Step 2)
                string queryWaiting = "SELECT queue_number FROM Queue WHERE step = 2 AND status = 'Waiting' ORDER BY queue_number ASC LIMIT 1";
                MySqlCommand cmdWaiting = new MySqlCommand(queryWaiting, conn);
                object resultWaiting = cmdWaiting.ExecuteScalar();

                // Update labels
                if (lblStep3Num.InvokeRequired)
                {
                    lblStep3Num.Invoke(new Action(() => lblStep3Num.Text = " "));
                    lblStep4Num.Invoke(new Action(() => lblStep4Num.Text = " "));
                    lblStep5Num.Invoke(new Action(() => lblStep5Num.Text = " "));
                    lblWaitNum.Invoke(new Action(() => lblWaitNum.Text = resultWaiting?.ToString() ?? "-"));

                    foreach (DataRow row in dtServing.Rows)
                    {
                        int step = Convert.ToInt32(row["step"]);
                        int queueNum = Convert.ToInt32(row["queue_number"]);

                        if (step == 3) lblStep3Num.Invoke(new Action(() => lblStep3Num.Text = queueNum.ToString()));
                        else if (step == 4) lblStep4Num.Invoke(new Action(() => lblStep4Num.Text = queueNum.ToString()));
                        else if (step == 5) lblStep5Num.Invoke(new Action(() => lblStep5Num.Text = queueNum.ToString()));
                    }
                }
                else
                {
                    lblStep3Num.Text = " ";
                    lblStep4Num.Text = " ";
                    lblStep5Num.Text = " ";
                    lblWaitNum.Text = resultWaiting?.ToString() ?? "-";

                    foreach (DataRow row in dtServing.Rows)
                    {
                        int step = Convert.ToInt32(row["step"]);
                        int queueNum = Convert.ToInt32(row["queue_number"]);

                        if (step == 3) lblStep3Num.Text = queueNum.ToString();
                        else if (step == 4) lblStep4Num.Text = queueNum.ToString();
                        else if (step == 5) lblStep5Num.Text = queueNum.ToString();
                    }
                }
            }
        }


        public void UpdateQueueNumbers()
        {
            LoadQueueNumbers();
        }


        private void queueForm_Load(object sender, EventArgs e)
        {
            timeDateTimer.Start();
        }

        private void timeDateTimer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            lblDate.Text = DateTime.Now.ToLongDateString();
        }



        private void panelBody_MouseDown(object sender, MouseEventArgs e)
        {
            // Display the tooltip when mouse is down
            dragToolTip.Show("Drag to the top-left corner to close.", this, e.Location.X, e.Location.Y - 30);


            // Store the mouse position relative to the form
            mouseLocation = new Point(-e.X, -e.Y);

            // If the form is maximized, restore it to normal state
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;

                // Adjust the mouse position after the form is restored
                mouseLocation = new Point(-e.X / 2, -e.Y / 2);
            }
        }

        private void panelBody_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Move the form based on the mouse movement
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;

                // Check if the form has been dragged to the top-left corner
                if (Location.X <= 0 && Location.Y <= 0)
                {
                    this.Close(); // Close the form if dragged to the top-left corner
                }
            }
        }

        private void panelBody_MouseUp(object sender, MouseEventArgs e)
        {
            // Hide the tooltip when mouse button is released
            dragToolTip.Hide(this);

            // Restore the form to maximized state when the mouse button is released
            if (e.Button == MouseButtons.Left)
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
