using Microsoft.EntityFrameworkCore;
using BroadwayReview.Domain.Entities;
using System;

namespace BroadwayReview.DataAccess
{
    public class BroadwayReviewContext : DbContext
    {
        public BroadwayReviewContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            modelBuilder.Entity<UserUseCase>().HasKey(x => new { x.UserId, x.UseCaseId });
            modelBuilder.Entity<PlayGenre>().HasKey(x => new { x.PlayId, x.GenreId });

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Nikolina\SQLEXPRESS
            optionsBuilder.UseSqlServer(@"Data Source=Nikolina\SQLEXPRESS;Initial Catalog=BroadwayReview;Integrated Security=True");
        }
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.CreatedAt = DateTime.UtcNow;
                            e.IsActive = true;
                            break;
                        case EntityState.Modified:
                            e.UpdatedAt = DateTime.UtcNow;
                            e.UpdatedBy = "";
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<ActorPlay> ActorPlays { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Play> Plays { get; set; }
        public DbSet<PlayGenre> PlayGenres { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<UseCaseLogger> UseCaseLogs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserUseCase> UserUseCases { get; set; }
    }
}
