using Jubilant.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jubilant.API.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _booksRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _booksRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));

        }
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var bookEntities = await _booksRepository.GetBooksAsync();
            return Ok(bookEntities);
        }
    }
}
