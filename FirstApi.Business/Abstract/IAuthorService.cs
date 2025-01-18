using FirstApi.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApi.Business.Abstract
{
    public interface IAuthorService : IGenericService<Author>
    {
        Author GetIEmailAddress(string email);
    }
}
