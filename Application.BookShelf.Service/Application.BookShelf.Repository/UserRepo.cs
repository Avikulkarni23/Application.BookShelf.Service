using Application.BookShelf.Core;
using Application.BookShelf.Infrastructure;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.BookShelf.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly BookShelfDbContext _context;

        #region SQLQueries
        private string verifiyUser = @"Select id,fullname,emailaddress,Password,role from Users where emailaddress = @email AND Password= @password";
        private string queryBookList = "Select * from users";
        #endregion
        public UserRepo(BookShelfDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserbyUserNameAndPassword(string email,string password)
        {
            using (var connection = _context.CreateConnection())
            {
               var userData =  await connection.QueryFirstOrDefaultAsync<User>(verifiyUser, new { email = email, password = password });
                if (userData == null)
                {
                    return null;
                }

                //var data = JsonSerializer.Serialize<User>(userData);
                return userData;
                
            }

        }
    }

}
