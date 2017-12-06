using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppPB_Lab2_2017_2.Models
{
    public class Ator
    {
        public int AtorId { get; set; }
        public string Nome { get; set; }
        public List<Filme> Filmes { get; set; }
    }
}