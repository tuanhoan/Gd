using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using GD.Entity.Responsitories;
using GD.SDK.Data.EFService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GD.Entity.Tables;
using System.Threading;
using GD.Data.Services.Interface;

namespace GD.Data.Services
{
    public partial class QueryService : EfQuery<GDContext>, IQueryService
    {

      protected readonly ILogger<QueryService> _logger;
      public QueryService(IServiceProvider serviceProvider, ILogger<QueryService> logger) : base(serviceProvider)
      {
         _logger = logger;
      }

      protected IQueryable<Class> Filter(Class query, CancellationToken cancellationToken = default)
      {
         return dbContext.Set<Class>()
                        .AsNoTracking()
                        .Where(e => 
                           (query.id == default || e.id == query.id)   
                           &&(query.MilitaryInformationFId == default || e.MilitaryInformationFId == query.MilitaryInformationFId)   
                           &&(query.ClassName == default || e.ClassName.Contains(query.ClassName))   
                           &&(query.SchoolYear == default || e.SchoolYear.Contains(query.SchoolYear))   
                           &&(query.UniqueId == default || e.UniqueId == query.UniqueId)   
                           &&(query.CreatedDate == default || e.CreatedDate == query.CreatedDate)   
                           &&(query.CreatedBy == default || e.CreatedBy == query.CreatedBy)   
                           &&(query.UpdatedDate == default || e.UpdatedDate == query.UpdatedDate)   
                           &&(query.UpdatedBy == default || e.UpdatedBy == query.UpdatedBy)   
                           &&(query.MilitaryInformation == default || e.MilitaryInformation == query.MilitaryInformation)   
                           
                        )
                        .Select(x => x);
      }
      public async Task<Class> GetModelAsync(Class query, CancellationToken cancellationToken = default)
      {
         return await dbContext.Set<Class>()
                        .AsNoTracking()
                        .FirstOrDefaultAsync(e => 
                           (query.id == default || e.id == query.id)&&(query.MilitaryInformationFId == default || e.MilitaryInformationFId == query.MilitaryInformationFId)&&(query.UniqueId == default || e.UniqueId == query.UniqueId),cancellationToken);
      }
      public async Task<List<Class>> QueryListAsync(Class query, CancellationToken cancellationToken = default)
      {
         return await Filter(query, cancellationToken)
				.ToListAsync(cancellationToken);
      }
      public async Task<bool> ExistsAsync(Class query, CancellationToken cancellationToken = default)
      {
         return await dbContext.Set<Class>()
                        .AsNoTracking()
                        .AnyAsync(e => 
                           (query.id == default || e.id == query.id)&&(query.MilitaryInformationFId == default || e.MilitaryInformationFId == query.MilitaryInformationFId)&&(query.UniqueId == default || e.UniqueId == query.UniqueId),cancellationToken);
      }

       protected IQueryable<Exam> Filter(Exam query, CancellationToken cancellationToken = default)
      {
         return dbContext.Set<Exam>()
                        .AsNoTracking()
                        .Where(e => 
                           (query.id == default || e.id == query.id)   
                           &&(query.MilitaryInformationFId == default || e.MilitaryInformationFId == query.MilitaryInformationFId)   
                           &&(query.SubjectName == default || e.SubjectName.Contains(query.SubjectName))   
                           &&(query.Duration == default || e.Duration == query.Duration)   
                           &&(query.term == default || e.term.Contains(query.term))   
                           &&(query.UniqueId == default || e.UniqueId == query.UniqueId)   
                           &&(query.CreatedDate == default || e.CreatedDate == query.CreatedDate)   
                           &&(query.CreatedBy == default || e.CreatedBy == query.CreatedBy)   
                           &&(query.UpdatedDate == default || e.UpdatedDate == query.UpdatedDate)   
                           &&(query.UpdatedBy == default || e.UpdatedBy == query.UpdatedBy)   
                           &&(query.MilitaryInformation == default || e.MilitaryInformation == query.MilitaryInformation)   
                           &&(query.ExamQuestions == default || e.ExamQuestions == query.ExamQuestions)   
                           &&(query.Tests == default || e.Tests == query.Tests)   
                           
                        )
                        .Select(x => x);
      }
      public async Task<Exam> GetModelAsync(Exam query, CancellationToken cancellationToken = default)
      {
         return await dbContext.Set<Exam>()
                        .AsNoTracking()
                        .FirstOrDefaultAsync(e => 
                           (query.id == default || e.id == query.id)&&(query.MilitaryInformationFId == default || e.MilitaryInformationFId == query.MilitaryInformationFId)&&(query.UniqueId == default || e.UniqueId == query.UniqueId),cancellationToken);
      }
      public async Task<List<Exam>> QueryListAsync(Exam query, CancellationToken cancellationToken = default)
      {
         return await Filter(query, cancellationToken)
				.ToListAsync(cancellationToken);
      }
      public async Task<bool> ExistsAsync(Exam query, CancellationToken cancellationToken = default)
      {
         return await dbContext.Set<Exam>()
                        .AsNoTracking()
                        .AnyAsync(e => 
                           (query.id == default || e.id == query.id)&&(query.MilitaryInformationFId == default || e.MilitaryInformationFId == query.MilitaryInformationFId)&&(query.UniqueId == default || e.UniqueId == query.UniqueId),cancellationToken);
      }

