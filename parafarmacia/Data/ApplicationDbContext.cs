using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using parafarmacia.Models;

namespace parafarmacia.Data
{

    /// <summary>
    /// classe que extende da identity user acrescentado dados, criado a quando da Identity
    /// </summary>
    public class ApplicationUser : IdentityUser
    {

        /// <summary>
        /// nome do utilizador a registar
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// data de criação do utilizador a registar
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// data de criação do utilizador a registar
        /// </summary>
        public int User { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProductCategories> ProductCategories { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Carts> Carts { get; set; }
        public DbSet<Users> User { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Users>()
                 .HasIndex(u => u.Email)
                 .IsUnique();
            builder.Entity<Products>()
                .HasIndex(p => p.Name)
                .IsUnique();
            builder.Entity<ProductCategories>()
                .HasIndex(c => c.Name)
                .IsUnique();

            builder.Entity<OrderProduct>().HasOne(op => op.Product).WithMany(p => p.OrderProductList);
            builder.Entity<OrderProduct>().HasOne(op => op.Order).WithMany(o => o.OrderProductList);

            builder.Entity<ProductCart>().HasOne(pc => pc.Product).WithMany(p => p.ProductCartList);
            builder.Entity<ProductCart>().HasOne(pc => pc.Cart).WithMany(c => c.ProductCartList);

            builder.Entity<Carts>().HasOne(u => u.User).WithMany(u => u.CartsList);

            builder.Entity<Products>().HasOne(p => p.Category).WithMany(c => c.CategoryList);

            //cria o utilizador admin para gerir os dados da aplicação web
            builder.Entity<Users>().HasData(new
            Users
            {
                Id = 1,
                Name = "Admin",
                Email = "admin@admin",
                Role = "Admin"
            });

            //adiciona o role de admin e user
            builder.Entity<IdentityRole>()
                .HasData(new IdentityRole
                {
                    Id = "1",
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "User",
                    NormalizedName = "User".ToUpper()
                });

            //cria o Application user: admin
            builder.Entity<ApplicationUser>()
                .HasData(new ApplicationUser
                {
                    Id = "1",
                    User = 1,
                    Nome = "Admin",
                    UserName = "admin@admin",
                    Email = "admin@admin",
                    NormalizedUserName = "admin@admin".ToUpper(),
                    NormalizedEmail = "admin@admin".ToUpper(),
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "admin"),
                    SecurityStamp = string.Empty,
                    Timestamp = DateTime.Now
                });

            //associa o role: Admin ao ApplicationUser: Admin
            builder.Entity<IdentityUserRole<string>>(b =>
            {
                builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
                {
                    RoleId = "1",
                    UserId = "1"
                });

                // Primary key
                b.HasKey(r => new { r.UserId, r.RoleId });

                // Maps to the AspNetUserRoles table
                b.ToTable("AspNetUserRoles");
            });
        }


        public DbSet<parafarmacia.Models.OrderProduct> OrderProduct { get; set; }


        public DbSet<parafarmacia.Models.ProductCart> ProductCart { get; set; }
    }
}
