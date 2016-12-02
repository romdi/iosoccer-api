using System.Collections.Generic;

namespace IosoccerApi.Models
{
    public interface IPlayerRepository
    {
        void Add(Player player);
        IEnumerable<Player> GetAll();
        Player Find(string key);
        Player Remove(string key);
        void Update(Player player);
    }
}