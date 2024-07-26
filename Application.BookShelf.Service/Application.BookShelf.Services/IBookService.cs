using Application.BookShelf.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookShelf.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooks();
    }
}
