using Lesson_3.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Windows;

namespace Lesson_3.VM
{
    public class StudentPageVM : PageVM
    {
        public Student Student { get; }
        public BindingList<StudentList> StudentList { get; }
        public StudentPageVM()
        {
            Student = new Student
            {
                MiddleName = "Иванов",
                FirstName = "Сергей",
                LastName = "Викторович",
                DateBirth = new DateTime(2002, 05, 04),
                YearUniversity = "2 курс"
            };
            StudentList = new BindingList<StudentList>();
        }


        public void StudentLoader (object sender, RoutedEventArgs e)
        {
            new StudentList()
            {
                FullName = Student.MiddleName + " " + Student.FirstName + " " + Student.LastName,
                Age = 18,
                YearUniversity = Student.YearUniversity
            };
        }
    }
}
