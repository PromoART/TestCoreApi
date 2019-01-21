using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Linq;
using TestApp.Core;
using TestApp.Core.Interfaces;
using TestApp.DataStore.Entities;


namespace TestApp.DataStore
{
    public class DataStoreProvider : IDataStoreProvider<Club>, IDataStoreProvider<Player>, IDisposable
    {

        private const string CurrentSessionKey = "nhibernate.current_session";
        private readonly ISessionFactory _sessionFactory;

        public DataStoreProvider()
        {
            var configuration = new Configuration();
           
            _sessionFactory = Fluently.Configure(configuration)
                .Database(SQLiteConfiguration.Standard.InMemory)
                .Mappings(m => 
                {
                    m.HbmMappings.AddFromAssemblyOf<PlayerEntity>();
                    m.HbmMappings.AddFromAssemblyOf<ClubEntity>();
                } 
                )
                .BuildSessionFactory();
        }

        public void Create(Club entity)
        {
            var session = _sessionFactory.OpenSession();
            try
            {
                using (var transaction = session.BeginTransaction())
                {
                    var club = new ClubEntity()
                    {
                        Name = entity.Name,
                        Town = entity.Town
                    };

                    session.Save(club);
                    transaction.Commit();
                }
            }
            finally
            {

                session.Close();
            }
        }

        public void Create(Player entity)
        {
            var session = _sessionFactory.OpenSession();
            try
            {
                using (var transaction = session.BeginTransaction())
                {
                    var player = new PlayerEntity()
                    {
                        FullName = entity.FullName,
                        Position = entity.Position,
                        Age = entity.Age,
                        ClubId = entity.ClubId
                    };

                    session.Save(player);
                    transaction.Commit();
                }
            }
            finally
            {

                session.Close();
            }
        }


        public Club Get(Club entity)
        {
            var session = _sessionFactory.OpenSession();
            try
            {
                var clubEntity = session.Query<ClubEntity>().Single(x => x.Id == entity.Id);

                return new Club(clubEntity.Id, clubEntity.Name, clubEntity.Town);
            }
            finally
            {

                session.Close();
            }
        }

        public Player Get(Player entity)
        {
            var session = _sessionFactory.OpenSession();
            try
            {
                var playerEntity = session.Query<PlayerEntity>().Single(x => x.Id == entity.Id);

                return new Player(playerEntity.Id, playerEntity.FullName, playerEntity.Position, playerEntity.Age, playerEntity.ClubId);
            }
            finally
            {

                session.Close();
            }
        }
        public void Delete(Club entity)
        {
            var session = _sessionFactory.OpenSession();
            try
            {
                using (var transaction = session.BeginTransaction())
                {
                    var clubEntity = session.Query<ClubEntity>().Single(x => x.Id == entity.Id);
                    session.Delete(clubEntity);
                    transaction.Commit();
                }
            }
            finally
            {
                session.Close();
            }
        }

        public void Delete(Player entity)
        {
            var session = _sessionFactory.OpenSession();
            try
            {
                using (var transaction = session.BeginTransaction())
                {
                    var clubEntity = session.Query<PlayerEntity>().Single(x => x.Id == entity.Id);
                    session.Delete(clubEntity);
                    transaction.Commit();
                }
            }
            finally
            {
                session.Close();
            }
        }
        public IEnumerable<Club> GetAll()
        {
            var session = _sessionFactory.OpenSession();
            try
            {
                return session.Query<ClubEntity>().Select(x => new Club(x.Id, x.Name, x.Town)).ToList();
            }
            finally
            {
                session.Close();
            }
        }
        IEnumerable<Player> IDataStoreProvider<Player>.GetAll()
        {
            var session = _sessionFactory.OpenSession();
            try
            {
                return session.Query<PlayerEntity>().Select(x => new Player(x.Id, x.FullName, x.Position, x.Age, x.ClubId)).ToList();
            }
            finally
            {
                session.Close();
            }
        }

        public void Update(Club newEntity)
        {
            var session = _sessionFactory.OpenSession();
            try
            {
                using (var transaction = session.BeginTransaction())
                {
                    var clubEntity = session.Query<ClubEntity>().Single(x => x.Id == newEntity.Id);

                    clubEntity.Name = newEntity.Name;
                    clubEntity.Town = newEntity.Town;

                    session.SaveOrUpdate(clubEntity);
                    transaction.Commit();
                }
            }
            finally
            {
                session.Close();
            }
        }

        public void Update(Player newEntity)
        {
            var session = _sessionFactory.OpenSession();
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
            _sessionFactory?.Dispose();
        }
    }
}
