using AT2_CS.DataAccessLayer;
using AT2_CS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT2_CS.BusinessLogicLayer
{
    public class SubjectBLL
    {
        AppDAL appDAL;
        public SubjectBLL()
        {
            appDAL = new AppDAL();
        }
        public List<SubjectModel> GetAll()
        {
            return appDAL.SubjectDALInstance.ReadAll();
        }

        public SubjectModel GetOne(int id)
        {
            return appDAL.SubjectDALInstance.Read(id);
        }

        public bool Create(SubjectModel subject)
        {
            if(GetOne(subject.SubjectId) != null)
            {
                // if SubjectId id exists, return false
                return false;
            }
            else
            {
                // if student id does not exist, create it
                appDAL.SubjectDALInstance.Create(subject);
            }

            return true;
        }

        public bool Update(SubjectModel subject)
        {
            if (GetOne(subject.SubjectId) == null)
            {
                // if SubjectId id does not exist, return false
                return false;
            }
            else
            {
                // if SubjectId id exists, update it
                appDAL.SubjectDALInstance.Update(subject);
            }

            return true;
        }

        public bool Delete(int id)
        {
            if (GetOne(id) == null)
            {
                // if SubjectId id does not exist, return false
                return false;
            }
            else
            {
                // if SubjectId id exists, delete it
                appDAL.SubjectDALInstance.Delete(id);
            }

            return true;
        }
    }
}