       protected IQueryable<ExamQuestion> Filter(ExamQuestion query, CancellationToken cancellationToken = default)
      {
         return dbContext.Set<ExamQuestion>()
                        .AsNoTracking()
                        .Where(e => 
                           (query.ExamFId == default || e.ExamFId == query.ExamFId)   
                           &&(query.QuestionFId == default || e.QuestionFId == query.QuestionFId)   
                           &&(query.QuestionSequence == default || e.QuestionSequence == query.QuestionSequence)   
                           &&(query.CreatedDate == default || e.CreatedDate == query.CreatedDate)   
                           &&(query.CreatedBy == default || e.CreatedBy == query.CreatedBy)   
                           &&(query.UpdatedDate == default || e.UpdatedDate == query.UpdatedDate)   
                           &&(query.UpdatedBy == default || e.UpdatedBy == query.UpdatedBy)   
                           &&(query.Exam == default || e.Exam == query.Exam)   
                           &&(query.Question == default || e.Question == query.Question)   
                           
                        )
                        .Select(x => x);
      }
      public async Task<ExamQuestion> GetModelAsync(ExamQuestion query, CancellationToken cancellationToken = default)
      {
         return await dbContext.Set<ExamQuestion>()
                        .AsNoTracking()
                        .FirstOrDefaultAsync(e => 
                           (query.ExamFId == default || e.ExamFId == query.ExamFId)&&(query.QuestionFId == default || e.QuestionFId == query.QuestionFId),cancellationToken);
      }
      public async Task<List<ExamQuestion>> QueryListAsync(ExamQuestion query, CancellationToken cancellationToken = default)
      {
         return await Filter(query, cancellationToken)
				.ToListAsync(cancellationToken);
      }
      public async Task<bool> ExistsAsync(ExamQuestion query, CancellationToken cancellationToken = default)
      {
         return await dbContext.Set<ExamQuestion>()
                        .AsNoTracking()
                        .AnyAsync(e => 
                           (query.ExamFId == default || e.ExamFId == query.ExamFId)&&(query.QuestionFId == default || e.QuestionFId == query.QuestionFId),cancellationToken);
      }

