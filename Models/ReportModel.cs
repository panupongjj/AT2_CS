using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT2_CS.Models
{
    public class ReportModel
    {

        [Key]
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        
        public ReportModel()
        {
            StudentId = 0;
            FullName = "";
            Email = "";
            SubjectId = 0;
            SubjectName = "";
            
        }

        public ReportModel(int studentId, string fullName, string email, int subjectId, string subjectName)
        {
            StudentId = studentId;
            FullName = fullName;
            Email = email;
            SubjectId = subjectId;
            SubjectName = subjectName;
           
        }
    }
}
