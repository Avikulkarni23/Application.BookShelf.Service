using Application.BookShelf.Core;
using Application.BookShelf.Repository;


namespace Application.BookShelf.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepo _iBookRepo;
        public BookService(IBookRepo iBookRepo) 
        {
            _iBookRepo = iBookRepo;
        }

        /// <summary>
        /// Fetch all the books
        /// </summary>
        /// <returns></returns>
        public async Task<List<Book>> GetAllBooks()
        {
            try
            {
                var bookList = await _iBookRepo.GetAllBooks();

                if (bookList != null)
                {
                    return bookList;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
          

           
        }
    }
}
