namespace WebAppPB_Lab2_2017_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ator",
                c => new
                    {
                        AtorId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.AtorId);
            
            CreateTable(
                "dbo.Filme",
                c => new
                    {
                        FilmeId = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Duracao = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.FilmeId);
            
            CreateTable(
                "dbo.Sessao",
                c => new
                    {
                        SessaoId = c.Int(nullable: false, identity: true),
                        DataHoraInicio = c.DateTime(nullable: false),
                        DataHoraFim = c.DateTime(nullable: false),
                        ValorInteira = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValorMeia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Encerrada = c.Boolean(nullable: false),
                        SalaId = c.Int(nullable: false),
                        IngressoId = c.Int(nullable: false),
                        FilmeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SessaoId)
                .ForeignKey("dbo.Filme", t => t.FilmeId)
                .ForeignKey("dbo.Ingresso", t => t.IngressoId)
                .ForeignKey("dbo.Sala", t => t.SalaId)
                .Index(t => t.SalaId)
                .Index(t => t.IngressoId)
                .Index(t => t.FilmeId);
            
            CreateTable(
                "dbo.Ingresso",
                c => new
                    {
                        IngressoId = c.Int(nullable: false, identity: true),
                        Tipo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IngressoId);
            
            CreateTable(
                "dbo.Sala",
                c => new
                    {
                        SalaId = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        Capacidade = c.Int(nullable: false),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.SalaId);
            
            CreateTable(
                "dbo.FilmeAtor",
                c => new
                    {
                        Filme_FilmeId = c.Int(nullable: false),
                        Ator_AtorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Filme_FilmeId, t.Ator_AtorId })
                .ForeignKey("dbo.Filme", t => t.Filme_FilmeId)
                .ForeignKey("dbo.Ator", t => t.Ator_AtorId)
                .Index(t => t.Filme_FilmeId)
                .Index(t => t.Ator_AtorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sessao", "SalaId", "dbo.Sala");
            DropForeignKey("dbo.Sessao", "IngressoId", "dbo.Ingresso");
            DropForeignKey("dbo.Sessao", "FilmeId", "dbo.Filme");
            DropForeignKey("dbo.FilmeAtor", "Ator_AtorId", "dbo.Ator");
            DropForeignKey("dbo.FilmeAtor", "Filme_FilmeId", "dbo.Filme");
            DropIndex("dbo.FilmeAtor", new[] { "Ator_AtorId" });
            DropIndex("dbo.FilmeAtor", new[] { "Filme_FilmeId" });
            DropIndex("dbo.Sessao", new[] { "FilmeId" });
            DropIndex("dbo.Sessao", new[] { "IngressoId" });
            DropIndex("dbo.Sessao", new[] { "SalaId" });
            DropTable("dbo.FilmeAtor");
            DropTable("dbo.Sala");
            DropTable("dbo.Ingresso");
            DropTable("dbo.Sessao");
            DropTable("dbo.Filme");
            DropTable("dbo.Ator");
        }
    }
}
