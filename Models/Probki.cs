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
    [Table("Probki")]
    public class Probki
    {
        [Key]
        [Column("IdBadania")]
        public int IdBadania { get; set; }

        [Required(ErrorMessage ="Nazwa próbki jest wymagana")]
        [MaxLength(20, ErrorMessage ="Nazwa próbki zbyt długa")]
        [RegularExpression("^[A-Z][a-z]+$",ErrorMessage ="Zły format nazwy próbki")]
        public string Nazwa_Probki { get; set; }
        
        public int Ilosc_Pojemnikow { get; set; }

        public double Waga_Probek { get; set; }

        public bool zbadane { get; set; }

        public decimal Kosztbadania { get; set; }

        [Column("FK_LAB")]
        public int? FkLab { get; set; }

        [ForeignKey(nameof(FkLab))]
        public Lab Lab { get; set; }

        public void Configure(EntityTypeBuilder<Probki> builder)
        {
            builder
                .Property(s => s.Kosztbadania)
                .HasColumnName("Kosztbadania")
                .HasDefaultValue(50M);

            builder
                .HasOne(s => s.Lab)
                .WithMany(g => g.Probki)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
