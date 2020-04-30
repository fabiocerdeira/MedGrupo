using System;
using System.ComponentModel.DataAnnotations;

namespace entitiesMedGrupo
{
    public class Contato
    {
        [Key]
        public int IdContato { get; set; } = 0;

        public string Nome { get; set; } = "";

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; } = DateTime.UtcNow;

        public string Sexo { get; set; } = "";

        public int Idade {
            get {
                // valor retornado pela função
                int _idade = 0;

                _idade = DateTime.Now.Year - this.DataNascimento.Year;

                if (DateTime.Now.Month < DataNascimento.Month || (DateTime.Now.Month == DataNascimento.Month && DateTime.Now.Day < DataNascimento.Day))
                {
                    _idade--;
                }

                // valor retornado pela função
                return _idade;
            }
        }

    }
}



