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
using System.Numerics;

namespace AT2_CS.DataAccessLayer
{
    public class ReportDAL
    {
        private SqlConnection Connection;
        public ReportDAL(SqlConnection connection)
        {
            // connect to the target database
            Connection = connection;
        }

        public List<ReportModel> ReadAll()
        {
            var reportModel = new List<ReportModel>();

            Connection.Open();

            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"SELECT
            Student.StudentId,
            Student.FullName,
            Student.Email,
            Subject.SubjectId,
            Subject.SubjectName
            FROM Student JOIN Enrolment ON Student.StudentId = Enrolment.StudentId_FK
                         JOIN Subject   ON Subject.SubjectId = Enrolment.SubjectId_FK
            ORDER BY StudentID";

            // execute the query
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var studentId = reader.GetInt32(0);
                var fullName = reader.GetString(1);
                var email = reader.GetString(2);
                var subjectId = reader.GetInt32(3);
                var subjectName = reader.GetString(4);
                reportModel.Add(new ReportModel(studentId, fullName, email, subjectId, subjectName));

            }
            Connection.Close();
            return reportModel;
        }
        public List<ReportModel> ReadByID(int id)
        {
            var reportModel = new List<ReportModel>();

            Connection.Open();

            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"SELECT
            Student.StudentId,
            Student.FullName,
            Student.Email,
            Subject.SubjectId,
            Subject.SubjectName
            FROM Student JOIN Enrolment ON Student.StudentId = Enrolment.StudentId_FK
                         JOIN Subject   ON Subject.SubjectId = Enrolment.SubjectId_FK
            WHERE Student.StudentId = @a
            ORDER BY StudentID";

            command.Parameters.AddWithValue("a", id);

            // execute the query
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var studentId = reader.GetInt32(0);
                var fullName = reader.GetString(1);
                var email = reader.GetString(2);
                var subjectId = reader.GetInt32(3);
                var subjectName = reader.GetString(4);
                reportModel.Add(new ReportModel(studentId, fullName, email, subjectId, subjectName));

            }
            Connection.Close();
            return reportModel;
        }
        public bool InsertTODataBase(dynamic CSVData)
        {
            //var students = new List<StudentModel>();
            Connection.Open();
           // var command = Connection.CreateCommand();
            foreach (var line in CSVData)
            {
                var values = line.Split(',');
                if (values.Length == 8) //
                {
                    if ((values[0]).ToString() == "StudentId")
                    {
                        continue;
                    }

                    var studentId = int.Parse(values[0]);
                    var studentFullName = (values[1]).ToString();
                    var studentPhone = int.Parse((values[2]).ToString().Replace(" ", ""));
                    var studentEmail = (values[3]).ToString();
                    var studentDoB = DateTime.Parse(values[4]);
                    var studentEnrolmentDate = DateTime.Parse(values[5]);
                    var studentEnrolmentCert = (values[6]).ToString();
                    var studentTotalScore = decimal.Parse(values[7]);

                    //students.Add(new StudentModel(studentId, studentFullName, studentPhone, studentEmail, studentDoB, studentEnrolmentDate, studentEnrolmentCert, studentTotalScore));
                    var insertCommand = new SqlCommand(
                           @"INSERT INTO Student
                    (FullName, Phone, Email, DoB, EnrolmentDate, EnrolmentCert, TotalScore)
                    VALUES(@b, @c, @d, @e, @f, @g, @h)", Connection);

                    //command.Parameters.AddWithValue("a", student.StudentId);
                    insertCommand.Parameters.AddWithValue("b", studentFullName);
                    insertCommand.Parameters.AddWithValue("c", studentPhone);
                    insertCommand.Parameters.AddWithValue("d", studentEmail);
                    insertCommand.Parameters.AddWithValue("e", studentDoB);
                    insertCommand.Parameters.AddWithValue("f", studentEnrolmentDate);
                    insertCommand.Parameters.AddWithValue("g", studentEnrolmentCert);
                    insertCommand.Parameters.AddWithValue("h", studentTotalScore);

                    // execute the query
                    insertCommand.ExecuteNonQuery();
                    
                }
            }
            Connection.Close();
            Console.WriteLine("Data loaded from CSV file and stored in SQL Server database.");
            return true;
        }
        public List<StudentModel> ReadAllStudent()
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
    }
}
