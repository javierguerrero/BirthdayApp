using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>()
                .HasData(
                    new Contact() { Id = 1, Name = "Bacilio", LastName ="Gonzales", Birthday= new DateTime(1985, 7, 8)  , Email="baciliogonzales@gmail.com",PhoneNumber="+51992691213" },
                    new Contact() { Id = 2, Name = "Javier", LastName ="Guerrero", Birthday= new DateTime(1982, 2, 17)  , Email="javierguerrero.tech@gmail.com",PhoneNumber="+51976268172" },
                    new Contact() { Id = 3, Name = "John", LastName ="Doe", Birthday= new DateTime(1980, 3, 10)  , Email="johndoe@gmail.com",PhoneNumber= "+51976268172" }
                );
        }

    }
}
