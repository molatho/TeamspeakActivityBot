using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TeamspeakActivityBot.Utils
{
    class JsonFile<T> where T : new()
    {
        public FileInfo File { get; private set; }
        public T Data
        {
            get
            {
                if (!dataRead)
                    Read();
                 
                return data;
            }
            set
            {
                data = value;
                if (AutoSave)
                    Save();
            }
        }

        private T data;
        private bool dataRead;
        private object fileLock = new object();

        protected bool LazyRead { get; set; }
        public bool AutoSave { get; private set; }

        public JsonFile(FileInfo file, bool lazyRead = false, bool autoSave = true)
        {
            File = file;
            dataRead = false;
            if (!lazyRead)
                Read();
        }

        public void Read(bool forceRead = false)
        {
            if (!forceRead && dataRead)
                return;

            if (!File.Exists)
            {
                data = new T();
                Save();
                return;
            }

            lock (fileLock)
            {
                data = JsonConvertEx.ReadFile<T>(File);
            }
            dataRead = true;
        }
        public void Save() 
        {
            lock (fileLock)
            {
                JsonConvertEx.WriteFile(File, data);
            }
        }
    }
}
