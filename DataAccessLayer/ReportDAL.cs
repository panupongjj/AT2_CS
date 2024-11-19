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


    }
}
