using Application.BookShelf.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookShelf.Repository
{
    public interface IUserRepo
    {
        Task<User> GetUserbyUserNameAndPassword(string email, string password);
    }
}
