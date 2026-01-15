
using CodeFirstApproach.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstApproach.Database
{
    public class InstagramDatabase : DbContext
    {
        public InstagramDatabase(DbContextOptions<InstagramDatabase> options) : base(options)
        {
        }

        // DbSet representerar tabeller i databasen
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        // OnModelCreating används för att konfigurera modellens schema
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(x => x.Caption)
                        .HasMaxLength(2200); // Instagram caption max antalet tecken

                // Relationer: User (Author) -> Flera Posts
                entity.HasOne(e => e.Author)
                      .WithMany(u => u.Posts)
                      .HasForeignKey(e => e.AuthorId)
                      .OnDelete(DeleteBehavior.Restrict); // Förhindra kaskad radering
            });
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(x => x.Text)
                        .HasMaxLength(1000) // Instagram kommentar max antalet tecken
                        .IsRequired();

                // Relationer: Post -> Flera Comments
                entity.HasOne(e => e.Post)
                      .WithMany(p => p.Comments)
                      .HasForeignKey(e => e.PostId)
                      .OnDelete(DeleteBehavior.Cascade); // Radera kommentarer när inlägget raderas

                // Relationer: User (Author) -> Flera Comments
                entity.HasOne(e => e.Author)
                      .WithMany(u => u.Comments)
                      .HasForeignKey(e => e.AuthorId)
                      .OnDelete(DeleteBehavior.Restrict); // Förhindra kaskad radering
            });
        }
    }
}
