using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppPB_Lab2_2017_2.Models
{
    public class Localizacao
    {
        public int LocalizacaoId { get; set; }
        public string Descricao { get; set; }
        public string PontoReferencia { get; set; }
        public Sala Sala { get; set; }
    }

}