using System;
using System.Collections.Generic;
using System.Text;
using ffrs.mvc.Data.Configurations;
using ffrs.mvc.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ffrs.mvc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<Contacto> Contactos { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ContactoConfiguration());

            base.OnModelCreating(builder);
            
        }
    }
}
