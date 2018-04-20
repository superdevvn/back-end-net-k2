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
    public class ProductService
    {
        ProductRepository productrepository = new ProductRepository();
        UserService userservice = new UserService();

        public IEnumerable GetList()
        {
            return productrepository.GetList();
        }

        public Product Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new Exception("PRODUCT_ID_ISNULL");
            }
            else
            {
                return productrepository.Get(id);
            }
        }

        public Product Save(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name) || string.IsNullOrWhiteSpace(product.Code) || product.Price <= 0 
                || string.IsNullOrWhiteSpace(product.Description))
            {
                throw new Exception("PRODUCT_INPUT_INVALID");
            }
            if (product.Id == Guid.Empty)
            {
                if (productrepository.HashCode(product.Code))
                {
                    throw new Exception("PRODUCT_DUPLICATE_CODE");
                }
                else
                {
                    product.Id = Guid.NewGuid();
                    product.CreatedDate = DateTime.Now;
                    product.CreatedBy = userservice.GetCurrrentUser().Id;
                    product.ModifiedDate = DateTime.Now;
                    product.ModifiedBy = userservice.GetCurrrentUser().Id;
                    return productrepository.Create(product);
                }
            }
            else
            {
                if (productrepository.HashCode(product.Code, product.Id))
                {
                    throw new Exception("PRODUCT_DUPLICATE_CODE");
                }
                else if(productrepository.HashId_Category(product.CategoryId))
                {
                    throw new Exception("PRODUCT_ID_CATEGORY_INVALID");
                }
                else if (productrepository.HashId_Manufacture(product.ManufacturerId))
                {
                    throw new Exception("PRODUCT_ID_MANUFACTURER_INVALID");
                }
                else
                {
                    product.ModifiedDate = DateTime.Now;
                    return productrepository.Update(product);
                }
            }
        }

        public void Delete(Guid id)
        {
            var entity = productrepository.Get(id);
            if (entity == null)
            {
                throw new Exception("PRODUCT_NOTFOUND");
            }
            else
            {
                productrepository.Delete(id);
            }
        }
    }
}
