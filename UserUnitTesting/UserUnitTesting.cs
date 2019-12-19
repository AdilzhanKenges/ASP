using BookMart2.Interfaces;
using BookMart2.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace BookMart2.UserUnitTesting
{
    public class UserUnitTesting
    {
        List<User> users = new List<User>
        {
            new User() { FirstName = "test fname 1", LastName="test lname 1", Email="test1@book.kz"},
            new User() { FirstName = "test fname 2", LastName="test lname 2", Email="test2@book.kz"},
            new User() { FirstName = "test fname 3", LastName="test lname 3", Email="test3@book.kz"},
        };

        [Fact]
        public async Task AddTest()
        {
            var fakeRepository = Mock.Of<IUsersRepository>();
            var userService = new Services.UsersService(fakeRepository);

            var user = new User() { FirstName = "test fname 1", LastName = "test lname 1", Email = "test1@book.kz"};
            await userService.AddAndSave(user);
        }

        [Fact]
        public async Task GetUsersTest()
        {
         
            var users = new List<User>
            {
               new User() { FirstName = "test fname 1", LastName="test lname 1", Email="test1@book.kz"},
            new User() { FirstName = "test fname 2", LastName="test lname 2", Email="test2@book.kz"},
            };

            var fakeRepositoryMock = new Mock<IUsersRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(users);


            var userService = new Services.UsersService(fakeRepositoryMock.Object);

            var resultUsers = await userService.GetUsers();

            Assert.Collection(resultUsers, user =>
            {
                Assert.Equal("test fname 1", user.FirstName);
            },
            user =>
            {
                Assert.Equal("test fname 2", user.FirstName);
            });
        }

        [Fact]
        public async Task DeleteEntityTest()
        {
            var fakeRepositoryMock = new Mock<IUsersRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(users);


            var userService = new Services.UsersService(fakeRepositoryMock.Object);

            await userService.DeleteUser(2);
        }
    }
}
