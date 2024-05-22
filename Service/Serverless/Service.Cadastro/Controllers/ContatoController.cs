using Application.Cadastro.Interfaces;
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
}