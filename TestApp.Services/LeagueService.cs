using System;
using System.Collections.Generic;
using System.Linq;
using TestApp.Core;
using TestApp.Core.Interfaces;

namespace TestApp.Services
{
    public class LeagueService : IService
    {
        private readonly IRepository<Player> _playerRepo;
        private readonly IRepository<Club> _clubRepo;

        public LeagueService(IRepository<Player> playerRepo, IRepository<Club> clubRepo)
        {
            _playerRepo = playerRepo ?? throw new ArgumentNullException(nameof(playerRepo));
            _clubRepo = clubRepo ?? throw new ArgumentNullException(nameof(clubRepo));
        }

        public IEnumerable<Player> GetAllPlayer()
        {
            var players = _playerRepo.GetAll().ToList();

            foreach (var storedPlayer in players)
                if (storedPlayer.ClubId > 0)
                    storedPlayer.Club = GetClub(storedPlayer.ClubId);

            return players;
        }

        public IEnumerable<Club> GetAllClubs()
        {
            var players = _playerRepo.GetAll().ToList();
            var clubs = _clubRepo.GetAll().ToList();

            foreach (var club in clubs)
            {
                var clubPlayers = players.Where(x => x.ClubId == club.Id);

                club.UpdatePlayers(clubPlayers.Select(x =>
                    new Player(x.FullName, x.Position, x.Age)
                    {
                        Id = x.Id,
                        ClubId = x.ClubId
                    }));
            }

            return clubs;
        }

        public Player GetPlayer(int id)
        {
            return _playerRepo.Get(id);
        }

        public Club GetClub(int id)
        {
            return _clubRepo.Get(id);
        }

        public void CreatePlayer(string fullName, int age, Position position, string clubName = null)
        {
            var player = new Player(fullName, position, age);

            if (!string.IsNullOrEmpty(clubName))
            {
                var club = GetAllClubs().SingleOrDefault(x => x.Name.Equals(clubName, StringComparison.OrdinalIgnoreCase));
                player.ClubId = club?.Id ?? 0;
            }

            _playerRepo.Create(player);
        }

        public void CreateClub(string town, string name)
        {
            var club = new Club(name, town);
            _clubRepo.Create(club);
        }

        public void UpdatePlayer(Player player)
        {
            _playerRepo.Update(player);
        }

        public void UpdateClub(Club club)
        {
            _clubRepo.Update(club);
        }

        public void DeletePlayer(int id)
        {
            _playerRepo.Delete(id);
        }

        public void DeleteClub(int id)
        {
            _clubRepo.Delete(id);
        }
    }
}
