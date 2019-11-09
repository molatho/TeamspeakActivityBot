using Newtonsoft.Json;
using TeamspeakActivityBot.Model;
using TeamspeakActivityBot.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TeamspeakActivityBot
{
    class ClientManager
    {
        public IEnumerable<Client> Clients => clientFile.Data.Values;
        private JsonFile<Dictionary<string, Client>> clientFile;

        public ClientManager(FileInfo file)
        {
            clientFile = new JsonFile<Dictionary<string, Client>>(file);
        }

        public Client this[string clientId] => HasClient(clientId) ? clientFile.Data[clientId] : null;
        public bool HasClient(string clientId) { return clientFile.Data.ContainsKey(clientId); }
        public Client AddClient(Client client)
        {
            clientFile.Data[client.ClientId] = client;
            if (clientFile.AutoSave)
                clientFile.Save();
            return client;
        }
        public void Save()
        {
            clientFile.Save();
        }
    }
}
