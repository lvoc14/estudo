using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppPB_Lab2_2017_2.Models
{
    public class Sessao
    {
        public int SessaoId { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }
        public decimal ValorInteira { get; set; }
        public decimal ValorMeia { get; set; }
        public bool Encerrada { get; set; }
        //Chave estrangeira (FK) da Classe Sala
        public int SalaId { get; set; }
        //Propiedade de Navegação
        public virtual Sala Sala { get; set; }
        //Chave estrangeira
        public int? IngressoId { get; set; }
        //Propriedade de navegação
        public virtual Ingresso Ingresso { get; set; }
        //Chave estrangeira
        public int FilmeId { get; set; }
        //Propriedade de navegação
        public virtual Filme Filme { get; set; }
    }
}