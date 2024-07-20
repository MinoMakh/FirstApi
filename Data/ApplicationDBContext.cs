using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstApi.Data
{
    // Entity Framework to connect json into entity objects
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}