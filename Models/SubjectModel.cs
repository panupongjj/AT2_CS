using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT2_CS.Models
{
    public class SubjectModel
    {   
        [Key]
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }


        public SubjectModel()
        {
            SubjectId = 0;
            SubjectName = "";

        }

        public SubjectModel(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;

        }
    }
}
