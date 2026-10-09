using Microsoft.AspNetCore.Mvc;

namespace Playlist.Controllers
{
    public class PlaylistController : Controller
    {
        private static readonly string[] songs =
        {
            "Toast - Koffee",
            "Song 2 - Alkaline",
            "Song 3 - Bob Marley",
            "Song 4 - Damian Marley",
            "Song 5 - Skrilla",
            "Song 6 - Lil tony"
        };

        public IActionResult Index()
        {
            return View(songs);
        }

        [Route("liner-notes")]
        public IActionResult Notes()
        {
            return View();
        }

        [Route("track/{number:int:range(1,6)=1}")]
        public IActionResult Track(int number)
        {
            ViewBag.Number = number;
            ViewBag.Song = songs[number - 1];
            ViewBag.Count = songs.Length;
            return View();
        }

        [Route("find/{word:alpha}")]
        public IActionResult Find(string word)
        {
            int index = Array.FindIndex(songs,
                s => s.Contains(word, StringComparison.OrdinalIgnoreCase));

            ViewBag.Word = word;
            if (index >= 0)
            {
                ViewBag.Song = songs[index];
                ViewBag.Number = index + 1;
            }
            else
            {
                ViewBag.Song = null;
            }
            return View();
        }

        [Route("find/{**rest}")]
        public IActionResult FindError(string rest)
        {
            ViewBag.Rest = rest;
            return View();
        }
    }
}
