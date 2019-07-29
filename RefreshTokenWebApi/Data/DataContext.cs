using Microsoft.EntityFrameworkCore;
using RefreshTokenWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefreshTokenWebApi.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Personal> Personals { get; set; }
    }
}
