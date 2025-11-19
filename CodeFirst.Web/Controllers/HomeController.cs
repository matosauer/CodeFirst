using CodeFirst.Domain;
using CodeFirst.Domain.Entities;
using CodeFirst.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace CodeFirst.Web.Controllers
{
    public class HomeController(BloggingContext context, ILogger<HomeController> logger) : Controller
    {
        private readonly BloggingContext _context = context;
        private readonly ILogger<HomeController> _logger = logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public async Task<IActionResult> Index()
        {
            List<Blog> list = await _context.Blogs
                                        .Include(f => f.Posts)
                                        .ToListAsync();

            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
