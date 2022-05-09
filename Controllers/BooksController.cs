using DotNetCoreLearnProj.Data.Services;
using DotNetCoreLearnProj.Data.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreLearnProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BookService _bookService;
        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }
        [HttpPost("add-book-with-author")]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            _bookService.AddBookWithAuthors(book);
            return Ok();
        }

        [HttpGet("get-all-book")]
        public IActionResult GetAllBook()
        {
            var allBook = _bookService.GetAllBook();
            return Ok(allBook);
        }

        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var bookDetails = _bookService.GetBookById(id);
            return Ok(bookDetails);
        }
        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody] BookVM book)
        {
            var bookDetails = _bookService.UpdateBookById(id, book);
            return Ok(bookDetails);
        }

        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult UpdateBookById(int id)
        {
            var deleteStatus = _bookService.DeleteBookById(id);
            return Ok(deleteStatus);
        }
    }
}
