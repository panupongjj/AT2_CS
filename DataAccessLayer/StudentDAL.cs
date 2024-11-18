using System.Data.SqlClient;
using AT2_CS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using AT2_CS.DataAccessLayer;


namespace AT2_CS.DataAccessLayer
{
    public class StudentDAL
    {
        private SqlConnection Connection;

        public StudentDAL(SqlConnection connection)
        {
            // connect to the target database
            Connection = connection;
        }
        // create
        public void Create(StudentModel student)
        {
            Connection.Open();
            // build the query commandnamespace AT2_CS.DataAccessLayer
            var command = Connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO Student
                (FullName, Phone, Email, DoB, EnrolmentDate, EnrolmentCert, TotalScore)
                VALUES(@b, @c, @d, @e, @f, @g, @h)
            ";

            //command.Parameters.AddWithValue("a", student.StudentId);
            command.Parameters.AddWithValue("b", student.FullName);
            command.Parameters.AddWithValue("c", student.Phone);
            command.Parameters.AddWithValue("d", student.Email);
            command.Parameters.AddWithValue("e", student.DoB);
            command.Parameters.AddWithValue("f", student.EnrolmentDate);
            command.Parameters.AddWithValue("g", student.EnrolmentCert);
            command.Parameters.AddWithValue("h", student.TotalScore);

            // execute the query
            command.ExecuteReader();

            Connection.Close();
        }

        public StudentModel Read(int Id)
        {
            StudentModel student = null;
            Connection.Open();
            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                SELECT *
                FROM Student
                WHERE StudentId = @a
            ";
            command.Parameters.AddWithValue("a", Id);


            // execute the query
            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                var studentId = reader.GetInt32(0);
                var studentFullName = reader.GetString(1);
                var studentPhone = reader.GetInt32(2);
                var studentEmail = reader.GetString(3);
                var studentDoB = reader.GetDateTime(4);
                var studentEnrolmentDate = reader.GetDateTime(5);
                var studentEnrolmentCert = reader.GetString(6);
                var studentTotalScore = reader.GetDecimal(7);
                student = new StudentModel(studentId, studentFullName, studentPhone, studentEmail, studentDoB, studentEnrolmentDate, studentEnrolmentCert, studentTotalScore);
            } // else student = null

            Connection.Close();

            return student;
        }

        // read all
        public List<StudentModel> ReadAll()
        {
            var students = new List<StudentModel>();

            Connection.Open();

            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"SELECT * FROM Student";

            // execute the query
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var studentId = reader.GetInt32(0);
                var studentFullName = reader.GetString(1);
                var studentPhone = reader.GetInt32(2);
                var studentEmail = reader.GetString(3);
                var studentDoB = reader.GetDateTime(4);
                var studentEnrolmentDate = reader.GetDateTime(5);
                var studentEnrolmentCert = reader.GetString(6);
                var studentTotalScore = reader.GetDecimal(7);
                students.Add(new StudentModel(studentId, studentFullName, studentPhone, studentEmail, studentDoB, studentEnrolmentDate, studentEnrolmentCert, studentTotalScore));
            }
            Connection.Close();
            return students;
        }

        public void Update(StudentModel student)
        {
            // challenge yourself
            Connection.Open();

            var command = Connection.CreateCommand();
            command.CommandText = @" UPDATE Student SET FullName = @b, Phone = @c, Email = @d, DoB = @e, EnrolmentDate = @f, EnrolmentCert = @g, TotalScore = @h  WHERE StudentId = @a";
            command.Parameters.AddWithValue("a", student.StudentId);
            command.Parameters.AddWithValue("b", student.FullName);
            command.Parameters.AddWithValue("c", student.Phone);
            command.Parameters.AddWithValue("d", student.Email);
            command.Parameters.AddWithValue("e", student.DoB);
            command.Parameters.AddWithValue("f", student.EnrolmentDate);
            command.Parameters.AddWithValue("g", student.EnrolmentCert);
            command.Parameters.AddWithValue("h", student.TotalScore);


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
                DELETE FROM Student
                WHERE StudentId = @a
            ";
            command.Parameters.AddWithValue("a", id);

            // execute the query
            command.ExecuteReader();

            Connection.Close();
        }
    }
}
