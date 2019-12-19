using BookMart2.Interfaces;
using BookMart2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMart2.Services
{
    public class UsersService
    {
        private readonly IUsersRepository _user;

        public UsersService(IUsersRepository context)
        {
            _user = context;
        }

        public async Task AddAndSave(User user)
        {
            _user.Add(user);
            await _user.Save();
        }

        public async Task<List<User>> GetUsers()
        {
            return await _user.GetAll();
        }

        public async Task DeleteUser(int id)
        {
            await _user.DeleteUser(id);
        }

        public bool IsEntityExist(int id)
        {
            return _user.IsEntityExist(id);
        }

    }
}
