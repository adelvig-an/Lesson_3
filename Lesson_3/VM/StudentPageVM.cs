using Lesson_3.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Security.Cryptography;
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
        public static ObservableCollection<Student> StudentList2 { get; set; }
        public StudentPageVM()
        {
            Student = new Student
            {
                //MiddleName = "Иванов",
                //FirstName = "Сергей",
                //LastName = "Викторович",
                //DateBirth = new DateTime(2002, 05, 04),
                //YearUniversity = "2 курс"
            };
            
            StudentList = new ObservableCollection<Student>()
            {
                new Student
                {
                    //FullName = Student.MiddleName+" "+Student.FirstName+" "+Student.LastName,
                    //Age = AgeResalt,
                    //YearUniversity = Student.YearUniversity,
                }
            };
            
            
            
            AddStudent = new RelayCommand(_ => AddStudentAction());
            RemoveStudent = new RelayCommand(_ => RemoveStudentAction());
            DeleteRowCommand = new RelayCommand(_ => DeleteCurrentSelected());
            FullDelete = new RelayCommand(_ => FullDeleteAction());
        }

        //Расчет возраста от даты рождения
        public int AgeResalt
        {
            get
            {
                var age = DateTime.Now.Year - Student.DateBirth.Year;
                if (DateTime.Now.Month < Student.DateBirth.Month ||
                   (DateTime.Now.Month == Student.DateBirth.Month && DateTime.Now.Day < Student.DateBirth.Day)) age--;

                return age;
            }
        }
        
        //Добавление данных Студента
        public ICommand AddStudent { get; }
        public void AddStudentAction()
        {
            StudentList.Add(new Student()
            {
                FullName = Student.MiddleName + " " + Student.FirstName + " " + Student.LastName,
                Age = AgeResalt,
                YearUniversity = Student.YearUniversity
            });
        }

        //Удаление данных Студента по значению в чекбоксе
        public ICommand RemoveStudent { get; }
        public void RemoveStudentAction()
        {
            StudentList2 = new ObservableCollection<Student>(StudentList);

            foreach (var student in StudentList2)
            {
                if (student.IsStudent == true)
                    StudentList.Remove(student);
            }
        }

        //Удаление выделеной строки
        private Student selectedStudents;
        public Student SelectedStudents
        {
            get => selectedStudents;
            set 
            {
                selectedStudents = value;
                OnPropertyChanged(nameof(SelectedStudents));
            }
        }
        public ICommand DeleteRowCommand { get; }
        public void DeleteCurrentSelected()
        {
            //StudentList2 = new ObservableCollection<Student>(StudentList);
            
            if (SelectedStudents != null)
            {
                StudentList.Remove(SelectedStudents);
                SelectedStudents = null;
            }
        }

        //Удаление всех значений
        public ICommand FullDelete { get; }
        public void FullDeleteAction()
        {
            StudentList2 = new ObservableCollection<Student>(StudentList);

            foreach (var student in StudentList2)
            {
                if (student != null)
                    StudentList.Remove(student);
            }
        }

    }
}
