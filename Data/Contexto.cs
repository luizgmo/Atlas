using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AtlasP.Models;

namespace AtlasP.Data
{
    public class Contexto : IdentityDbContext<User>
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Photo> Photos { get; set; }
        public DbSet<Coach> Coachs { get; set; }
        public DbSet<Modality> Modalities { get; set; }
        public DbSet<Value> Values { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /* FluenteAPI */
            #region Identity Setting
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable(name: "User");
            });
            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable(name: "UserRoles");
            });
            modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable(name: "UserClaims");
            });
            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable(name: "UserLogins");
            });
            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable(name: "UserTokens");
            });
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable(name: "RoleClaims");
            });
            #endregion

            #region Populate Roles 
            var roles = new List<IdentityRole>(){
                new IdentityRole{
                    Id = Guid.NewGuid().ToString(),
                    Name = "Administrador",
                    NormalizedName = "ADMINISTRADOR"
                },
                new IdentityRole{
                    Id = Guid.NewGuid().ToString(),
                    Name = "Moderador",
                    NormalizedName = "MODERADOR"
                },
                new IdentityRole{
                    Id = Guid.NewGuid().ToString(),
                    Name = "Usuario",
                    NormalizedName = "USUARIO"
                }
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);
            #endregion

            #region Populate Users
            var hash = new PasswordHasher<User>();
            byte[] avatarPic = File.ReadAllBytes(
                Directory.GetCurrentDirectory() + @"\wwwroot\img\logo.png");
            var users = new List<User>(){
                new User{
                    Id = Guid.NewGuid().ToString(),
                    Name = "Luiz Gustavo Monico",
                    UserName = "Admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@atlasp.com",
                    NormalizedEmail = "ADMIN@ATLASP.COM",
                    EmailConfirmed = true,
                    PasswordHash = hash.HashPassword(null, "123456"),
                    SecurityStamp = hash.GetHashCode().ToString(),
                    ProfilePicture = avatarPic,
                    BirthDate = DateTime.Parse("05/08/1981")
                }
            };
            modelBuilder.Entity<User>().HasData(users);
            #endregion

            #region Populate User Role
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>{
                    UserId = users[0].Id,
                    RoleId = roles[0].Id
                },
                new IdentityUserRole<string>{
                    UserId = users[0].Id,
                    RoleId = roles[1].Id
                },
                new IdentityUserRole<string>{
                    UserId = users[0].Id,
                    RoleId = roles[2].Id
                }
            );
            #endregion
        }

    }
}