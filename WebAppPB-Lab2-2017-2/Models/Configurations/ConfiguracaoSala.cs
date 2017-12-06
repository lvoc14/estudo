using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace WebAppPB_Lab2_2017_2.Models.Configurations
{
    public class ConfiguracaoSala : EntityTypeConfiguration<Sala>
    {
        public ConfiguracaoSala()
        {
            //Configura a propriedade 
           Property(s => s.Descricao)
                .HasColumnType("varchar")
                .IsRequired()//É obrigatório
                .HasMaxLength(500);//Tamanho máximo de 500 caracteres

            //Configura associação one-to-one (um-para-um)
           HasOptional(l => l.Localizacao)
                .WithRequired(s => s.Sala)
                .WillCascadeOnDelete(true);

            //Configura associação one-to-many (um-para-muitos)
            HasMany(se => se.Sessoes)
                .WithRequired(s => s.Sala)//Associação obrigatória(forte)
                .HasForeignKey(s => s.SalaId)
                .WillCascadeOnDelete(false);
        }
    }
}