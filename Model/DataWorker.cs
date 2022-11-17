using GaspromDiagnostics.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GaspromDiagnostics.Model
{
    public static class DataWorker
    {
        // Получить все объекты
        public static List<Object> GetAllObjects()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Objects.ToList();
                return result;
            }
        }

        // Перезаписываем все объекты
        public static void RewriteAllObjects(List<Object> objects)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // удаляем старые объекты
                db.Objects.RemoveRange(db.Objects);
                db.SaveChanges();

                // Загружаем новые объекты
                foreach (Object obj in objects)
                {
                    db.Objects.Add(obj);
                }
                db.SaveChanges();
            }
        }

        // создать объекты
        public static void CreateObject(string name, float distance, float angle,
            float width, float heigth, bool isDefect)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Object newObject = new Object
                {
                    Name = name,
                    Angle = angle,
                    Width = width,
                    Heigth = heigth,
                    IsDefect = isDefect
                };
                db.Objects.Add(newObject);
                db.SaveChanges();
            }
        }

        // удаление объекта
        public static void DeleteObject(Object obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Objects.Remove(obj);
                db.SaveChanges();
            }
        }

        // редактирование объекта
        public static void EditObject(Object oldObject, string newName, float newDistance, 
            float newAngle, float newWidth, float newHeigth, bool newIsDefect)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Object newObject = db.Objects.First(pos => pos.Id == oldObject.Id);
                if (newObject != null)
                {
                    newObject.Name = newName;
                    newObject.Distance = newDistance;
                    newObject.Angle = newAngle;
                    newObject.Width = newWidth;
                    newObject.Heigth = newHeigth;
                    newObject.IsDefect = newIsDefect;
                    db.SaveChanges();
                }
            }
        }
    }
}
