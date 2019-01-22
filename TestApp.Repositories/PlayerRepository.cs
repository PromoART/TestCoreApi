using System;
using System.Collections.Generic;
using System.Linq;
using TestApp.Core;
using TestApp.Core.Interfaces;
using TestApp.DataStore.Entities;

namespace TestApp.Repositories
{
    public class PlayerRepository : IRepository<Player>
    {
        private readonly IDataProviderFactory _dataProvider;

        public PlayerRepository(IDataProviderFactory dataProvider)
        {
            _dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));
        }

        public void Create(Player entity)
        {
            var session = _dataProvider.Factory.OpenSession();
            try
            {
                using (var transaction = session.BeginTransaction())
                {
                    var playerEntity = new PlayerEntity
                    {
                        FullName = entity.FullName,
                        Position = entity.Position,
                        Age = entity.Age,
                        ClubId = entity.ClubId
                    };

                    session.Save(playerEntity);
                    transaction.Commit();
                }
            }
            finally
            {

                session.Close();
            }
        }

        public void Delete(int id)
        {
            var session = _dataProvider.Factory.OpenSession();
            try
            {
                using (var transaction = session.BeginTransaction())
                {
                    var clubEntity = session.Query<PlayerEntity>().Single(x => x.Id == id);
                    session.Delete(clubEntity);
                    transaction.Commit();
                }
            }
            finally
            {
                session.Close();
            }
        }

        public Player Get(int id)
        {
            var session = _dataProvider.Factory.OpenSession();
            try
            {
                var playerEntity = session.Query<PlayerEntity>().Single(x => x.Id == id);

                return new Player(playerEntity.FullName, playerEntity.Position, playerEntity.Age)
                {
                    Id = playerEntity.Id,
                    ClubId = playerEntity.ClubId
                };
            }
            finally
            {

                session.Close();
            }
        }

        public IEnumerable<Player> GetAll()
        {
            var session = _dataProvider.Factory.OpenSession();
            try
            {
                var playersQuery = session.Query<PlayerEntity>().Select(x => new Player(x.FullName, x.Position, x.Age)
                {
                    Id = x.Id,
                    ClubId = x.ClubId
                });

                return playersQuery.ToList();
            }
            finally
            {
                session.Close();
            }
        }

        public void Update(Player newEntity)
        {
            var session = _dataProvider.Factory.OpenSession();
            try
            {
                using (var transaction = session.BeginTransaction())
                {
                    var playerEntity = session.Query<PlayerEntity>().Single(x => x.Id == newEntity.Id);

                    playerEntity.Age = newEntity.Age;
                    playerEntity.ClubId = newEntity.ClubId;
                    playerEntity.Position = newEntity.Position;
                    playerEntity.FullName = newEntity.FullName;

                    session.SaveOrUpdate(playerEntity);
                    transaction.Commit();
                }
            }
            finally
            {
                session.Close();
            }
        }

        public void Dispose()
        {
            _dataProvider.Factory?.Dispose();
        }
    }
}
