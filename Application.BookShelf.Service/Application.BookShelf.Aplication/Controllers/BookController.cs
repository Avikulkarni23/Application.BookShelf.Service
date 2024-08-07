using Application.BookShelf.Core;
using Application.BookShelf.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Application.BookShelf.Aplication.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }


        [Route("api/GetAllBooks")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllBooks()
        {
            var list = await _bookService.GetAllBooks();
            if (list == null)
            {
                return NotFound();               
            }
            else
            {
                return Ok(list);
            }

        }


        [Route("api/BookDetails")]
        [HttpGet]
        [Authorize]
        public IEnumerable<Book> GetBookDetails()
        {
            return new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    BookName = "Rising Stars",
                    BookAutherName = "Kane Willam",
                    BookGenere = "Biopic",
                    BookEdition = "Second Edition"
                },
                new Book()
                {
                    Id = 2,
                    BookName = "Rising liitle champ",
                    BookAutherName = "Willam",
                    BookGenere = "Horror",
                    BookEdition = "First Edition"
                },
            };
        }


        [Route("api/Book/{Id}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Book>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Book> GetEmployeeDetails(int Id)
        {
            if (Id == 0)
            {
                return NotFound();
            }
            else if (Id == 1) {
            
                return new Book()
                {
                    Id = 1,
                    BookName = "Rising Stars",
                    BookAutherName = "Kane Willam",
                    BookGenere = "Biopic",
                    BookEdition = "Second Edition"
                };
            }
            else
            {
                return BadRequest();
            }


        }



    }
}
