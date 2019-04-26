using System.Collections.Generic;
using System.Threading.Tasks;
using TestApp.Core.Data;
using TestApp.Core.Domain;

namespace TestApp.Repositories
{
    public class TeamRepository: IRepository<Team>
    {
        public Task<IEnumerable<Team>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task Create(Team entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Team entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
