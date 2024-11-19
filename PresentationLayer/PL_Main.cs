using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AT2_CS.BusinessLogicLayer;
using AT2_CS.PresentationLayer.EnrolmentPL;
using AT2_CS.PresentationLayer.StudentPL;
using AT2_CS.PresentationLayer.SubjectPL;
using AT2_CS.PresentationLayer.ReportPL;
namespace AT2_CS.PresentationLayer
{
    public class PL_Main
    {
        public void RUN()
        {
            //Display Class pass Parameter for display ( Symbol , MenuName)
            MainMenu dpMain = new MainMenu("+", "Management System");
            StudentMenagementMenu studenMenu = new StudentMenagementMenu("/", "Student Management system");
            SubjectMenagementMenu subjectMenu = new SubjectMenagementMenu("*", "Subject Management system");
            EnrolmentMenagementMenu enrolmentMenu = new EnrolmentMenagementMenu("-", "Enrolment Management System");
            ReportMenagementMenu reportlmentMenu = new ReportMenagementMenu("-", "Report Management System");

            //General Class
            GeneralMethodBLL gnMt = new GeneralMethodBLL();

            //Control flow valiable
            bool checke = true;
            bool checkb_sub = true;
            int userInput_sub = 0;

            while (checke)
            {
                string strPrint = "";
                //Display Students Management System
                dpMain.displayMenu();
                strPrint = ("Enter the select number: ");
                int userInput = gnMt.inputIntChecker(strPrint);
                switch (userInput)
                {
                    case 1:
                        //Display Students Data System
                        checkb_sub = true;
                        while (checkb_sub)
                        {
                            Console.Clear();
                            studenMenu.displayMenu();
                            strPrint = ("Enter the select number: ");
                            userInput_sub = gnMt.inputIntChecker(strPrint);
                            switch (userInput_sub)
                            {
                                case 1:
                                    (new Student_CRUD()).Add();
                                    Console.WriteLine("\nPress enter to continue . . . .");
                                    Console.ReadLine();
                                    break;
                                case 2:
                                    (new Student_CRUD()).Update();
                                    Console.WriteLine("\nPress enter to continue . . . .");
                                    Console.ReadLine();
                                    break;
                                case 3:
                                    (new Student_CRUD()).Delete();
                                    Console.WriteLine("\nPress enter to continue . . . .");
                                    Console.ReadLine();
                                    break;
                                case 4:
                                    (new Student_CRUD()).View();
                                    Console.WriteLine("\nPress enter to continue . . . .");
                                    Console.ReadLine();
                                    break;
                                case 5:
                                    (new Student_CRUD()).ViewbyID("VIEW");
                                    Console.WriteLine("\nPress enter to continue . . . .");
                                    Console.ReadLine();
                                    break;
                                case 9:
                                    checkb_sub = false;
                                    break;
                                case 0:
                                    checkb_sub = false;
                                    checke = false;
                                    break;
                                default:
                                    break;

                            }
                        }
                        break;

                    case 2:
                        //Display Calculation System
                        checkb_sub = true;
                        while (checkb_sub)
                        {
                            Console.Clear();
                            subjectMenu.displayMenu();
                            strPrint = ("Enter the select number: ");
                            userInput_sub = gnMt.inputIntChecker(strPrint);
                            switch (userInput_sub)
                            {
                                case 1:
                                    (new Subject_CRUD()).Add();
                                    Console.WriteLine("\nPress enter to continue . . . .");
                                    Console.ReadLine();
                                    break;
                                case 2:
                                    (new Subject_CRUD()).Update();
                                    Console.WriteLine("\nPress enter to continue . . . .");
                                    Console.ReadLine();
                                    break;
                                case 3:
                                    (new Subject_CRUD()).Delete();
                                    Console.WriteLine("\nPress enter to continue . . . .");
                                    Console.ReadLine();
                                    break;
                                case 4:
                                    (new Subject_CRUD()).View();
                                    Console.WriteLine("\nPress enter to continue . . . .");
                                    Console.ReadLine();
                                    break;
                                case 5:
                                    (new Subject_CRUD()).ViewbyID("VIEW");
                                    Console.WriteLine("\nPress enter to continue . . . .");
                                    Console.ReadLine();
                                    break;
                                case 9:
                                    checkb_sub = false;
                                    break;
                                case 0:
                                    checkb_sub = false;
                                    checke = false;
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;

                    case 3:
                        //Display Management system
                        checkb_sub = true;
                        while (checkb_sub)
                        {
                            Console.Clear();
                            enrolmentMenu.displayMenu();
                            strPrint = ("Enter the select number: ");
                            userInput_sub = gnMt.inputIntChecker(strPrint);
                            switch (userInput_sub)
                            {
                                case 1:
                                    (new Enrolment_CRUD()).Add();
                                    Console.WriteLine("\nPress enter to continue . . . .");
                                    Console.ReadLine();
                                    break;
                                case 2:
                                    (new Enrolment_CRUD()).Update();
                                    Console.WriteLine("\nPress enter to continue . . . .");
                                    Console.ReadLine();
                                    break;
                                case 3:
                                    (new Enrolment_CRUD()).Delete();
                                    Console.WriteLine("\nPress enter to continue . . . .");
                                    Console.ReadLine();
                                    break;
                                case 4:
                                    (new Enrolment_CRUD()).View();
                                    Console.WriteLine("\nPress enter to continue . . . .");
                                    Console.ReadLine();
                                    break;
                                case 5:
                                    (new Enrolment_CRUD()).ViewbyID("VIEW");
                                    Console.WriteLine("\nPress enter to continue . . . .");
                                    Console.ReadLine();
                                    break;
                                case 9:
                                    checkb_sub = false;
                                    break;
                                case 0:
                                    checkb_sub = false;
                                    checke = false;
                                    break;
                                default:
                                    break;

                            }
                        }
                        break;
                    case 4:
                        //Display Students Data System
                        checkb_sub = true;
                        while (checkb_sub)
                        {
                            Console.Clear();
                            reportlmentMenu.displayMenu();
                            strPrint = ("Enter the select number: ");
                            userInput_sub = gnMt.inputIntChecker(strPrint);
                            switch (userInput_sub)
                            {
                                case 1:
                                    (new Report_CRUD()).View();
                                    Console.WriteLine("\nPress enter to continue . . . .");
                                    Console.ReadLine();
                                    break;
                                case 2:
                                    (new Report_CRUD()).Email();
                                    Console.WriteLine("\nPress enter to continue . . . .");
                                    Console.ReadLine();
                                    break;
                                case 3:
                                    //import
                                    Console.WriteLine("\nPress enter to continue . . . .");
                                    Console.ReadLine();
                                    break;
                                case 4:
                                    //export
                                    Console.WriteLine("\nPress enter to continue . . . .");
                                    Console.ReadLine();
                                    break;
                                case 9:
                                    checkb_sub = false;
                                    break;
                                case 0:
                                    checkb_sub = false;
                                    checke = false;
                                    break;
                                default:
                                    break;

                            }
                        }
                        break;
                    
                    case 0:
                        checke = false;
                        break;
                    
                    default:
                        break;

                }

            }
        }



    }
}
