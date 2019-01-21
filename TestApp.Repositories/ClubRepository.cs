using System;
using System.Collections.Generic;
using TestApp.Core;
using TestApp.Core.Interfaces;

namespace TestApp.Repositories
{
    public class ClubRepository : IRepository<Club>
    {
        private readonly IDataStoreProvider<Club> _clubStoreProvider;

        public ClubRepository(IDataStoreProvider<Club> clubStoreProvider)
        {
            _clubStoreProvider = clubStoreProvider ?? throw new ArgumentNullException(nameof(clubStoreProvider));
        }
        public void Create(Club entity)
        {
            _clubStoreProvider.Create(entity);
        }

        public void Delete(Club entity)
        {
            _clubStoreProvider.Delete(entity);
        }


        public Club Get(Club entity)
        {
            return _clubStoreProvider.Get(entity);
        }

        public IEnumerable<Club> GetAll()
        {
            return _clubStoreProvider.GetAll();
        }

        public void Update(Club newEntity)
        {
            _clubStoreProvider.Update(newEntity);
        }
    }
}
