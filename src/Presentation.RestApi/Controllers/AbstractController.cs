namespace DocumentGeneratorApp.Presentation.RestApi.Controllers;

/// <summary>
/// Controller base
/// </summary>
[ApiController]
public class AbstractController : ControllerBase
{
    protected readonly ILogger<AbstractController> _logger;

    public AbstractController(ILogger<AbstractController> logger)
    {
        _logger = logger;
    }
}
