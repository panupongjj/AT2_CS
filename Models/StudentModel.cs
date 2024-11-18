using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT2_CS.Models
{
    public class StudentModel
    {   
        [Key]
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public DateTime DoB { get; set; }
        public DateTime EnrolmentDate { get; set; }
        public string EnrolmentCert { get; set; }
        public decimal TotalScore { get; set; }

        public StudentModel()
        {   
            StudentId = 0;
            FullName = "";
            Phone = 0;
            Email = "";
            DoB = DateTime.Now;
            EnrolmentDate = DateTime.Now;
            EnrolmentCert = "";
            TotalScore = 0;
        }

        public StudentModel(int studentId, string fullName, int phone, string email, DateTime dob, DateTime enrolmentDate, string enrolmentCert, decimal totalScore)
        {
            StudentId = studentId;
            FullName = fullName;
            Phone = phone;
            Email = email;
            DoB = dob;
            EnrolmentDate = enrolmentDate;
            EnrolmentCert = enrolmentCert;
            TotalScore = totalScore;
        }
    }
}
