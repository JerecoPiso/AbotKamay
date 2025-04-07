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
            string fileName = Path.Combine(folderPath, $"csv_{DateTime.Now.ToString("HHmmss")}.csv");
            PdfWriter writer = new PdfWriter(fileName);
            PdfDocument pdfDoc = new PdfDocument(writer);
            Document doc = new Document(pdfDoc);
            List<string> imagePaths = new List<string>();
            int cols = 2;
            float imageWidth = 200f;
            
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
                        }
                     
                        // Create a directory based on the current date (if it doesn't exist)
                      
                    }
                }
            }

            int rows = (int)Math.Ceiling((double)imagePaths.Count / cols);

            for (int i= 0; i < rows; i++)
            {
                Paragraph paragraph = new Paragraph();
                for(int j = 0; j < cols; j++)
                {
                    int imageIndex = i * cols + j;

                    if(imageIndex < imagePaths.Count)
                    {
                        
                        iText.Layout.Element.Image image = new iText.Layout.Element.Image(iText.IO.Image.ImageDataFactory.Create(imagePaths[imageIndex]));
                        image.ScaleAbsolute(imageWidth, 200);
                        paragraph.Add(image);

                    }

                    if(j < cols - 1)
                    {
                        paragraph.Add(new Text(""));
                    }
                }
                paragraph.Add(new Text("\n"));
                doc.Add(paragraph);
            }

            doc.Close();
        }
    }
}
