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
    public class RoleService
    {
        RoleRepository rolerepository = new RoleRepository();
        UserService userservice = new UserService();

        public Role Save(Role role)
        {
            if(string.IsNullOrWhiteSpace(role.Code) || role.Code.Length > 15)
            {
                throw new Exception("ROLE_INVALID_CODE");
            }
            if(role.Id == Guid.Empty)
            {
                if(rolerepository.HashCode(role.Code))
                {
                    throw new Exception("ROLE_DUPLICATE_CODE");
                }
                else
                {
                    role.Id = Guid.NewGuid();
                    role.CreatedDate = DateTime.Now;
                    role.CreatedBy = userservice.GetCurrrentUser().Id;
                    role.ModifiedDate = DateTime.Now;
                    role.ModifiedBy = userservice.GetCurrrentUser().Id;
                    return rolerepository.Create(role);
                }
            }
            else
            {
                if(rolerepository.HashCode(role.Code, role.Id))
                {
                    throw new Exception("ROLE_DUPLICATE_CODE");
                }
                else
                {
                    role.ModifiedDate = DateTime.Now;
                    return rolerepository.Update(role);
                }
            }
        }

        public void Delete(Guid id)
        {
            var role = rolerepository.Get(id);
            if (role == null)
            {
                throw new Exception("ROLE_INCORRECT_ID");
            }
            rolerepository.Delete(id);
        }

        public IEnumerable GetList()
        {
            return rolerepository.GetList();
        }

        public Role Get(Guid id)
        {
            return rolerepository.Get(id);
        }
    }
}
