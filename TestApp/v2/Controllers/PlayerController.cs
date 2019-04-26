using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TestApp.ClientDataContracts;
using TestApp.Core.Domain;
using TestApp.Core.Interfaces;
using Player = TestApp.Core.Player;

namespace TestApp.v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IService _service;
        public PlayerController(IService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<PlayerContract>> Get()
        {
            var players = _service.GetAllPlayer();

            return players.Select(storedPlayer => new PlayerContract
            {
                Id = storedPlayer.Id.ToString(),
                Age = storedPlayer.Age.ToString(),
                FullName = storedPlayer.FullName,
                Position = storedPlayer.Position.ToString(),
                ClubId = storedPlayer.ClubId.ToString(),
                Club = storedPlayer.Club != null ? new ClubContract { Name = storedPlayer.Club.Name, Id = storedPlayer.Club.Id.ToString(), Town = storedPlayer.Club.Town } : null
            }).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<PlayerContract> Get(string id)
        {
            var player = _service.GetPlayer(int.Parse(id));
            return new PlayerContract
            {
                Age = player.Age.ToString(),
                FullName = player.FullName,
                Position = player.Position.ToString(),
                Club = new ClubContract { Name = player.Club.Name, Id = player.Club.Id.ToString(), Town = player.Club.Town }
            };
        }

        [HttpPost]
        public void Create([FromBody] PlayerContract playerContract)
        {
            var position = Enum.Parse<Position>(playerContract.Position);
            var age = int.Parse(playerContract.Age);

            _service.CreatePlayer(playerContract.FullName, age, position, playerContract.Club?.Name);

        }

        [HttpPut]
        public void Update([FromBody] PlayerContract playerContract)
        {
            var position = Enum.Parse<Position>(playerContract.Position);
            var age = int.Parse(playerContract.Age);

            var player = new Player(playerContract.FullName, position, age)
            {
                Club = new Club(playerContract.Club.Name, playerContract.Club.Town)
            };

            _service.UpdatePlayer(player);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _service.DeletePlayer(int.Parse(id));

        }
    }
}