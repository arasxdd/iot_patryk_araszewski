using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab2_araszewski.Rest.Models;
using Microsoft.EntityFrameworkCore;

namespace lab2_araszewski.Rest.Context
{
    public class AzureDbContext : DbContext
    {
        public AzureDbContext(DbContextOptions<AzureDbContext> options) : base(options)
        {

        }

        protected AzureDbContext()
        {

        }

        public DbSet<Person> People { get; set; }
    }
}
