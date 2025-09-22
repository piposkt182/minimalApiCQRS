using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class SocialDbContext : DbContext
    {
        public SocialDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de Post
            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Posts"); // 👈 evita que sea "Posts"
                entity.HasKey(e => e.Id);
            });

            // Configuración de User
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User"); // 👈 evita que sea "Users"

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.Dni)
                      .IsRequired();

                entity.Property(e => e.Name)
                      .HasMaxLength(200)
                      .IsUnicode(true);

                entity.Property(e => e.lastName)
                      .HasMaxLength(200)
                      .IsUnicode(true);

                entity.Property(e => e.DateOfBirth)
                      .IsRequired()
                      .HasColumnType("datetime");

                entity.Property(e => e.Email)
                      .HasMaxLength(255)
                      .IsUnicode(true);

                entity.Property(e => e.GenderId)
                      .IsRequired();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasOne(u => u.Address)
                      .WithOne() // 👈 ya no especificamos la navegación inversa
                      .HasForeignKey<Address>(a => a.Id);
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Addresses");
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Id).ValueGeneratedOnAdd(); // 
                entity.HasOne(a => a.User).WithOne(u => u.Address).HasForeignKey<Address>(a => a.UserId);
            });
        }
    }
}
