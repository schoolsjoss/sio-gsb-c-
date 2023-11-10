using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WinFormsApp1
{
    internal class DrugDataAcess
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["localhost"].ConnectionString;
        private List<Drug> drugs = new List<Drug>();
        
        public void addDrug(Drug drug)
        {
            this.drugs.Add(drug);
        }

      
        public List<Drug> getDrugList() {  return this.drugs; }

        public List<Drug> getDrugListFromDB()
        {
      
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT name, description FROM drugs";
                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    using(MySqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            this.drugs.Add(new Drug(reader["name"].ToString(), reader["description"].ToString()));
                        }
                    }
                    
                }
                conn.Close();

            }
            return this.drugs;
        }

        public int addDrugToDB(Drug drug)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Drugs (name, description) VALUES (@name, @description)";
                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@name", drug.Name);
                    command.Parameters.AddWithValue("@description", drug.Description);
                    int result = command.ExecuteNonQuery();
                    conn.Close();
                    return result;
                }

            }

        }
    }
}
