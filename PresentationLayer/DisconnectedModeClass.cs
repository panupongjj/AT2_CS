using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data;
using System.Data.SqlClient;
using AT2_CS.DataAccessLayer;

namespace AT2_CS.PresentationLayer
{
    public class DisconnectedModeClass
    {
        public DataTable GetStudents()
        {
            DataTable studentTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(AT2_CS_DataBase.ConnectionString))
            {
                string query = "SELECT * FROM Student"; // Assuming Students table exists

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(studentTable); // Fill the DataTable in disconnected mode
            }
            return studentTable;

        }

        public void Disconnected() {

            DisconnectedModeClass dmc = new DisconnectedModeClass();

            // Example: Retrieve Students
            DataTable students = dmc.GetStudents();
            Console.WriteLine("Students List:");
            foreach (DataRow row in students.Rows)
            {
                Console.WriteLine($"{row["StudentId"]} - {row["FullName"]} - {row["EnrolmentCert"]}");
            }

        }


    }
}
