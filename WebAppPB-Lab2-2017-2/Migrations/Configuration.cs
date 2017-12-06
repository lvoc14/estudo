namespace WebAppPB_Lab2_2017_2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebAppPB_Lab2_2017_2.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<CinemaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "WebAppPB_Lab2_2017_2.Models.CinemaContext";
        }

        protected override void Seed(CinemaContext context)
        {
            if (context.Salas.Any()) return;
            try
            {
                PopularDados(context);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                // TODO: fazer log de erro
                ex.ToString();
            }
        }

        private void PopularDados(CinemaContext contexto)
        {
            var salas = new List<Sala>
            {
                new Sala
                {
                    Descricao = "Sala 1",
                    Capacidade = 50,
                    Numero = 20
                },
                new Sala
                {
                    Descricao = "Sala 2",
                    Capacidade = 30,
                    Numero = 40
                }
            };
            contexto.Salas.AddRange(salas);

            var ingressos = new List<Ingresso>
            {
                new Ingresso { Tipo = TipoIngresso.Inteira },
                new Ingresso { Tipo = TipoIngresso.Meia },
            };
            contexto.Ingressoes.AddRange(ingressos);

            var filmes = new List<Filme>
            {
                new Filme { Titulo = "Senhor dos Anéis", Duracao = 1 },
                new Filme { Titulo = "Titanic", Duracao = 2 }
            };
            contexto.Filmes.AddRange(filmes);

            var atores = new List<Ator>
            {
                new Ator
                {
                    Nome = "Angelina Jolie" ,
                    Filmes = new List<Filme>{ filmes[0], filmes[1] }
                    
                },
                new Ator
                {
                    Nome = "Antonio Banderas",
                    Filmes = new List<Filme>{ filmes[0] }
                }
            };
            contexto.Ators.AddRange(atores);

            var sessoes = new List<Sessao>
            {
                new Sessao
                {
                    Sala = salas[1],
                    Ingresso = ingressos[0],
                    Filme = filmes[1],
                    Encerrada = false,
                    ValorInteira = 50,
                    ValorMeia = 25,
                    DataHoraInicio = DateTime.Now,
                    DataHoraFim = DateTime.Now
                },
            };
            contexto.Sessaos.AddRange(sessoes);

        }
    }
}
