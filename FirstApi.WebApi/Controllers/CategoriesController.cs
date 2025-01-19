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
            try
            {
                var categories = _categoryService.GetAll();
                if (categories != null)
                {
                    return Ok(categories);
                }
                return NotFound();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //[HttpGet("{id}")]
        [HttpGet("[action]/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var categories = _categoryService.GetById(id);
                if (categories != null)
                {
                    return Ok(categories);
                }
                return NotFound();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            try
            {
                _categoryService.Insert(category);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //[HttpPut("{id}")]
        [HttpPut]
        public IActionResult Update(Category category)
        {
            try
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
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var category = _categoryService.GetById(id);
                if (category != null)
                {
                    _categoryService.Remove(category);
                    return Ok("Ürün Başarıyla silindi...");
                }
                return NotFound($"Kategori bulunamadı...");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
