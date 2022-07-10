using GD.Data.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : GDBaseController
    {
        public ExamController(IChangeService changeService, IQueryService queryService) : base(changeService, queryService)
        {
        }

    }
}
