using System;
using AT2_CS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AT2_CS.BusinessLogicLayer;
using System.Xml.Linq;




namespace AT2_CS.PresentationLayer.EnrolmentPL
{
    public class Subject_CRUD
    {
        GeneralMethodBLL gnMt = new GeneralMethodBLL();

        public void View(int onlyIdAndName = 0)
        {
            var subjectBLL = new SubjectBLL();
            Console.WriteLine("Getting all subject");
            Console.WriteLine("\nSubject:");
            Console.WriteLine("---------");
            Console.WriteLine("Subject ID, Subject Name");
            Console.WriteLine("-------------------------");
            var result = subjectBLL.GetAll();
            if (result.Count == 0)
            {
                Console.WriteLine("table is empty");
            }
            else
            {
                foreach (var item in result)
                {
                    Console.WriteLine($"{item.SubjectId}\t{item.SubjectName}");
                }
            }
        }

        public int ViewbyID(string msg, int onlyIdAndName = 0)
        {
            var subject = new SubjectModel();
            string strPrint = "";

            strPrint = "Enter the subject ID for " + msg + ": ";
            subject.SubjectId = gnMt.inputIntChecker(strPrint);

            Console.WriteLine("\nSubject:");
            Console.WriteLine("---------");
            Console.WriteLine("Subject ID, Subject Name");
            Console.WriteLine("-------------------------");
            var subjectBLL = new SubjectBLL();
            var Result = subjectBLL.GetOne(subject.SubjectId);
            if (Result == null)
            {
                Console.WriteLine($"Subject({Result.SubjectId}) does not exist");
            }
            else
            {
                Console.WriteLine($"{Result.SubjectId}\t{Result.SubjectName}");
            }

            return subject.SubjectId;

        }

        public void Add()
        {
            var subject = new SubjectModel();
            string strPrint = "";

            Console.WriteLine("Creating a new subject");

            strPrint = "Enter subject Name: ";
            subject.SubjectName = gnMt.inputStringChecker(strPrint);

            var subjectBLL = new SubjectBLL();
            var result = subjectBLL.Create(subject);

            if (result == false)
            {
                Console.WriteLine($"Create new subject unsuccessful");
            }
            else
            {
                Console.WriteLine($"Create new subject successful");
            }

        }

        public void Update()
        {
            var subject = new SubjectModel();
            string strPrint = "";
            subject.SubjectId = ViewbyID("UPDATE");

            Console.WriteLine("Updating a new subject");

            strPrint = "Enter subject Name: ";
            subject.SubjectName = gnMt.inputStringChecker(strPrint);


            var subjectBLL = new SubjectBLL();
            var result = subjectBLL.Update(subject);

            if (result == false)
            {
                Console.WriteLine($"Update new subject unsuccessful");
            }
            else
            {
                Console.WriteLine($"Update new subject successful");
            }

        }
        public void Delete()
        {
            var subject = new SubjectModel();
            string strPrint = "";
            subject.SubjectId = ViewbyID("DELETE");

            Console.WriteLine("Deleting a subject");

            var subjectBLL = new SubjectBLL();
            var result = subjectBLL.Delete(subject.SubjectId);
            if (result == false)
            {
                Console.WriteLine($"Delete subject unsuccessful");
            }
            else
            {
                Console.WriteLine($"Delete subject successful");
            }


        }

    }
}
