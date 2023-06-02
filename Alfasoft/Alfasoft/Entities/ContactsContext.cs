using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Alfasoft.EntityModels;

public partial class ContactsContext : DbContext
{
    public ContactsContext()
    {
    }

    public ContactsContext(DbContextOptions<ContactsContext> options)
        : base(options)
    {
    }
    public virtual DbSet<ContactsEntity> Contacts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;database=db;uid=rafaela;pwd=123456", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.6.13-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactsEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<ContactsEntity>().Property(x => x.Id).UseMySqlIdentityColumn();
        modelBuilder.Entity<ContactsEntity>().Property(x => x.Name).IsRequired();
        modelBuilder.Entity<ContactsEntity>().Property(x => x.Contact).HasPrecision(9);
        modelBuilder.Entity<ContactsEntity>().Property(x => x.Email);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
