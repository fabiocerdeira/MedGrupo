using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using entitiesMedGrupo;
using businessMedGrupo;
using apiMedGrupo.Controllers;

using System.Web.Http.Results;
using Microsoft.AspNetCore.Mvc;


namespace testMedGrupo
{
    [TestClass]
    public class MyTestContato
    {


        /*
         * Carregar um contato da API
         */
        [TestMethod]
        public void CarregarUmContatoDoController_Sucesso()
        {
            Contato oContatoMOQ = new Contato
            {
                IdContato = 1,
                Nome = "Fabio Mahfoud Cerdeira",
                Sexo = "M",
                DataNascimento = new System.DateTime(1977, 4, 13)
            };

            // declarar o controller da api.
            var controlador = new ContatosController();

            // recuperar o contato de id=1.
            var resultado = controlador.Get(1) as ActionResult<apiMedGrupo.Envelope>;

            // verificar se temos resultado carregado?
            Assert.IsNotNull(resultado);

            // recuperar o envelope.
            apiMedGrupo.Envelope envelope = (apiMedGrupo.Envelope)((Microsoft.AspNetCore.Mvc.ObjectResult)resultado.Result).Value;

            // recuperar o primeiro contato da coleção.
            Contato oContato = (Contato)envelope.Colecao[0];

            // comparação do objeto com o outro objeto, em todas as suas propriedades.
            Assert.AreEqual(oContatoMOQ, oContato);

            // comparação de um determinado campo apenas.
            // Assert.AreEqual(oContatoMOQ.Nome, oContato.Nome);

        }


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
                DataNascimento = DateTime.Now.AddYears(-6)
            };

            try
            {
                BusContato bContato = new BusContato();
                bContato.Salvar(oContatoMOQ);

                // recuperar o id do novo registro no banco.
                int novoId = oContatoMOQ.IdContato;

                // carregar do banco o registro recem criado.
                Contato oContato = bContato.Carregar(novoId);

                // comparação do objeto com o outro objeto, em todas as suas propriedades.
                Assert.AreEqual(oContatoMOQ, oContato);

                /*
                 * // comparar por propriedade.
                Assert.AreEqual(oContatoMOQ.IdContato, oContato.IdContato);
                Assert.AreEqual(oContatoMOQ.Nome, oContato.Nome);
                Assert.AreEqual(oContatoMOQ.Sexo, oContato.Sexo);
                Assert.AreEqual(oContatoMOQ.Idade, oContato.Idade);
                */
            }
            catch (MyException e)
            {
                Assert.Fail(e.Infos[0]);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }


        [TestMethod]
        public void CriarUmApagarOmesmo()
        {

            Contato oContatoMOQ = new Contato
            {
                Nome = "Teste Criar Apagar " + DateTime.Now.Ticks.ToString(),
                Sexo = "X",
                DataNascimento = DateTime.Now.AddYears(-6)
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
        [ExpectedException(typeof(MyException))]
        public void SalvarComMesmoNome()
        {
            // novo contato com o mesmo nome que já existe antes.
            Contato oContatoMOQ = new Contato
            {
                // Nome = "Fabio Mahfoud Cerdeira " + DateTime.Now.Ticks.ToString(), // nesse nome NÃO da FALHA no teste.
                Nome = "Fabio Mahfoud Cerdeira",
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



        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void IdadeAbaixoMinima_Excecao()
        {
            // novo contato com o mesmo nome que já existe antes.
            Contato oContatoMOQ = new Contato
            {
                Nome = "Fabio Mahfoud Cerdeira " + DateTime.Now.Ticks.ToString(),
                Sexo = "M",
                DataNascimento = DateTime.Now
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
