using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace EFC;

public class DataContext : DbContext
{
    
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = ../EFC/Reddit.db");
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(user => user.Username);
        modelBuilder.Entity<Post>().HasKey(post => post.Id);
    }
    
}