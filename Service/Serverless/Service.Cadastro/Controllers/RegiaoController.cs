using System;
using System.Collections.Generic;
using System.Linq;
using Application.Cadastro.Interfaces;
using Application.Cadastro.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Service.Cadastro.Controllers;

[ApiController]
[Route("Regiao")]
public class RegiaoController  : ControllerBase
{
    private readonly IRegiaoAppService _regiaoAppService;
    
    public RegiaoController(IRegiaoAppService regiaoAppService)
    {
        _regiaoAppService = regiaoAppService;
    }
    
    [HttpGet]
    [Route("PorFiltro")]
    [ProducesResponseType(typeof(Ok<IEnumerable<RegiaoViewModel>>), StatusCodes.Status200OK)]
    public IActionResult Get([FromQuery] RegiaoFiltroViewModel filtros)
    {
        var regioes = _regiaoAppService.ObterListagemRegiao(filtros);
        return regioes?.Any() == true ? Ok(regioes) : Ok();
    }
    
    [HttpGet]
    [Route("PorId/{regiaoId:guid}")]
    [ProducesResponseType(typeof(Ok<RegiaoViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
    public IActionResult GetPorId([FromRoute] Guid regiaoId)
    {
        var regiao = _regiaoAppService.ObterRegiaoPorId(regiaoId);
        return regiao != null ? Ok(regiao) : BadRequest("Falha ao Obter Região");
    }
}