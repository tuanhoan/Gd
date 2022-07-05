using TaskApi.SDK.Data.EFService;
using TaskApi.SDK.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TasksApi.Entity.Responsitories;

namespace GD.Data.Services.Services
{
	public partial class QueryService : EfQueryService<TasksDbContext>, IQueryService
	{
		public QueryService(IServiceProvider serviceProvider) : base(serviceProvider)
		{
		}

	}
}
