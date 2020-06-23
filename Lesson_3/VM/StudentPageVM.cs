using Lesson_3.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

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
            AddStudent = new RelayCommand(_ => AddStudentAction());
        }

        private string text;
        public string MiddleNameText
        {
            get => text;
            set => SetProperty(ref text, value);
        }
        public string FirstNameText
        {
            get => text;
            set => SetProperty(ref text, value);
        }
        public string LastNameText
        {
            get => text;
            set => SetProperty(ref text, value);
        }
        public string YearUniversityText
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        private DateTime dateTimeText;
        public DateTime DateTimeText
        {
            get => dateTimeText;
            set => SetProperty(ref dateTimeText, value);
        }

        //public int AgeResalt
        //{
        //    get
        //    {
        //        int a;
        //        a = Convert.ToString(DateTimeText.DateTime);
        //        var date = DateTime.ParseExact(a, "dd.MM.yyyy", CultureInfo.InvariantCulture);
        //        var age = DateTime.Now.Year - date.Year;
        //        if (DateTime.Now.Month < date.Month ||
        //           (DateTime.Now.Month == date.Month && DateTime.Now.Day < date.Day)) age--;
                
        //        return age;
        //    }
        //}

        public ICommand AddStudent { get; }
        public void AddStudentAction()
        {
            StudentList.Add(new Student());
        }
    }
}
