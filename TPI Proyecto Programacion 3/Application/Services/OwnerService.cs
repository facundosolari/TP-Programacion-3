using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Services
{
    public class OwnerService
    {
        public Owner GetOwnerService()
        {
            return new Owner();
        }
    }
}
