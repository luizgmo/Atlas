using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AtlasP.Data;
using AtlasP.Models;

namespace AtlasP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Contexto _context;

        public HomeController(ILogger<HomeController> logger, Contexto context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var modalities = _context.Modalities.ToList();
            return View(modalities);
        }

        public IActionResult About()
        {
            var coachs = _context.Coachs.ToList();
            return View(coachs);
        }

        public IActionResult Schedule()
        {
            var modalities = _context.Modalities.ToList();
            return View(modalities);
        }

        public IActionResult Gallery()
        {
            var photos = _context.Photos.ToList();
            return View(photos);
        }

        public IActionResult Contact()
        {
            var values = _context.Values.ToList();
            return View(values);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
