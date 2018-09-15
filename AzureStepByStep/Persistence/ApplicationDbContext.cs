﻿using AzureStepByStep.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureStepByStep.Persistence
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }

    }
    public class BloggingContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public IConfiguration Configuration { get; }

        public ApplicationDbContext CreateDbContext(string[] args)
        {

            
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=devazurestepbystep.database.windows.net;Initial Catalog=azureDB;Persist Security Info=True;User ID=administrator_05; Password=Angular@2018;");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }

}

