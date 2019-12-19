using BookMart2.Interfaces;
using BookMart2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMart2.Services
{
    public class BookService
    {
        private readonly IBookRepository _book;

        public BookService(IBookRepository context)
        {
            _book = context;
        }

        public async Task AddAndSave(Book book)
        {
            _book.Add(book);
            await _book.Save();
        }

        public async Task<List<Book>> GetBooks()
        {
            return await _book.GetAll();
        }

        public async Task DeleteBook(int id)
        {
            await _book.DeleteBook(id);
        }

        public bool IsEntityExist(int id)
        {
            return _book.IsEntityExist(id);
        }

    }
}
