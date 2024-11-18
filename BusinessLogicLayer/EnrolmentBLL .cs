using AT2_CS.DataAccessLayer;
using AT2_CS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT2_CS.BusinessLogicLayer
{
    public class EnrolmentBLL
    {
        AppDAL appDAL;
        public EnrolmentBLL()
        {
            appDAL = new AppDAL();
        }
        public List<EnrolmentModel> GetAll()
        {
            return appDAL.EnrolmentDALInstance.ReadAll();
        }

        public EnrolmentModel GetOne(int id)
        {
            return appDAL.EnrolmentDALInstance.Read(id);
        }

        public bool Create(EnrolmentModel enrolment)
        {
            if(GetOne(enrolment.ID) != null)
            {
                // if student id exists, return false
                return false;
            }
            else
            {
                // if student id does not exist, create it
                appDAL.EnrolmentDALInstance.Create(enrolment);
            }

            return true;
        }

        public bool Update(EnrolmentModel enrolment)
        {
            if (GetOne(enrolment.ID) == null)
            {
                // if student id does not exist, return false
                return false;
            }
            else
            {
                // if student id exists, update it
                appDAL.EnrolmentDALInstance.Update(enrolment);
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
                appDAL.EnrolmentDALInstance.Delete(id);
            }

            return true;
        }
    }
}
