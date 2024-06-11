using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace laba4_rework.Serialization
{
    public static class Writer<T>
    {
        public static void SerializeObject(string path, T obj)
        {
            var objList = ParseObjectsFromFile(path);
            objList.Add(obj);
            WriteObjectsToFile(path, objList);
        }

        public static List<T> ParseObjectsFromFile(string path)
        {
            if (File.Exists(path) && new FileInfo(path).Length != 0)
            {
                var jsonString = File.ReadAllText(path);
                return JsonSerializer.Deserialize<List<T>>(jsonString);
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