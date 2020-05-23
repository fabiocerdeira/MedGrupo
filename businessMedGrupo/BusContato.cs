using System;
using System.Collections.Generic;
using crudMedGrupo;
using entitiesMedGrupo;


namespace businessMedGrupo
{
    public class BusContato
    {


        private CrudContato _crudContato = new CrudContato();


        public List<Contato> Listar()
        {
            return _crudContato.Listar();
        }

        public Contato Carregar(int id)
        {
            return _crudContato.Carregar(id);
        }

        public void Apagar(int id)
        {
            _crudContato.Apagar(id);
        }

        public void Salvar(Contato oContato)
        {
            /*
             * objeto de exceção. 
             * para acumular as várias infos de validação das regras de negócio
             * para se gravar um contato.
             */
            MyException myException = new MyException();

            /*
             Abaixo criei 2 (duas) validações de regras de negócio 
             para demonstrar o uso da minha classe de exceção.
             Preferi NÃO usar IF (validacao) pq meu objetivo era retornar para a API
             uma lista acumulada de falhas em validações, isto é, testo TODAS as regras de 
             negócio e se várias estiverem com erro, retorno uma lista de erros.
             Fiz dessa maneira para DEMONSTRAR essa técnica.
             */

            // validar sé contato tem idade mínima?
            this.TemIdadeMinima(myException, oContato.Idade);

            // validar se já temos outro contato com o mesmo nome?
            this.ExisteContatoMesmoNome(myException, oContato.IdContato, oContato.Nome);

            // verificar se não temos problemas de validação
            if (!myException.TemInfos)
            {
                // não temos problemas de validação, então salvar.
                _crudContato.Salvar(oContato);
            }
            else
            {
                // temos erros de validação, 
                // então retornar o objeto de validação/exceção
                throw myException;
            }

        }


        /*
         * Verificar se contato tem idáde mínima obrigatória para ser gravado.
         */
        private void TemIdadeMinima(MyException myException, int idade)
        {
            // valor retornado pela função
            if (idade<5)
            {
                myException.NovaInfo("Contato precisa ter idade mínima de 5 anos.");
            }
        }


        /*
         * antes de salvar verificar se já temos outro contato com o mesmo nome.
         */
        private void ExisteContatoMesmoNome(MyException myException, int idContato, string nome)
        {
            // novo objet de contato
            Contato contato;

            // tentar carregar algum contato por ID + Nome.
            // tenho que informar o ID para casos de alteração.
            // pq ele esta alterando um registro de um contato do mesmo nome.
            contato = _crudContato.CarregarPorIdNome(idContato, nome);

            // verifiar se achamos algum contato?
            if (contato != null)
            {
                // outro contato com o mesmo nome foi encontrado.
                myException.NovaInfo("Impossível salvar dois contatos com o mesmo nome.");
            }
        }



    }
}

