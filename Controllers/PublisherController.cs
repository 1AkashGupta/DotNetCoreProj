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
    public class PublisherController : ControllerBase
    {
        public PublisherService _publisherService;
        public PublisherController(PublisherService publisherService)
        {
            _publisherService = publisherService;
        }
        [HttpPost("add-publisher")]
        public IActionResult AddAuthor([FromBody] PublisherVM publisher)
        {
            var newPublisher1 = _publisherService.AddPublisher(publisher);
            return Created(nameof(AddAuthor),publisher);
        }
        [HttpGet("get-publisher-by-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            var publisherDetails = _publisherService.getPublisherById(id);
            if(publisherDetails != null)
            {
                return Ok(publisherDetails);
            }else
                return NotFound();
        }

        [HttpGet("get-publisher-data/{id}")]
        public IActionResult GetPublisherData(int id)
        {
            var publisherDetails = _publisherService.GetPublisherData(id);
            return Ok(publisherDetails);
        }

        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            var deleteStatus = _publisherService.DeletePublisherById(id);
            return Ok(deleteStatus);
        }
    }
}
