using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StageBear.Data;
using StageBear.Models;

namespace StageBear.Controllers
{
    public class ShowsController : Controller
    {
        private readonly StageBearContext _context;

        public ShowsController(StageBearContext context)
        {
            _context = context;
        }

        // GET: Shows
        public async Task<IActionResult> Index()
        {
            var stageBearContext = _context.Show.Include(s => s.Category).Include(s => s.Owner).Include(s => s.Venue);
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

        // GET: Shows/Create
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "CategoryId", "CategoryTitle");
            ViewData["OwnerID"] = new SelectList(_context.Set<Owner>(), "OwnerId", "FullName");
            ViewData["VenueID"] = new SelectList(_context.Set<Venue>(), "VenueId", "VenueName");
            return View();
        }

        // POST: Shows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShowID,Title,Description,Scheduled,DateRecorded,Image,CategoryID,VenueID,OwnerID")] Show show)
        {
            if (ModelState.IsValid)
            {
                _context.Add(show);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "CategoryId", "CategoryTitle", show.CategoryID);
            ViewData["OwnerID"] = new SelectList(_context.Set<Owner>(), "OwnerId", "FullName", show.OwnerID);
            ViewData["VenueID"] = new SelectList(_context.Set<Venue>(), "VenueId", "VenueName", show.VenueID);
            return View(show);
        }

        // GET: Shows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Show.FindAsync(id);
            if (show == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "CategoryId", "CategoryTitle", show.CategoryID);
            ViewData["OwnerID"] = new SelectList(_context.Set<Owner>(), "OwnerId", "FullName", show.OwnerID);
            ViewData["VenueID"] = new SelectList(_context.Set<Venue>(), "VenueId", "VenueName", show.VenueID);
            return View(show);
        }

        // POST: Shows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShowID,Title,Description,Scheduled,DateRecorded,Image,CategoryID,VenueID,OwnerID")] Show show)
        {
            if (id != show.ShowID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(show);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowExists(show.ShowID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "CategoryId", "CategoryTitle", show.CategoryID);
            ViewData["OwnerID"] = new SelectList(_context.Set<Owner>(), "OwnerId", "FullName", show.OwnerID);
            ViewData["VenueID"] = new SelectList(_context.Set<Venue>(), "VenueId", "VenueName", show.VenueID);
            return View(show);
        }

        // GET: Shows/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var show = await _context.Show.FindAsync(id);
            if (show != null)
            {
                _context.Show.Remove(show);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowExists(int id)
        {
            return _context.Show.Any(e => e.ShowID == id);
        }
    }
}
