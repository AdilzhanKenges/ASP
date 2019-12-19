using BookMart2.Interfaces;
using BookMart2.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace BookMart2.BookUnitTesting
{
    public class BookUnitTesting
    {
        List<Book> books = new List<Book>
        {
            new Book() { name = "test fname 1", year=5646,UserID=1},
            new Book() { name = "test fname 2", year=5646,UserID=1},
            new Book() { name = "test fname 3", year=5646,UserID=1},
           
        };

        [Fact]
        public async Task AddTest()
        {
            var fakeRepository = Mock.Of<IBookRepository>();
            var bookService = new Services.BookService(fakeRepository);

            var book = new Book() { name = "test fname 3", year = 5646, UserID = 1};
            await bookService.AddAndSave(book);
        }

        [Fact]
        public async Task GetBooksTest()
        {
         
            var books = new List<Book>
            {
               new Book() { name = "test name 1", year=5646,UserID=1},
            new Book() { name = "test name 2", year=5646,UserID=1},
            };

            var fakeRepositoryMock = new Mock<IBookRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(books);


            var bookService = new Services.BookService(fakeRepositoryMock.Object);

            var resultBooks = await bookService.GetBooks();

            Assert.Collection(resultBooks, book =>
            {
                Assert.Equal("test name 1", book.name);
            },
            book =>
            {
                Assert.Equal("test name 2", book.name);
            });
        }

        [Fact]
        public async Task DeleteEntityTest()
        {
            var fakeRepositoryMock = new Mock<IBookRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(books);


            var bookService = new Services.BookService(fakeRepositoryMock.Object);

            await bookService.DeleteBook(2);
        }
    }
}
