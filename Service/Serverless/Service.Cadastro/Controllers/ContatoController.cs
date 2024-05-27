using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Cadastro.Interfaces;
using Application.Cadastro.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Service.Cadastro.Controllers;

[ApiController]
[Route("Cadastro")]
public class ContatoController : ControllerBase
{
    private readonly IContatoAppService _contatoAppService;
    
    public ContatoController(IContatoAppService contatoAppService)
    {
        _contatoAppService = contatoAppService;
    }
    
    /// <summary>
    ///     Endpoint para obtenção da lista de contatos por filtros
    /// </summary>
    /// <param name="filtros">Filtros para listagem</param>
    /// <returns>Lista de Contatos filtrados</returns>
    [HttpGet]
    [Route("PorFiltros")]
    [ProducesResponseType(typeof(Ok<IEnumerable<ContatoViewModel>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Ok), StatusCodes.Status200OK)]
    public IActionResult Get([FromQuery] ContatoFiltroViewModel filtros)
    {
        var contatos = _contatoAppService.ObterListaContatos(filtros);

        return contatos?.Any() == true ? Ok(contatos) : Ok();
    }
    
    /// <summary>
    ///     Endpoint para obtenção do contato por meio do identificador
    /// </summary>
    /// <param name="contatoId">Identificador do Contato</param>
    /// <returns>Contato Obtido</returns>
    [HttpGet]
    [Route("PorId/{contatoId:guid}")]
    [ProducesResponseType(typeof(Ok<ContatoViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
    public IActionResult GetPorId([FromRoute] Guid contatoId)
    {
        var contato = _contatoAppService.ObterContatoPorId(contatoId);

        return contato != null ? Ok(contato) : BadRequest("Falha ao Obter Contato");
    }
    
    /// <summary>
    ///     Endpoint para cadastro de um contato
    /// </summary>
    /// <param name="contatoViewModel">Dados do contato</param>
    /// <returns>Identificador do Contato cadastrado</returns>
    [HttpPost]
    [Route("Cadastrar")]
    [ProducesResponseType(typeof(Ok<Guid>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] CadastrarContatoViewModel contatoViewModel)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState.Values);
        
        var contatoId = await _contatoAppService.CadastarContato(contatoViewModel);

        return contatoId != Guid.Empty ? Ok(contatoId) : BadRequest("Falha ao Cadastrar Contato");
    }
    
    /// <summary>
    ///     Endpoint para atualização de um contato
    /// </summary>
    /// <param name="contatoViewModel">Dados do Contato</param>
    /// <returns>Boleano indicando sucesso da operação</returns>
    [HttpPut]
    [Route("Atualizar")]
    [ProducesResponseType(typeof(Ok<bool>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put([FromBody] AtualizarContatoViewModel contatoViewModel)
    {
        if (!ModelState.IsValid) return BadRequest();

        var contatoAtualizado = await _contatoAppService.AtualizarContato(contatoViewModel);

        return contatoAtualizado ? Ok(true) : BadRequest("Falha ao Cadastrar Contato");
    }
    
    /// <summary>
    ///     Endpoint para remoção de um contato por meio do identificador
    /// </summary>
    /// <param name="contatoId">Identificador do Contato</param>
    /// <returns>Boleano indicando sucesso da operação</returns>
    [HttpDelete]
    [Route("Remover/{contatoId:guid}")]
    [ProducesResponseType(typeof(Ok<bool>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete([FromRoute] Guid contatoId)
    {
        var contatoRemovido = await _contatoAppService.RemoverContato(contatoId);

        return contatoRemovido ? Ok(true) : BadRequest("Falha ao Cadastrar Contato");
    }
    
    /// <summary>
    ///     Endpoint para obtenção da lista de codigo de discagem por filtros
    /// </summary>
    /// <param name="filtros">Filtros para listagem</param>
    /// <returns>Lista de Codigos de Discagem filtrados</returns>
    [HttpGet]
    [Route("CodigoDiscagem/PorFiltros")]
    [ProducesResponseType(typeof(Ok<IEnumerable<CodigoDiscagemViewModel>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Ok), StatusCodes.Status200OK)]
    public IActionResult GetCodigoDiscagem([FromQuery] CodigoDiscagemFiltroViewModel filtros)
    {
        var listaCodigoDiscagem = _contatoAppService.ObterListaCodigoDiscagem(filtros);

        return listaCodigoDiscagem?.Any() == true ? Ok(listaCodigoDiscagem) : Ok();
    }
}
