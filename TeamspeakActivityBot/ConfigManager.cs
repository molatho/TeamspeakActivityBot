using SchmuserBot.Model;
using SchmuserBot.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SchmuserBot
{
    class ConfigManager
    {
        public Config Config => configFile.Data;
        private JsonFile<Config> configFile;

        public ConfigManager(FileInfo file)
        {
            configFile = new JsonFile<Config>(file);
        }

        public void Save()
        {
            configFile.Save();
        }
    }
}
