using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class RutiranjeContext : DbContext
    {
        public RutiranjeContext(DbContextOptions<RutiranjeContext> options)
            : base(options)
        {
        }


        public DbSet<Rutiranje> Rutiranja { get; set; }
    }
}
