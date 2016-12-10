using System.IO;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IosoccerApi
{
    class MatchParser
    {
        private readonly ILogger _logger;

        public MatchParser(ILogger logger)
        {
            _logger = logger;
        }
        
        public void ParseMatches()
        {
            var files = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "uploads/match-files"), "*.json");
            
            foreach (var file in files)
            {
                using(StreamReader reader = File.OpenText(file))
                {
                    dynamic json = JObject.Parse(reader.ReadToEnd());
                    _logger.LogInformation((string)json.matchData.statisticTypes[1]);
                }
            }
        }
    }
}