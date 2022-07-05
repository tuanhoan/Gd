
using TaskApi.SDK.Data.EFService;
using TaskApi.SDK.EFService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TasksApi.Entity.Responsitories;

namespace GD.Data.Services.Services
{
	public partial class Service : EfService<TasksDbContext>, IService
	{
		public Service(IServiceProvider serviceProvider, IBulkOperation bulkOperation) : base(serviceProvider, bulkOperation)
		{
		}
	

	}
}