using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.AdminModels.Request;
using Application.Models.AdminModels.Response;

namespace Application.Interfaces;

public interface IAdminService
{
    List<AdminResponse> GetAll();
    AdminResponse GetById(int id);
    AdminResponse Create(AdminRequest admin);
    AdminResponse UpdateAdmin(int id, AdminRequest admin);
    AdminResponse DeleteAdmin(int id);
   
}
