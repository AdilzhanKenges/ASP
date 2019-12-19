using BookMart2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookMart2.Interfaces
{
    public interface IBookRepository
    {
        void Add(Book book);
        Task Save();
        Task<List<Book>> GetAll();
        Task<List<Book>> GetBook(Expression<Func<Book, bool>> predicate);
        Task DeleteBook(int id);
        bool IsEntityExist(int id);
    }
}
