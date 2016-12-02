using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using IosoccerApi.Models;

namespace IosoccerApi.Controllers
{
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {
        public IPlayerRepository Players { get; set; }
        
        public PlayersController(IPlayerRepository players)
        {
            Players = players;
        }

        [HttpGet]
        public IEnumerable<Player> GetAll()
        {
            return Players.GetAll();
        }

        [HttpGet("{id}", Name = "GetPlayer")]
        public IActionResult GetById(string id)
        {
            var item = Players.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
    }
}