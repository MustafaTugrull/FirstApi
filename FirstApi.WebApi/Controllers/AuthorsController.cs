using FirstApi.Business.Abstract;
using FirstApi.DataAccess.Abstract;
using FirstApi.Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost]
        public IActionResult Add(Author author)
        {
            _authorService.Insert(author);
            return Ok(author);
            //return Created("/authors", book);
        }

        [HttpPut]
        public IActionResult Update(Author author)
        {
            _authorService.Modify(author);
            return Ok(author);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var authors = _authorService.GetById(id);
            if (authors != null)
            {
                _authorService.Remove(authors);
                return Ok("Yazar Başarıyla silindi...");
            }
            return NotFound("Yazar bulunamadı...");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var authors = _authorService.GetAll();
            if (authors != null)
            {
                return Ok(authors);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var authors = _authorService.GetById(id);
            if (authors != null)
            {
                return Ok(authors);
            }
            return NotFound();
        }

        [HttpGet("[action]/{email}")]
        public IActionResult GetIEmailAddress(string email)
        {
            var author = _authorService.GetIEmailAddress(email);
            if (author != null)
            {
                return Ok(author);
            }
            return NotFound("Yazar bulunamadı...");
        }

        [HttpGet("[action]")]
        public IActionResult GetAllWithBooks()
        {
            var author = _authorService.GetAllQueryable().Include(a => a.Books).Select(a => new
            {
                a.FirstName,
                a.LastName,
                Books = a.Books.Select(b => new
                {
                    b.Title
                }).ToList()
            }).ToList();
            if (author != null)
            {
                return Ok(author);
            }
            return NotFound("Yazarlar bulunamadı...");
        }
    }
}
