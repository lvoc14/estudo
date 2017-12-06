using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace WebAppPB_Lab2_2017_2.Models.Configurations
{
    public class ConfiguracaoSessao : EntityTypeConfiguration<Sessao>
    {
        public ConfiguracaoSessao()
        {
            //Configura propriedade para o tipo datetime2
            Property(s => s.DataHoraInicio)
                .HasColumnType("datetime2");

            //Configura propriedade para o tipo datetime2
            Property(s => s.DataHoraFim)
                .HasColumnType("datetime2");
        }
    }
}