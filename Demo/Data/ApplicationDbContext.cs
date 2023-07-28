using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Demo.Models;
namespace Demo.Data{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<HoaQua> HoaQua { get; set; } = default!;
        public DbSet<Studen> Studens { get; set; } = default!;
    }
}
    
