using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppPB_Lab2_2017_2.Models
{
    public class Ingresso
    {
        public int IngressoId { get; set; }
        public TipoIngresso Tipo { get; set; }
        public List<Sessao> Sessoes { get; set; }
    }
}