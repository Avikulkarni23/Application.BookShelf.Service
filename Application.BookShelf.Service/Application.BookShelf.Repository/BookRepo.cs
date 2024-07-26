using Application.BookShelf.Core;
using Application.BookShelf.Infrastructure;
using Dapper;

namespace Application.BookShelf.Repository
{
    public class BookRepo : IBookRepo
    {
        private readonly BookShelfDbContext _context;

        #region SQLQueries
        private string queryBookList = "Select * from Book";
        #endregion
        public BookRepo(BookShelfDbContext context) 
        { 
            _context = context;
        }

        /// <summary>
        /// This method will fetch the all books from DB
        /// </summary>
        /// <returns></returns>
        public async Task<List<Book>> GetAllBooks()
        {
            using (var connection = _context.CreateConnection())
            { 
                var bookList = await connection.QueryAsync<Book>(queryBookList);
                return bookList.ToList();
            }
            
        }



    }
}
