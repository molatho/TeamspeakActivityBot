using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SchmuserBot.Utils
{
    static class JsonConvertEx
    {
        public static T ReadFile<T>(FileInfo file)
        {
            if (!file.Exists) throw new FileNotFoundException();

            using (var fStream = file.OpenRead())
            {
                using (var reader = new StreamReader(fStream))
                {
                    return JsonConvert.DeserializeObject<T>(reader.ReadToEnd());
                }
            }
        }

        public static void WriteFile<T>(FileInfo file, T data)
        {
            using(var fStream = file.Open(FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (var writer = new StreamWriter(fStream))
                {
                    writer.Write(JsonConvert.SerializeObject(data));
                }
            }
        }
    }
}
