using DCSS_8536_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCSS_8536_API.DBContexts
{
    public class ServiceContext : DbContext
    {
        public ServiceContext(DbContextOptions<ServiceContext> options) : base(options)
        {
        }
        public DbSet<Service> Services { get; set; }
    }
}
