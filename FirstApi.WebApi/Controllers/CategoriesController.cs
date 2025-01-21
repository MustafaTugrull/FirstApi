using FirstApi.Business.Abstract;
using FirstApi.Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _categoryService.GetAll();
            if (categories != null)
            {
                return Ok(categories);
            }
            return NotFound();
        }

        //[HttpGet("{id}")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var categories = _categoryService.GetById(id);
            if (categories != null)
            {
                return Ok(categories);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            _categoryService.Insert(category);
            return Ok(category);

        }

        //[HttpPut("{id}")]
        [HttpPut]
        public IActionResult Update(Category category)
        {
            //if (category == null || id != category.Id)
            //{
            //    return BadRequest("Invalid category data.");
            //}

            //var existingCategory = _categoryService.GetById(id);
            //if (existingCategory == null)
            //{
            //    return NotFound($"Category with ID {id} not found.");
            //}

            _categoryService.Modify(category);
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var category = _categoryService.GetById(id);
            if (category != null)
            {
                _categoryService.Remove(category);
                return Ok("Kategori Başarıyla silindi...");
            }
            return NotFound($"Kategori bulunamadı...");
        }

        [HttpGet("[action]")]
        public IActionResult GetAllWithProducts()
        {

            var categories = _categoryService.GetAllQueryable()
                .Select(x => new
                {
                    x.Name,
                    Products = x.Products.Select(item => new
                    {
                        item.Name,
                        item.Price,
                        item.Stock
                    }).ToList()
                }).ToList();
            //var categories = _categoryService.GetAllWithProducts();

            if (categories != null)
            {
                return Ok(categories);
            }
            return NotFound();

        }
    }
}
