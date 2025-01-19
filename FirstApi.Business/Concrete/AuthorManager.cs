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
            return _authorDal.GetAll();
        }

        public IQueryable<Author> GetAllQueryable()
        {
            return _authorDal.GetAllQueryable();
        }

        public Author GetById(int id)
        {
            return _authorDal.Get(x => x.Id == id);
        }

        public Author GetIEmailAddress(string email)
        {
            return _authorDal.Get(x => x.Email == email);
        }

        public void Insert(Author entity)
        {
            _authorDal.Add(entity);
        }

        public void Modify(Author entity)
        {
            _authorDal.Update(entity);
        }

        public void Remove(Author entity)
        {
            _authorDal.Delete(entity);
        }
    }
}
