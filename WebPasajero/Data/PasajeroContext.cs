using WebPasajero.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace WebPasajero.Data
{
    public class PasajeroContext: DbContext
    {
        public PasajeroContext(DbContextOptions<PasajeroContext>options):base(options) { }

        public DbSet<Pasajero> Pasajeros { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pasajero>().HasData(
               new Pasajero
               {
                   PasajeroId = 1,
                   Nombre = "Agustin",
                   Apellido = "Di Nezio",
                   FechaNacimiento = new DateTime(1994,07,08),
                   Ciudad = "Mar del Plata"
               },
               new Pasajero
               {
                   PasajeroId = 2,
                   Nombre = "Matias",
                   Apellido = "Tito",
                   FechaNacimiento = new DateTime(1996, 09, 01),
                   Ciudad = "Mar del Plata"
               });
        }

    }
}

