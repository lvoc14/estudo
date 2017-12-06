using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppPB_Lab2_2017_2.Models
{
    public class Sala
    {
        public int SalaId { get; set; }
        public int Numero { get; set; }
        public int Capacidade { get; set; }
        public string Descricao { get; set; }
        public List<Sessao> Sessoes { get; set; }
        public Localizacao Localizacao { get; set; }
    }
}