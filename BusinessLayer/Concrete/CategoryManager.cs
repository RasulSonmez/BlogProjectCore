using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFrameWork;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public ICollection<Category> GetAllStatusActive()
        {
            throw new NotImplementedException();
        }

        public void TAdd(Category t)
        {
            _categoryDal.Insert(t);
        }

        public void TDelete(Category t)
        {
            _categoryDal.Delete(t);
        }

        public List<Category> TGetAll()
        {
            return _categoryDal.GetListAll().ToList();
        }

        public Category TGetById(int id)
        {
            return _categoryDal.GetByID(id);
        }

        public void TUpdate(Category t)
        {
            _categoryDal.Update(t);
        }
    }
}