       protected IQueryable<MilitaryInformation> Filter(MilitaryInformation query, CancellationToken cancellationToken = default)
      {
         return dbContext.Set<MilitaryInformation>()
                        .AsNoTracking()
                        .Where(e => 
                           (query.id == default || e.id == query.id)   
                           &&(query.FirstName == default || e.FirstName.Contains(query.FirstName))   
                           &&(query.LastName == default || e.LastName.Contains(query.LastName))   
                           &&(query.MilitaryLevel == default || e.MilitaryLevel.Contains(query.MilitaryLevel))   
                           &&(query.MilitaryPosition == default || e.MilitaryPosition.Contains(query.MilitaryPosition))   
                           &&(query.WorkUnit == default || e.WorkUnit.Contains(query.WorkUnit))   
                           &&(query.Image == default || e.Image.Contains(query.Image))   
                           &&(query.PhoneNumber == default || e.PhoneNumber.Contains(query.PhoneNumber))   
                           &&(query.UniqueId == default || e.UniqueId == query.UniqueId)   
                           &&(query.CreatedDate == default || e.CreatedDate == query.CreatedDate)   
                           &&(query.CreatedBy == default || e.CreatedBy == query.CreatedBy)   
                           &&(query.UpdatedDate == default || e.UpdatedDate == query.UpdatedDate)   
                           &&(query.UpdatedBy == default || e.UpdatedBy == query.UpdatedBy)   
                           &&(query.Classes == default || e.Classes == query.Classes)   
                           &&(query.Exams == default || e.Exams == query.Exams)   
                           &&(query.Students == default || e.Students == query.Students)   
                           &&(query.Users == default || e.Users == query.Users)   
                           
                        )
                        .Select(x => x);
      }
      public async Task<MilitaryInformation> GetModelAsync(MilitaryInformation query, CancellationToken cancellationToken = default)
      {
         return await dbContext.Set<MilitaryInformation>()
                        .AsNoTracking()
                        .FirstOrDefaultAsync(e => 
                           (query.id == default || e.id == query.id)&&(query.UniqueId == default || e.UniqueId == query.UniqueId),cancellationToken);
      }
      public async Task<List<MilitaryInformation>> QueryListAsync(MilitaryInformation query, CancellationToken cancellationToken = default)
      {
         return await Filter(query, cancellationToken)
				.ToListAsync(cancellationToken);
      }
      public async Task<bool> ExistsAsync(MilitaryInformation query, CancellationToken cancellationToken = default)
      {
         return await dbContext.Set<MilitaryInformation>()
                        .AsNoTracking()
                        .AnyAsync(e => 
                           (query.id == default || e.id == query.id)&&(query.UniqueId == default || e.UniqueId == query.UniqueId),cancellationToken);
      }

       protected IQueryable<Question> Filter(Question query, CancellationToken cancellationToken = default)
      {
         return dbContext.Set<Question>()
                        .AsNoTracking()
                        .Where(e => 
                           (query.id == default || e.id == query.id)   
                           &&(query.Content == default || e.Content.Contains(query.Content))   
                           &&(query.ImageUrl == default || e.ImageUrl.Contains(query.ImageUrl))   
                           &&(query.SubjectName == default || e.SubjectName.Contains(query.SubjectName))   
                           &&(query.QuestionLevel == default || e.QuestionLevel == query.QuestionLevel)   
                           &&(query.CreatedDate == default || e.CreatedDate == query.CreatedDate)   
                           &&(query.CreatedBy == default || e.CreatedBy == query.CreatedBy)   
                           &&(query.UpdatedDate == default || e.UpdatedDate == query.UpdatedDate)   
                           &&(query.UpdatedBy == default || e.UpdatedBy == query.UpdatedBy)   
                           &&(query.ExamQuestions == default || e.ExamQuestions == query.ExamQuestions)   
                           &&(query.QuestionChoices == default || e.QuestionChoices == query.QuestionChoices)   
                           
                        )
                        .Select(x => x);
      }
      public async Task<Question> GetModelAsync(Question query, CancellationToken cancellationToken = default)
      {
         return await dbContext.Set<Question>()
                        .AsNoTracking()
                        .FirstOrDefaultAsync(e => 
                           (query.id == default || e.id == query.id),cancellationToken);
      }
      public async Task<List<Question>> QueryListAsync(Question query, CancellationToken cancellationToken = default)
      {
         return await Filter(query, cancellationToken)
				.ToListAsync(cancellationToken);
      }
      public async Task<bool> ExistsAsync(Question query, CancellationToken cancellationToken = default)
      {
         return await dbContext.Set<Question>()
                        .AsNoTracking()
                        .AnyAsync(e => 
                           (query.id == default || e.id == query.id),cancellationToken);
      }

