using FirstApi.DataAccess.Abstract;
using FirstApi.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApi.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfGenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(FirstApiDbContext context) : base(context)
        {
        }
    }
}
