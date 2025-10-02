using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StageBear.Data;
using StageBear.Models;
using System.Diagnostics;

namespace StageBear.Controllers
{
    public class HomeController : Controller
    {
        private readonly StageBearContext _context;

        public HomeController(StageBearContext context)
        {
            _context = context;
        }
      

        // GET: Shows
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var stageBearContext = _context.Show
                .Include(s => s.Category)
                .Include(s => s.Owner)
                .Include(s => s.Venue)
                .OrderBy(s => s.Scheduled)
                .AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                stageBearContext = stageBearContext.Where(s => s.Title.ToUpper().Contains(searchString));
            }

            return View(await stageBearContext.ToListAsync());
        }

        // GET: Shows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Show
                .Include(s => s.Category)
                .Include(s => s.Owner)
                .Include(s => s.Venue)
                .FirstOrDefaultAsync(m => m.ShowID == id);
            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
