using GD.Data.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : GDBaseController
    {
        public TeacherController(IChangeService changeService, IQueryService queryService) : base(changeService, queryService)
        {
        }
    }
}
