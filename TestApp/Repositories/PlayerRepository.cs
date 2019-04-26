using System.Collections.Generic;
using System.Threading.Tasks;
using TestApp.Core.Data;
using TestApp.Core.Domain;

namespace TestApp.Repositories
{
    public class PlayerRepository:IRepository<Player>
    {
        public Task<IEnumerable<Player>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task Create(Player entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Player entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
