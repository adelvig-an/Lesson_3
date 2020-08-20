using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lesson_3.Model
{
    class FileTxt : FileService
    {
        public override IEnumerable<Student> Read(string filePath)
        {
            return
                File.ReadLines(filePath)
                .Select(Parse);
        }

        public override bool Write(string filePath, IEnumerable<Student> students)
        {
            try
            {
                File.WriteAllLines(filePath, students.Select(dp => dp.ToString()));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Student Parse(string str)
        {

        }
    }
}
