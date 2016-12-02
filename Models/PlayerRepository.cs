using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace IosoccerApi.Models
{
    public class PlayerRepository : IPlayerRepository
    {
        private static ConcurrentDictionary<string, Player> _players =
              new ConcurrentDictionary<string, Player>();

        public PlayerRepository()
        {
            Add(new Player { Name = "Player1" });
            Add(new Player { Name = "Player2" });
            Add(new Player { Name = "Player3" });
        }

        public IEnumerable<Player> GetAll()
        {
            return _players.Values;
        }

        public void Add(Player player)
        {
            player.Key = Guid.NewGuid().ToString();
            _players[player.Key] = player;
        }

        public Player Find(string key)
        {
            Player player;
            _players.TryGetValue(key, out player);
            return player;
        }

        public Player Remove(string key)
        {
            Player player;
            _players.TryRemove(key, out player);
            return player;
        }

        public void Update(Player player)
        {
            _players[player.Key] = player;
        }
    }
}