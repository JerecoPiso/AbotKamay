using Abot_Kamay_Tracking_and_Queuing_System.Utilities;
using MySql.Data.MySqlClient;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Abot_Kamay_Tracking_and_Queuing_System
{
    public partial class Pictures : Form
    {
        public Pictures()
        {
            InitializeComponent();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "CsvPictures", DateTime.Now.ToString("yyyy-MM-dd"));
            Directory.CreateDirectory(folderPath);

            // Generate a filename based on the current timestamp
            string fileName = Path.Combine(folderPath, $"pdf_{DateTime.Now.ToString("HHmmss")}.pdf");
            PdfWriter writer = new PdfWriter(fileName);
            PdfDocument pdfDoc = new PdfDocument(writer);
            Document doc = new Document(pdfDoc);
            List<string> imagePaths = new List<string>();
            List<string> clientNames = new List<string>();

            int cols = 2;
            float imageWidth = 250f;
            
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = $"SELECT * FROM disbursementinformation WHERE DATE(created_timestamp) BETWEEN @date_from AND @date_to;";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@date_from", date_from.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@date_to", date_to.Value.ToString("yyyy-MM-dd"));
                    using (MySqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            imagePaths.Add(rd["filepath"].ToString());
                            clientNames.Add(rd["client_name"].ToString());
                        }
                     
                        // Create a directory based on the current date (if it doesn't exist)
                      
                    }
                }
            }

            int rows = (int)Math.Ceiling((double)imagePaths.Count / cols);

            for (int i = 0; i < rows; i++)
            {
                // Use a Paragraph for the current row
                Paragraph paragraph = new Paragraph();

                for (int j = 0; j < cols; j++)
                {
                    int imageIndex = i * cols + j;

                    if (imageIndex < imagePaths.Count)
                    {
                        // Load the image
                        var image = new iText.Layout.Element.Image(
                            iText.IO.Image.ImageDataFactory.Create(imagePaths[imageIndex])
                        ).ScaleAbsolute(imageWidth, 200);

                        // Create a caption text
                        var caption = new Paragraph($"{clientNames[imageIndex]}")
                            .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                            .SetFontSize(10);

                        // Create a Div to group the image and caption vertically
                        var div = new iText.Layout.Element.Div();
                        div.Add(image);
                        div.Add(caption);

                        // Add the div to the paragraph
                        paragraph.Add(div);
                    }

                    if (j < cols - 1)
                    {
                        paragraph.Add(new Text("    ")); // Optional spacing between columns
                    }
                }

                paragraph.Add(new Text("\n\n")); // Extra space between rows
                doc.Add(paragraph);
            }

            doc.Close();
        }
    }
}
