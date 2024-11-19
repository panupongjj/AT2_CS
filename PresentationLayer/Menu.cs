using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT2_CS.PresentationLayer
{
    // Display class for display different menu based on user selection
    // Parent class will be overried by child class on displayMenu()
    class Display
    {
        public Display() {
        
        }
        public virtual void displayMenu()
        {
            Console.WriteLine("Students management system");
        }

    }

    // MainMenu class for display the main menu option of the program 
    // inherited from Display and Override displayMenu() method
    class MainMenu : Display
    {
        string manuName;
        string manuSymbol;
        public MainMenu(string manuSymbol, string manuName) { 
            this.manuName = manuName;
            this.manuSymbol = manuSymbol;
        }
        public override void displayMenu()
        {
            Console.Clear();
            string symL = string.Concat(Enumerable.Repeat(this.manuSymbol, 51));
            string symS = string.Concat(Enumerable.Repeat(this.manuSymbol, 15));
            string text = "[ " + this.manuName + " ]";
            Console.WriteLine(symL);
            Console.WriteLine(symS + text+ symS);
            Console.WriteLine(symL);
            Console.WriteLine("\t 1. Student Management system");
            Console.WriteLine("\t 2. Subject Management system");
            Console.WriteLine("\t 3. Enrolment Management system");
            Console.WriteLine("\t 4. Report Management system");
            Console.WriteLine("\n\t ----------------------");
            Console.WriteLine("\t 0. Exit The Program");
            Console.WriteLine(symL);
        }

    }
    // StudentMenu class for display the student menu option of the program
    // inherited from Display and Override displayMenu() method
    class EnrolmentMenagementMenu : Display
    {
        string manuName;
        string manuSymbol;
        public EnrolmentMenagementMenu(string manuSymbol, string manuName)
        {
            this.manuName = manuName;
            this.manuSymbol = manuSymbol;
        }
        public override void displayMenu()
        {
            Console.Clear();
            string symL = string.Concat(Enumerable.Repeat(this.manuSymbol, 55));
            string symS = string.Concat(Enumerable.Repeat(this.manuSymbol, 12));
            string text = "[ " + this.manuName + " ]";
            Console.WriteLine(symL);
            Console.WriteLine(symS + text + symS);
            Console.WriteLine(symL);
            Console.WriteLine("\t 1. Add New Enrolment Data");
            Console.WriteLine("\t 2. Update Enrolment Data");
            Console.WriteLine("\t 3. Delete Enrolment Data");
            Console.WriteLine("\t 4. View Enrolment Data");
            Console.WriteLine("\t 5. View Enrolment Data By ID");
            Console.WriteLine("\n\t ----------------------");
            Console.WriteLine("\t 9. Back To Previous Menu");
            Console.WriteLine("\t 0. Exit The Program");
            Console.WriteLine(symL);

        }

    }
    // CalculationMenu class for display the claculation menu option of the program
    // inherited from Display and Override displayMenu() method
    class SubjectMenagementMenu : Display
    {
        string manuName;
        string manuSymbol;
        public SubjectMenagementMenu(string manuSymbol, string manuName)
        {
            this.manuName = manuName;
            this.manuSymbol = manuSymbol;
        }
        public override void displayMenu()
        {
            Console.Clear();
            string symL = string.Concat(Enumerable.Repeat(this.manuSymbol, 49));
            string symS = string.Concat(Enumerable.Repeat(this.manuSymbol, 10));
            string text = "[ " + this.manuName + " ]";
            Console.WriteLine(symL);
            Console.WriteLine(symS + text + symS);
            Console.WriteLine(symL);
            Console.WriteLine("\t 1. Add New Subject Data");
            Console.WriteLine("\t 2. Update Subject Data");
            Console.WriteLine("\t 3. Delete Subject Data");
            Console.WriteLine("\t 4. View Subject Data");
            Console.WriteLine("\t 5. View Subject Data By ID");
            Console.WriteLine("\n\t ----------------------");
            Console.WriteLine("\t 9. Back To Previous Menu");
            Console.WriteLine("\t 0. Exit The Program");
            Console.WriteLine(symL);


        }

    }
    // MenagementMenu class for display the menagement menu option of the program
    // inherited from Display and Override displayMenu() method
    class StudentMenagementMenu : Display
    {
        string manuName;
        string manuSymbol;
        public StudentMenagementMenu(string manuSymbol, string manuName)
        {
            this.manuName = manuName;
            this.manuSymbol = manuSymbol;
        }
        public override void displayMenu()
        {
            Console.Clear();
            string symL = string.Concat(Enumerable.Repeat(this.manuSymbol, 49));
            string symS = string.Concat(Enumerable.Repeat(this.manuSymbol, 10));
            string text = "[ " + this.manuName + " ]";
            Console.WriteLine(symL);
            Console.WriteLine(symS + text + symS);
            Console.WriteLine(symL);
            Console.WriteLine("\t 1. Add New Student Data");
            Console.WriteLine("\t 2. Update Student Data");
            Console.WriteLine("\t 3. Delete Student Data");
            Console.WriteLine("\t 4. View Student Data");
            Console.WriteLine("\t 5. View Student Data By ID");
            Console.WriteLine("\n\t ----------------------");
            Console.WriteLine("\t 9. Back To Previous Menu");
            Console.WriteLine("\t 0. Exit The Program");
            Console.WriteLine(symL);


        }



    }
        class ReportMenagementMenu : Display
        {
            string manuName;
            string manuSymbol;
            public ReportMenagementMenu(string manuSymbol, string manuName)
            {
                this.manuName = manuName;
                this.manuSymbol = manuSymbol;
            }
            public override void displayMenu()
            {
                Console.Clear();
                string symL = string.Concat(Enumerable.Repeat(this.manuSymbol, 49));
                string symS = string.Concat(Enumerable.Repeat(this.manuSymbol, 10));
                string text = "[ " + this.manuName + " ]";
                Console.WriteLine(symL);
                Console.WriteLine(symS + text + symS);
                Console.WriteLine(symL);
                Console.WriteLine("\t 1. Enroment Report");
                Console.WriteLine("\t 2. Email Notification");
                Console.WriteLine("\t 3. Import CSV to Database");
                Console.WriteLine("\t 4. Export Database to CSV");
                Console.WriteLine("\n\t ----------------------");
                Console.WriteLine("\t 9. Back To Previous Menu");
                Console.WriteLine("\t 0. Exit The Program");
                Console.WriteLine(symL);


            }

        }

}
