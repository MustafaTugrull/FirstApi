using FirstApi.Business.Abstract;
using FirstApi.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApi.Business.Concrete
{
    public class ProductManager : IProductService
    {
        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByBetweenPrice(decimal min, decimal max)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByHigherThanPrice(decimal price)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByLowerThanPrice(decimal price)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> GetAllQueryable()
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Modify(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
