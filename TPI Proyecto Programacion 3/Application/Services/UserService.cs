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
                return AdminProfile.ToAdminResponse(admin);
            }

            var owner = _ownerRepository.GetById(userId);
            if (owner != null)
            {
                return OwnerProfile.ToOwnerResponse(owner);
            }

            var tenant = _tenantRepository.GetById(userId);
            if (tenant != null)
            {
                return TenantProfile.ToTenantResponse(tenant);
            }

            return null;
        }
    }
}
