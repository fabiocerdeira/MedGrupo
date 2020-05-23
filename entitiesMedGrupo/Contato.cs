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


        /*
         * Método que compara dois objetos.
         */
        public override bool Equals(Object obj)
        {
            // valor retornado pela função.
            bool retorno = true;

            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                // objetos diferentes.
                retorno = false;
            }
            else
            {
                Contato objContato = (Contato)obj;
                if (objContato.IdContato != this.IdContato) retorno = false;
                if (objContato.Nome != this.Nome) retorno = false;
                if (objContato.DataNascimento != this.DataNascimento) retorno = false;
                if (objContato.Sexo != this.Sexo) retorno = false;
                if (objContato.Idade != this.Idade) retorno = false;
            }

            // valor retornado pela função.
            return retorno;

        }

    }
}



