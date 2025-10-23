using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StageBear.Data;
using StageBear.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StageBear.Controllers
{
    [Authorize]
    public class ShowsController : Controller
    {
        private readonly IConfiguration _config;
        private readonly StageBearContext _context;
        private readonly BlobContainerClient _containerClient;

        public ShowsController(IConfiguration configuration, StageBearContext context)
        {
            _context = context;
            _config = configuration;


            //set up blob container client
            var connectionString = _config.GetConnectionString("AzureStorage");
            var containerName = "stgbr-poster-uploads";
            _containerClient = new BlobContainerClient(connectionString, containerName);
        }


        // GET: Shows/Create
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "CategoryID", "CategoryTitle");
            ViewData["OwnerID"] = new SelectList(_context.Set<Owner>(), "OwnerID", "FullName");
            ViewData["VenueID"] = new SelectList(_context.Set<Venue>(), "VenueID", "VenueName");
            return View();
        }

        // POST: Shows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShowID,Title,Description,Scheduled,Image,CategoryID,VenueID,OwnerID,FormFile")] Show show)
        {
            // Initialize values
            show.DateRecorded = DateTime.Now;

            if (ModelState.IsValid)
            {
                if (show.FormFile != null)
                {
                    //string filename = show.FormFile.FileName;
                    //show.Image = filename;

                    //string saveFileStream = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","assets",filename);

                    //using (FileStream fileStream = new FileStream(saveFileStream, FileMode.Create))
                    //{
                    //    await show.FormFile.CopyToAsync(fileStream);
                    //} THE OLD WAY



                    // THE NEW WAY
                    // Upload file to azure blob storage

                    //store the filename in fileUpload
                    IFormFile fileUpload = show.FormFile;

                    //create a unique filename for the blob
                    string blobName = Guid.NewGuid().ToString() + "_" + fileUpload.FileName;
                    var blobClient = _containerClient.GetBlobClient(blobName);

                    using (var stream = fileUpload.OpenReadStream())
                    {
                        await blobClient.UploadAsync(stream, new BlobHttpHeaders { ContentType = fileUpload.ContentType });
                    }
                    string blobURL = blobClient.Uri.ToString();
                    show.Image = blobURL;
                }
                else
                {
                    show.Image = "/shakes/ShakesPlaceholder.png";
                }

                    _context.Add(show);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Home");
            }
            ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "CategoryID", "CategoryTitle", show.CategoryID);
            ViewData["OwnerID"] = new SelectList(_context.Set<Owner>(), "OwnerID", "FullName", show.OwnerID);
            ViewData["VenueID"] = new SelectList(_context.Set<Venue>(), "VenueID", "VenueName", show.VenueID);
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
            ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "CategoryID", "CategoryTitle", show.CategoryID);
            ViewData["OwnerID"] = new SelectList(_context.Set<Owner>(), "OwnerID", "FullName", show.OwnerID);
            ViewData["VenueID"] = new SelectList(_context.Set<Venue>(), "VenueID", "VenueName", show.VenueID);
            return View(show);
        }

        // POST: Shows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShowID,Title,Description,Scheduled,Image,CategoryID,VenueID,OwnerID,FormFile")] Show show)
        {
            show.DateRecorded = DateTime.Now;

            if (id != show.ShowID)
            {
                return NotFound();
            }
            //Copilot helped me with this
            var existingShow = await _context.Show.AsNoTracking().FirstOrDefaultAsync(s => s.ShowID == id);

            if (existingShow == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (show.FormFile != null)
                {
                    string filename = show.FormFile.FileName;
                    show.Image = filename;

                    string saveFileStream = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets", filename);

                    using (FileStream fileStream = new FileStream(saveFileStream, FileMode.Create))
                    {
                        await show.FormFile.CopyToAsync(fileStream);
                    }
                    if (!string.IsNullOrEmpty(existingShow.Image))
                    {
                        string oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets", existingShow.Image);
                        if (System.IO.File.Exists(oldImagePath) && existingShow.Image != "ShakesPlaceholder.png")
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                }
                else
                {
                    show.Image = existingShow.Image;
                }

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
                return RedirectToAction("Index", "Home");
            }

            ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "CategoryID", "CategoryTitle", show.CategoryID);
            ViewData["OwnerID"] = new SelectList(_context.Set<Owner>(), "OwnerID", "FullName", show.OwnerID);
            ViewData["VenueID"] = new SelectList(_context.Set<Venue>(), "VenueID", "VenueName", show.VenueID);
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
            if (!string.IsNullOrEmpty(show.Image))
            {
                string DeleteImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets", show.Image);
                if (System.IO.File.Exists(DeleteImagePath) && show.Image != "ShakesPlaceholder.png")
                {
                    System.IO.File.Delete(DeleteImagePath);
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        private bool ShowExists(int id)
        {
            return _context.Show.Any(e => e.ShowID == id);
        }
    }
}
