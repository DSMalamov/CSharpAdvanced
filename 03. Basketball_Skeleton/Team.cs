using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        private List<Player> players;
        public Team(string name, int openPositions, char group)
        {
            players = new List<Player>();
            Name = name;
            OpenPositions = openPositions;
            Group = group;
        }

        public IReadOnlyCollection<Player> Players => this.players;
        public string Name { get; private set; }
        public int OpenPositions { get; private set; }
        public char Group { get; private set; }

        public int Count { get { return Players.Count; } }

        public string AddPlayer(Player player)
        {
            if (OpenPositions > 0)
            {
                if (player.Name == null || player.Position == string.Empty)
                {
                    return "Invalid player's information.";
                }
                else if (player.Rating < 80)
                {
                    return "Invalid player's rating.";
                }
                else
                {
                    players.Add(player);
                    OpenPositions--;
                    return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
                }
               
            }
            else
            {
                return "There are no more open positions.";
            }
            
        }

        public bool RemovePlayer(string name)
        {
            if (Players.Any(p => p.Name == name))
            {
                for (int i = 0; i < Players.Count; i++)
                {
                    if (players[i].Name == name)
                    {
                        players.Remove(players[i]);
                    }
                }
                OpenPositions++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public int RemovePlayerByPosition(string position)
        {
            int counter = 0;

            for (int i = 0; i < Players.Count; i++)
            {
                if (players[i].Position == position)
                {
                    players.Remove(players[i]);
                    i--;
                    counter++;
                    OpenPositions++;
                }
            }

            return counter;

        }

        public Player RetirePlayer(string name)
        {
            var currPlayer = players.FirstOrDefault(p => p.Name == name);

            if (currPlayer == null)
            {
                return null;
            }
            else
            {
                currPlayer.Retired = true;
                return currPlayer;
            }
        }

        public List<Player> AwardPlayers(int games)
        {
            var list = new List<Player>();
            foreach (var item in players.Where(p => p.Games >= games))
            {
                list.Add(item);
            }

            return list;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Active players competing for Team {Name} from Group {Group}:");
            foreach (var player in players.Where(p => p.Retired == false))
            {
                sb.AppendLine(player.Name);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
