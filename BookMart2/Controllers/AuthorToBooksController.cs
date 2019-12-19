using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookMart2.Data;
using BookMart2.Models;

namespace BookMart2.Controllers
{
    public class AuthorToBooksController : Controller
    {
        private readonly MyDbContext _context;

        public AuthorToBooksController(MyDbContext context)
        {
            _context = context;
        }

        // GET: AuthorToBooks
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.AuthorToBooks.Include(a => a.Authors).Include(a => a.Books);
            return View(await myDbContext.ToListAsync());
        }

        // GET: AuthorToBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorToBook = await _context.AuthorToBooks
                .Include(a => a.Authors)
                .Include(a => a.Books)
                .FirstOrDefaultAsync(m => m.AuthorToBookId == id);
            if (authorToBook == null)
            {
                return NotFound();
            }

            return View(authorToBook);
        }

        // GET: AuthorToBooks/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "name");
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "name");
            return View();
        }

        // POST: AuthorToBooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuthorToBookId,AuthorId,BookId")] AuthorToBook authorToBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(authorToBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "name", authorToBook.AuthorId);
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "name", authorToBook.BookId);
            return View(authorToBook);
        }

        // GET: AuthorToBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorToBook = await _context.AuthorToBooks.FindAsync(id);
            if (authorToBook == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "name", authorToBook.AuthorId);
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "name", authorToBook.BookId);
            return View(authorToBook);
        }

        // POST: AuthorToBooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AuthorToBookId,AuthorId,BookId")] AuthorToBook authorToBook)
        {
            if (id != authorToBook.AuthorToBookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(authorToBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorToBookExists(authorToBook.AuthorToBookId))
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
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "name", authorToBook.AuthorId);
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "name", authorToBook.BookId);
            return View(authorToBook);
        }

        // GET: AuthorToBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorToBook = await _context.AuthorToBooks
                .Include(a => a.Authors)
                .Include(a => a.Books)
                .FirstOrDefaultAsync(m => m.AuthorToBookId == id);
            if (authorToBook == null)
            {
                return NotFound();
            }

            return View(authorToBook);
        }

        // POST: AuthorToBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var authorToBook = await _context.AuthorToBooks.FindAsync(id);
            _context.AuthorToBooks.Remove(authorToBook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorToBookExists(int id)
        {
            return _context.AuthorToBooks.Any(e => e.AuthorToBookId == id);
        }
    }
}
