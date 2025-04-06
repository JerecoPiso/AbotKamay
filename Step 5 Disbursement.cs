using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing.Imaging;
using Abot_Kamay_Tracking_and_Queuing_System.Utilities;
using MySql.Data.MySqlClient;

namespace Abot_Kamay_Tracking_and_Queuing_System
{
    public partial class Step5Form : Form
    {
        private string role;
        private int? clientId;
        private string fullName;

        private FilterInfoCollection videoDevices; // To store active cameras
        private VideoCaptureDevice videoSource; // To access the selected camera
        private Bitmap capturedImage; // To store the captured image
        private bool isCapturing = false; // Flag to track if we are capturing

        public Step5Form(string userRole, int? clientId = null, string fullName = null)
        {
            InitializeComponent();

            role = userRole;
            this.clientId = clientId;
            this.fullName = fullName;

            lblGetName.Text = fullName;  // Display full name in the label
        }

        private void Step5Form_Load(object sender, EventArgs e)
        {
            timeDateTimer.Start();


            // Populate the camera selection combobox with active devices
            LoadActiveCameras();

            // Set default state
            cmbCameras.SelectedIndex = 0; // "Select Camera" as default
            btnPreview.Enabled = false; // Disable Preview button initially
        }


        private void LoadActiveCameras()
        {
            cmbCameras.Items.Clear(); // Clear the combobox
            cmbCameras.Items.Add("Select Camera"); // Add default option

            // Detect active video input devices
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            // Add the internal camera as the first option
            cmbCameras.Items.Add("Internal Camera");

            // Check for external cameras and add them
            foreach (FilterInfo device in videoDevices)
            {
                try
                {
                    // Attempt to initialize the device to check if it's active
                    var testDevice = new VideoCaptureDevice(device.MonikerString);
                    testDevice.NewFrame += (s, ev) => { }; // Test event handler
                    testDevice.SignalToStop(); // Stop the test device
                    testDevice.WaitForStop();

                    // Add active devices to combobox
                    cmbCameras.Items.Add(device.Name);
                }
                catch
                {
                    // Skip any inactive or non-working cameras
                }
            }

            // Enable ComboBox selection
            if (cmbCameras.Items.Count == 1)
            {
                // If no active cameras are found
                MessageBox.Show("No active cameras found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbCameras_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Enable Preview button only when a valid camera is selected
            btnPreview.Enabled = cmbCameras.SelectedIndex > 0; // Enable only if a valid camera is selected

            // Change button color based on camera selection
            if (cmbCameras.SelectedIndex == 0)
            {
                // No camera selected, reset to default color
                btnPreview.BackColor = SystemColors.Control; // Default color
            }
            else if (cmbCameras.SelectedItem.ToString() == "Internal Camera")
            {
                // Internal camera selected, change button color to green
                btnPreview.BackColor = Color.Green; // Change to green for internal camera
            }
            else
            {
                // External camera selected, change button color to blue
                btnPreview.BackColor = Color.Crimson; // Change to blue for external camera
            }
        }



        private void btnPreview_Click(object sender, EventArgs e)
        {
            // Enable the Preview button only if a valid camera is selected
            if (cmbCameras.SelectedIndex > 0)
            {
                // If the internal camera is selected, choose the first device in the list (index 0)
                if (cmbCameras.SelectedItem.ToString() == "Internal Camera")
                {
                    videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString); // Use the internal camera
                }
                else
                {
                    // If it's an external camera, subtract 1 from SelectedIndex
                    // because the "Select Camera" option is at index 0 in the combobox.
                    int selectedDeviceIndex = cmbCameras.SelectedIndex - 1;
                    if (selectedDeviceIndex >= 0 && selectedDeviceIndex < videoDevices.Count)
                    {
                        videoSource = new VideoCaptureDevice(videoDevices[selectedDeviceIndex].MonikerString);
                    }
                    else
                    {
                        MessageBox.Show("Invalid camera selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                videoSource.NewFrame += VideoSource_NewFrame;
                videoSource.Start();
            }
            else
            {
                MessageBox.Show("Please select a camera.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // Display the live feed in the PictureBox
            if (!isCapturing)
            {
                Bitmap frame = (Bitmap)eventArgs.Frame.Clone();
                pbCamera.Image = frame;
            }
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (pbCamera.Image != null && !isCapturing)
            {
                isCapturing = true;

                // Capture the current frame
                capturedImage = new Bitmap(pbCamera.Image);
                pbCamera.Image = capturedImage;

                // Stop the video feed temporarily
                StopCamera();

                // Disable the Capture button to prevent another capture during review
                btnCapture.Enabled = false;

                var result = MessageBox.Show("Do you want to save this photo?", "Save Photo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SaveCapturedImage();
                  
                }
                else
                {
                    MessageBox.Show("Capture discarded. Resuming the camera feed.", "Discarded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Enable the Capture button and restart the video feed
                btnCapture.Enabled = true;
                StartVideoCapture();
                isCapturing = false;
            }
        }

        private void SaveCapturedImage()
        {
            // Create a directory based on the current date (if it doesn't exist)
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "CapturedImages", DateTime.Now.ToString("yyyy-MM-dd"));
            Directory.CreateDirectory(folderPath);

            // Generate a filename based on the current timestamp
            string fileName = Path.Combine(folderPath, $"photo_{DateTime.Now.ToString("HHmmss")}.jpg");

            // Save the captured image as a .jpg file
            capturedImage.Save(fileName, ImageFormat.Jpeg);
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                string q = @"INSERT INTO disbursementinformation (client_id, client_name, address, filepath, last_assistance_date) VALUES (@client_id, @client_name, @address, @filepath, @last_assistance_date);";
                using (MySqlCommand cmd = new MySqlCommand(q, conn))
                {
                    cmd.Parameters.AddWithValue("@client_id", clientId);
                    cmd.Parameters.AddWithValue("@client_name", fullName);
                    cmd.Parameters.AddWithValue("@address", "");
                    cmd.Parameters.AddWithValue("@filepath", fileName);
                    cmd.Parameters.AddWithValue("last_assistance_date", DateTime.Now.ToString("yyyy-MM-dd"));
                    cmd.ExecuteNonQuery();
                }
            }
            // Show a message that the image has been saved
            MessageBox.Show($"Image saved as: {fileName}", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Enable the Capture button to allow the user to capture another photo
            btnCapture.Enabled = true;

            // Resume the webcam feed after saving the photo
            StartVideoCapture();
        }

        private void StartVideoCapture()
        {
            if (videoSource == null || !videoSource.IsRunning)
            {
                // Restart the video feed
                if (cmbCameras.SelectedItem.ToString() == "Internal Camera")
                {
                    videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                }
                else
                {
                    int selectedDeviceIndex = cmbCameras.SelectedIndex - 1;
                    if (selectedDeviceIndex >= 0 && selectedDeviceIndex < videoDevices.Count)
                    {
                        videoSource = new VideoCaptureDevice(videoDevices[selectedDeviceIndex].MonikerString);
                    }
                }

                videoSource.NewFrame += VideoSource_NewFrame;
                videoSource.Start();
            }
        }



        private void StopCamera()
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
                videoSource.NewFrame -= VideoSource_NewFrame; // Unsubscribe from events
                videoSource = null;
            }
        }



        private void Step5Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop the camera when closing the form
            StopCamera();
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(role); // Pass the role back to MainForm
            mainForm.Show();
            this.Close(); // Close the current form
        }


    }
}
