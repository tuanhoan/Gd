using GD.Entity.Tables;
using GD.SDK.Data;
using GD.SDK.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GD.Data.Services.Interface
{
    public partial interface IChangeService : IAsyncChange, IUnitOfWork
	{
        Task<bool> ExistsAsync(Class entity, CancellationToken cancellationToken = default);
        Task AddAsync(Class entity, CancellationToken cancellationToken = default);
        Task AddOrUpdateAsync(Class entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(Class entity, CancellationToken cancellationToken = default);
        Task AddOrUpdateAsync(IEnumerable<Class> entities, CancellationToken cancellationToken = default);
        Task DeleteAsync(Class entity, CancellationToken cancellationToken = default);
        Task BulkAddAsync(IList<Class> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        Task BulkUpdateAsync(IList<Class> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        Task BulkDeleteAsync(IList<Class> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        Task BulkAddOrUpdateAsync(IList<Class> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        
        Task<bool> ExistsAsync(Exam entity, CancellationToken cancellationToken = default);
        Task AddAsync(Exam entity, CancellationToken cancellationToken = default);
        Task AddOrUpdateAsync(Exam entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(Exam entity, CancellationToken cancellationToken = default);
        Task AddOrUpdateAsync(IEnumerable<Exam> entities, CancellationToken cancellationToken = default);
        Task DeleteAsync(Exam entity, CancellationToken cancellationToken = default);
        Task BulkAddAsync(IList<Exam> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        Task BulkUpdateAsync(IList<Exam> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        Task BulkDeleteAsync(IList<Exam> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        Task BulkAddOrUpdateAsync(IList<Exam> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        
        Task<bool> ExistsAsync(ExamQuestion entity, CancellationToken cancellationToken = default);
        Task AddAsync(ExamQuestion entity, CancellationToken cancellationToken = default);
        Task AddOrUpdateAsync(ExamQuestion entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(ExamQuestion entity, CancellationToken cancellationToken = default);
        Task AddOrUpdateAsync(IEnumerable<ExamQuestion> entities, CancellationToken cancellationToken = default);
        Task DeleteAsync(ExamQuestion entity, CancellationToken cancellationToken = default);
        Task BulkAddAsync(IList<ExamQuestion> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        Task BulkUpdateAsync(IList<ExamQuestion> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        Task BulkDeleteAsync(IList<ExamQuestion> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        Task BulkAddOrUpdateAsync(IList<ExamQuestion> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        
        Task<bool> ExistsAsync(MilitaryInformation entity, CancellationToken cancellationToken = default);
        Task AddAsync(MilitaryInformation entity, CancellationToken cancellationToken = default);
        Task AddOrUpdateAsync(MilitaryInformation entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(MilitaryInformation entity, CancellationToken cancellationToken = default);
        Task AddOrUpdateAsync(IEnumerable<MilitaryInformation> entities, CancellationToken cancellationToken = default);
        Task DeleteAsync(MilitaryInformation entity, CancellationToken cancellationToken = default);
        Task BulkAddAsync(IList<MilitaryInformation> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        Task BulkUpdateAsync(IList<MilitaryInformation> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        Task BulkDeleteAsync(IList<MilitaryInformation> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        Task BulkAddOrUpdateAsync(IList<MilitaryInformation> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        
        Task<bool> ExistsAsync(Question entity, CancellationToken cancellationToken = default);
        Task AddAsync(Question entity, CancellationToken cancellationToken = default);
        Task AddOrUpdateAsync(Question entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(Question entity, CancellationToken cancellationToken = default);
        Task AddOrUpdateAsync(IEnumerable<Question> entities, CancellationToken cancellationToken = default);
        Task DeleteAsync(Question entity, CancellationToken cancellationToken = default);
        Task BulkAddAsync(IList<Question> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        Task BulkUpdateAsync(IList<Question> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        Task BulkDeleteAsync(IList<Question> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        Task BulkAddOrUpdateAsync(IList<Question> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        
        Task<bool> ExistsAsync(QuestionChoice entity, CancellationToken cancellationToken = default);
        Task AddAsync(QuestionChoice entity, CancellationToken cancellationToken = default);
        Task AddOrUpdateAsync(QuestionChoice entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(QuestionChoice entity, CancellationToken cancellationToken = default);
        Task AddOrUpdateAsync(IEnumerable<QuestionChoice> entities, CancellationToken cancellationToken = default);
        Task DeleteAsync(QuestionChoice entity, CancellationToken cancellationToken = default);
        Task BulkAddAsync(IList<QuestionChoice> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        Task BulkUpdateAsync(IList<QuestionChoice> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        Task BulkDeleteAsync(IList<QuestionChoice> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        Task BulkAddOrUpdateAsync(IList<QuestionChoice> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        
        Task<bool> ExistsAsync(RefreshToken entity, CancellationToken cancellationToken = default);
        Task AddAsync(RefreshToken entity, CancellationToken cancellationToken = default);
        Task AddOrUpdateAsync(RefreshToken entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(RefreshToken entity, CancellationToken cancellationToken = default);
        Task AddOrUpdateAsync(IEnumerable<RefreshToken> entities, CancellationToken cancellationToken = default);
        Task DeleteAsync(RefreshToken entity, CancellationToken cancellationToken = default);
        Task BulkAddAsync(IList<RefreshToken> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        Task BulkUpdateAsync(IList<RefreshToken> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        Task BulkDeleteAsync(IList<RefreshToken> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        Task BulkAddOrUpdateAsync(IList<RefreshToken> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        
        Task<bool> ExistsAsync(Student entity, CancellationToken cancellationToken = default);
        Task AddAsync(Student entity, CancellationToken cancellationToken = default);
        Task AddOrUpdateAsync(Student entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(Student entity, CancellationToken cancellationToken = default);
        Task AddOrUpdateAsync(IEnumerable<Student> entities, CancellationToken cancellationToken = default);
        Task DeleteAsync(Student entity, CancellationToken cancellationToken = default);
        Task BulkAddAsync(IList<Student> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        Task BulkUpdateAsync(IList<Student> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        Task BulkDeleteAsync(IList<Student> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        Task BulkAddOrUpdateAsync(IList<Student> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        
        Task<bool> ExistsAsync(StudentTest entity, CancellationToken cancellationToken = default);
        Task AddAsync(StudentTest entity, CancellationToken cancellationToken = default);
        Task AddOrUpdateAsync(StudentTest entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(StudentTest entity, CancellationToken cancellationToken = default);
        Task AddOrUpdateAsync(IEnumerable<StudentTest> entities, CancellationToken cancellationToken = default);
        Task DeleteAsync(StudentTest entity, CancellationToken cancellationToken = default);
        Task BulkAddAsync(IList<StudentTest> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        Task BulkUpdateAsync(IList<StudentTest> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        Task BulkDeleteAsync(IList<StudentTest> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        Task BulkAddOrUpdateAsync(IList<StudentTest> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        
        Task<bool> ExistsAsync(Test entity, CancellationToken cancellationToken = default);
        Task AddAsync(Test entity, CancellationToken cancellationToken = default);
        Task AddOrUpdateAsync(Test entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(Test entity, CancellationToken cancellationToken = default);
        Task AddOrUpdateAsync(IEnumerable<Test> entities, CancellationToken cancellationToken = default);
        Task DeleteAsync(Test entity, CancellationToken cancellationToken = default);
        Task BulkAddAsync(IList<Test> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        Task BulkUpdateAsync(IList<Test> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        Task BulkDeleteAsync(IList<Test> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        Task BulkAddOrUpdateAsync(IList<Test> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        
        Task<bool> ExistsAsync(User entity, CancellationToken cancellationToken = default);
        Task AddAsync(User entity, CancellationToken cancellationToken = default);
        Task AddOrUpdateAsync(User entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(User entity, CancellationToken cancellationToken = default);
        Task AddOrUpdateAsync(IEnumerable<User> entities, CancellationToken cancellationToken = default);
        Task DeleteAsync(User entity, CancellationToken cancellationToken = default);
        Task BulkAddAsync(IList<User> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        Task BulkUpdateAsync(IList<User> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        Task BulkDeleteAsync(IList<User> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        Task BulkAddOrUpdateAsync(IList<User> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default);
        
        
	}
}