using System;
using CodeFirst.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirst.Web.Controllers;

[Route("BlogDetails")]
public class BlogDetailsController(BloggingContext context, ILogger<BlogDetailsController> logger) : Controller
{
    private readonly BloggingContext _context = context;
    private readonly ILogger<BlogDetailsController> _logger = logger;

    [HttpGet("{id}")]
    public async Task<IActionResult> Index(Guid id)
    {
        var blog = await _context.Blogs.FindAsync(id);
        if (blog == null)
        {
            return NotFound();
        }

        return View(blog);
    }
}
