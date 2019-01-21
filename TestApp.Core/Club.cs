using System;
using System.Collections.Generic;

namespace TestApp.Core
{
    public class Club
    {
        private List<Player> _players;

        public Club(Guid id,string name, string town)
        {
            Id = id;
            Name = name;
            Town = town;
            _players = new List<Player>();
        }

        public Guid Id{ get; }
        public string Name { get; }

        public string Town { get; }

        public IEnumerable<Player> Players => _players;
    }
}
