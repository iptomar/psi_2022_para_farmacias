using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PROJETO_PSI_2122_21296.Data {

    /// <summary>
    /// Classe com os dados do utilizador registado.
    /// </summary>
    public class ApplicationUser : IdentityUser {

        /// <summary>
        /// Nome de batismo do utilizador.
        /// </summary>
        public string NomeDoUtilizador { get; set; }

        /// <summary>
        /// Data em que o utilizador se registou.
        /// </summary>
        public DateTime DataRegisto { get; set; }

    }
    
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }

        /// <summary>
        /// Método que é executado imediatamente antes da criação do Modelo.
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            // Cria um cargo administrador na aplicação.---------------------------------------- //
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "a", Name = "Administrador", NormalizedName = "ADMINISTRADOR" }
                );
            // --------------------------------------------------------------------------------- //

            //// Adicionar um utilizador quando a base de dados é criada para ser o Administrador. //
            //var hasher = new PasswordHasher<IdentityUser>();

            //builder.Entity<IdentityUser>().HasData(
            //    new IdentityUser {
            //        Id = "adminuser0",
            //        UserName = "admin",
            //        NormalizedUserName = "admin",
            //        Email = "admin@gmail.com",
            //        NormalizedEmail = "admin@gmail.com",
            //        EmailConfirmed = true,
            //        PasswordHash = hasher.HashPassword(null, "Admin123#"),
            //        SecurityStamp = string.Empty
            //    });
            //// --------------------------------------------------------------------------------- //

            //// Adiciona o cargo Administrador ao utilizador criado.----------------------------- //
            //builder.Entity<IdentityUserRole<string>>().HasData(
            //    new IdentityUserRole<string> { UserId = "adminuser0", RoleId = "a" }
            //    );
            //// --------------------------------------------------------------------------------- //

        }

        // Definir as tabelas da base de dados.
        public DbSet<Models.Medicamento> Medicamentos { get; set; }

    }
}