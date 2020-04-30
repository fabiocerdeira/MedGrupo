using System.Collections.Generic;
using System.Linq;
using entitiesMedGrupo;

namespace crudMedGrupo
{
    public class CrudContato : CrudBase
    {

        public List<Contato> Listar()
        {
            return Database.Contatos
                .OrderBy(c => c.IdContato)
                .ToList<Contato>();
        }

        public Contato Carregar(int id)
        {
            return Database.Contatos
                .Where(c => c.IdContato == id)
                .FirstOrDefault();
        }

        public Contato CarregarPorIdNome(int id, string nome)
        {
            return Database.Contatos
                .Where(c => (c.Nome == nome && c.IdContato != id))
                .FirstOrDefault();
        }

        public void Apagar(int id)
        {
            Contato oContato = new Contato { IdContato = id };
            Database.Contatos.Remove(oContato);
            Database.SaveChanges();
            oContato = null;
        }

        public void Salvar(Contato oContato)
        {
            if (oContato.IdContato == 0)
            {
                Database.Contatos.Add(oContato);
            }
            else
            {
                Database.Contatos.Update(oContato);
            }
            Database.SaveChanges();
        }


    }
}