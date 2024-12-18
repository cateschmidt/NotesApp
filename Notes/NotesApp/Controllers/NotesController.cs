// Controllers/NotesController.cs
using Microsoft.AspNetCore.Mvc;
using NotesApp.Data;
using NotesApp.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace NotesApp.Controllers
{
    public class NotesController : Controller
    {
        /// <summary>
        /// The application database context used by the NotesController.
        /// </summary>
        private readonly ApplicationDbContext _context;

        public NotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Notes
        public IActionResult Index()
        {
            var notes = _context.Notes.ToList();
            return View(notes);
        }

        // GET: Notes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Notes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Title, Content")] Note note)
        {
            if (ModelState.IsValid)
            {
                _context.Add(note);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(note);
        }

        // GET: Notes/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = _context.Notes.Find(id);
            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        // POST: Notes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id, Title, Content")] Note note)
        {
            if (id != note.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(note);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Notes.Any(e => e.Id == note.Id))
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
            return View(note);
        }

        // GET: Notes/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = _context.Notes
                .FirstOrDefault(m => m.Id == id);
            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        // POST: Notes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var note = _context.Notes.Find(id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}


