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

	    protected readonly ILogger<ChangeService> _logger;
		private readonly IQueryService _queryService;
        private readonly IActionContextAccessor _actionContextAccessor;

        public ChangeService(IServiceProvider serviceProvider, IBulkOperation bulkOperation,
			ILogger<ChangeService> logger ,IQueryService queryService,  IActionContextAccessor actionContextAccessor) : base(serviceProvider, bulkOperation)
		{
			_logger = logger;
			_queryService = queryService;
            _actionContextAccessor = actionContextAccessor;

        }
        protected int GetUserID()
        {
             return dbContext.Users.FirstOrDefault(x=> x.Username == _actionContextAccessor.ActionContext.HttpContext.User.Identity.Name).id;
        }
        public Task<bool> ExistsAsync(Class entity, CancellationToken cancellationToken = default)
        {
            return this.dbContext.Set<Class>().AnyAsync(e => 
                                                                e.id == entity.id, cancellationToken);
        }
        public async Task AddAsync(Class entity, CancellationToken cancellationToken = default)
        {

            
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
            entity.UpdatedDate = DateTime.Now;
            entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
            await dbContext.Set<Class>().AddAsync(entity);
            
        }
        public async Task AddOrUpdateAsync(Class entity, CancellationToken cancellationToken = default)
        {
            var existed = await dbContext.Set<Class>().FirstOrDefaultAsync(e => e.id == entity.id);
            if (existed == null)
            {
                
                entity.CreatedDate = DateTime.Now;
                entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                dbContext.Set<Class>().Add(entity);
            }
            else
            {
                
                entity.CreatedDate = existed.CreatedDate;
                entity.CreatedBy = existed.CreatedBy;
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                dbContext.Entry(existed).CurrentValues.SetValues(entity);
            }
        }
        public async Task UpdateAsync(Class entity, CancellationToken cancellationToken = default)
        {
            var existed = await dbContext.Set<Class>().FirstOrDefaultAsync(e =>e.id == entity.id);
            if (existed != null)
            {
                
                entity.CreatedDate = existed.CreatedDate;
                entity.CreatedBy = existed.CreatedBy;
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                dbContext.Entry(existed).CurrentValues.SetValues(entity);
            }
        }
        public async Task DeleteAsync(Class entity, CancellationToken cancellationToken = default)
        {
            var existed = await dbContext.Set<Class>().FirstOrDefaultAsync(e =>(e.id == entity.id ||entity.id == default ));
            if (existed != null)
            {
                dbContext.Set<Class>().Remove(existed);
            }
        }
        public Task AddOrUpdateAsync(IEnumerable<Class> entities, CancellationToken cancellationToken = default)
        {
            Expression<Func<Class, object>> keySelector = (e => new {
                                                                    e.id} ); 
            foreach(var entity in entities)
            {      
                if(entity.id == default|| entity.id <= 0 || entity.UniqueId == default)  
                {
                    
                    entity.CreatedDate = DateTime.Now;
                    entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }
                else
                {
                    
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }
           
            }
            return AddOrUpdateAsync(entities, keySelector, cancellationToken);
        }
        public Task BulkAddAsync(IList<Class> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default) 
        { 
            foreach (var entity in entities)
            {
                
				entity.CreatedDate = DateTime.Now;
				entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
            }
            return _bulkOperation.BulkAddAsync(dbContext,entities, bulkOptions, progress, cancellationToken);
        }
        public Task BulkUpdateAsync(IList<Class> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default)
        {
            foreach (var entity in entities)
            {
                
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
            }
            return _bulkOperation.BulkUpdateAsync(dbContext, entities, bulkOptions, progress, cancellationToken);
        }

        public Task BulkDeleteAsync(IList<Class> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default)
        {
            if(!entities.Any())  return Task.CompletedTask ;
            return _bulkOperation.BulkDeleteAsync(dbContext, entities, bulkOptions, progress, cancellationToken);
        }

        public Task BulkAddOrUpdateAsync(IList<Class> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default)
        { 
            foreach (var entity in entities)
            {
                if(entity.id == default|| entity.id <= 0 || entity.UniqueId == default)  
                {
                    
                    entity.CreatedDate = DateTime.Now;
                    entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }
                else
                {
                    
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }

            }
            return _bulkOperation.BulkAddOrUpdateAsync(dbContext,entities, bulkOptions, progress, cancellationToken);
        }
        
        public Task<bool> ExistsAsync(Exam entity, CancellationToken cancellationToken = default)
        {
            return this.dbContext.Set<Exam>().AnyAsync(e => 
                                                                e.id == entity.id, cancellationToken);
        }
        public async Task AddAsync(Exam entity, CancellationToken cancellationToken = default)
        {

            
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
            entity.UpdatedDate = DateTime.Now;
            entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
            await dbContext.Set<Exam>().AddAsync(entity);
            
        }
        public async Task AddOrUpdateAsync(Exam entity, CancellationToken cancellationToken = default)
        {
            var existed = await dbContext.Set<Exam>().FirstOrDefaultAsync(e => e.id == entity.id);
            if (existed == null)
            {
                
                entity.CreatedDate = DateTime.Now;
                entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                dbContext.Set<Exam>().Add(entity);
            }
            else
            {
                
                entity.CreatedDate = existed.CreatedDate;
                entity.CreatedBy = existed.CreatedBy;
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                dbContext.Entry(existed).CurrentValues.SetValues(entity);
            }
        }
        public async Task UpdateAsync(Exam entity, CancellationToken cancellationToken = default)
        {
            var existed = await dbContext.Set<Exam>().FirstOrDefaultAsync(e =>e.id == entity.id);
            if (existed != null)
            {
                
                entity.CreatedDate = existed.CreatedDate;
                entity.CreatedBy = existed.CreatedBy;
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                dbContext.Entry(existed).CurrentValues.SetValues(entity);
            }
        }
        public async Task DeleteAsync(Exam entity, CancellationToken cancellationToken = default)
        {
            var existed = await dbContext.Set<Exam>().FirstOrDefaultAsync(e =>(e.id == entity.id ||entity.id == default ));
            if (existed != null)
            {
                dbContext.Set<Exam>().Remove(existed);
            }
        }
        public Task AddOrUpdateAsync(IEnumerable<Exam> entities, CancellationToken cancellationToken = default)
        {
            Expression<Func<Exam, object>> keySelector = (e => new {
                                                                    e.id} ); 
            foreach(var entity in entities)
            {      
                if(entity.id == default|| entity.id <= 0 || entity.UniqueId == default)  
                {
                    
                    entity.CreatedDate = DateTime.Now;
                    entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }
                else
                {
                    
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }
           
            }
            return AddOrUpdateAsync(entities, keySelector, cancellationToken);
        }
        public Task BulkAddAsync(IList<Exam> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default) 
        { 
            foreach (var entity in entities)
            {
                
				entity.CreatedDate = DateTime.Now;
				entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
            }
            return _bulkOperation.BulkAddAsync(dbContext,entities, bulkOptions, progress, cancellationToken);
        }
        public Task BulkUpdateAsync(IList<Exam> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default)
        {
            foreach (var entity in entities)
            {
                
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
            }
            return _bulkOperation.BulkUpdateAsync(dbContext, entities, bulkOptions, progress, cancellationToken);
        }

        public Task BulkDeleteAsync(IList<Exam> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default)
        {
            if(!entities.Any())  return Task.CompletedTask ;
            return _bulkOperation.BulkDeleteAsync(dbContext, entities, bulkOptions, progress, cancellationToken);
        }

        public Task BulkAddOrUpdateAsync(IList<Exam> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default)
        { 
            foreach (var entity in entities)
            {
                if(entity.id == default|| entity.id <= 0 || entity.UniqueId == default)  
                {
                    
                    entity.CreatedDate = DateTime.Now;
                    entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }
                else
                {
                    
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }

            }
            return _bulkOperation.BulkAddOrUpdateAsync(dbContext,entities, bulkOptions, progress, cancellationToken);
        }
        
        public Task<bool> ExistsAsync(ExamQuestion entity, CancellationToken cancellationToken = default)
        {
            return this.dbContext.Set<ExamQuestion>().AnyAsync(e => 
                                                                e.ExamFId == entity.ExamFId
                                                                    && e.QuestionFId == entity.QuestionFId, cancellationToken);
        }
        public async Task AddAsync(ExamQuestion entity, CancellationToken cancellationToken = default)
        {

            
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
            entity.UpdatedDate = DateTime.Now;
            entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
            await dbContext.Set<ExamQuestion>().AddAsync(entity);
            
        }
        public async Task AddOrUpdateAsync(ExamQuestion entity, CancellationToken cancellationToken = default)
        {
            var existed = await dbContext.Set<ExamQuestion>().FirstOrDefaultAsync(e => e.ExamFId == entity.ExamFId
                                                                    && e.QuestionFId == entity.QuestionFId);
            if (existed == null)
            {
                
                entity.CreatedDate = DateTime.Now;
                entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                dbContext.Set<ExamQuestion>().Add(entity);
            }
            else
            {
                
                entity.CreatedDate = existed.CreatedDate;
                entity.CreatedBy = existed.CreatedBy;
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                dbContext.Entry(existed).CurrentValues.SetValues(entity);
            }
        }
        public async Task UpdateAsync(ExamQuestion entity, CancellationToken cancellationToken = default)
        {
            var existed = await dbContext.Set<ExamQuestion>().FirstOrDefaultAsync(e =>e.ExamFId == entity.ExamFId
                                                                    && e.QuestionFId == entity.QuestionFId);
            if (existed != null)
            {
                
                entity.CreatedDate = existed.CreatedDate;
                entity.CreatedBy = existed.CreatedBy;
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                dbContext.Entry(existed).CurrentValues.SetValues(entity);
            }
        }
        public async Task DeleteAsync(ExamQuestion entity, CancellationToken cancellationToken = default)
        {
            var existed = await dbContext.Set<ExamQuestion>().FirstOrDefaultAsync(e =>(e.ExamFId == entity.ExamFId ||entity.ExamFId == default )
                                                                    && (e.QuestionFId == entity.QuestionFId ||entity.QuestionFId == default));
            if (existed != null)
            {
                dbContext.Set<ExamQuestion>().Remove(existed);
            }
        }
        public Task AddOrUpdateAsync(IEnumerable<ExamQuestion> entities, CancellationToken cancellationToken = default)
        {
            Expression<Func<ExamQuestion, object>> keySelector = (e => new {
                                                                    e.ExamFId
                                                                    , e.QuestionFId} ); 
            foreach(var entity in entities)
            {      
                if(entity.ExamFId == default|| entity.ExamFId <= 0|| entity.QuestionFId == default|| entity.QuestionFId <= 0)  
                {
                    
                    entity.CreatedDate = DateTime.Now;
                    entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }
                else
                {
                    
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }
           
            }
            return AddOrUpdateAsync(entities, keySelector, cancellationToken);
        }
        public Task BulkAddAsync(IList<ExamQuestion> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default) 
        { 
            foreach (var entity in entities)
            {
                
				entity.CreatedDate = DateTime.Now;
				entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
            }
            return _bulkOperation.BulkAddAsync(dbContext,entities, bulkOptions, progress, cancellationToken);
        }
        public Task BulkUpdateAsync(IList<ExamQuestion> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default)
        {
            foreach (var entity in entities)
            {
                
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
            }
            return _bulkOperation.BulkUpdateAsync(dbContext, entities, bulkOptions, progress, cancellationToken);
        }

        public Task BulkDeleteAsync(IList<ExamQuestion> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default)
        {
            if(!entities.Any())  return Task.CompletedTask ;
            return _bulkOperation.BulkDeleteAsync(dbContext, entities, bulkOptions, progress, cancellationToken);
        }

        public Task BulkAddOrUpdateAsync(IList<ExamQuestion> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default)
        { 
            foreach (var entity in entities)
            {
                if(entity.ExamFId == default|| entity.ExamFId <= 0|| entity.QuestionFId == default|| entity.QuestionFId <= 0)  
                {
                    
                    entity.CreatedDate = DateTime.Now;
                    entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }
                else
                {
                    
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }

            }
            return _bulkOperation.BulkAddOrUpdateAsync(dbContext,entities, bulkOptions, progress, cancellationToken);
        }
        
        public Task<bool> ExistsAsync(MilitaryInformation entity, CancellationToken cancellationToken = default)
        {
            return this.dbContext.Set<MilitaryInformation>().AnyAsync(e => 
                                                                e.id == entity.id, cancellationToken);
        }
        public async Task AddAsync(MilitaryInformation entity, CancellationToken cancellationToken = default)
        {

            
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
            entity.UpdatedDate = DateTime.Now;
            entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
            await dbContext.Set<MilitaryInformation>().AddAsync(entity);
            
        }
        public async Task AddOrUpdateAsync(MilitaryInformation entity, CancellationToken cancellationToken = default)
        {
            var existed = await dbContext.Set<MilitaryInformation>().FirstOrDefaultAsync(e => e.id == entity.id);
            if (existed == null)
            {
                
                entity.CreatedDate = DateTime.Now;
                entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                dbContext.Set<MilitaryInformation>().Add(entity);
            }
            else
            {
                
                entity.CreatedDate = existed.CreatedDate;
                entity.CreatedBy = existed.CreatedBy;
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                dbContext.Entry(existed).CurrentValues.SetValues(entity);
            }
        }
        public async Task UpdateAsync(MilitaryInformation entity, CancellationToken cancellationToken = default)
        {
            var existed = await dbContext.Set<MilitaryInformation>().FirstOrDefaultAsync(e =>e.id == entity.id);
            if (existed != null)
            {
                
                entity.CreatedDate = existed.CreatedDate;
                entity.CreatedBy = existed.CreatedBy;
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                dbContext.Entry(existed).CurrentValues.SetValues(entity);
            }
        }
        public async Task DeleteAsync(MilitaryInformation entity, CancellationToken cancellationToken = default)
        {
            var existed = await dbContext.Set<MilitaryInformation>().FirstOrDefaultAsync(e =>(e.id == entity.id ||entity.id == default ));
            if (existed != null)
            {
                dbContext.Set<MilitaryInformation>().Remove(existed);
            }
        }
        public Task AddOrUpdateAsync(IEnumerable<MilitaryInformation> entities, CancellationToken cancellationToken = default)
        {
            Expression<Func<MilitaryInformation, object>> keySelector = (e => new {
                                                                    e.id} ); 
            foreach(var entity in entities)
            {      
                if(entity.id == default|| entity.id <= 0 || entity.UniqueId == default)  
                {
                    
                    entity.CreatedDate = DateTime.Now;
                    entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }
                else
                {
                    
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }
           
            }
            return AddOrUpdateAsync(entities, keySelector, cancellationToken);
        }
        public Task BulkAddAsync(IList<MilitaryInformation> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default) 
        { 
            foreach (var entity in entities)
            {
                
				entity.CreatedDate = DateTime.Now;
				entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
            }
            return _bulkOperation.BulkAddAsync(dbContext,entities, bulkOptions, progress, cancellationToken);
        }
        public Task BulkUpdateAsync(IList<MilitaryInformation> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default)
        {
            foreach (var entity in entities)
            {
                
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
            }
            return _bulkOperation.BulkUpdateAsync(dbContext, entities, bulkOptions, progress, cancellationToken);
        }

        public Task BulkDeleteAsync(IList<MilitaryInformation> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default)
        {
            if(!entities.Any())  return Task.CompletedTask ;
            return _bulkOperation.BulkDeleteAsync(dbContext, entities, bulkOptions, progress, cancellationToken);
        }

        public Task BulkAddOrUpdateAsync(IList<MilitaryInformation> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default)
        { 
            foreach (var entity in entities)
            {
                if(entity.id == default|| entity.id <= 0 || entity.UniqueId == default)  
                {
                    
                    entity.CreatedDate = DateTime.Now;
                    entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }
                else
                {
                    
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }

            }
            return _bulkOperation.BulkAddOrUpdateAsync(dbContext,entities, bulkOptions, progress, cancellationToken);
        }
        
        public Task<bool> ExistsAsync(Question entity, CancellationToken cancellationToken = default)
        {
            return this.dbContext.Set<Question>().AnyAsync(e => 
                                                                e.id == entity.id, cancellationToken);
        }
        public async Task AddAsync(Question entity, CancellationToken cancellationToken = default)
        {

            
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
            entity.UpdatedDate = DateTime.Now;
            entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
            await dbContext.Set<Question>().AddAsync(entity);
            
        }
        public async Task AddOrUpdateAsync(Question entity, CancellationToken cancellationToken = default)
        {
            var existed = await dbContext.Set<Question>().FirstOrDefaultAsync(e => e.id == entity.id);
            if (existed == null)
            {
                
                entity.CreatedDate = DateTime.Now;
                entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                dbContext.Set<Question>().Add(entity);
            }
            else
            {
                
                entity.CreatedDate = existed.CreatedDate;
                entity.CreatedBy = existed.CreatedBy;
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                dbContext.Entry(existed).CurrentValues.SetValues(entity);
            }
        }
        public async Task UpdateAsync(Question entity, CancellationToken cancellationToken = default)
        {
            var existed = await dbContext.Set<Question>().FirstOrDefaultAsync(e =>e.id == entity.id);
            if (existed != null)
            {
                
                entity.CreatedDate = existed.CreatedDate;
                entity.CreatedBy = existed.CreatedBy;
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                dbContext.Entry(existed).CurrentValues.SetValues(entity);
            }
        }
        public async Task DeleteAsync(Question entity, CancellationToken cancellationToken = default)
        {
            var existed = await dbContext.Set<Question>().FirstOrDefaultAsync(e =>(e.id == entity.id ||entity.id == default ));
            if (existed != null)
            {
                dbContext.Set<Question>().Remove(existed);
            }
        }
        public Task AddOrUpdateAsync(IEnumerable<Question> entities, CancellationToken cancellationToken = default)
        {
            Expression<Func<Question, object>> keySelector = (e => new {
                                                                    e.id} ); 
            foreach(var entity in entities)
            {      
                if(entity.id == default|| entity.id <= 0)  
                {
                    
                    entity.CreatedDate = DateTime.Now;
                    entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }
                else
                {
                    
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }
           
            }
            return AddOrUpdateAsync(entities, keySelector, cancellationToken);
        }
        public Task BulkAddAsync(IList<Question> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default) 
        { 
            foreach (var entity in entities)
            {
                
				entity.CreatedDate = DateTime.Now;
				entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
            }
            return _bulkOperation.BulkAddAsync(dbContext,entities, bulkOptions, progress, cancellationToken);
        }
        public Task BulkUpdateAsync(IList<Question> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default)
        {
            foreach (var entity in entities)
            {
                
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
            }
            return _bulkOperation.BulkUpdateAsync(dbContext, entities, bulkOptions, progress, cancellationToken);
        }

        public Task BulkDeleteAsync(IList<Question> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default)
        {
            if(!entities.Any())  return Task.CompletedTask ;
            return _bulkOperation.BulkDeleteAsync(dbContext, entities, bulkOptions, progress, cancellationToken);
        }

        public Task BulkAddOrUpdateAsync(IList<Question> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default)
        { 
            foreach (var entity in entities)
            {
                if(entity.id == default|| entity.id <= 0)  
                {
                    
                    entity.CreatedDate = DateTime.Now;
                    entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }
                else
                {
                    
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }

            }
            return _bulkOperation.BulkAddOrUpdateAsync(dbContext,entities, bulkOptions, progress, cancellationToken);
        }
        
        public Task<bool> ExistsAsync(QuestionChoice entity, CancellationToken cancellationToken = default)
        {
            return this.dbContext.Set<QuestionChoice>().AnyAsync(e => 
                                                                e.id == entity.id, cancellationToken);
        }
        public async Task AddAsync(QuestionChoice entity, CancellationToken cancellationToken = default)
        {

            
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
            entity.UpdatedDate = DateTime.Now;
            entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
            await dbContext.Set<QuestionChoice>().AddAsync(entity);
            
        }
        public async Task AddOrUpdateAsync(QuestionChoice entity, CancellationToken cancellationToken = default)
        {
            var existed = await dbContext.Set<QuestionChoice>().FirstOrDefaultAsync(e => e.id == entity.id);
            if (existed == null)
            {
                
                entity.CreatedDate = DateTime.Now;
                entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                dbContext.Set<QuestionChoice>().Add(entity);
            }
            else
            {
                
                entity.CreatedDate = existed.CreatedDate;
                entity.CreatedBy = existed.CreatedBy;
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                dbContext.Entry(existed).CurrentValues.SetValues(entity);
            }
        }
        public async Task UpdateAsync(QuestionChoice entity, CancellationToken cancellationToken = default)
        {
            var existed = await dbContext.Set<QuestionChoice>().FirstOrDefaultAsync(e =>e.id == entity.id);
            if (existed != null)
            {
                
                entity.CreatedDate = existed.CreatedDate;
                entity.CreatedBy = existed.CreatedBy;
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                dbContext.Entry(existed).CurrentValues.SetValues(entity);
            }
        }
        public async Task DeleteAsync(QuestionChoice entity, CancellationToken cancellationToken = default)
        {
            var existed = await dbContext.Set<QuestionChoice>().FirstOrDefaultAsync(e =>(e.id == entity.id ||entity.id == default ));
            if (existed != null)
            {
                dbContext.Set<QuestionChoice>().Remove(existed);
            }
        }
        public Task AddOrUpdateAsync(IEnumerable<QuestionChoice> entities, CancellationToken cancellationToken = default)
        {
            Expression<Func<QuestionChoice, object>> keySelector = (e => new {
                                                                    e.id} ); 
            foreach(var entity in entities)
            {      
                if(entity.id == default|| entity.id <= 0)  
                {
                    
                    entity.CreatedDate = DateTime.Now;
                    entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }
                else
                {
                    
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }
           
            }
            return AddOrUpdateAsync(entities, keySelector, cancellationToken);
        }
        public Task BulkAddAsync(IList<QuestionChoice> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default) 
        { 
            foreach (var entity in entities)
            {
                
				entity.CreatedDate = DateTime.Now;
				entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
            }
            return _bulkOperation.BulkAddAsync(dbContext,entities, bulkOptions, progress, cancellationToken);
        }
        public Task BulkUpdateAsync(IList<QuestionChoice> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default)
        {
            foreach (var entity in entities)
            {
                
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
            }
            return _bulkOperation.BulkUpdateAsync(dbContext, entities, bulkOptions, progress, cancellationToken);
        }

        public Task BulkDeleteAsync(IList<QuestionChoice> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default)
        {
            if(!entities.Any())  return Task.CompletedTask ;
            return _bulkOperation.BulkDeleteAsync(dbContext, entities, bulkOptions, progress, cancellationToken);
        }

        public Task BulkAddOrUpdateAsync(IList<QuestionChoice> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default)
        { 
            foreach (var entity in entities)
            {
                if(entity.id == default|| entity.id <= 0)  
                {
                    
                    entity.CreatedDate = DateTime.Now;
                    entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }
                else
                {
                    
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }

            }
            return _bulkOperation.BulkAddOrUpdateAsync(dbContext,entities, bulkOptions, progress, cancellationToken);
        }
        
        public Task<bool> ExistsAsync(RefreshToken entity, CancellationToken cancellationToken = default)
        {
            return this.dbContext.Set<RefreshToken>().AnyAsync(e => 
                                                                e.id == entity.id, cancellationToken);
        }
        public async Task AddAsync(RefreshToken entity, CancellationToken cancellationToken = default)
        {

            
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
            entity.UpdatedDate = DateTime.Now;
            entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
            await dbContext.Set<RefreshToken>().AddAsync(entity);
            
        }
        public async Task AddOrUpdateAsync(RefreshToken entity, CancellationToken cancellationToken = default)
        {
            var existed = await dbContext.Set<RefreshToken>().FirstOrDefaultAsync(e => e.id == entity.id);
            if (existed == null)
            {
                
                entity.CreatedDate = DateTime.Now;
                entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                dbContext.Set<RefreshToken>().Add(entity);
            }
            else
            {
                
                entity.CreatedDate = existed.CreatedDate;
                entity.CreatedBy = existed.CreatedBy;
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                dbContext.Entry(existed).CurrentValues.SetValues(entity);
            }
        }
        public async Task UpdateAsync(RefreshToken entity, CancellationToken cancellationToken = default)
        {
            var existed = await dbContext.Set<RefreshToken>().FirstOrDefaultAsync(e =>e.id == entity.id);
            if (existed != null)
            {
                
                entity.CreatedDate = existed.CreatedDate;
                entity.CreatedBy = existed.CreatedBy;
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                dbContext.Entry(existed).CurrentValues.SetValues(entity);
            }
        }
        public async Task DeleteAsync(RefreshToken entity, CancellationToken cancellationToken = default)
        {
            var existed = await dbContext.Set<RefreshToken>().FirstOrDefaultAsync(e =>(e.id == entity.id ||entity.id == default ));
            if (existed != null)
            {
                dbContext.Set<RefreshToken>().Remove(existed);
            }
        }
        public Task AddOrUpdateAsync(IEnumerable<RefreshToken> entities, CancellationToken cancellationToken = default)
        {
            Expression<Func<RefreshToken, object>> keySelector = (e => new {
                                                                    e.id} ); 
            foreach(var entity in entities)
            {      
                if(entity.id == default|| entity.id <= 0)  
                {
                    
                    entity.CreatedDate = DateTime.Now;
                    entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }
                else
                {
                    
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }
           
            }
            return AddOrUpdateAsync(entities, keySelector, cancellationToken);
        }
        public Task BulkAddAsync(IList<RefreshToken> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default) 
        { 
            foreach (var entity in entities)
            {
                
				entity.CreatedDate = DateTime.Now;
				entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
            }
            return _bulkOperation.BulkAddAsync(dbContext,entities, bulkOptions, progress, cancellationToken);
        }
        public Task BulkUpdateAsync(IList<RefreshToken> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default)
        {
            foreach (var entity in entities)
            {
                
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
            }
            return _bulkOperation.BulkUpdateAsync(dbContext, entities, bulkOptions, progress, cancellationToken);
        }

        public Task BulkDeleteAsync(IList<RefreshToken> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default)
        {
            if(!entities.Any())  return Task.CompletedTask ;
            return _bulkOperation.BulkDeleteAsync(dbContext, entities, bulkOptions, progress, cancellationToken);
        }

        public Task BulkAddOrUpdateAsync(IList<RefreshToken> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default)
        { 
            foreach (var entity in entities)
            {
                if(entity.id == default|| entity.id <= 0)  
                {
                    
                    entity.CreatedDate = DateTime.Now;
                    entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }
                else
                {
                    
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }

            }
            return _bulkOperation.BulkAddOrUpdateAsync(dbContext,entities, bulkOptions, progress, cancellationToken);
        }
        
        public Task<bool> ExistsAsync(Student entity, CancellationToken cancellationToken = default)
        {
            return this.dbContext.Set<Student>().AnyAsync(e => 
                                                                e.id == entity.id, cancellationToken);
        }
        public async Task AddAsync(Student entity, CancellationToken cancellationToken = default)
        {

            
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
            entity.UpdatedDate = DateTime.Now;
            entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
            await dbContext.Set<Student>().AddAsync(entity);
            
        }
        public async Task AddOrUpdateAsync(Student entity, CancellationToken cancellationToken = default)
        {
            var existed = await dbContext.Set<Student>().FirstOrDefaultAsync(e => e.id == entity.id);
            if (existed == null)
            {
                
                entity.CreatedDate = DateTime.Now;
                entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                dbContext.Set<Student>().Add(entity);
            }
            else
            {
                
                entity.CreatedDate = existed.CreatedDate;
                entity.CreatedBy = existed.CreatedBy;
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                dbContext.Entry(existed).CurrentValues.SetValues(entity);
            }
        }
        public async Task UpdateAsync(Student entity, CancellationToken cancellationToken = default)
        {
            var existed = await dbContext.Set<Student>().FirstOrDefaultAsync(e =>e.id == entity.id);
            if (existed != null)
            {
                
                entity.CreatedDate = existed.CreatedDate;
                entity.CreatedBy = existed.CreatedBy;
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                dbContext.Entry(existed).CurrentValues.SetValues(entity);
            }
        }
        public async Task DeleteAsync(Student entity, CancellationToken cancellationToken = default)
        {
            var existed = await dbContext.Set<Student>().FirstOrDefaultAsync(e =>(e.id == entity.id ||entity.id == default ));
            if (existed != null)
            {
                dbContext.Set<Student>().Remove(existed);
            }
        }
        public Task AddOrUpdateAsync(IEnumerable<Student> entities, CancellationToken cancellationToken = default)
        {
            Expression<Func<Student, object>> keySelector = (e => new {
                                                                    e.id} ); 
            foreach(var entity in entities)
            {      
                if(entity.id == default|| entity.id <= 0)  
                {
                    
                    entity.CreatedDate = DateTime.Now;
                    entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }
                else
                {
                    
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }
           
            }
            return AddOrUpdateAsync(entities, keySelector, cancellationToken);
        }
        public Task BulkAddAsync(IList<Student> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default) 
        { 
            foreach (var entity in entities)
            {
                
				entity.CreatedDate = DateTime.Now;
				entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
            }
            return _bulkOperation.BulkAddAsync(dbContext,entities, bulkOptions, progress, cancellationToken);
        }
        public Task BulkUpdateAsync(IList<Student> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default)
        {
            foreach (var entity in entities)
            {
                
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
            }
            return _bulkOperation.BulkUpdateAsync(dbContext, entities, bulkOptions, progress, cancellationToken);
        }

        public Task BulkDeleteAsync(IList<Student> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default)
        {
            if(!entities.Any())  return Task.CompletedTask ;
            return _bulkOperation.BulkDeleteAsync(dbContext, entities, bulkOptions, progress, cancellationToken);
        }

        public Task BulkAddOrUpdateAsync(IList<Student> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default)
        { 
            foreach (var entity in entities)
            {
                if(entity.id == default|| entity.id <= 0)  
                {
                    
                    entity.CreatedDate = DateTime.Now;
                    entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }
                else
                {
                    
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }

            }
            return _bulkOperation.BulkAddOrUpdateAsync(dbContext,entities, bulkOptions, progress, cancellationToken);
        }
        
        public Task<bool> ExistsAsync(StudentTest entity, CancellationToken cancellationToken = default)
        {
            return this.dbContext.Set<StudentTest>().AnyAsync(e => 
                                                                e.id == entity.id, cancellationToken);
        }
        public async Task AddAsync(StudentTest entity, CancellationToken cancellationToken = default)
        {

            
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
            entity.UpdatedDate = DateTime.Now;
            entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
            await dbContext.Set<StudentTest>().AddAsync(entity);
            
        }
        public async Task AddOrUpdateAsync(StudentTest entity, CancellationToken cancellationToken = default)
        {
            var existed = await dbContext.Set<StudentTest>().FirstOrDefaultAsync(e => e.id == entity.id);
            if (existed == null)
            {
                
                entity.CreatedDate = DateTime.Now;
                entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                dbContext.Set<StudentTest>().Add(entity);
            }
            else
            {
                
                entity.CreatedDate = existed.CreatedDate;
                entity.CreatedBy = existed.CreatedBy;
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                dbContext.Entry(existed).CurrentValues.SetValues(entity);
            }
        }
        public async Task UpdateAsync(StudentTest entity, CancellationToken cancellationToken = default)
        {
            var existed = await dbContext.Set<StudentTest>().FirstOrDefaultAsync(e =>e.id == entity.id);
            if (existed != null)
            {
                
                entity.CreatedDate = existed.CreatedDate;
                entity.CreatedBy = existed.CreatedBy;
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                dbContext.Entry(existed).CurrentValues.SetValues(entity);
            }
        }
        public async Task DeleteAsync(StudentTest entity, CancellationToken cancellationToken = default)
        {
            var existed = await dbContext.Set<StudentTest>().FirstOrDefaultAsync(e =>(e.id == entity.id ||entity.id == default ));
            if (existed != null)
            {
                dbContext.Set<StudentTest>().Remove(existed);
            }
        }
        public Task AddOrUpdateAsync(IEnumerable<StudentTest> entities, CancellationToken cancellationToken = default)
        {
            Expression<Func<StudentTest, object>> keySelector = (e => new {
                                                                    e.id} ); 
            foreach(var entity in entities)
            {      
                if(entity.id == default|| entity.id <= 0)  
                {
                    
                    entity.CreatedDate = DateTime.Now;
                    entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }
                else
                {
                    
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }
           
            }
            return AddOrUpdateAsync(entities, keySelector, cancellationToken);
        }
        public Task BulkAddAsync(IList<StudentTest> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default) 
        { 
            foreach (var entity in entities)
            {
                
				entity.CreatedDate = DateTime.Now;
				entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
            }
            return _bulkOperation.BulkAddAsync(dbContext,entities, bulkOptions, progress, cancellationToken);
        }
        public Task BulkUpdateAsync(IList<StudentTest> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default)
        {
            foreach (var entity in entities)
            {
                
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
            }
            return _bulkOperation.BulkUpdateAsync(dbContext, entities, bulkOptions, progress, cancellationToken);
        }

        public Task BulkDeleteAsync(IList<StudentTest> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default)
        {
            if(!entities.Any())  return Task.CompletedTask ;
            return _bulkOperation.BulkDeleteAsync(dbContext, entities, bulkOptions, progress, cancellationToken);
        }

        public Task BulkAddOrUpdateAsync(IList<StudentTest> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default)
        { 
            foreach (var entity in entities)
            {
                if(entity.id == default|| entity.id <= 0)  
                {
                    
                    entity.CreatedDate = DateTime.Now;
                    entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }
                else
                {
                    
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }

            }
            return _bulkOperation.BulkAddOrUpdateAsync(dbContext,entities, bulkOptions, progress, cancellationToken);
        }
        
        public Task<bool> ExistsAsync(Test entity, CancellationToken cancellationToken = default)
        {
            return this.dbContext.Set<Test>().AnyAsync(e => 
                                                                e.id == entity.id, cancellationToken);
        }
        public async Task AddAsync(Test entity, CancellationToken cancellationToken = default)
        {

            
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
            entity.UpdatedDate = DateTime.Now;
            entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
            await dbContext.Set<Test>().AddAsync(entity);
            
        }
        public async Task AddOrUpdateAsync(Test entity, CancellationToken cancellationToken = default)
        {
            var existed = await dbContext.Set<Test>().FirstOrDefaultAsync(e => e.id == entity.id);
            if (existed == null)
            {
                
                entity.CreatedDate = DateTime.Now;
                entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                dbContext.Set<Test>().Add(entity);
            }
            else
            {
                
                entity.CreatedDate = existed.CreatedDate;
                entity.CreatedBy = existed.CreatedBy;
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                dbContext.Entry(existed).CurrentValues.SetValues(entity);
            }
        }
        public async Task UpdateAsync(Test entity, CancellationToken cancellationToken = default)
        {
            var existed = await dbContext.Set<Test>().FirstOrDefaultAsync(e =>e.id == entity.id);
            if (existed != null)
            {
                
                entity.CreatedDate = existed.CreatedDate;
                entity.CreatedBy = existed.CreatedBy;
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                dbContext.Entry(existed).CurrentValues.SetValues(entity);
            }
        }
        public async Task DeleteAsync(Test entity, CancellationToken cancellationToken = default)
        {
            var existed = await dbContext.Set<Test>().FirstOrDefaultAsync(e =>(e.id == entity.id ||entity.id == default ));
            if (existed != null)
            {
                dbContext.Set<Test>().Remove(existed);
            }
        }
        public Task AddOrUpdateAsync(IEnumerable<Test> entities, CancellationToken cancellationToken = default)
        {
            Expression<Func<Test, object>> keySelector = (e => new {
                                                                    e.id} ); 
            foreach(var entity in entities)
            {      
                if(entity.id == default|| entity.id <= 0 || entity.UniqueId == default)  
                {
                    
                    entity.CreatedDate = DateTime.Now;
                    entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }
                else
                {
                    
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }
           
            }
            return AddOrUpdateAsync(entities, keySelector, cancellationToken);
        }
        public Task BulkAddAsync(IList<Test> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default) 
        { 
            foreach (var entity in entities)
            {
                
				entity.CreatedDate = DateTime.Now;
				entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
            }
            return _bulkOperation.BulkAddAsync(dbContext,entities, bulkOptions, progress, cancellationToken);
        }
        public Task BulkUpdateAsync(IList<Test> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default)
        {
            foreach (var entity in entities)
            {
                
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
            }
            return _bulkOperation.BulkUpdateAsync(dbContext, entities, bulkOptions, progress, cancellationToken);
        }

        public Task BulkDeleteAsync(IList<Test> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default)
        {
            if(!entities.Any())  return Task.CompletedTask ;
            return _bulkOperation.BulkDeleteAsync(dbContext, entities, bulkOptions, progress, cancellationToken);
        }

        public Task BulkAddOrUpdateAsync(IList<Test> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default)
        { 
            foreach (var entity in entities)
            {
                if(entity.id == default|| entity.id <= 0 || entity.UniqueId == default)  
                {
                    
                    entity.CreatedDate = DateTime.Now;
                    entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }
                else
                {
                    
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }

            }
            return _bulkOperation.BulkAddOrUpdateAsync(dbContext,entities, bulkOptions, progress, cancellationToken);
        }
        
        public Task<bool> ExistsAsync(User entity, CancellationToken cancellationToken = default)
        {
            return this.dbContext.Set<User>().AnyAsync(e => 
                                                                e.id == entity.id, cancellationToken);
        }
        public async Task AddAsync(User entity, CancellationToken cancellationToken = default)
        {

            
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
            entity.UpdatedDate = DateTime.Now;
            entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
            await dbContext.Set<User>().AddAsync(entity);
            
        }
        public async Task AddOrUpdateAsync(User entity, CancellationToken cancellationToken = default)
        {
            var existed = await dbContext.Set<User>().FirstOrDefaultAsync(e => e.id == entity.id);
            if (existed == null)
            {
                
                entity.CreatedDate = DateTime.Now;
                entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                dbContext.Set<User>().Add(entity);
            }
            else
            {
                
                entity.CreatedDate = existed.CreatedDate;
                entity.CreatedBy = existed.CreatedBy;
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                dbContext.Entry(existed).CurrentValues.SetValues(entity);
            }
        }
        public async Task UpdateAsync(User entity, CancellationToken cancellationToken = default)
        {
            var existed = await dbContext.Set<User>().FirstOrDefaultAsync(e =>e.id == entity.id);
            if (existed != null)
            {
                
                entity.CreatedDate = existed.CreatedDate;
                entity.CreatedBy = existed.CreatedBy;
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                dbContext.Entry(existed).CurrentValues.SetValues(entity);
            }
        }
        public async Task DeleteAsync(User entity, CancellationToken cancellationToken = default)
        {
            var existed = await dbContext.Set<User>().FirstOrDefaultAsync(e =>(e.id == entity.id ||entity.id == default ));
            if (existed != null)
            {
                dbContext.Set<User>().Remove(existed);
            }
        }
        public Task AddOrUpdateAsync(IEnumerable<User> entities, CancellationToken cancellationToken = default)
        {
            Expression<Func<User, object>> keySelector = (e => new {
                                                                    e.id} ); 
            foreach(var entity in entities)
            {      
                if(entity.id == default|| entity.id <= 0 || entity.UniqueId == default)  
                {
                    
                    entity.CreatedDate = DateTime.Now;
                    entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }
                else
                {
                    
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }
           
            }
            return AddOrUpdateAsync(entities, keySelector, cancellationToken);
        }
        public Task BulkAddAsync(IList<User> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default) 
        { 
            foreach (var entity in entities)
            {
                
				entity.CreatedDate = DateTime.Now;
				entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
            }
            return _bulkOperation.BulkAddAsync(dbContext,entities, bulkOptions, progress, cancellationToken);
        }
        public Task BulkUpdateAsync(IList<User> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default)
        {
            foreach (var entity in entities)
            {
                
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
            }
            return _bulkOperation.BulkUpdateAsync(dbContext, entities, bulkOptions, progress, cancellationToken);
        }

        public Task BulkDeleteAsync(IList<User> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default)
        {
            if(!entities.Any())  return Task.CompletedTask ;
            return _bulkOperation.BulkDeleteAsync(dbContext, entities, bulkOptions, progress, cancellationToken);
        }

        public Task BulkAddOrUpdateAsync(IList<User> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default)
        { 
            foreach (var entity in entities)
            {
                if(entity.id == default|| entity.id <= 0 || entity.UniqueId == default)  
                {
                    
                    entity.CreatedDate = DateTime.Now;
                    entity.CreatedBy = GetUserID()== default ? 1 : GetUserID();
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }
                else
                {
                    
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = GetUserID()== default ? 1 : GetUserID();
                }

            }
            return _bulkOperation.BulkAddOrUpdateAsync(dbContext,entities, bulkOptions, progress, cancellationToken);
        }
        
        
    }
}