       protected IQueryable<QuestionChoice> Filter(QuestionChoice query, CancellationToken cancellationToken = default)
      {
         return dbContext.Set<QuestionChoice>()
                        .AsNoTracking()
                        .Where(e => 
                           (query.id == default || e.id == query.id)   
                           &&(query.QuestionFId == default || e.QuestionFId == query.QuestionFId)   
                           &&(query.content == default || e.content.Contains(query.content))   
                           &&(query.ImageUrl == default || e.ImageUrl.Contains(query.ImageUrl))   
                           &&(query.is_answer == default || e.is_answer == query.is_answer)   
                           &&(query.CreatedDate == default || e.CreatedDate == query.CreatedDate)   
                           &&(query.CreatedBy == default || e.CreatedBy == query.CreatedBy)   
                           &&(query.UpdatedDate == default || e.UpdatedDate == query.UpdatedDate)   
                           &&(query.UpdatedBy == default || e.UpdatedBy == query.UpdatedBy)   
                           &&(query.Question == default || e.Question == query.Question)   
                           &&(query.StudentTests == default || e.StudentTests == query.StudentTests)   
                           
                        )
                        .Select(x => x);
      }
      public async Task<QuestionChoice> GetModelAsync(QuestionChoice query, CancellationToken cancellationToken = default)
      {
         return await dbContext.Set<QuestionChoice>()
                        .AsNoTracking()
                        .FirstOrDefaultAsync(e => 
                           (query.id == default || e.id == query.id)&&(query.QuestionFId == default || e.QuestionFId == query.QuestionFId),cancellationToken);
      }
      public async Task<List<QuestionChoice>> QueryListAsync(QuestionChoice query, CancellationToken cancellationToken = default)
      {
         return await Filter(query, cancellationToken)
				.ToListAsync(cancellationToken);
      }
      public async Task<bool> ExistsAsync(QuestionChoice query, CancellationToken cancellationToken = default)
      {
         return await dbContext.Set<QuestionChoice>()
                        .AsNoTracking()
                        .AnyAsync(e => 
                           (query.id == default || e.id == query.id)&&(query.QuestionFId == default || e.QuestionFId == query.QuestionFId),cancellationToken);
      }

       protected IQueryable<RefreshToken> Filter(RefreshToken query, CancellationToken cancellationToken = default)
      {
         return dbContext.Set<RefreshToken>()
                        .AsNoTracking()
                        .Where(e => 
                           (query.id == default || e.id == query.id)   
                           &&(query.UserFId == default || e.UserFId == query.UserFId)   
                           &&(query.TokenHash == default || e.TokenHash.Contains(query.TokenHash))   
                           &&(query.TokenSalt == default || e.TokenSalt.Contains(query.TokenSalt))   
                           &&(query.TS == default || e.TS == query.TS)   
                           &&(query.ExpiryDate == default || e.ExpiryDate == query.ExpiryDate)   
                           &&(query.CreatedDate == default || e.CreatedDate == query.CreatedDate)   
                           &&(query.CreatedBy == default || e.CreatedBy == query.CreatedBy)   
                           &&(query.UpdatedDate == default || e.UpdatedDate == query.UpdatedDate)   
                           &&(query.UpdatedBy == default || e.UpdatedBy == query.UpdatedBy)   
                           &&(query.User == default || e.User == query.User)   
                           
                        )
                        .Select(x => x);
      }
      public async Task<RefreshToken> GetModelAsync(RefreshToken query, CancellationToken cancellationToken = default)
      {
         return await dbContext.Set<RefreshToken>()
                        .AsNoTracking()
                        .FirstOrDefaultAsync(e => 
                           (query.id == default || e.id == query.id)&&(query.UserFId == default || e.UserFId == query.UserFId),cancellationToken);
      }
      public async Task<List<RefreshToken>> QueryListAsync(RefreshToken query, CancellationToken cancellationToken = default)
      {
         return await Filter(query, cancellationToken)
				.ToListAsync(cancellationToken);
      }
      public async Task<bool> ExistsAsync(RefreshToken query, CancellationToken cancellationToken = default)
      {
         return await dbContext.Set<RefreshToken>()
                        .AsNoTracking()
                        .AnyAsync(e => 
                           (query.id == default || e.id == query.id)&&(query.UserFId == default || e.UserFId == query.UserFId),cancellationToken);
      }

