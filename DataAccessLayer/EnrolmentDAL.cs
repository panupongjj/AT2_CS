using System.Data.SqlClient;
using AT2_CS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;

namespace AT2_CS.DataAccessLayer
{
    public class EnrolmentDAL
    {
        private SqlConnection Connection;

        public EnrolmentDAL(SqlConnection connection)
        {
            // connect to the target database
            Connection = connection;
        }
        // create
        public void Create(EnrolmentModel Enrolment)
        {

            Connection.Open();
            var command = Connection.CreateCommand();
            command.CommandText = @"
            INSERT INTO EnrolmentEEE
            (StudentId_FK,SubjectId_FK)
            VALUES(@b,@c)";

            command.Parameters.AddWithValue("b", Enrolment.StudentId_FK);
            command.Parameters.AddWithValue("c", Enrolment.SubjectId_FK);

            try
            {   // execute the query
                command.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
            
            Connection.Close();

        }

        public EnrolmentModel Read(int Id)
        {
            EnrolmentModel Enrolment = null;
            Connection.Open();
            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                SELECT *
                FROM Enrolment
                WHERE ID = @a
            ";
            command.Parameters.AddWithValue("a", Id);

            // execute the query
            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                var ID = reader.GetInt32(0);
                var studentId_FK = reader.GetInt32(1);
                var subjectId_FK = reader.GetInt32(1);

                Enrolment = new EnrolmentModel(ID, studentId_FK, subjectId_FK);
            }

            Connection.Close();

            return Enrolment;
        }

        // read all
        public List<EnrolmentModel> ReadAll()
        {
            var enrolments = new List<EnrolmentModel>();

            Connection.Open();

            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"SELECT * FROM Enrolment";

            // execute the query
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var ID = reader.GetInt32(0);
                var studentId_FK = reader.GetInt32(1);
                var subjectId_FK = reader.GetInt32(2);
                enrolments.Add(new EnrolmentModel(ID, studentId_FK, subjectId_FK));

            }
            Connection.Close();
            return enrolments;
        }

        public void Update(EnrolmentModel Enrolment)
        {
            // challenge yourself
            Connection.Open();

            var command = Connection.CreateCommand();
            command.CommandText = @" UPDATE Enrolment SET StudentId_FK = @b ,SubjectId_FK = @C WHERE SubjectId = @a";
            command.Parameters.AddWithValue("a", Enrolment.ID);
            command.Parameters.AddWithValue("b", Enrolment.StudentId_FK);
            command.Parameters.AddWithValue("C", Enrolment.SubjectId_FK);
            // execute the query
            command.ExecuteReader();

            Connection.Close();
        }

        public void Delete(int id)
        {
            // challenge yourself
            Connection.Open();

            var command = Connection.CreateCommand();
            command.CommandText = @"
                DELETE FROM Enrolment
                WHERE ID = @a
            ";
            command.Parameters.AddWithValue("a", id);

            // execute the query
            command.ExecuteReader();

            Connection.Close();
        }
    }
}
