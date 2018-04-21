using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperDev.Models;
using SuperDev.Repositories;

namespace SuperDev.Services
{
    public class RoleService
    {
        RoleRepository roleRepository = new RoleRepository();
        UserService userService = new UserService();
        public async Task<IEnumerable> GetList()
        {
            return await roleRepository.GetList();
        }

        public async Task<Role> Get(Guid id)
        {
            var role = await roleRepository.Get(id);
            if (role == null) throw new Exception("ROLE_INCORRECT_ID");
            return role;
        }

        public async Task<Role> Save(Role role)
        {
            if (string.IsNullOrWhiteSpace(role.Code) || role.Code.Length > 15) throw new Exception("ROLE_INVALID_CODE");
            var currentUser = await userService.GetCurrrentUser();
            if (role.Id == Guid.Empty)
            {
                if (roleRepository.HasCode(role.Code)) throw new Exception("ROLE_DUPLICATE_CODE");
                role.Id = Guid.NewGuid();
                role.CreatedDate = DateTime.Now;
                role.CreatedBy = currentUser.Id;
                role.ModifiedDate = DateTime.Now;
                role.ModifiedBy = currentUser.Id;
                return await roleRepository.Create(role);
            }
            else
            {
                if (roleRepository.HasCode(role.Id, role.Code)) throw new Exception("ROLE_DUPLICATE_CODE");
                role.ModifiedDate = DateTime.Now;
                role.ModifiedBy = currentUser.Id;
                return await roleRepository.Update(role);
            }
        }

        public async Task Delete(Guid id)
        {
            var role = roleRepository.Get(id);
            if (role == null) throw new Exception("ROLE_INCORRECT_ID");
            await roleRepository.Delete(id);
        }
    }
}
