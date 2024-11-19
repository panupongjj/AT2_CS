using System;
using AT2_CS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AT2_CS.BusinessLogicLayer;


namespace AT2_CS.PresentationLayer.SubjectPL
{
    public class Student_CRUD
    {
        GeneralMethodBLL gnMt = new GeneralMethodBLL();

        public void View(int onlyIdAndName = 0)
        {
            var studentBLL = new StudentBLL();
            Console.WriteLine("Getting all students");
            Console.WriteLine("\nStudents:");
            Console.WriteLine("---------");
            if (onlyIdAndName == 1)
            {
                Console.WriteLine("Student ID, Student Name");
            } else{
                Console.WriteLine("Student ID, Student Name, Phone Number, Email, Date of birth, Enrolment Date, Enrolment Cert, Total Score");
            }
            Console.WriteLine("-------------------------");
            var result = studentBLL.GetAll();
            if (result.Count == 0)
            {
                Console.WriteLine("table is empty");
            }
            else
            {
                foreach (var item in result)
                {
                    if (onlyIdAndName == 1)
                    {
                        Console.WriteLine($"{item.StudentId}\t{item.FullName}");
                    }
                    else {
                        Console.WriteLine($"{item.StudentId}\t{item.FullName}\t{item.Phone}\t{item.Email}\t{item.DoB}\t{item.EnrolmentDate}\t{item.EnrolmentCert}\t{item.TotalScore}");
                    }
                }
                    
            }
        }

        public int ViewbyID(string msg, int onlyIdAndName = 0)
        {
            var student = new StudentModel();
            string strPrint = "";

            strPrint = ("Enter the student ID for " + msg + ": ");
            student.StudentId = gnMt.inputIntChecker(strPrint);

            Console.WriteLine("\nStudents:");
            Console.WriteLine("---------");
            if (onlyIdAndName == 1)
            {
                Console.WriteLine("Student ID, Student Name");
            }
            else
            {
                Console.WriteLine("Student ID, Student Name, Phone Number, Email, Date of birth, Enrolment Date, Enrolment Cert, Total Score");
            }
            Console.WriteLine("-------------------------");

            var studentBLL = new StudentBLL();
            var Result = studentBLL.GetOne(student.StudentId);
            if (Result == null)
            {
                Console.WriteLine($"Student({student.StudentId}) does not exist");
            }
            else
            {
                if (onlyIdAndName == 1)
                {
                    Console.WriteLine($"{Result.StudentId}\t{Result.FullName}");
                }
                else
                {
                    Console.WriteLine($"{Result.StudentId}\t{Result.FullName}\t{Result.Phone}\t{Result.Email}\t{Result.DoB}\t{Result.EnrolmentDate}\t{Result.EnrolmentCert}\t{Result.TotalScore}");
                }           
            }

            return student.StudentId;

        }

        public void Add()
        {
            var student = new StudentModel();
            string strPrint = "";
            
            Console.WriteLine("Creating a new student");

            strPrint = "Enter student FullName: ";
            student.FullName = gnMt.inputStringChecker(strPrint);

            strPrint = "Enter student Phone: ";
            student.Phone = gnMt.inputPhoneChecker(strPrint);

            strPrint = "Enter student Email: ";
            student.Email = gnMt.inputStringChecker(strPrint);

            strPrint = "Enter student DoB: ";
            student.DoB = DateTime.Parse(gnMt.inputDateChecker(strPrint));

            strPrint = "Enter student EnrolmentDate: ";
            student.EnrolmentDate = DateTime.Parse(gnMt.inputDateChecker(strPrint));

            strPrint = "Enter student EnrolmentCert: ";
            student.EnrolmentCert = gnMt.inputStringChecker(strPrint);

            strPrint = "Enter student TotalScore: ";
            student.TotalScore = gnMt.inputScoreChecker(strPrint);

            var studentBLL = new StudentBLL();
            var result = studentBLL.Create(student);

            if (result == false)
            {
                Console.WriteLine($"Create new student unsuccessful");
            }
            else
            {
                Console.WriteLine($"Create new student successful");
            }

        }

        public void Update()
        {
            var student = new StudentModel();
            string strPrint = "";
            student.StudentId = ViewbyID("UPDATE");

            Console.WriteLine("Updating a new student");

            strPrint = "Enter student FullName: ";
            student.FullName = gnMt.inputStringChecker(strPrint);

            strPrint = "Enter student Phone: ";
            student.Phone = gnMt.inputPhoneChecker(strPrint);

            strPrint = "Enter student Email: ";
            student.Email = gnMt.inputStringChecker(strPrint);

            strPrint = "Enter student DoB: ";
            student.DoB = DateTime.Parse(gnMt.inputDateChecker(strPrint));

            strPrint = "Enter student EnrolmentDate: ";
            student.EnrolmentDate = DateTime.Parse(gnMt.inputDateChecker(strPrint));

            strPrint = "Enter student EnrolmentCert: ";
            student.EnrolmentCert = gnMt.inputStringChecker(strPrint);

            strPrint = "Enter student TotalScore: ";
            student.TotalScore = gnMt.inputScoreChecker(strPrint);

            var studentBLL = new StudentBLL();
            var result = studentBLL.Update(student);

            if (result == false)
            {
                Console.WriteLine($"Update new student unsuccessful");
            }
            else
            {
                Console.WriteLine($"Update new student successful");
            }

        }
        public void Delete()
        {
            var student = new StudentModel();
            string strPrint = "";
            student.StudentId = ViewbyID("DELETE");
            Console.WriteLine("Deleting a student");
            var studentBLL = new StudentBLL();
            var result = studentBLL.Delete(student.StudentId);
            if (result == false)
            {
                Console.WriteLine($"Delete student unsuccessful");
            }
            else
            {
                Console.WriteLine($"Delete student successful");
            }


        }

    }
}
