using GD.Data.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GDBaseController : ControllerBase
    {
        public IChangeService _changeService;
        public IQueryService _queryService;

        public GDBaseController(IChangeService changeService, IQueryService queryService)
        {
            _changeService = changeService;
            _queryService = queryService;
        }

        protected int UserID => int.Parse(FindClaim(ClaimTypes.NameIdentifier));
        private string FindClaim(string claimName)
        {

            var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;

            var claim = claimsIdentity.FindFirst(claimName);

            if (claim == null)
            {
                return null;
            }

            return claim.Value;

        }
    }
}
