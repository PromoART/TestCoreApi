using System;
using System.Collections.Generic;
using TestApp.Core;
using TestApp.Core.Interfaces;

namespace TestApp.Repositories
{
    public class PlayerRepository : IRepository<Player>
    {
        private readonly IDataStoreProvider<Player> _playerStoreProvider;

        public PlayerRepository(IDataStoreProvider<Player> playerStoreProvider)
        {
            _playerStoreProvider = playerStoreProvider ?? throw new ArgumentNullException(nameof(playerStoreProvider));
        }
        public void Create(Player entity)
        {
            _playerStoreProvider.Create(entity);
        }

        public void Delete(Player entity)
        {
            _playerStoreProvider.Delete(entity);
        }

        public Player Get(Player entity)
        {
            return _playerStoreProvider.Get(entity);
        }

        public IEnumerable<Player> GetAll()
        {
            return _playerStoreProvider.GetAll();
        }

        public void Update(Player newEntity)
        {
            _playerStoreProvider.Delete(newEntity);
        }
    }
}
