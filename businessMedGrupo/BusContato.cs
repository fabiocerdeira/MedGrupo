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
            // antes de salvar verificar se já temos outro contato com o mesmo nome.
            if (!this.ExisteContatoMesmoNome( oContato.IdContato, oContato.Nome ))
            {
                _crudContato.Salvar(oContato);
            }
        }


        /*
         * antes de salvar verificar se já temos outro contato com o mesmo nome.
         */
        private bool ExisteContatoMesmoNome(int idContato, string nome)
        {
            // valor retornado pela função
            bool retorno = false;

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
                throw new Exception("Impossível salvar dois contatos com o mesmo nome.");
            }

            // valor retornado pela função
            return retorno;
        }



    }
}

