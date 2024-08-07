using Application.BookShelf.Core;
using Application.BookShelf.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookShelf.Services
{
    public  class UserService: IUserService
    {
        private readonly IUserRepo _userRepo;
        public UserService(IUserRepo userRepo) 
        {
            _userRepo = userRepo;
        }


        public async Task<User> getUserByEmailAndPassword(string email,string password)
        {
            var userData= await _userRepo.GetUserbyUserNameAndPassword(email, password);
            if(userData != null)
            {
                return userData;
            }
            else
            {
                return null;
            }
           
        }



    }
}
