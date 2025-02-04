using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Streamove
{
    public class Team
    {
        public string Name { get; set; }
        private List<IPlayer> players = new List<IPlayer>();
        private ILog log;
        public Team(string name, string path = @"C:\Users\Student4\Desktop\")
        {
            this.Name = name;
            this.log = new TXT($"{path}{this.Name}.txt");
            log.Save($"{this.Name} отбор беше създаден на {DateTime.Now}");
        }
        public void PrintLog()
        {
            this.log.PrintLogger();
        }

        public void Log(string typeOfLog)
        {
            if(typeOfLog == "xlsx") throw new NotImplementedException();
            Console.WriteLine("Информацията е записана във файла");
            this.log.Write();
        }

        public void AddPlayer(IPlayer player)
        {
            this.players.Add(player);
            log.Save($"{player.Name} е успешно добавен - {DateTime.Now}.");
        }

        public void RemovePlayer(string name)
        {
            var player = this.players.FirstOrDefault(p => p.Name == name);
            if (player != null)
            {
                this.players.Remove(player);
                log.Save($"Играч с позиция:{player.Position} и име:{player.Name} беше успешно премахнат - {DateTime.Now}.");
            }
            Console.WriteLine($"Играч с името:{name} не съществува");
            log.Save($"Играч с името:{name} не съществува");
        }
    }
}
