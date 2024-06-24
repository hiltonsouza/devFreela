using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext : DbContext
    {
        //Consultor
        public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options) : base(options)
        {

            //Projects = new List<Project>
            //{
            //    //Parece que no C#8 não precisa colocar novamente a Lista do projeto
            //    new(1,"Meu projeto ASPNET Core 1", "Minha Descrição de Projeto 1 ", 1, 1, 10000),
            //    new Project(1,"Meu projeto ASPNET Core 2", "Minha Descrição de Projeto 2 ", 1, 1, 20000),
            //    new Project(1,"Meu projeto ASPNET Core 3", "Minha Descrição de Projeto 3 ", 1, 1, 30000),

            //};

            //Users = new List<User> {
            // new("Hilton Paiva", "h_iltonsouza@outlook.com", new DateTime(1997, 12, 3)),
            // new("Emily Santos", "Emili_santos@outlook.com", new DateTime(1997, 12, 3)),
            // new("Benjamin Souza", "BenSouza@outlook.com", new DateTime(1997, 12, 3)),
            //};

            //Skills = new List<Skill> {
            //new(".NET Core"),
            //new("C#"),
            //new("SQL"),
            //};

        }

        // DbSet se refere as tabelas do banco relacional
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<ProjectComment> ProjectComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
