using Abot_Kamay_Tracking_and_Queuing_System.Utilities;
using MySql.Data.MySqlClient;

namespace Abot_Kamay_Tracking_and_Queuing_System
{
    public partial class SummaryDisbursementOfAICS : Form
    {

        public int clientId;
   
    

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          using(MySqlConnection conn = DatabaseConnection.GetConnection())
          {
            string query = $"SELECT ci.*, \r\n       bi.last_name AS blname,\r\n       bi.first_name AS bfname,\r\n       bi.middle_name AS bmname,\r\n       bi.ext_name AS bename,\r\n       bi.sex AS bsex,\r\n       bi.date_of_birth AS bdob,\r\n       bi.age AS bage,\r\n       bi.birth_place AS bbirth_place,\r\n       bi.contact_number AS bcontact,\r\n       bi.region AS bregion,\r\n       bi.province AS bprovince,\r\n       bi.city_municipality AS bmun,\r\n       bi.district AS bdistrict,\r\n       bi.barangay AS bbarangay,\r\n       bi.street_purok AS bstreet,\r\n       bi.civil_status AS bcivil,\r\n       bi.beneficiary_type,\r\n       bi.civil_status_other AS bcivilother,\r\n       ai.amount,\r\n       ai.financial_assistance,\r\n       ai.material_assistance,\r\n       ai.medical,\r\n       ai.burial,\r\n       ai.transpo,\r\n       ai.food_pack,\r\n       ai.used_clothing,\r\n       ai.specify,\r\n       ai.material_specify\r\nFROM clientinformation ci\r\nRIGHT JOIN beneficiaryinformation bi \r\n    ON ci.client_id = bi.client_id\r\nLEFT JOIN (\r\n    SELECT ai.*, \r\n           ROW_NUMBER() OVER (PARTITION BY ai.beneficiary_id ORDER BY ai.id DESC) AS rn\r\n    FROM assistanceinformation ai\r\n) ai\r\n    ON bi.beneficiary_id = ai.beneficiary_id \r\n    AND ai.rn = 1\r\nWHERE ci.last_assistance_date BETWEEN @date_from AND @date_to\r\nORDER BY ci.last_assistance_date;\r\n";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@date_from", dateFrom.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@date_to", dateTo.Value.ToString("yyyy-MM-dd"));
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                        // Create a directory based on the current date (if it doesn't exist)
                        string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "CsvReports", DateTime.Now.ToString("yyyy-MM-dd"));
                        Directory.CreateDirectory(folderPath);

                        // Generate a filename based on the current timestamp
                        string fileName = Path.Combine(folderPath, $"csv_{DateTime.Now.ToString("HHmmss")}.csv");
                        int client_no = 1;
                        using(StreamWriter writer = new StreamWriter(fileName))
                        {
                            writer.WriteLine("DATE, NO., CLIENT'S NAME, SEX, CLIENTS CATEGORY, BENEFECIARY, ADDRESS, UNKNOWN, AMOUNT");
                            while (rd.Read())
                            {
                                writer.WriteLine($"{rd["last_assistance_date"].ToString().Split()[0]}, {client_no.ToString()}, {rd["first_name"].ToString() + " " + rd["middle_name"].ToString() + " " + rd["last_name"].ToString()}, {rd["sex"].ToString()}, {rd["beneficiary_type"].ToString()}, {rd["bfname"].ToString() + " " + rd["bmname"].ToString() + " " + rd["blname"].ToString()},  {rd["street_purok"].ToString() + " " + rd["barangay"].ToString() + " " + rd["district"].ToString() + " " + rd["city_municipality"].ToString() + " " + rd["province"].ToString() + " " + rd["region"].ToString()}, {(rd.GetInt32("financial_assistance") == 1 ? "Financial " : "Material ") + FinancialAssistanceidentifier(rd.GetInt32("financial_assistance"), rd.GetInt32("medical"), rd.GetInt32("burial"), rd.GetInt32("transpo"), rd.GetInt32("food_pack"), rd.GetInt32("used_clothing"))}, Php {rd["amount"].ToString()}");
                                client_no++;
                            }
                        }
                }
            }
          }
        }
        private string FinancialAssistanceidentifier(int financialAssistance, int medical, int burial, int transpo, int food_pack, int used_clothing)
        {

            if (financialAssistance == 1)
            {
                if (medical == 1)
                {
                    return "(Medical)";
                }
                else if (burial == 1)
                {
                    return "(Burial)";
                }
                else if (transpo == 1)
                {
                    return "(Transpo)";

                }
            }
            else
            {
                if (food_pack == 1)
                {
                    return "(Food pack)";
                }
                else if (used_clothing == 1)
                {
                    return "(Used clothing)";
                }

            }

            return "";
        }
    }

}
