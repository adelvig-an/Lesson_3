using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Lesson_3.Model
{
    public abstract class File
    {
        private readonly string PATH;

        public File(string path)
        {
            PATH = path;
        }
        
        public ObservableCollection<Student> LoadData()
        {
            return null;
        }

        public void SaveData (ObservableCollection<Student> studentList)
        {

        }
    }
}
