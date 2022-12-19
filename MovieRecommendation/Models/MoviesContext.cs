using Microsoft.EntityFrameworkCore;

namespace MovieRecommendation.Models
{
    public partial class MoviesContext : DbContext
    {
        public MoviesContext()
        {

        }
        public MoviesContext(DbContextOptions option ) : base(option)
        {

        }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server= DESKTOP-3S3KF7F;Database=MovieRecomendDB;Integrated Security=True; Encrypt=false;");
            }
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("tblMovie");

            });
            modelBuilder.Entity<Genre>(
                entity =>
                {
                    entity.ToTable("tblGener");
                    entity.HasMany(d => d.Movies)
                    .WithOne(g => g.Genre)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK_Genere_Movie");
                    

                }


                );
            onModelCreatingPartial(modelBuilder);
        }
        partial void onModelCreatingPartial(ModelBuilder model);


    }
}
 