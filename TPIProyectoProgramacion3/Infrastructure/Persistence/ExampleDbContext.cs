using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence;

public class ExampleDbContex : DbContext
{
    public class ExampleDbContext(DbContextOptions<ExampleDbContex> options) : base(options)
    {

    }
    
    
}
