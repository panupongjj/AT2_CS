using System;
using AT2_CS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AT2_CS.BusinessLogicLayer;
using System.Xml.Linq;
using AT2_CS.PresentationLayer.SubjectPL;
using AT2_CS.PresentationLayer.StudentPL;


namespace AT2_CS.PresentationLayer.EnrolmentPL
{
    public class Enrolment_CRUD
    {
        GeneralMethodBLL gnMt = new GeneralMethodBLL();

        public void View()
        {
            var enrolmentBLL = new EnrolmentBLL();
            Console.WriteLine("Getting all Enrolment");
            Console.WriteLine("\nEnrolment:");
            Console.WriteLine("---------");
            Console.WriteLine("Enrolment ID, Student ID, Subject ID");
            Console.WriteLine("-------------------------");
            var result = enrolmentBLL.GetAll();
            if (result.Count == 0)
            {
                Console.WriteLine("table is empty");
            }
            else
            {
                foreach (var item in result)
                {
                    Console.WriteLine($"{item.ID}\t{item.StudentId_FK}\t{item.SubjectId_FK}");
                }
            }
        }

        public (int, int, int) ViewbyID(string msg)
        {
            var enrolment = new EnrolmentModel();
            string strPrint = "";

            strPrint = "Enter the enrolment ID for " + msg + ": ";
            enrolment.ID = gnMt.inputIntChecker(strPrint);
            Console.WriteLine("Getting all Enrolment");
            Console.WriteLine("\nEnrolment:");
            Console.WriteLine("---------");
            Console.WriteLine("Enrolment ID, Student ID, Subject ID");
            Console.WriteLine("-------------------------");
            int studentID_FK = 0;
            int subjectID_FK = 0;
            var enrolmentBLL = new EnrolmentBLL();
            var Result = enrolmentBLL.GetOne(enrolment.ID);
            if (Result == null)
            {
                Console.WriteLine($"enrolment({enrolment.ID}) does not exist");
            }
            else
            {
                Console.WriteLine($"{Result.ID}\t{Result.StudentId_FK}\t{Result.SubjectId_FK}");
                studentID_FK = Result.StudentId_FK;
                subjectID_FK = Result.SubjectId_FK;
            }

            return (enrolment.ID, studentID_FK, subjectID_FK);

        }

        public void Add()
        {
            var enrolment = new EnrolmentModel();
            string strPrint = "";

            int onlyIdAndName = 1;
            Student_CRUD student = new Student_CRUD();
            student.View(onlyIdAndName);

            Subject_CRUD Subject = new Subject_CRUD();
            Subject.View(onlyIdAndName);



            Console.WriteLine("Creating a new enrolment");

            strPrint = "Enter Student ID: ";
            enrolment.StudentId_FK = gnMt.inputIntChecker(strPrint);
            strPrint = "Enter Subject ID: ";
            enrolment.SubjectId_FK = gnMt.inputIntChecker(strPrint);
            var enrolmentBLL = new EnrolmentBLL();
            var result = enrolmentBLL.Create(enrolment);


            if (result == false)
            {
                Console.WriteLine($"Create new enrolment unsuccessful");
            }
            else
            {
                Console.WriteLine($"Create new enrolment successful");
            }

        }

        public void Update()
        {
            var enrolment = new EnrolmentModel();
            string strPrint = "";
            var data = ViewbyID("UPDATE");
            enrolment.ID = data.Item1;
            int studentID = data.Item2;
            int subjectID = data.Item3;


            var studentBLL = new StudentBLL();
            var student = studentBLL.GetOne(studentID);
            if (student == null)
            {
                Console.WriteLine($"Student({student.StudentId}) does not exist");
            }
            else
            {
                Console.WriteLine($"{student.StudentId}\t{student.FullName}");
            }

            var subjectBLL = new SubjectBLL();
            var subject = subjectBLL.GetOne(subjectID);
            if (subject == null)
            {
                Console.WriteLine($"subject({subject.SubjectId}) does not exist");
            }
            else
            {
                Console.WriteLine($"{subject.SubjectId}\t{subject.SubjectName}");
            }


            Console.WriteLine("Updating a new enrolment");
            strPrint = "Enter Student ID: ";
            enrolment.StudentId_FK = gnMt.inputIntChecker(strPrint);
            strPrint = "Enter Subject ID: ";
            enrolment.SubjectId_FK = gnMt.inputIntChecker(strPrint);
            var enrolmentBLL = new EnrolmentBLL();
            var result = enrolmentBLL.Update(enrolment);

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

            
            var enrolment = new EnrolmentModel();
            string strPrint = "";
            var data = ViewbyID("DELETE");
            enrolment.ID = data.Item1;
            int studentID = data.Item2;
            int subjectID = data.Item3;


            var studentBLL = new StudentBLL();
            var student = studentBLL.GetOne(studentID);
            if (student == null)
            {
                Console.WriteLine($"Student({student.StudentId}) does not exist");
            }
            else
            {
                Console.WriteLine($"{student.StudentId}\t{student.FullName}");
            }

            var subjectBLL = new SubjectBLL();
            var subject = subjectBLL.GetOne(subjectID);
            if (subject == null)
            {
                Console.WriteLine($"subject({subject.SubjectId}) does not exist");
            }
            else
            {
                Console.WriteLine($"{subject.SubjectId}\t{subject.SubjectName}");
            }

            Console.WriteLine("Deleting a subject");
            var enrolmentBLL = new EnrolmentBLL();;
            var result = enrolmentBLL.Delete(enrolment.ID);
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
