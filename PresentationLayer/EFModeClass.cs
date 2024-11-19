using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AT2_CS.DataAccessLayer;
using AT2_CS.Models;

namespace AT2_CS.PresentationLayer
{
    public class EFModeClass
    {
        private readonly AT2_CS_Context _context;

        public EFModeClass()
        {
            _context = new AT2_CS_Context();
        }

        // CREATE: Add a new student
        public void AddStudent(string firstName, string lastName, DateTime dateOfBirth)
        {
            var student = new StudentEF
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth
            };

            _context.Students.Add(student);
            _context.SaveChanges();

            Console.WriteLine($"Student {firstName} {lastName} added successfully!");
        }

        // READ: Get a student by ID
        public StudentEF GetStudentById(int studentId)
        {
            return _context.Students.SingleOrDefault(s => s.StudentId == studentId);
        }

        // UPDATE: Update student details
        public void UpdateStudent(int studentId, string newFirstName, string newLastName, DateTime newDateOfBirth)
        {
            var student = _context.Students.SingleOrDefault(s => s.StudentId == studentId);
            if (student != null)
            {
                student.FirstName = newFirstName;
                student.LastName = newLastName;
                student.DateOfBirth = newDateOfBirth;

                _context.SaveChanges();

                Console.WriteLine($"Student {studentId} updated successfully!");
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
        }

        // DELETE: Delete a student by ID
        public void DeleteStudent(int studentId)
        {
            var student = _context.Students.SingleOrDefault(s => s.StudentId == studentId);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();

                Console.WriteLine($"Student {studentId} deleted successfully!");
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
        }

        // OPTIONAL: List all students
        public void ListAllStudents()
        {
            var students = _context.Students.ToList();
            if (students.Any())
            {
                foreach (var student in students)
                {
                    Console.WriteLine($"{student.StudentId}: {student.FirstName} {student.LastName} ({student.DateOfBirth.ToShortDateString()})");
                }
            }
            else
            {
                Console.WriteLine("No students found.");
            }
        }
    }

    public class StudentEF
    {
        [Key]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }


   
}
