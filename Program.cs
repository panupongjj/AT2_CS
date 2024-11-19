using AT2_CS.PresentationLayer;

namespace AT2_CS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (new PL_Main()).RUN();
            
            //var efClass = new EFModeClass();

            // CREATE: Add a new student
            //efClass.AddStudent("Pan", "jan", new DateTime(1992, 5, 28));

            ////READ: Get student by ID
            //var student = efClass.GetStudentById(3);
            //if (student != null)
            //{
            //    Console.WriteLine($"Found student: {student.FirstName} {student.LastName}");
            //}

            //// UPDATE: Update an existing student
            //efClass.UpdateStudent(2, "John", "XXXXXX", new DateTime(2000, 1, 15));

            //// DELETE: Delete a student by ID
            //efClass.DeleteStudent(2);

            //// List all students
            //efClass.ListAllStudents();
        }
    }
}
