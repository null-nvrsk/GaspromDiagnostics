using System;
using System.Collections.Generic;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace GaspromDiagnostics.Services
{
    public class DataFileService : IFileService
    {
        
        public List<Object>? Open(string filename)
        {
            string ext = Path.GetExtension(filename);
            switch(ext)
            {
                case ".csv":
                    return OpenCsvFile(filename);
                case ".xls":
                case ".xlsx":
                        return OpenExcelFile(filename);
                default:
                        return null;    
            }
        }

        public void Save(string filename, List<Object> objects)
        {
            string ext = Path.GetExtension(filename);
            switch (ext)
            {
                case ".csv":
                    SaveCsvFile(filename, objects);
                    break;
                case ".xls":
                case ".xlsx":
                    SaveExcelFile(filename, objects);
                    break;
            }
        }

        private List<Object> OpenCsvFile(string filename)
        {
            List<Object> objects = new List<Object>();
            using (var reader = new StreamReader(filename))
            {
                int counter = 0;
                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();
                    string[] values = line?.Split(';');

                    try
                    {
                        Object obj = new Object
                        {
                            Name = values[0]?.Trim(),
                            Distance = Convert.ToSingle(values[1]),
                            Angle = Convert.ToSingle(values[2]),
                            Width = Convert.ToSingle(values[3]),
                            Heigth = Convert.ToSingle(values[4]),
                            IsDefect = (values[5] == "yes"),
                            Id = ++counter
                        };
                        objects.Add(obj);
                    }
                    catch (Exception) { }
                }
                return objects;
            }
        }
        private List<Object> OpenExcelFile(string filename)
        {
            List<Object> objects = new List<Object>();
            
            // открываем таблицу
            Excel.Application excel = new Excel.Application();
            Excel.Workbook wb = excel.Workbooks.Open(filename);
            Excel.Worksheet? sheet = wb.ActiveSheet as Excel.Worksheet;

            Excel.Range usedRange = sheet.UsedRange;
            int counter = 0;
            for (int row = 1; row < usedRange.Rows.Count; row++)
            {
                try
                {
                    Object obj = new Object
                    {
                        Name = sheet.Cells[row, 1]?.ToString(),
                        Distance = Convert.ToSingle(sheet.Cells[row, 2]),
                        Angle = Convert.ToSingle(sheet.Cells[row, 3]),
                        Width = Convert.ToSingle(sheet.Cells[row, 4]),
                        Heigth = Convert.ToSingle(sheet.Cells[row, 5]),
                        IsDefect = (sheet.Cells[row, 6].ToString() == "yes"),
                        Id = ++counter
                    };
                    objects.Add(obj);
                    
                } catch { }
            }

            return objects;
        }

        private void SaveCsvFile(string filename, List<Object> objects)
        {
            using StreamWriter writer = new StreamWriter(filename, false);
            writer.WriteLine("Name;Distance;Angle;Width;Heigth;IsDefect");
            foreach (Object obj in objects)
            {
                string csvLine =
                    obj.Name + ";" +
                    obj.Distance + ";" +
                    obj.Angle + ";" +
                    obj.Width + ";" +
                    obj.Heigth + ";" +
                    (obj.IsDefect ? "yes" : "no");

                writer.WriteLine(csvLine);
            }
        }

        private void SaveExcelFile(string filename, List<Object> objects)
        {
            // TODO: Реализовать выгрузку в Excel
            System.Windows.MessageBox.Show($"выгрузка {objects.Count} объектов в Excel");
        }
    }
}
