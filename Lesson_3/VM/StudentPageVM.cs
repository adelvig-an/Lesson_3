using Lesson_3.Model;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Lesson_3.VM
{
    public class StudentPageVM : PageVM
    {
        public Student Student { get; }
        public FileService FileService;
        
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
                //new Student
                //{
                //    //FullName = Student.MiddleName+" "+Student.FirstName+" "+Student.LastName,
                //    //Age = AgeResalt,
                //    //YearUniversity = Student.YearUniversity,
                //}
            };


            AddStudent = new RelayCommand(_ => AddStudentAction());
            RemoveStudent = new RelayCommand(_ => RemoveStudentAction());
            DeleteRowCommand = new RelayCommand(SelectedItems => DeleteCurrentSelected(SelectedItems));
            FullDelete = new RelayCommand(_ => FullDeleteAction());
            SaveStudent = new RelayCommand(_ => SaveStudentAction());
            LoadStudent = new RelayCommand(_ => LoadStudentAction());
        }

        public ICommand DeleteRowCommand { get; }

        //Удаление выделенных строк
        public void DeleteCurrentSelected(object p) 
        { 
            IList selectedItems = (IList)p; 
            foreach (var s in selectedItems.OfType<Student>().ToArray()) 
            { 
                StudentList.Remove(s); 
            } 
        }

        //Расчет возраста от даты рождения
        public int AgeResult
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
                FirstName = Student.FirstName,
                MiddleName = Student.MiddleName,
                LastName = Student.LastName,
                DateBirth = Student.DateBirth,
                Age = AgeResult,
                YearUniversity = Student.YearUniversity,
                FullName = Student.MiddleName + " " + Student.FirstName + " " + Student.LastName,
                IsStudent = Student.IsStudent
            });
        }

        //Удаление данных Студента по значению в чекбоксе
        public ICommand RemoveStudent { get; }
        public void RemoveStudentAction()
        {
            StudentList2 = new ObservableCollection<Student>(StudentList);

            foreach (var student in StudentList2)
                if (student.IsStudent == true)
                    StudentList.Remove(student);
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

        SaveFileDialog SaveFileDialog = new SaveFileDialog();
        OpenFileDialog OpenFileDialog = new OpenFileDialog();
        

        //Постоянное имя файла
        //const string filePath = "temp_student.json";

        
        FileService fileServiceXml = new FileXml();
        FileService fileServiceJson = new FileJson();
        FileService fileServiceTxt = new FileTxt();

        //Сохраняем список студентов
        public ICommand SaveStudent { get; }
        public void SaveStudentAction()
        {
            SaveFileDialog.Filter = "Txt files (*.txt)|*.txt|Xml files (*.xml)|*.xml|Json files (*.jon)|*.json|All files (*.*)|*.*";
            if (true == SaveFileDialog.ShowDialog())
            {
                string filePath = SaveFileDialog.FileName;
                //FileInfo fileInfo = new FileInfo(filePath);
                var b = Path.GetExtension(filePath) switch 
                { 
                    ".xml" => fileServiceXml.Write(filePath, StudentList), 
                    ".json" => fileServiceJson.Write(filePath, StudentList), 
                    ".txt" => fileServiceTxt.Write(filePath, StudentList), 
                    _ => throw new Exception("") 
                }; 
                MessageBox.Show(b ? "Записано" : "Ошибка");
            }
        }

        //Загружаем список студентов
        public ICommand LoadStudent { get; }
        public void LoadStudentAction()
        {
            OpenFileDialog.Filter = "Txt files (*.txt)|*.txt|Xml files (*.xml)|*.xml|Json files (*.jon)|*.json|All files (*.*)|*.*";
            if (true == OpenFileDialog.ShowDialog())
            {
                string filePath = OpenFileDialog.FileName;
                var dataStudentR = Path.GetExtension(filePath) switch
                {
                    ".xml" => fileServiceXml.Read(filePath),
                    ".json" => fileServiceJson.Read(filePath),
                    ".txt" => fileServiceTxt.Read(filePath),
                    _ => throw new Exception("")
                };
                foreach (var student in dataStudentR)
                {
                    StudentList.Add(student);
                }
            }
        }

    }
}
