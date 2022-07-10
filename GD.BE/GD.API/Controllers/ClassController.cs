using GD.Data.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : GDBaseController
    {
        public ClassController(IChangeService changeService, IQueryService queryService) : base(changeService, queryService)
        {
        }
    }
}
