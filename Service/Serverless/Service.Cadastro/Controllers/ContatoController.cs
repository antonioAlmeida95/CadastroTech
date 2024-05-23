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
    
    [HttpGet]
    [Route("PorFiltros")]
    [ProducesResponseType(typeof(Ok<IEnumerable<ContatoViewModel>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Ok), StatusCodes.Status200OK)]
    public IActionResult Get([FromQuery] ContatoFiltroViewModel filtros)
    {
        var contatos = _contatoAppService.ObterListaContatos(filtros);

        return contatos?.Any() == true ? Ok(contatos) : Ok();
    }
    
    [HttpGet]
    [Route("PorId/{contatoId:guid}")]
    [ProducesResponseType(typeof(Ok<ContatoViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
    public IActionResult GetPorId([FromRoute] Guid contatoId)
    {
        var contato = _contatoAppService.ObterContatoPorId(contatoId);

        return contato != null ? Ok(contato) : BadRequest("Falha ao Obter Região");
    }
    
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
    
    [HttpDelete]
    [Route("Remover/{contatoId:guid}")]
    [ProducesResponseType(typeof(Ok<bool>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete([FromRoute] Guid contatoId)
    {
        var contatoRemovido = await _contatoAppService.RemoverContato(contatoId);

        return contatoRemovido ? Ok(true) : BadRequest("Falha ao Cadastrar Contato");
    }
    
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
