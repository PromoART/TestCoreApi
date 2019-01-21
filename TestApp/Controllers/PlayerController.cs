using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApp.Core;
using TestApp.Core.Interfaces;

namespace TestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IRepository<Player> _playerRepo;
        private readonly IRepository<Club> _clubRepo;

        public PlayerController(IRepository<Player> playerRepo, IRepository<Club> clubRepo)
        {
            _playerRepo = playerRepo;
            _clubRepo = clubRepo;
        }
        // GET api/player
        [HttpGet]
        public ActionResult<IEnumerable<string[]>> Get()
        {
            var Players = new List<string[]>();
            var storedPlayers = _playerRepo.GetAll();
          
            foreach (var storedPlayer in storedPlayers)
            {
                var clubName = _clubRepo.Get(new Club(storedPlayer.ClubId, null, null)).Name;
                Players.Add(new string[] { storedPlayer.FullName, storedPlayer.Age.ToString(), clubName, storedPlayer.Position.ToString() });
            }
            return Players;
        }

        // GET api/player/guid
        [HttpGet("{id}")]
        public ActionResult<string[]> Get(string id)
        {
            var storedPlayer = _playerRepo.Get(new Player(Guid.Parse(id), null, Position.PointGuard, 0, Guid.NewGuid()));
            var clubName = _clubRepo.Get(new Club(storedPlayer.ClubId, null, null)).Name;

            return new string[] { storedPlayer.FullName, storedPlayer.Age.ToString(), clubName, storedPlayer.Position.ToString() };
        }

        // POST api/player/array
        [HttpPost]
        public void Create([FromBody] string []values)
        {
            var position = Enum.Parse<Position>(values[1]);
            var clubId = _clubRepo.GetAll().Single(x => x.Name == values[3]).Id;
            var player = new Player(Guid.NewGuid(), values[0], position, int.Parse(values[2]), clubId);
            _playerRepo.Create(player);
        }

        // PUT api/player/array 
        [HttpPut]
        public void Update([FromBody] string []values)
        {
            var position = Enum.Parse<Position>(values[1]);
            var clubId = _clubRepo.GetAll().Single(x => x.Name == values[3]).Id;
            var player = new Player(Guid.NewGuid(), values[0], position, int.Parse(values[2]), clubId);
            _playerRepo.Update(player);
        }

        // DELETE api/player/guid
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var storedPlayer = _playerRepo.Get(new Player(Guid.Parse(id), null, Position.PointGuard, 0, Guid.NewGuid()));
            var clubName = _clubRepo.Get(new Club(storedPlayer.ClubId, null, null)).Name;

            _playerRepo.Delete(storedPlayer);
        }
    }
}