       protected IQueryable<Student> Filter(Student query, CancellationToken cancellationToken = default)
      {
         return dbContext.Set<Student>()
                        .AsNoTracking()
                        .Where(e => 
                           (query.id == default || e.id == query.id)   
                           &&(query.Class == default || e.Class == query.Class)   
                           &&(query.StudentCode == default || e.StudentCode.Contains(query.StudentCode))   
                           &&(query.MilitaryInformationFId == default || e.MilitaryInformationFId == query.MilitaryInformationFId)   
                           &&(query.CreatedDate == default || e.CreatedDate == query.CreatedDate)   
                           &&(query.CreatedBy == default || e.CreatedBy == query.CreatedBy)   
                           &&(query.UpdatedDate == default || e.UpdatedDate == query.UpdatedDate)   
                           &&(query.UpdatedBy == default || e.UpdatedBy == query.UpdatedBy)   
                           &&(query.MilitaryInformation == default || e.MilitaryInformation == query.MilitaryInformation)   
                           &&(query.Tests == default || e.Tests == query.Tests)   
                           
                        )
                        .Select(x => x);
      }
      public async Task<Student> GetModelAsync(Student query, CancellationToken cancellationToken = default)
      {
         return await dbContext.Set<Student>()
                        .AsNoTracking()
                        .FirstOrDefaultAsync(e => 
                           (query.id == default || e.id == query.id)&&(query.StudentCode == default || e.StudentCode.Contains(query.StudentCode))&&(query.MilitaryInformationFId == default || e.MilitaryInformationFId == query.MilitaryInformationFId),cancellationToken);
      }
      public async Task<List<Student>> QueryListAsync(Student query, CancellationToken cancellationToken = default)
      {
         return await Filter(query, cancellationToken)
				.ToListAsync(cancellationToken);
      }
      public async Task<bool> ExistsAsync(Student query, CancellationToken cancellationToken = default)
      {
         return await dbContext.Set<Student>()
                        .AsNoTracking()
                        .AnyAsync(e => 
                           (query.id == default || e.id == query.id)&&(query.StudentCode == default || e.StudentCode.Contains(query.StudentCode))&&(query.MilitaryInformationFId == default || e.MilitaryInformationFId == query.MilitaryInformationFId),cancellationToken);
      }

       protected IQueryable<StudentTest> Filter(StudentTest query, CancellationToken cancellationToken = default)
      {
         return dbContext.Set<StudentTest>()
                        .AsNoTracking()
                        .Where(e => 
                           (query.id == default || e.id == query.id)   
                           &&(query.TestFId == default || e.TestFId == query.TestFId)   
                           &&(query.Choice == default || e.Choice == query.Choice)   
                           &&(query.CreatedDate == default || e.CreatedDate == query.CreatedDate)   
                           &&(query.CreatedBy == default || e.CreatedBy == query.CreatedBy)   
                           &&(query.UpdatedDate == default || e.UpdatedDate == query.UpdatedDate)   
                           &&(query.UpdatedBy == default || e.UpdatedBy == query.UpdatedBy)   
                           &&(query.Test == default || e.Test == query.Test)   
                           &&(query.QuestionChoice == default || e.QuestionChoice == query.QuestionChoice)   
                           
                        )
                        .Select(x => x);
      }
      public async Task<StudentTest> GetModelAsync(StudentTest query, CancellationToken cancellationToken = default)
      {
         return await dbContext.Set<StudentTest>()
                        .AsNoTracking()
                        .FirstOrDefaultAsync(e => 
                           (query.id == default || e.id == query.id)&&(query.TestFId == default || e.TestFId == query.TestFId),cancellationToken);
      }
      public async Task<List<StudentTest>> QueryListAsync(StudentTest query, CancellationToken cancellationToken = default)
      {
         return await Filter(query, cancellationToken)
				.ToListAsync(cancellationToken);
      }
      public async Task<bool> ExistsAsync(StudentTest query, CancellationToken cancellationToken = default)
      {
         return await dbContext.Set<StudentTest>()
                        .AsNoTracking()
                        .AnyAsync(e => 
                           (query.id == default || e.id == query.id)&&(query.TestFId == default || e.TestFId == query.TestFId),cancellationToken);
      }

