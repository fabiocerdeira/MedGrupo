using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiMedGrupo
{
    public class Envelope
    {
        public int Id { get; set; } = 0;
        public string Resultado { get; set; } = "";
        public string MensagemErro { get; set; } = "";
        public object Objeto { get; set; }
        public List<object> Colecao { get; set; }
    }
}
