using FirstApi.Business.Abstract;
using FirstApi.Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            _productService.Insert(product);
            return Ok(product);
            //return Created("/products", product);
        }

        [HttpPut]
        public IActionResult Update(Product product)
        {
            _productService.Modify(product);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var products = _productService.GetById(id);
            if (products != null)
            {
                _productService.Remove(products);
                return Ok("Ürün Başarıyla silindi...");
            }
            return NotFound($"Ürün bulunamadı...");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.GetAll();
            if (products != null)
            {
                return Ok(products);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var products = _productService.GetById(id);
            if (products != null)
            {
                return Ok(products);
            }
            return NotFound();
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetAllByCategoryId(int id)
        {
            var products = _productService.GetAllByCategoryId(id);
            if (products != null)
            {
                return Ok(products);
            }
            return NotFound();
        }

        [HttpGet("[action]")]
        public IActionResult GetAllByBetweenPrice(decimal min, decimal max)
        {
            var products = _productService.GetAllByBetweenPrice(min, max);
            if (products.Count > 0)
            {
                return Ok(products);
            }
            return NotFound("Bu fiyat aralığında ürün bulunamadı.");
        }

        [HttpGet("[action]")]
        public IActionResult GetAllByHigherThanPrice(decimal price)
        {
            var products = _productService.GetAllByHigherThanPrice(price);
            if (products.Count > 0)
            {
                return Ok(products);
            }
            return NotFound("Belirtilen fiyattan yüksek fiyatlı ürün bulunamadı.");
        }

        [HttpGet("[action]")]
        public IActionResult GetAllByLowerThanPrice(decimal price)
        {
            var products = _productService.GetAllByLowerThanPrice(price);
            if (products.Count > 0)
            {
                return Ok(products);
            }
            return NotFound("Belirtilen fiyattan düşük fiyatlı ürün bulunamadı.");
        }

    }
}
