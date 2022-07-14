﻿using GD.Data.Services.Interface;
using GD.Entity.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizsController : GDBaseController
    {
        public QuizsController(IChangeService changeService, IQueryService queryService) : base(changeService, queryService)
        {
        }
        [HttpGet]
        public async Task<IActionResult> GetClass()
        {
            var data = await _queryService.GetQuestionChoices();
            return Ok(data);
        }
    }
}
