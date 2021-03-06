﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using businessMedGrupo;
using entitiesMedGrupo;



namespace apiMedGrupo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatosController : ControllerBase
    {

        // GET api/values
        [HttpGet]
        public ActionResult<IActionResult> Get()
        {
            Envelope envelope = new Envelope();
            try
            {
                // retornar a lista de contatos
                BusContato bContato = new BusContato();

                // retorno da API
                envelope.Colecao = bContato.Listar().ToList<object>();
            }
            catch (Exception e)
            {
                envelope.AddExcecao("Erro ao CARREGAR contato.", e);
            }
            return Ok(envelope);
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Envelope> Get(int id)
        {
            Envelope envelope = new Envelope();
            try
            {
                // carregar e retornar um contato
                BusContato bContato = new BusContato();

                // retorno da API
                envelope.Colecao.Add( bContato.Carregar(id));
            }
            catch (Exception e)
            {
                envelope.AddExcecao("Erro ao CARREGAR contato", e);
            }
            return Ok(envelope);
        }


        // POST api/values
        [HttpPost]
        public ActionResult<IActionResult> Post([FromBody] Contato value)
        {
            Envelope envelope = new Envelope();
            try
            {
                // criar ou editar (salvar)
                BusContato bContato = new BusContato();
                bContato.Salvar(value);

                // retorno da API
                envelope.Infos.Add("Sucesso ao GRAVAR contato");

                // retorno o mesmo objeto para cliente poder ter campos atualizados (pk e idade);
                envelope.Colecao.Add(value);
            }
            catch (Exception e)
            {
                envelope.AddExcecao("Erro ao GRAVAR contato", e);
            }
            return Ok(envelope);
        }

        /*
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        */

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<IActionResult> Delete(int id)
        {
            Envelope envelope = new Envelope();
            try
            {
                // apagar
                BusContato bContato = new BusContato();
                bContato.Apagar(id);

                // retorno da API
                envelope.Infos.Add("Sucesso ao APAGAR contato");
            }
            catch (Exception e)
            {
                envelope.AddExcecao("Erro ao APAGAR contato", e);
            }
            return Ok(envelope);
        }
    }
}
