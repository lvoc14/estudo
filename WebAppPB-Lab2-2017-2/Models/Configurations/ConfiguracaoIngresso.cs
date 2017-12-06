using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace WebAppPB_Lab2_2017_2.Models.Configurations
{
    public class ConfiguracaoIngresso : EntityTypeConfiguration<Ingresso>
    {
        public ConfiguracaoIngresso()
        {
            //Configura associação one-to-many (um-para-muitos)
            HasMany(se => se.Sessoes)
                .WithOptional(i => i.Ingresso)//Associação opcional(fraca)
                .HasForeignKey(i => i.IngressoId)
                .WillCascadeOnDelete(false);
        }
    }
}