using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace FileService
{ 
    public class FileService<TValueType> where TValueType : class
    {
        public IEnumerable<TValueType> ReadFile(string fileName)
        {
            try
            {
                using StreamReader sr = new(fileName);
                var json = sr.ReadToEnd();
                var restored = JsonSerializer.Deserialize<List<TValueType>>(json);
                return restored;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            return new List<TValueType>();
        }

        public void SaveData(List<TValueType> data, string fileName)
        {
            try
            {
                using FileStream sw = new(fileName, FileMode.OpenOrCreate);

                JsonSerializer.SerializeAsync(sw, data, typeof(List<TValueType>) ).Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }

}