using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace zaj9.Models
{
    [Table("Lab")]
    public class Lab : IEntityTypeConfiguration<Lab>
    {
        [Key]
        [Column("ID")]
        public int IDLAB { get; set; }

        [RegularExpression(@"^[A-Z][a-z]+\d+$", ErrorMessage = "Zły format nazwy")]
        public string NazwaLab { get; set; }

        public int iloscPracownikow { get; set; }

        public List<Probki> Probki { get; set; }

        public void Configure(EntityTypeBuilder<Lab> builder)
        {
            builder
                .Property(g => g.NazwaLab)
                .HasColumnName("NAZWALAB")
                .IsRequired()
                .HasMaxLength(20);

            builder
                .HasData(
                new Lab { IDLAB = 1, NazwaLab = "ZTM", iloscPracownikow = 6 },
                new Lab { IDLAB = 2, NazwaLab = "GRC", iloscPracownikow = 15 },
                new Lab { IDLAB = 3, NazwaLab = "MTU", iloscPracownikow = 7 }
                );

        }
    }
}
