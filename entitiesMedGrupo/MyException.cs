using System;
using System.Collections.Generic;
using System.Text;

namespace entitiesMedGrupo
{
    public class MyException : Exception
    {
        /*
         * Classe de Exception:
         * 
         * A propriedade "Infos" será usada para acumular as mensagens de retorno das 
         * regras de negocio do sistema (validações, sucessos, falhas e erros)
         * 
         * A propriedade "base.Message" será usada para carregar os erros internos do sistema
         * (sql, calculos, io, etc) como normalmente seria com exceções do sistema. 
         * Acumulando seus "inners".
         */

        public List<string> Infos = new List<string>();

        public MyException()
        {
        }

        public MyException(string message)
            : base(message)
        {
            this.Infos.Add(message);
        }

        public MyException(string message, Exception inner)
            : base(message, inner)
        {
            this.Infos.Add(message);
        }

        /*
         * Adicionar uma informação a lista.
         */
        public void NovaInfo(string info)
        {
            this.Infos.Add(info);
        }

        /* 
         * Retorna se temos ou não infos na coleção.
         * Criado apenas para facilitar a leitura do código fonte das funções que 
         * sempre testavam a qtd de infos (infos.count)
         */
        public bool TemInfos
        {
            get
            { return (this.Infos.Count > 0); }
        }

    }


}
