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
    public class SubjectDAL
    {
        private SqlConnection Connection;

        public SubjectDAL(SqlConnection connection)
        {
            // connect to the target database
            Connection = connection;
        }
        // create
        public void Create(SubjectModel subject)
        {
            Connection.Open();
            // build the query commandnamespace AT2_CS.DataAccessLayer
            var command = Connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO Subject
                (SubjectName)
                VALUES(@b)
            ";

            command.Parameters.AddWithValue("b", subject.SubjectName);

            // execute the query
            command.ExecuteReader();

            Connection.Close();
        }

        public SubjectModel Read(int Id)
        {
            SubjectModel subject = null;
            Connection.Open();
            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                SELECT *
                FROM Subject
                WHERE SubjectId = @a
            ";
            command.Parameters.AddWithValue("a", Id);

            // execute the query
            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                var subjectId = reader.GetInt32(0);
                var subjectName = reader.GetString(1);

                subject = new SubjectModel(subjectId, subjectName);
            } 

            Connection.Close();

            return subject;
        }

        // read all
        public List<SubjectModel> ReadAll()
        {
            var subjects = new List<SubjectModel>();

            Connection.Open();

            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"SELECT * FROM Subject";

            // execute the query
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var subjectId = reader.GetInt32(0);
                var subjectName = reader.GetString(1);
                subjects.Add(new SubjectModel(subjectId, subjectName));
      
            }
            Connection.Close();
            return subjects;
        }

        public void Update(SubjectModel subject)
        {
            // challenge yourself
            Connection.Open();

            var command = Connection.CreateCommand();
            command.CommandText = @" UPDATE Subject SET SubjectName = @b WHERE SubjectId = @a";
            command.Parameters.AddWithValue("a", subject.SubjectId);
            command.Parameters.AddWithValue("b", subject.SubjectName);

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
                DELETE FROM Subject
                WHERE SubjectId = @a
            ";
            command.Parameters.AddWithValue("a", id);

            // execute the query
            command.ExecuteReader();

            Connection.Close();
        }
    }
}
