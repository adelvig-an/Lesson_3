using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_3.Model
{
    public class Student
    {
        public string MiddleName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateBirth { get; set; }
        public int Age { get; set; }
        public string YearUniversity { get; set; }
        public string FullName { get; set; }
        public bool IsStudent { get; set; }

        public override string ToString() 
        { 
            var sb = new StringBuilder(); 
            sb.AppendLine(FirstName); 
            sb.AppendLine(MiddleName); 
            sb.AppendLine(LastName); 
            sb.AppendLine(DateBirth.ToString()); 
            sb.AppendLine(Age.ToString()); 
            sb.AppendLine(YearUniversity); 
            sb.AppendLine(FullName); 
            sb.AppendLine(IsStudent.ToString()); 
            return sb.ToString(); 
        }

        public static bool TryParse(string str, out Student student) 
        { 
            student = null; 
            if (string.IsNullOrWhiteSpace(str)) 
            { 
                return false; 
            } 
            var data = str.Split(Environment.NewLine); 
            if (data.Length != 8) 
            { 
                return false; 
            } 
            var firstName = data[0]; 
            var middleName = data[1]; 
            var lastName = data[2]; 
            if (!DateTime.TryParse(data[3], out DateTime dateBirth)) 
            { 
                return false; 
            } 
            if (!int.TryParse(data[4], out int age)) 
            { 
                return false; 
            } 
            var yearUniversity = data[5]; 
            var fullName = data[6]; 
            if (!bool.TryParse(data[7], out bool isStudent)) 
            { 
                return false; 
            } 
            student = new Student 
            { 
                FirstName = firstName, 
                MiddleName = middleName, 
                LastName = lastName, 
                DateBirth = dateBirth, 
                YearUniversity = yearUniversity, 
                FullName = fullName, 
                IsStudent = isStudent, 
                Age = age 
            }; 
            return true; 
        }
    }
}
