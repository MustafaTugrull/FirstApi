using FirstApi.Business.Abstract;
using FirstApi.DataAccess.Abstract;
using FirstApi.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApi.Business.Concrete
{
    public class ProductFeatureManager : IProductFeatureService
    {
        private IProductFeatureDal _productFeatureDal;

        public ProductFeatureManager(IProductFeatureDal productFeatureDal)
        {
            _productFeatureDal = productFeatureDal;
        }

        public List<ProductFeature> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProductFeature> GetAllQueryable()
        {
            throw new NotImplementedException();
        }

        public ProductFeature GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(ProductFeature entity)
        {
            throw new NotImplementedException();
        }

        public void Modify(ProductFeature entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(ProductFeature entity)
        {
            throw new NotImplementedException();
        }
    }
}
