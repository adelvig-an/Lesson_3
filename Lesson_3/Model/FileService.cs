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

        //public FileService(string path)
        //{
        //    PATH = path;
        //}
        
        public IEnumerable<Student> LoadData()
        {
            return null;
        }

        public void SaveData (IEnumerable<Student> studentList)
        {
            File.WriteAllLines(PATH, studentList.Select(student => student.ToString()));
        }
    }
}
