﻿using HandyTaxApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HandyTaxApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { 
        }

        public DbSet<ActualNews> ActualNews { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; } 
        public DbSet<Invoice> Invoices { get; set; }    
    }
}