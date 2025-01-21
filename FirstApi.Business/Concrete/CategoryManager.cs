using FirstApi.Business.Abstract;
using FirstApi.DataAccess.Abstract;
using FirstApi.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApi.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public IQueryable<Category> GetAllQueryable()
        {
            return _categoryDal.GetAllQueryable().Include(c => c.Products);
        }

        public Category GetById(int id)
        {
            return _categoryDal.Get(x => x.Id == id);
        }

        public void Insert(Category entity)
        {
            _categoryDal.Add(entity);
        }

        public void Modify(Category entity)
        {
            _categoryDal.Update(entity);
        }

        public void Remove(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public IQueryable<object> GetAllWithProducts()
        {
            var categories = _categoryDal.GetAllQueryable().Include(x => x.Products)
                    .Select(x => new
                    {
                        x.Name,
                        Products = x.Products.Select(item => new
                        {
                            item.Name,
                            item.Price,
                            item.Stock
                        }).ToList()
                    });

            return categories;
        }
    }
}
