using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zaj9.Models
{
    public class ProbkiDb:DbContext
    {
        public DbSet<Probki> Probka { get; set; }
        public DbSet<Lab> Labs { get; set; }

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddDebug(); });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;
                                          Initial Catalog=ProbkiDb;Integrated Security=True;
                                          Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;
                                          ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
                            .UseLoggerFactory(MyLoggerFactory); //polecenie rejestrowania pracy EF Core

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Lab>()
                .Property(g => g.NazwaLab)
                .HasColumnName("NazwaLab");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProbkiDb).Assembly);
        }
        public DbSet<zaj9.Models.Lab> Lab { get; set; }
    }
}
