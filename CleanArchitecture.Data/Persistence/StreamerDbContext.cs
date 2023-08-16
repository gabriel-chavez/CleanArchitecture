using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infraestructure.Persistence
{
    public class StreamerDbContext : DbContext
    {
        public StreamerDbContext(DbContextOptions<StreamerDbContext> options) : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken=default) { 
            foreach(var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch(entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate= DateTime.Now;
                        entry.Entity.CreateBy = "system";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate= DateTime.Now;
                        entry.Entity.LastModifiedBy = "system";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog=Streamer; Integrated Security=True; TrustServerCertificate=True")
        //    optionsBuilder.UseSqlServer("Server=localhost;Initial Catalog=Streamer;Integrated Security=False;User Id=sa;Password=Gabriel123+;TrustServerCertificate=True;")

        //        .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information)
        //        .EnableSensitiveDataLogging();

        //}
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //SearchOption utiliza el Fluen Api cuando no se siga la convención de Entity Framework, por ejemplo cuando no se agregue el nombre de la clave foreanea como StreamerID y en su lugar StreamerSecuencial
        //    modelBuilder.Entity<Streamer>()
        //        .HasMany(m => m.Videos)
        //        .WithOne(m => m.Streamer)
        //        .HasForeignKey(m => m.StreamerId)
        //        .IsRequired()
        //        .OnDelete(DeleteBehavior.Restrict);
        //    //relación muchos a muchos
        //    modelBuilder.Entity<Video>()
        //        .HasMany(p => p.Actores) //tendra muchas instancias de la clase actores
        //        .WithMany(t => t.Videos)
        //        .UsingEntity<VideoActor>(
        //            pt => pt.HasKey(e => new { e.ActorId, e.VideoId })
        //        );
        //}

        public DbSet<Streamer>? Streamers { get; set; }
        public DbSet<Video>? Videos { get; set; }

        public DbSet<Actor>? Actores { get; set; }
    }
}
