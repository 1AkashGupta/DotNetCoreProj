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
    public class AuthorController : ControllerBase
    {
        public AuthorService _authorService;
        public AuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }
        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
            _authorService.AddAuthor(author);
            return Ok();
        }
        [HttpGet("get-all-author")]
        public IActionResult GetAllAuthor()
        {
            var allAuthor = _authorService.GetAllAuthor();
            return Ok(allAuthor);
        }

        [HttpGet("get-author-by-id/{id}")]
        public IActionResult GetAuthorById(int id)
        {
            var authorDetails = _authorService.GetAuthorById(id);
            return Ok(authorDetails);
        }
    }
}
