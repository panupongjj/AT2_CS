using AT2_CS.DataAccessLayer;
using AT2_CS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT2_CS.BusinessLogicLayer
{
    public class ReportBLL
    {
        AppDAL appDAL;
        public ReportBLL()
        {
            appDAL = new AppDAL();
        }
        public List<ReportModel> GetReport()
        {
            return appDAL.ReportDALInstance.ReadAll();
        }
        public List<ReportModel> GetEmail(int id)
        {
            return appDAL.ReportDALInstance.ReadByID(id);
        }


    }
}
