using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookApi.Models;

namespace BookApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BookChaptersController : Controller
    {
        private readonly IBookChaptersRepository _repository;
        public BookChaptersController(IBookChaptersRepository repository)
        {
            _repository = repository;
        }

        // GET: api/bookchapters

        [HttpGet("/api/chapters")]

        // [HttpGet("/api/items.{format}"), FormatFilter]
        public IEnumerable<BookChapter> GetBookChapters() => _repository.GetAll();

        // GET api/bookchapters/guid
        //[HttpGet("{id}", Name = nameof(GetBookChapterById))]

        [HttpGet("/api/chapter/{id}")]
        public IActionResult GetBookChapterById(string id)
        {
            BookChapter chapter = _repository.Find(id);
            if (chapter == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(chapter);
            }
        }

        // POST api/bookchapters
      
        [HttpPost("/api/chapter")]
        public IActionResult PostBookChapter([FromBody]BookChapter chapter)
        {
            if (chapter == null)
            {
                return BadRequest();
            }
            _repository.Add(chapter);
            // return a 201 response, Created
            return CreatedAtRoute(nameof(GetBookChapterById), new { id = chapter.Id }, chapter);
        }

        // PUT api/bookchapters/guid
     
        [HttpPut("/api/chapter/{id}")]
        public IActionResult PutBookChapter(string id, [FromBody]BookChapter chapter)
        {
            if (chapter == null || id != chapter.Id)
            {
                return BadRequest();
            }
            if (_repository.Find(id) == null)
            {
                return NotFound();
            }

            _repository.Update(chapter);
            return new NoContentResult();  // 204
        }

        // DELETE api/bookchapters/guid
       
        [HttpDelete("/api/chapter/{id}")]
        public void Delete(string id)
        {
            _repository.Remove(id);
            // void returns 204, No Content
        }
    }
}