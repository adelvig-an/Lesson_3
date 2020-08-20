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
            using var reader = new StreamReader(filePath); 
            while (!reader.EndOfStream) 
            { 
                var line1 = reader.ReadLine(); 
                var line2 = reader.ReadLine(); 
                var line3 = reader.ReadLine(); 
                var line4 = reader.ReadLine(); 
                var line5 = reader.ReadLine(); 
                var line6 = reader.ReadLine(); 
                var line7 = reader.ReadLine(); 
                var line8 = reader.ReadLine(); 
                var str = string.Join(Environment.NewLine, 
                    line1, line2, line3, line4, line5, line6, line7, line8); 
                if (Student.TryParse(str, out Student student))
                { 
                    yield return student; 
                } 
            }
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
    }
}
