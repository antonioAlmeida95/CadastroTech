using System;
using System.Linq;
using Application.Cadastro.Interfaces;
using Application.Cadastro.ViewModels;
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
    public IActionResult Get([FromQuery] RegiaoFiltroViewModel filtros)
    {
        var regioes = _regiaoAppService.ObterListagemRegiao(filtros);
        return regioes?.Any() == true ? Ok(regioes) : Ok();
    }
    
    [HttpGet]
    [Route("PorId/{regiaoId:guid}")]
    public IActionResult GetPorId([FromRoute] Guid regiaoId)
    {
        var regiao = _regiaoAppService.ObterRegiaoPorId(regiaoId);
        return regiao != null ? Ok(regiao) : BadRequest("Falha ao Obter Região");
    }
}