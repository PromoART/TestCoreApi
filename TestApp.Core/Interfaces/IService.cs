using System.Collections.Generic;

namespace TestApp.Core.Interfaces
{
    public interface IService
    {
        IEnumerable<Player> GetAllPlayer();

        IEnumerable<Club> GetAllClubs();

        Player GetPlayer(int id);

        Club GetClub(int id);

        void CreatePlayer(string fullName, int age, Position position, string clubName = null);

        void CreateClub(string town, string name);

        void UpdatePlayer(Player player);

        void UpdateClub(Club club);

        void DeletePlayer(int id);

        void DeleteClub(int id);
    }
}