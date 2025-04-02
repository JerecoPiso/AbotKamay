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
using Tracking_and_Queuing_System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Abot_Kamay_Tracking_and_Queuing_System
{
    public partial class MainForm : Form
    {
        private int selectedClientId;
        private int selectedBeneficiaryId;
        private string role;
        private int currentQueueNumber = 0;
        private Button lastClickedButton;
        private static bool isQueueRunning = false;  // Static flag to track if the queue has started
        private string userName;

        public MainForm(string userRole = null, string firstName = null)
        {
            InitializeComponent();

            this.Shown += MainForm_Shown;

            close.Click += close_Click;

            if (userRole != null)
            {
                role = userRole;
            }

            if (firstName != null)
            {
                userName = firstName;
                lblUser.Text = $"Welcome, {userName}!"; // Display the user's first name
            }
        }


        private void MainForm_Load(object sender, EventArgs e)
        {

            btnHome.PerformClick();

            timeDateTimer.Start();

            // Hide/show the Settings button based on user role
            switch (role)
            {
                case "Admin": // Only Admin can see the Settings button
                    btnSettings.Visible = true;
                    btnQueue.Visible = false;
                    menuStripSettings.Visible = false;
                    break;
                case "Admin Clerk 1":
                    btnSettings.Visible = false;
                    btnQueue.Visible = false;
                    //panelSideBar.Visible = false;  // Hide the entire sidebar
                    // mainPanel.Size = new Size(1920, 976); // Resize mainPanel
                    break;
                default: // Hide for other roles
                    btnSettings.Visible = false;
                    break;
            }
        }


        // Method to dynamically set the role
        public void SetRole(string userRole)
        {
            role = userRole;
        }


        /* private void ShowCounterQueueForm(int step)
         {
             CounterQueueForm counterQueueForm = new CounterQueueForm();
             counterQueueForm.StepNumber = step; // Set the step number
             counterQueueForm.Show(); // Show the CounterQueueForm
         }*/

        // Method to show CounterQueueForm
        private void ShowCounterQueueForm(int step)
        {
            // Create the form and pass the step number to the constructor
            CounterQueueForm counterQueueForm = new CounterQueueForm(step); // Pass the step as an argument
            counterQueueForm.Show(); // Show the CounterQueueForm
        }



        private bool isLoggingOut = false;

        private void Logout()
        {
            if (isLoggingOut) return; // If already logging out, do nothing
            isLoggingOut = true; // Set the flag to indicate logout process has started

            // Show confirmation dialog
            var result = MessageBox.Show("By clicking this button, you will be logged out. Do you want to continue?",
                                          "Confirm Logout",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // If the user clicks Yes, log out
            if (result == DialogResult.Yes)
            {
                this.Close();

                // Show the login form again
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
            else
            {
                isLoggingOut = false; // Reset the flag if the user cancels the logout
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }



        public void loadform(object Form)
        {
            // Clear the mainPanel first, but not dispose controls
            if (this.mainPanel.Controls.Count > 0)
            {
                this.mainPanel.Controls.Clear();
            }

            // Add the new form
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainPanel.Controls.Add(f);
            this.mainPanel.Tag = f; //tag the panel with the form
            f.Show();
        }


        private void btnHome_Click(object sender, EventArgs e)
        {
            ChangeButtonColor(sender as Button);
            HomeForm homeForm = new HomeForm(role); // Pass the role to HomeForm
            loadform(homeForm); // Load the HomeForm in the main panel
        }

        private void btnQueue_Click_1(object sender, EventArgs e)
        {
            ChangeButtonColor(sender as Button);

            // ✅ If Admin Clerk 2, open InputQueueForm instead of CounterQueueForm
            if (role == "Admin Clerk 2")
            {
                InputQueueForm inputQueueForm = new InputQueueForm();
                inputQueueForm.Show();
                return; // ✅ Exit to prevent further execution
            }

            int step = 0;

            // Determine the step based on the user role
            switch (role)
            {
                case "Admin":
                    btnQueue.Enabled = false;
                    break;
                case "Admin Clerk 3":
                    step = 3; // Step 3
                    break;
                case "Social Worker":
                    step = 4; // Step 4
                    break;
                case "SDO":
                    step = 5; // Step 5
                    break;
                default:
                    MessageBox.Show("You do not have access to this function.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }

            // 🔴 Temporary bypass: Comment out or remove this check for testing
            /*
            if (!HomeForm.isQueueFormOpen)
            {
                MessageBox.Show("Please open the Queue display first in Step 2.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return; // Exit if QueueForm is not open
            }
            */


            //OR...

            // ✅ Check if QueueForm is open, if not, open it automatically
            //if (!HomeForm.isQueueFormOpen)
            //{
               
            //    QueueForm queueForm = new QueueForm();
            //    queueForm.Show();
            //    HomeForm.isQueueFormOpen = true; // Mark it as open
            //    System.Threading.Thread.Sleep(500); // Delay for smooth UI transition
            //}

           // If QueueForm is open, check if the queue is already running
            if (!isQueueRunning)
            {
                DialogResult result = MessageBox.Show("Do you want to start the queue?", "Start Queue", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    isQueueRunning = true;
                    ShowCounterQueueForm(step); // Start the queue if the user chooses Yes
                }
            }
            else
            {
                ShowCounterQueueForm(step); // If the queue is running, just show the CounterQueueForm
            }
        }


        private void ChangeButtonColor(Button clickedButton)
        {
            // Reset the color of the last clicked button
            if (lastClickedButton != null)
            {
                lastClickedButton.BackColor = Color.FromArgb(45, 45, 45);
            }

            // Change the color of the currently clicked button
            clickedButton.BackColor = Color.FromArgb(20, 103, 204);

            // Update the last clicked button
            lastClickedButton = clickedButton;
        }


        private void btnSettings_Click(object sender, EventArgs e)
        {
            ChangeButtonColor(sender as Button);

            // Clear existing controls in the mainPanel
            if (this.mainPanel.Controls.Count > 0)
            {
                this.mainPanel.Controls.Clear();
            }

            // Add the MenuStrip to mainPanel if not yet added
            if (!mainPanel.Controls.Contains(menuStripSettings))
            {
                mainPanel.Controls.Add(menuStripSettings);
            }

            // Set the MenuStrip to a new location within the mainPanel
            menuStripSettings.Dock = DockStyle.None; // Disable automatic docking
            menuStripSettings.Anchor = AnchorStyles.None; // Disable anchoring
            menuStripSettings.Location = new Point(10, 10); // Set desired location

            menuStripSettings.Visible = true;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            ChangeButtonColor(sender as Button);
            Logout();
        }



        private void timeDateTimer_Tick(object sender, EventArgs e)
        {
            lblTimenow.Text = DateTime.Now.ToLongTimeString();
            lblDate.Text = DateTime.Now.ToLongDateString();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AddUserForm addUserForm = new AddUserForm();
            addUserForm.TopLevel = false;
            mainPanel.Controls.Add(addUserForm);
            // addUserForm.Dock = DockStyle.Fill;
            addUserForm.Location = new Point((mainPanel.Width - addUserForm.Width) / 2, (mainPanel.Height - addUserForm.Height) / 2);
            addUserForm.Show(); // Use ShowDialog for a modal window
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            menuStripSettings.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panelBlue_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            btnHome.PerformClick();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
