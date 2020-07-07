using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

namespace Lesson_3.Model
{
    public abstract class FileService
    {
        private readonly string PATH;

        public FileService()
        {
            var testData = new Student[]
            {
                new Student(),
                new Student()
            };

            new FileTxt().SaveData("temp.txt", testData);
        }

        public IEnumerable<Student> LoadData()
        {
            return null;
        }

        public void SaveData (string path, IEnumerable<Student> studentList)
        {
            File.WriteAllLines(path, studentList.Select(student => student.ToString()));
        }

        
    }
}
