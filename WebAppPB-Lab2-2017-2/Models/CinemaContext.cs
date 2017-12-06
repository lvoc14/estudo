using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WebAppPB_Lab2_2017_2.Models.Configurations;

namespace WebAppPB_Lab2_2017_2.Models
{
    public class CinemaContext : DbContext
    {
   
        public CinemaContext() : base("name=CinemaContext")
        {
            //Desabilitando o Lazy Loading para todas as entidades
            //Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Sala> Salas { get; set; }

        public DbSet<Sessao> Sessaos { get; set; }

        public DbSet<Filme> Filmes { get; set; }

        public DbSet<Ingresso> Ingressoes { get; set; }

        public DbSet<Ator> Ators { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Remove convenções de pluralização
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //Remove conveções de deleção em cascata
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new ConfiguracaoSala());
            modelBuilder.Configurations.Add(new ConfiguracaoSessao());
            modelBuilder.Configurations.Add(new ConfiguracaoIngresso());
            modelBuilder.Configurations.Add(new ConfiguracaoFilme());

            //Adicionando configurações globais do Fluent API
            modelBuilder.Properties<string>()
            .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(200));

            modelBuilder.Properties<DateTime>()
                .Configure(p=> p.HasColumnType("datetime2"));

            //Mapeia todas as classes para o tipo stored procedures
            modelBuilder.Types()
                .Configure(t => t.MapToStoredProcedures());
        }
    }
}
