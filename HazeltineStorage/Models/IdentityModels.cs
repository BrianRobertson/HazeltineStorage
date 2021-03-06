﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HazeltineStorage.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //public System.Data.Entity.DbSet<HazeltineStorage.Models.Customer> Customers { get; set; }//Generated by scaffolding the first time.
        public DbSet<Customer> Customers { get; set; } //Manually created, works the same as above.
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<CustomerStatus> CustomerStatus { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<StorageUnit> StorageUnits { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<ActivityLog> Activities { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }

        //public System.Data.Entity.DbSet<HazeltineStorage.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}