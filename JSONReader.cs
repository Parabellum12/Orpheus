using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using Newtonsoft.Json;
using Orpheus.Database;

namespace Orpheus
{
    public class JSONReader
    {
        public string token { get; set; }
        public string prefix { get; set; }
        public DiscordUser registeredAdmin { get; set; }

        public async Task ReadJson()
        {
            using (StreamReader sr = new StreamReader("config\\config.json"))
            {
                string json = await sr.ReadToEndAsync();
                JSONStructure data = JsonConvert.DeserializeObject<JSONStructure>(json);
                this.token = data.token;
                this.prefix = data.prefix;
                DBEngine.SetConnectionStrings(data.host, data.database, data.username, data.password);
            }
        }
    }

    internal sealed class JSONStructure
    {
        public string token { get; set; }
        public string prefix { get; set; }
        public string host { get; set; }
        public string database { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
