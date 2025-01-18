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
    public class AuthorManager : IAuthorService
    {
        private IAuthorDal _authorDal;

        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }

        public List<Author> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Author> GetAllQueryable()
        {
            throw new NotImplementedException();
        }

        public Author GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Author GetIEmailAddress(string email)
        {
            throw new NotImplementedException();
        }

        public void Insert(Author entity)
        {
            throw new NotImplementedException();
        }

        public void Modify(Author entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Author entity)
        {
            throw new NotImplementedException();
        }
    }
}
