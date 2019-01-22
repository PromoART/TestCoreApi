using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TestApp.ClientDataContracts;
using TestApp.Core;
using TestApp.Core.Interfaces;

namespace TestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly IService _service;

        public ClubController(IService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public ActionResult<IEnumerable<ClubContract>> Get()
        {
            var clubs = _service.GetAllClubs();
            return clubs.Select(x => new ClubContract
            {
                Id = x.Id.ToString(),
                Name = x.Name,
                Town = x.Town,
                Players = x.Players.Select(storedPlayer => new PlayerContract
                {
                    Id = storedPlayer.Id.ToString(),
                    Age = storedPlayer.Age.ToString(),
                    FullName = storedPlayer.FullName,
                    Position = storedPlayer.Position.ToString(),
                    ClubId = storedPlayer.ClubId.ToString()
                })
            }).ToList();
        }


        [HttpGet("{id}")]
        public ActionResult<ClubContract> Get(string id)
        {
            var club = _service.GetClub(int.Parse(id));
            return new ClubContract
            {
                Id = club.Id.ToString(),
                Name = club.Name,
                Town = club.Town,
                Players = club.Players.Select(storedPlayer => new PlayerContract
                {
                    Id = storedPlayer.Id.ToString(),
                    Age = storedPlayer.Age.ToString(),
                    FullName = storedPlayer.FullName,
                    Position = storedPlayer.Position.ToString()
                })
            };

        }


        [HttpPost]
        public void Create([FromBody] ClubContract clubContract)
        {
            _service.CreateClub(clubContract.Town, clubContract.Name);
        }


        [HttpPut]
        public void Update([FromBody] ClubContract clubContract)
        {
            var club = new Club(clubContract.Name, clubContract.Town);

            club.UpdatePlayers(clubContract.Players.Select(x => new Player(x.FullName, Enum.Parse<Position>(x.Position), int.Parse(x.Age))));
            _service.UpdateClub(club);
        }


        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _service.DeleteClub(int.Parse(id));
        }
    }
}