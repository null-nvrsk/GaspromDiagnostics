using System;
using System.Collections.Generic;
using System.IO;

namespace GaspromDiagnostics.Services
{
    public class CsvFileService : IFileService
    {
        public List<Object> Open(string filename)
        {
            List<Object> objects = new List<Object>();
            using (var reader = new StreamReader(filename))
            {

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(';');

                    try
                    {
                        Object obj = new Object();

                        obj.Name = values[0].Trim();
                        obj.Distance = Convert.ToSingle(values[1]);
                        obj.Angle = Convert.ToSingle(values[2]);
                        obj.Width = Convert.ToSingle(values[3]);
                        obj.Heigth = Convert.ToSingle(values[4]);
                        obj.IsDefect = (values[5] == "yes");

                        objects.Add(obj);
                    }
                    catch (Exception) { }
                }
                return objects;
            }
        }
        public void Save(string filename, List<Object> objects)
        {
            using (StreamWriter writer = new StreamWriter(filename, false))
            {
                foreach (Object obj in objects)
                {
                    string text = String.Join(';', obj);
                    writer.WriteLine(text);
                }
            }
        }
    }
}
