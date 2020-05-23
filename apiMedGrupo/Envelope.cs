using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using entitiesMedGrupo;


namespace apiMedGrupo
{

    /*
     * A classe Envelope é uma maneira dos métodos da API retornarem mais de uma informação em cada 
     * url chamada. Por exemplo: Se chamar a API para gravar eu retorno ao mesmo tempo a(s) vária(s)
     * mensagem(ns) de erro ou sucesso e o objeto que foi gravado só que com o campo PK atualizado
     */
    public class Envelope
    {
        /*
         * Mensagens de retorno, que devem ser exibidas na camada de apresentação.
         * Usado para mensagens de sucesso ao realizar uma operação
         * ou erro ao realizar uma operação
         * ou validações de regras de negócio.
         * Não é usado para erros internos do sistema.
         */
        public List<string> Infos { get; set; } = new List<string>();


        /*
         * Informa se temos ou não Infos?
         * Criado somente para facilitar a vida da camada de apresenação.
         * Mesmo sendo redundante com a propriedade Infos, preferi criar assim para facilitar o javascript.
         */
        public bool TemInfos
        {
            get
            { return (this.Infos.Count > 0); }
        }


        /*
         * Retorno de um objeto ou de uma coleção de objetos.
         * Muito usado em listagens 
         * e no retorno de criar um novo registro.
         */
        public List<object> Colecao { get; set; } = new List<object>();



        /*
         * Metodo para converter um exceção em infos.
         * Com esse método consegui reduzir a qtd de linhas do try-catch dos controllers
         */
        public void AddExcecao(string info, Exception e)
        {
            // colocar a info na coleção de infos.
            this.Infos.Add(info);

            // se a exceção for do tipo que eu criei para tratar regras de negócio
            // então copiar as infos da exceção para as infos do envelope.
            if (  e.GetType() == typeof(MyException) )
            {
                // converter o objeto recebido no argumento
                // para o meu objeto de exceção.
                MyException myex = (MyException)e;
                // agora posso acessar o método com a coleção de "Infos".
                this.Infos.AddRange(myex.Infos);
            }
        }

    }
}
