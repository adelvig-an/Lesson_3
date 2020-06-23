using Lesson_3.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Windows;

namespace Lesson_3.VM
{
    public class StudentPageVM : PageVM
    {
        public Student Student { get; }
        
        public static ObservableCollection<Student> StudentList { get; set; }
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
            
            StudentList = new ObservableCollection<Student>()
            {
                new Student
                {
                    FullName = Student.MiddleName+" "+Student.FirstName+" "+Student.LastName,
                    Age = 18,
                    YearUniversity = Student.YearUniversity
                }
            };
        }
    }
}
