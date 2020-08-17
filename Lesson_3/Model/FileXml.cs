using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Lesson_3.Model
{
    class FileXml : FileService
    {
        public override IEnumerable<Student> Read(string filePath)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(IEnumerable<Student>));
            var fs = new FileStream(filePath, FileMode.OpenOrCreate);
            return
                (IEnumerable<Student>)deserializer.Deserialize(fs);
        }

        public override bool Write(string filePath, IEnumerable<Student> students)
        {
            try
            {
                using var fstream = new FileStream(filePath, FileMode.OpenOrCreate);
                XmlSerializer serializer = new XmlSerializer(students.GetType());
                serializer.Serialize(fstream, students);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
