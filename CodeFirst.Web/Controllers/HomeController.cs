using CodeFirst.Domain;
using CodeFirst.Domain.Entities;
using CodeFirst.Domain.Migrations;
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

        public async Task<IActionResult> Index()
        {
            List<Blog> list = await _context.Blogs
                                        .Include(f => f.Posts)
                                        .ToListAsync();

            return View(list);
        }

        [HttpPost(Name = "AddBlog")]
        public async Task<IActionResult> AddBlog(string blogName)
        {
            if (string.IsNullOrWhiteSpace(blogName))
            {
                return BadRequest("Blog name is required.");
            }

            Blog newBlog = new Blog
            {
                Name = blogName,
                State = State.Draft
            };

            _context.Blogs.Add(newBlog);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        

        [HttpPost(Name = "ToggleBlogState")]
        public async Task<IActionResult> ToggleBlogState(Guid? id)
        {
            if(id == null)
            {
                return BadRequest("Blog ID is required.");
            }


            Blog? blog = await _context.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }            

            blog.State = blog.State == State.Draft ? State.Published : State.Draft;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
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
