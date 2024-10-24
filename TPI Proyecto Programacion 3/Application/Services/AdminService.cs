using System;
using System.Collections.Generic;
using System.Linq;
using Application.Interfaces;
using Application.Models.Mappings;
using Application.Models.AdminModels.Request;
using Application.Models.AdminModels.Response;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IBuildingRepository _buildingRepository;

        public AdminService(IAdminRepository adminRepository, IBuildingRepository buildingRepository)
        {
            _adminRepository = adminRepository;
            _buildingRepository = buildingRepository;
        }

        public List<AdminResponse> GetAll()
        {
            var admins = _adminRepository.GetAll();

            if (admins == null || admins.Count == 0)
            {
                throw new Exception("No existen administradores");
            }

            var adminsResponse = admins.Select(admin => AdminProfile.ToAdminResponse(admin)).ToList();
            return adminsResponse;
        }

        public AdminResponse GetById(int id)
        {
            var admin = _adminRepository.GetById(id);

            if (admin == null)
            {
                throw new Exception("Administrador no encontrado");
            }

            return AdminProfile.ToAdminResponse(admin);
        }

        public AdminResponse Create(AdminRequest admin)
        {
            var newAdmin = AdminProfile.ToAdminEntity(admin);

            if (newAdmin == null)
            {
                throw new Exception("Error al crear nuevo administrador");
            }

            _adminRepository.Create(newAdmin);
            return AdminProfile.ToAdminResponse(newAdmin);
        }

        public AdminResponse UpdateAdmin(int id, AdminRequest updatedAdmin)
        {
            var admin = _adminRepository.GetById(id);

            if (admin == null)
            {
                throw new Exception("Administrador no encontrado");
            }

            AdminProfile.ToAdminUpdate(admin, updatedAdmin);
            _adminRepository.UpdateAdmin(admin);

            return AdminProfile.ToAdminResponse(admin);
        }

        public AdminResponse DeleteAdmin(int id)
        {
            var admin = _adminRepository.GetById(id);

            if (admin == null)
            {
                throw new Exception("Administrador no encontrado");
            }

            _adminRepository.DeleteAdmin(admin);
            return AdminProfile.ToAdminResponse(admin);
        }

    }
}
