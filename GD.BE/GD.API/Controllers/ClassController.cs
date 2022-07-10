
using GD.Data.Services.Interface;
using GD.Entity.Tables;
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
        [HttpGet]
        public async Task<IActionResult> GetClass()
        {
            var data = await _queryService.QueryAsync<Class>(x => x.id != default);
            return Ok(data);
        }
    }
}
