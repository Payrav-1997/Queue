using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
public class BaseController : ControllerBase
{
    protected Guid GetCurrentUserId()
    {
        if (!(HttpContext.User.Identity is ClaimsIdentity identity))
        {
            return Guid.Empty;
        }

        var nameIdentifierClaim = identity.FindFirst(ClaimTypes.NameIdentifier);

        if (nameIdentifierClaim == null || string.IsNullOrEmpty(nameIdentifierClaim.Value))
        {
            return Guid.Empty;
        }

        if (Guid.TryParse(nameIdentifierClaim.Value, out var userId))
        {
            return userId;
        }
        else
        {
            return Guid.Empty;
        }
    }
    
    
    protected Guid GetCurrentPositionId()
    {
        if (!(HttpContext.User.Identity is ClaimsIdentity identity))
        {
            return Guid.Empty;
        }

        var nameIdentifierClaim = identity.FindFirst("PositionId");

        if (nameIdentifierClaim == null || string.IsNullOrEmpty(nameIdentifierClaim.Value))
        {
            return Guid.Empty;
        }

        if (Guid.TryParse(nameIdentifierClaim.Value, out var positionId))
        {
            return positionId;
        }
        else
        {
            return Guid.Empty;
        }
    }
    
    protected string GetIpAddress()
    {
        return HttpContext.Connection.RemoteIpAddress!.ToString();
    }
}