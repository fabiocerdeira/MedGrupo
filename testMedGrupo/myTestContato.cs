using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using entitiesMedGrupo;
using businessMedGrupo;


namespace testMedGrupo
{
    [TestClass]
    public class MyTestContato
    {


        [TestMethod]
        public void CarregarUm()
        {

            Contato oContatoMOQ = new Contato
            {
                IdContato = 1,
                Nome = "Fabio Mahfoud Cerdeira",
                Sexo = "M",
                DataNascimento = new System.DateTime(1977, 4, 13)
            };


            BusContato bContato = new BusContato();
            Contato oContato = bContato.Carregar(1);

            // como o AreEqual não compara objetos fiz a comparação por propriedades.
            // se eu tivesse mais tempo faria um metodo usando a interface IComparable 
            // Assert.AreEqual(oContatoMOQ, oContato);

            Assert.AreEqual(oContatoMOQ.IdContato, oContato.IdContato);
            Assert.AreEqual(oContatoMOQ.Nome, oContato.Nome);
            Assert.AreEqual(oContatoMOQ.Sexo, oContato.Sexo);
            Assert.AreEqual(oContatoMOQ.Idade, oContato.Idade);

        }


        [TestMethod]
        public void CriarUm()
        {
            Contato oContatoMOQ = new Contato
            {
                Nome = "Teste Criar Um " + DateTime.Now.Ticks.ToString(),
                Sexo = "M",
                DataNascimento = DateTime.Now
            };

            BusContato bContato = new BusContato();
            bContato.Salvar(oContatoMOQ);

            // recuperar o id do novo registro no banco.
            int novoId = oContatoMOQ.IdContato;

            // carregar do banco o registro recem criado.
            Contato oContato = bContato.Carregar(novoId);

            // comparar.
            Assert.AreEqual(oContatoMOQ.IdContato, oContato.IdContato);
            Assert.AreEqual(oContatoMOQ.Nome, oContato.Nome);
            Assert.AreEqual(oContatoMOQ.Sexo, oContato.Sexo);
            Assert.AreEqual(oContatoMOQ.Idade, oContato.Idade);
        }


        [TestMethod]
        public void CriarUmApagarOmesmo()
        {

            Contato oContatoMOQ = new Contato
            {
                Nome = "Teste Criar Apagar " + DateTime.Now.Ticks.ToString(),
                Sexo = "X",
                DataNascimento = DateTime.Now
            };

            BusContato bContato = new BusContato();
            bContato.Salvar(oContatoMOQ);

            // recuperar o id do novo registro no banco.
            int novoId = oContatoMOQ.IdContato;

            // apagar
            bContato = new BusContato();
            bContato.Apagar(novoId);

            /*
             * usando TRY CATCH para falhar ou passar no teste:
             */

            try
            {
                // tentar carregar
                Contato contato = bContato.Carregar(novoId);
                if (contato != null)
                {
                    Assert.Fail("Objeto não foi apagado");
                }
            }
            catch (InvalidOperationException)
            {
                Assert.IsTrue(true);
            }
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SalvarComMesmoNome()
        {
            // novo contato com o mesmo nome que já existe antes.
            Contato oContatoMOQ = new Contato
            {
                // Nome = "Fabio Mahfoud Cerdeira " + DateTime.Now.Ticks.ToString(), // nesse nome NÃO da FALHA no teste.
                Nome = "Fabio Mahfoud Cerdeira dsdsd sdsdsdsds ",
                Sexo = "M",
                DataNascimento = new System.DateTime(1977, 4, 13)
            };

            /*
             * usando ExpectedException para falhar ou passar no teste:
             */

            // tentar carregar
            BusContato bContato = new BusContato();
            bContato.Salvar(oContatoMOQ);
        }




    }

}
