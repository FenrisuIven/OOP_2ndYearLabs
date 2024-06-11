using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Windows;

namespace laba4_rework.Serialization
{
    public static class Writer<T>
    {
        public static List<T> ParseObjectsFromFile(string path)
        {
            if (File.Exists(path) && new FileInfo(path).Length != 0)
            {
                var jsonString = File.ReadAllText(path);
                try
                {
                    var list = JsonSerializer.Deserialize<List<T>>(jsonString);
                    return list;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error happened during deserialization. Some data might be corrupted.");
                }
            }
            return new List<T>();
        }
        public static void WriteObjectsToFile(string path, List<T> objects)
        {
            var jsonString = JsonSerializer.Serialize(objects);
            File.WriteAllText(path, string.Empty);
            File.WriteAllText(path, jsonString);
        }
    }
}