using FirstApi.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApi.DataAccess.Abstract
{
    public interface IProductFeatureDal : IEntityRepository<ProductFeature>
    {
    }
}
