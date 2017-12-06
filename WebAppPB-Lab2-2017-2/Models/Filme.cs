using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppPB_Lab2_2017_2.Models
{
    public class Filme
    {
        public int FilmeId { get; set; }
        public string Titulo { get; set; }
        public decimal Duracao { get; set; }
        //adicione a propriedadde como virtual para ativar o recurso de Lazy Loading
        //para uma entidade específica
        public virtual ICollection<Sessao> Sessoes { get; set; }
        //remova a proriedade virtual para desativar o Lazy Loading
        //para uma entidade específica
        //public ICollection<Sessao> Sessoes { get; set; }
        public virtual ICollection<Ator> Atores { get; set; }
    }
}