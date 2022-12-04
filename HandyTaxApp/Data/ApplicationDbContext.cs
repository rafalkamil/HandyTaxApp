using HandyTaxApp.Models;
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

        public DbSet<ApplicationUser> ApplicationUsers { get; set; } 
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<OutcomeInvoice> OutcomeInvoices { get; set; }
    }
}