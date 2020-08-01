using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lesson_3.Model
{
    public class FileJson : FileService
    {
        public override IEnumerable<Student> Read(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return
                JsonConvert.DeserializeObject<IEnumerable<Student>>(json);
        }

        public override bool Write(string filePath, IEnumerable<Student> students)
        {
            try
            {
                string json = JsonConvert.SerializeObject(students);
                File.WriteAllText(filePath, json);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
