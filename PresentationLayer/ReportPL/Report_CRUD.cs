using System;
using AT2_CS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AT2_CS.BusinessLogicLayer;
using AT2_CS.PresentationLayer.StudentPL;


namespace AT2_CS.PresentationLayer.ReportPL
{
    public class Report_CRUD
    {
        GeneralMethodBLL gnMt = new GeneralMethodBLL();

        public void View(int onlyIdAndName = 0)
        {
            var reportBLL = new ReportBLL();
            Console.WriteLine("Enrolment Report");;
            Console.WriteLine("---------");

            Console.WriteLine("Student ID, Student Name, Subject Id, Subject Name");
            
            Console.WriteLine("-------------------------");
            var result = reportBLL.GetReport();
            if (result.Count == 0)
            {
                Console.WriteLine("table is empty");
            }
            else
            {
                foreach (var item in result)
                {
                  Console.WriteLine($"{item.StudentId}\t{item.FullName}\t{item.SubjectId}\t{item.SubjectName}");
                  //Console.WriteLine($"{item.SubjectId}\t{item.SubjectName}{item.StudentId}\t{item.FullName}");

                }
                    
            }
        }
        public void Email(int onlyIdAndName = 0)
        {
            var reportBLL = new ReportBLL();
            string strPrint = "";
            string msg = "Send Email Notification";


            Student_CRUD student = new Student_CRUD();
            student.View(1);
            strPrint = ("Enter the student ID for " + msg + ":");
            int StudentId = gnMt.inputIntChecker(strPrint);

            var result = reportBLL.GetEmail(StudentId);
            if (result.Count == 0)
            {
                Console.WriteLine("table is empty");
            }
            else
            {
;               int count = 0;
                foreach (var item in result)
                {
                    if (count == 0) {

                        Console.WriteLine("-----------------------------------------");
                        Console.WriteLine(" FROM : Holmesglens@hom.com ");
                        Console.WriteLine(" TO : "+item.Email+" ");
                        Console.WriteLine("-----------------------------------------\n");
                        Console.WriteLine(" Dear " + item.FullName + ",\n");
                        Console.WriteLine(" You have been enrolment in the following subject");
                    }

                    Console.WriteLine(" >  "+item.SubjectName + " (SU" + (item.SubjectId*100)+(item.SubjectId) + ")");
                    count++;
                }
                Console.WriteLine(" Please login to your account and confirm the above enrolments.\n");
                Console.WriteLine(" Regards,\n CAIT Department");

            }
        }


    }
}
