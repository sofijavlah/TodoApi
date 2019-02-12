using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        //public TodoContext(DbContextOptions<TodoContext> options)
        //    : base(options)
        //{


        //}

        protected readonly IHostingEnvironment hostingEnvirement;
        public TodoContext(DbContextOptions<TodoContext> options, IHostingEnvironment hostingEnvirement) : base(options)
        {
            this.hostingEnvirement = hostingEnvirement;
        }


        public DbSet<TodoItem> TodoItems { get; set; }

        public DbSet<Osoba> Osobe { get; set; }

        //!
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var path = hostingEnvirement.ContentRootPath;
            var path1 = Path.Combine(path, "proba.json");
            
            var jsonString = File.ReadAllText(path1);
            var list = JsonConvert.DeserializeObject<List<Osoba>>(jsonString);
            modelBuilder.Entity<Osoba>().HasData(list);

        }

    }
}
