using AT2_CS.DataAccessLayer;
using AT2_CS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT2_CS.BusinessLogicLayer
{
    public class StudentBLL
    {
        AppDAL appDAL;
        public StudentBLL()
        {
            appDAL = new AppDAL();
        }
        public List<StudentModel> GetAll()
        {
            return appDAL.StudentDALInstance.ReadAll();
        }

        public StudentModel GetOne(int id)
        {
            return appDAL.StudentDALInstance.Read(id);
        }

        public bool Create(StudentModel student)
        {
            if(GetOne(student.StudentId) != null)
            {
                // if student id exists, return false
                return false;
            }
            else
            {
                // if student id does not exist, create it
                appDAL.StudentDALInstance.Create(student);
            }

            return true;
        }

        public bool Update(StudentModel student)
        {
            if (GetOne(student.StudentId) == null)
            {
                // if student id does not exist, return false
                return false;
            }
            else
            {
                // if student id exists, update it
                appDAL.StudentDALInstance.Update(student);
            }

            return true;
        }

        public bool Delete(int id)
        {
            if (GetOne(id) == null)
            {
                // if student id does not exist, return false
                return false;
            }
            else
            {
                // if student id exists, delete it
                appDAL.StudentDALInstance.Delete(id);
            }

            return true;
        }
    }
}
