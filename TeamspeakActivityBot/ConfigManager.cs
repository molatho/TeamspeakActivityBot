using TeamspeakActivityBot.Model;
using TeamspeakActivityBot.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TeamspeakActivityBot
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
