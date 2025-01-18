using FirstApi.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApi.Business.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> GetAllByCategoryId(int categoryId);
        List<Product> GetAllByBetweenPrice(decimal min, decimal max);
        List<Product> GetAllByHigherThanPrice(decimal price);
        List<Product> GetAllByLowerThanPrice(decimal price);
    }
}
