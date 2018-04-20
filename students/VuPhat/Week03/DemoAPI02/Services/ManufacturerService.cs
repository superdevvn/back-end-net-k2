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
    public class ManufacturerService
    {
        ManufacturerRepository manufacturerrepository = new ManufacturerRepository();
        UserService userservice = new UserService();

        public IEnumerable GetList()
        {
            return manufacturerrepository.GetList();
        }

        public Manufacturer Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new Exception("MANUFACTURER_ID_ISNULL");
            }
            else
            {
                return manufacturerrepository.Get(id);
            }
        }

        public Manufacturer Save(Manufacturer manufacturer)
        {
            if (string.IsNullOrWhiteSpace(manufacturer.Code) || manufacturer.Code.Length > 15)
            {
                throw new Exception("MANUFACTURER_INVALID_CODE");
            }
            if (manufacturer.Id == Guid.Empty)
            {
                if (manufacturerrepository.HashCode(manufacturer.Code))
                {
                    throw new Exception("MANUFACTURER_DUPLICATE_CODE");
                }
                else
                {
                    manufacturer.Id = Guid.NewGuid();
                    manufacturer.CreatedDate = DateTime.Now;
                    manufacturer.CreatedBy = userservice.GetCurrrentUser().Id;
                    manufacturer.ModifiedDate = DateTime.Now;
                    manufacturer.ModifiedBy = userservice.GetCurrrentUser().Id;
                    return manufacturerrepository.Create(manufacturer);
                }
            }
            else
            {
                if (manufacturerrepository.HashCode(manufacturer.Code, manufacturer.Id))
                {
                    throw new Exception("MANUFACTURER_DUPLICATE_CODE");
                }
                else
                {
                    manufacturer.ModifiedDate = DateTime.Now;
                    return manufacturerrepository.Update(manufacturer);
                }
            }
        }

        public void Delete(Guid id)
        {
            var entity = manufacturerrepository.Get(id);
            if (entity == null)
            {
                throw new Exception("MANUFACTURER_NOTFOUND");
            }
            else
            {
                manufacturerrepository.Delete(id);
            }
        }
    }
}
