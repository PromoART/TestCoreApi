using System;
using System.Collections.Generic;
using System.Linq;
using TestApp.Core;
using TestApp.Core.Interfaces;
using TestApp.DataStore.Entities;

namespace TestApp.Repositories
{
    public class ClubRepository : IRepository<Club>
    {
        private readonly IDataProviderFactory _dataProvider;

        public ClubRepository(IDataProviderFactory dataProvider)
        {
            _dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));
        }

        public void Create(Club entity)
        {
            var session = _dataProvider.Factory.OpenSession();
            try
            {
                using (var transaction = session.BeginTransaction())
                {
                    var club = new ClubEntity
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

        public void Delete(int id)
        {
            var session = _dataProvider.Factory.OpenSession();
            try
            {
                using (var transaction = session.BeginTransaction())
                {
                    var clubEntity = session.Query<ClubEntity>().Single(x => x.Id == id);
                    session.Delete(clubEntity);
                    transaction.Commit();
                }
            }
            finally
            {
                session.Close();
            }
        }

        public Club Get(int id)
        {
            var session = _dataProvider.Factory.OpenSession();
            try
            {
                var clubEntity = session.Query<ClubEntity>().Single(x => x.Id == id);

                return new Club(clubEntity.Name, clubEntity.Town)
                {
                    Id = clubEntity.Id
                };
            }
            finally
            {

                session.Close();
            }
        }

        public IEnumerable<Club> GetAll()
        {
            var session = _dataProvider.Factory.OpenSession();
            try
            {
                var clubsQuery = session.Query<ClubEntity>().Select(x => new Club(x.Name, x.Town) { Id = x.Id });

                return clubsQuery.ToList();
            }
            finally
            {
                session.Close();
            }
        }

        public void Update(Club newEntity)
        {
            var session = _dataProvider.Factory.OpenSession();
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

        public void Dispose()
        {
            _dataProvider.Factory?.Dispose();
        }
    }
}
