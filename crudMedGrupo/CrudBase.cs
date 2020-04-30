using System;
using System.Collections.Generic;
using System.Text;

namespace crudMedGrupo
{
    public class CrudBase
    {

        protected readonly MedGrupoContext Database;

        public CrudBase()
        {
            Database = new MedGrupoContext();
        }

    }
}