       protected IQueryable<Test> Filter(Test query, CancellationToken cancellationToken = default)
      {
         return dbContext.Set<Test>()
                        .AsNoTracking()
                        .Where(e => 
                           (query.id == default || e.id == query.id)   
                           &&(query.ExamFId == default || e.ExamFId == query.ExamFId)   
                           &&(query.StudentFId == default || e.StudentFId == query.StudentFId)   
                           &&(query.CreatedDate == default || e.CreatedDate == query.CreatedDate)   
                           &&(query.TestingTime == default || e.TestingTime == query.TestingTime)   
                           &&(query.UniqueId == default || e.UniqueId == query.UniqueId)   
                           &&(query.CreatedBy == default || e.CreatedBy == query.CreatedBy)   
                           &&(query.UpdatedDate == default || e.UpdatedDate == query.UpdatedDate)   
                           &&(query.UpdatedBy == default || e.UpdatedBy == query.UpdatedBy)   
                           &&(query.Exam == default || e.Exam == query.Exam)   
                           &&(query.Student == default || e.Student == query.Student)   
                           &&(query.StudentTests == default || e.StudentTests == query.StudentTests)   
                           
                        )
                        .Select(x => x);
      }
      public async Task<Test> GetModelAsync(Test query, CancellationToken cancellationToken = default)
      {
         return await dbContext.Set<Test>()
                        .AsNoTracking()
                        .FirstOrDefaultAsync(e => 
                           (query.id == default || e.id == query.id)&&(query.ExamFId == default || e.ExamFId == query.ExamFId)&&(query.StudentFId == default || e.StudentFId == query.StudentFId)&&(query.UniqueId == default || e.UniqueId == query.UniqueId),cancellationToken);
      }
      public async Task<List<Test>> QueryListAsync(Test query, CancellationToken cancellationToken = default)
      {
         return await Filter(query, cancellationToken)
				.ToListAsync(cancellationToken);
      }
      public async Task<bool> ExistsAsync(Test query, CancellationToken cancellationToken = default)
      {
         return await dbContext.Set<Test>()
                        .AsNoTracking()
                        .AnyAsync(e => 
                           (query.id == default || e.id == query.id)&&(query.ExamFId == default || e.ExamFId == query.ExamFId)&&(query.StudentFId == default || e.StudentFId == query.StudentFId)&&(query.UniqueId == default || e.UniqueId == query.UniqueId),cancellationToken);
      }

       protected IQueryable<User> Filter(User query, CancellationToken cancellationToken = default)
      {
         return dbContext.Set<User>()
                        .AsNoTracking()
                        .Where(e => 
                           (query.id == default || e.id == query.id)   
                           &&(query.Username == default || e.Username.Contains(query.Username))   
                           &&(query.PasswordHash == default || e.PasswordHash.Contains(query.PasswordHash))   
                           &&(query.CreateDate == default || e.CreateDate == query.CreateDate)   
                           &&(query.status == default || e.status == query.status)   
                           &&(query.MilitaryInformationFId == default || e.MilitaryInformationFId == query.MilitaryInformationFId)   
                           &&(query.UniqueId == default || e.UniqueId == query.UniqueId)   
                           &&(query.Password == default || e.Password.Contains(query.Password))   
                           &&(query.PasswordSalt == default || e.PasswordSalt.Contains(query.PasswordSalt))   
                           &&(query.Active == default || e.Active == query.Active)   
                           &&(query.FirstName == default || e.FirstName.Contains(query.FirstName))   
                           &&(query.LastName == default || e.LastName.Contains(query.LastName))   
                           &&(query.Email == default || e.Email.Contains(query.Email))   
                           &&(query.CreatedDate == default || e.CreatedDate == query.CreatedDate)   
                           &&(query.CreatedBy == default || e.CreatedBy == query.CreatedBy)   
                           &&(query.UpdatedDate == default || e.UpdatedDate == query.UpdatedDate)   
                           &&(query.UpdatedBy == default || e.UpdatedBy == query.UpdatedBy)   
                           &&(query.MilitaryInformation == default || e.MilitaryInformation == query.MilitaryInformation)   
                           &&(query.RefreshTokens == default || e.RefreshTokens == query.RefreshTokens)   
                           
                        )
                        .Select(x => x);
      }
      public async Task<User> GetModelAsync(User query, CancellationToken cancellationToken = default)
      {
         return await dbContext.Set<User>()
                        .AsNoTracking()
                        .FirstOrDefaultAsync(e => 
                           (query.id == default || e.id == query.id)&&(query.MilitaryInformationFId == default || e.MilitaryInformationFId == query.MilitaryInformationFId)&&(query.UniqueId == default || e.UniqueId == query.UniqueId),cancellationToken);
      }
      public async Task<List<User>> QueryListAsync(User query, CancellationToken cancellationToken = default)
      {
         return await Filter(query, cancellationToken)
				.ToListAsync(cancellationToken);
      }
      public async Task<bool> ExistsAsync(User query, CancellationToken cancellationToken = default)
      {
         return await dbContext.Set<User>()
                        .AsNoTracking()
                        .AnyAsync(e => 
                           (query.id == default || e.id == query.id)&&(query.MilitaryInformationFId == default || e.MilitaryInformationFId == query.MilitaryInformationFId)&&(query.UniqueId == default || e.UniqueId == query.UniqueId),cancellationToken);
      }

       
    }
}