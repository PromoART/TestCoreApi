using System.Collections.Generic;
using System.Linq;

namespace TestApp.Core
{
    public class Club
    {
        private List<Player> _players;

        public Club(string name, string town)
        {
            Name = name;
            Town = town;
            _players = new List<Player>();
        }

        public int Id { get; set; }

        public string Name { get; }

        public string Town { get; }

        public IEnumerable<Player> Players => _players;

        public void UpdatePlayers(IEnumerable<Player> players)
        {
            _players = players.ToList();
        }
    }
}
