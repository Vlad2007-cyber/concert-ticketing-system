using System;
using System.Collections.Generic;
using System.IO;

namespace lab2OOP
{
    public static class FileManager
    {
        public static void Add(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (!entity.IsValid())
            {
                throw new Exception("Entity is invalid.");
            }

            var record = entity.Format();

            using (var writer = new StreamWriter(entity.FileName, append: true))
            {
                writer.WriteLine(record);
            }

            if (entity is Computer computer)
            {
                Computer.AddToList(computer);
            }
        }

        public static List<string> ReadAll(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return new List<string>();
            }

            return new List<string>(File.ReadAllLines(fileName));
        }
    }
}