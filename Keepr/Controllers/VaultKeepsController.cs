namespace Keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class VaultKeepsController : ControllerBase
{
    private readonly VaultKeepsSevice _vaultKeepsService;
    private readonly Auth0Provider _auth;

    public VaultKeepsController(VaultKeepsSevice vaultKeepsService, Auth0Provider auth)
    {
        _vaultKeepsService = vaultKeepsService;
        _auth = auth;
    }
}
