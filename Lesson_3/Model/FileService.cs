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
        public abstract bool Write(string filePath, IEnumerable<Student> students);
        public abstract IEnumerable<Student> Read(string filePaht);
        
    }
}
