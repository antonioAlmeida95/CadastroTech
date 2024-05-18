using Microsoft.AspNetCore.Mvc;

namespace Service.Cadastro.Controllers;

[ApiController]
[Route("Cadastro")]
public class CadastroController : ControllerBase
{
    private readonly ILogger<CadastroController> _logger;

    public CadastroController(ILogger<CadastroController> logger)
    {
        _logger = logger;
    }
}