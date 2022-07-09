using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GD.Data.Services.Interface;
using GD.Entity.Tables;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using GD.SDK.EFService;
using GD.Entity.Responsitories;
using GD.SDK.Data.EFService;
using GD.SDK.Models;
using System.Linq;

namespace GD.Data.Services
{
    public partial class ChangeService : EfChange<GDContext>, IChangeService
	{

        public async Task getdata(QueryModel<Class> query)
        {
            var data = await GetAsync<Class>(x => x.id == 10);
            var data2 = await QueryAsync<Class>(x => x.id == 10);
            var data3 = await QueryAsync<Class>(x => x.id == 10, query.Page, query.PageSize);

        }
    }
}