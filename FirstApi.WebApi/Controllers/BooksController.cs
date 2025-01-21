using FirstApi.Business.Abstract;
using FirstApi.Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public IActionResult Add(Book book)
        {

            _bookService.Insert(book);
            return Ok(book);
            //return Created("/books", book);
        }

        [HttpPut]
        public IActionResult Update(Book book)
        {
            _bookService.Modify(book);
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _bookService.GetById(id);
            if (book != null)
            {
                _bookService.Remove(book);
                return Ok("Kitap Başarıyla silindi...");
            }
            return NotFound($"Kitap bulunamadı...");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var book = _bookService.GetAll();
            if (book != null)
            {
                return Ok(book);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _bookService.GetById(id);
            if (book != null)
            {
                return Ok(book);
            }
            return NotFound();
        }

        [HttpGet("[action]")]
        public IActionResult GetBooksWithAuthor()
        {
            var books = _bookService.GetAllQueryable().Include(b => b.Author).Select(x => new
            {
                x.Title,
                x.Author.FirstName,
                x.Author.LastName,
                x.Author.Email,
            }).ToList();
            if (books.Count > 0)
            {
                return Ok(books);
            }
            return NotFound("Kitaplar bulunamadı...");
        }
    }
}
