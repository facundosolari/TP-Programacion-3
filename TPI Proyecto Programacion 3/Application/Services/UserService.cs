using Application.Interfaces;
using Application.Models.Mappings;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly ITenantRepository _tenantRepository;
        private readonly IAdminRepository _adminRepository;

        public UserService(IOwnerRepository ownerRepository, ITenantRepository tenantRepository, IAdminRepository adminRepository)
        {
            _ownerRepository = ownerRepository;
            _tenantRepository = tenantRepository;
            _adminRepository = adminRepository;
        }
        public dynamic GetSelfUser(int userId)
        {
            var admin = _adminRepository.GetById(userId);
            if (admin != null)
            {
                return new
                {
                    userId = admin.Id,
                    username = admin.Username,
                    email = admin.Email,
                    firstName = admin.Name,
                    lastName = admin.Lastname,
                    photo = admin.Photo,
                    role = "Tenant"
                };
            }

            var owner = _ownerRepository.GetById(userId);
            if (owner != null)
            {
                return new
                {
                    userId = owner.Id,
                    username = owner.Username,
                    email = owner.Email,
                    firstName = owner.Name,
                    lastName = owner.Lastname,
                    photo = owner.Photo,
                    role = "Tenant"
                };
            }

            var tenant = _tenantRepository.GetById(userId);
            if (tenant != null)
            {
                return new
                {
                    userId = tenant.Id,
                    username = tenant.Username,
                    email = tenant.Email,
                    firstName = tenant.Name,
                    lastName = tenant.Lastname,
                    photo = tenant.Photo,
                    role = "Tenant"
                };
            }

            return null;
        }
    }
}
