using BookMart2.Data;
using BookMart2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookMart2.Interfaces
{
    public class BookRepository
    {

        readonly MyDbContext _context;

        public BookRepository(MyDbContext context)
        {
            _context = context;
        }

        public void Add(Book book)
        {
            _context.Add(book);
        }

        public Task DeleteBook(int id)
        {
            var var = _context.Books.FindAsync(id);
            _context.Books.Remove(var.Result);
            return _context.SaveChangesAsync();
        }

        public Task<List<Book>> GetAll()
        {
            return _context.Books.ToListAsync();

        }

        public Task<List<Book>> GetBooks(Expression<Func<Book, bool>> predicate)
        {
            return _context.Books.Where(predicate).ToListAsync();
        }

        public bool IsEntityExist(int id)
        {
            return _context.Books.Any(e => e.BookId == id);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

    }
}

