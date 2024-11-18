using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT2_CS.Models
{
    public class EnrolmentModel
    {   
        [Key]
        public int ID { get; set; }
        public int StudentId_FK { get; set; }
        public int SubjectId_FK { get; set; }
      
        public EnrolmentModel()
        {
            ID = 0;
            StudentId_FK = 0;
            SubjectId_FK = 0;
        }

        public EnrolmentModel(int ID, int studentId_FK, int subjectId_FK)
        {
            ID = ID;
            StudentId_FK = studentId_FK;
            SubjectId_FK = subjectId_FK;
        }
    }
}
