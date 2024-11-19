using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AT2_CS.DataAccessLayer;
using AT2_CS.PresentationLayer;

namespace AT2_CS.Models
{
    public class AT2_CS_Context : DbContext
    {
        public DbSet<StudentModel> Student { get; set; }
        public DbSet<SubjectModel> Subject { get; set; }
        public DbSet<EnrolmentModel> Enrolment { get; set; }
        public DbSet<StudentEF> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {   
            optionsBuilder.UseSqlServer(AT2_CS_DataBase.ConnectionString);
        }

    }
}
