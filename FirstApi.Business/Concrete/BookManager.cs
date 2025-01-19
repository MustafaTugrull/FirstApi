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
    public class BookManager : IBookService
    {
        private IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public List<Book> GetAll()
        {
            return _bookDal.GetAll();
        }

        public IQueryable<Book> GetAllQueryable()
        {
            return _bookDal.GetAllQueryable();
        }

        public Book GetById(int id)
        {
            return _bookDal.Get(x => x.Id == id);
        }

        public void Insert(Book entity)
        {
            _bookDal.Add(entity);
        }

        public void Modify(Book entity)
        {
            _bookDal.Update(entity);
        }

        public void Remove(Book entity)
        {
            _bookDal.Delete(entity);
        }
    }
}
