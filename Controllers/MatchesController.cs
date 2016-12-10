using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using IosoccerApi.Models;
using Microsoft.Extensions.Logging;

namespace IosoccerApi.Controllers
{
    [Route("api/[controller]")]
    public class MatchesController : Controller
    {
        private IHostingEnvironment _environment;
        private readonly ILogger<MatchesController> _logger;

        public MatchesController(IHostingEnvironment environment, ILogger<MatchesController> logger)
        {
            _environment = environment;
            _logger = logger;
        }

        [HttpPost("search")]
        public string Search(string text)
        {
            return $"{text} {text}";
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadMatchFiles(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            var matchFiles = Path.Combine(Directory.GetCurrentDirectory(), "uploads/match-files");
            Directory.CreateDirectory(matchFiles);

            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(matchFiles, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                        new MatchParser(_logger).ParseMatches();
                    }
                }
            }

            return Ok(new { count = files.Count, size, matchFiles});
        }
    }
}