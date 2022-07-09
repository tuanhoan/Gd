using GD.Entity.Tables;
using GD.SDK.Data;
using GD.SDK.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GD.Data.Services.Interface
{
    public partial interface IQueryService : IAsyncQuery
    {
       Task<Class> GetModelAsync(Class query, CancellationToken cancellationToken = default);
       Task<List<Class>> QueryListAsync(Class query, CancellationToken cancellationToken = default);
       Task<bool> ExistsAsync(Class entity, CancellationToken cancellationToken = default); 
       Task<Exam> GetModelAsync(Exam query, CancellationToken cancellationToken = default);
       Task<List<Exam>> QueryListAsync(Exam query, CancellationToken cancellationToken = default);
       Task<bool> ExistsAsync(Exam entity, CancellationToken cancellationToken = default); 
       Task<ExamQuestion> GetModelAsync(ExamQuestion query, CancellationToken cancellationToken = default);
       Task<List<ExamQuestion>> QueryListAsync(ExamQuestion query, CancellationToken cancellationToken = default);
       Task<bool> ExistsAsync(ExamQuestion entity, CancellationToken cancellationToken = default); 
       Task<MilitaryInformation> GetModelAsync(MilitaryInformation query, CancellationToken cancellationToken = default);
       Task<List<MilitaryInformation>> QueryListAsync(MilitaryInformation query, CancellationToken cancellationToken = default);
       Task<bool> ExistsAsync(MilitaryInformation entity, CancellationToken cancellationToken = default); 
       Task<Question> GetModelAsync(Question query, CancellationToken cancellationToken = default);
       Task<List<Question>> QueryListAsync(Question query, CancellationToken cancellationToken = default);
       Task<bool> ExistsAsync(Question entity, CancellationToken cancellationToken = default); 
       Task<QuestionChoice> GetModelAsync(QuestionChoice query, CancellationToken cancellationToken = default);
       Task<List<QuestionChoice>> QueryListAsync(QuestionChoice query, CancellationToken cancellationToken = default);
       Task<bool> ExistsAsync(QuestionChoice entity, CancellationToken cancellationToken = default); 
       Task<RefreshToken> GetModelAsync(RefreshToken query, CancellationToken cancellationToken = default);
       Task<List<RefreshToken>> QueryListAsync(RefreshToken query, CancellationToken cancellationToken = default);
       Task<bool> ExistsAsync(RefreshToken entity, CancellationToken cancellationToken = default); 
       Task<Student> GetModelAsync(Student query, CancellationToken cancellationToken = default);
       Task<List<Student>> QueryListAsync(Student query, CancellationToken cancellationToken = default);
       Task<bool> ExistsAsync(Student entity, CancellationToken cancellationToken = default); 
       Task<StudentTest> GetModelAsync(StudentTest query, CancellationToken cancellationToken = default);
       Task<List<StudentTest>> QueryListAsync(StudentTest query, CancellationToken cancellationToken = default);
       Task<bool> ExistsAsync(StudentTest entity, CancellationToken cancellationToken = default); 
       Task<Test> GetModelAsync(Test query, CancellationToken cancellationToken = default);
       Task<List<Test>> QueryListAsync(Test query, CancellationToken cancellationToken = default);
       Task<bool> ExistsAsync(Test entity, CancellationToken cancellationToken = default); 
       Task<User> GetModelAsync(User query, CancellationToken cancellationToken = default);
       Task<List<User>> QueryListAsync(User query, CancellationToken cancellationToken = default);
       Task<bool> ExistsAsync(User entity, CancellationToken cancellationToken = default); 
       
    }
}