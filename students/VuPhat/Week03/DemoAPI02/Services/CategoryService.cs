using Model;
using Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService
    {
        CategoryRepository categoryrepository = new CategoryRepository();
        UserService userservice = new UserService();

        public IEnumerable GetList()
        {
            return categoryrepository.GetList();
        }

        public Category Get(Guid id)
        {
            if(id == Guid.Empty)
            {
                throw new Exception("CATEGORY_ID_ISNULL");
            }
            else
            {
                return categoryrepository.Get(id);
            }
        }

        public Category Save(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Code) || category.Code.Length > 15)
            {
                throw new Exception("CATEGORY_INVALID_CODE");
            }
            if (category.Id == Guid.Empty)
            {
                if (categoryrepository.HashCode(category.Code))
                {
                    throw new Exception("CATEGORY_DUPLICATE_CODE");
                }
                else
                {
                    category.Id = Guid.NewGuid();
                    category.CreatedDate = DateTime.Now;
                    category.CreatedBy = userservice.GetCurrrentUser().Id;
                    category.ModifiedDate = DateTime.Now;
                    category.ModifiedBy = userservice.GetCurrrentUser().Id;
                    return categoryrepository.Create(category);
                }
            }
            else
            {
                if (categoryrepository.HashCode(category.Code, category.Id))
                {
                    throw new Exception("CATEGORY_DUPLICATE_CODE");
                }
                else
                {
                    category.ModifiedDate = DateTime.Now;
                    return categoryrepository.Update(category);
                }
            }
        }

        public void Delete(Guid id)
        {
            var entity = categoryrepository.Get(id);
            if(entity == null)
            {
                throw new Exception("CATEGORY_NOTFOUND");
            }
            else
            {
                categoryrepository.Delete(id);
            }
        }
    }
}
