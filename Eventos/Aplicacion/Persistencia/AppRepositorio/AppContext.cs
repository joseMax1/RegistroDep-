using Microsoft.EntityFrameworkCore;
using Dominio;



namespace Persistencia
{
   public class AppContext:DbContext
   {
    //Atributos
    public DbSet<Municipio> Municipios {get;set;}
    public DbSet<Patrocinador> Patrocinadores {get;set;}
    public DbSet<Colegio> colegios {get;set;}

    public DbSet<Torneo> Torneos {get;set;}

    public DbSet <UnidadDeportiva> UnidadDeportivas {get;set;}
    public DbSet<TorneoEquipo> TorneoEquipos {get;set;}

    public DbSet <Arbitro> Arbitros {get;set;}

     public DbSet<Equipo> Equipos {get;set;}


    public DbSet <Deportista> Deportistas {get;set;}

   // public DbSet <Equipo> Equipos {get;set;}

    public DbSet <Entrenador> Entrenadores {get;set;}

   public DbSet<Login> Logins {get;set;}


   // public DbSet <TorneoEquipo> TorneoEquipos {get;set;}

    public DbSet <Escenario> Escenarios {get;set;}



    // crear la conexion con la base datos
    protected override void OnConfiguring(DbContextOptionsBuilder OptionsBuilder)
    {
        if (!OptionsBuilder.IsConfigured){

            //OptionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=Eventos30");
            OptionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=Eventos30");


        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TorneoEquipo>().HasKey(x=>new {x.TorneoId,x.EquipoId});
            

            //Marcar un campo como unico
            modelBuilder.Entity<Torneo>().HasIndex(t => t.Nombre).IsUnique();
            modelBuilder.Entity<Municipio>().HasIndex(m => m.Nombre).IsUnique();
            modelBuilder.Entity<Equipo>().HasIndex(e => e.Nombre).IsUnique();
            modelBuilder.Entity<Entrenador>().HasIndex(ent => ent.Documento).IsUnique();
            modelBuilder.Entity<Login>().HasIndex(l => l.Usuario).IsUnique();

            //Controlar la eliminacion en cascada
            
        }
   }
}