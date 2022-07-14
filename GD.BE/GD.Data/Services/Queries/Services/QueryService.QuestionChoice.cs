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
using GD.Data.Dto.QuestionChoice;

namespace GD.Data.Services
{
    public partial class QueryService : EfQuery<GDContext>, IQueryService
    {
        public async Task<List<QuestionsDto>> GetQuestionChoices()
        {
            Random rdn = new Random();
            var questionChoices = await dbContext.QuestionChoices.ToListAsync();
            var questions = await dbContext.Questions
                .ToListAsync();
            var result = new List<QuestionsDto>();

            foreach (var item in questions.OrderBy(x => rdn.Next(0, questions.Count)).Distinct().Take(10))
            {
                var questionC = questionChoices.Where(x => x.QuestionFId == item.id)
                    .Select(x => new QuestionChoiceDto
                    {
                        Id = x.id,
                        content = x.content,
                        ImgUrl = x.ImageUrl,
                        IsAnswer = x.is_answer,
                    }).ToList();
                result.Add(new QuestionsDto
                {
                    QuestionId = item.id,
                    content = item.content,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    ImgUrl = item.ImageUrl,
                    QuestionChoiceDtos = questionC,
                    SubjectName = item.SubjectName,
                    IsMultiple = questionC.Count(x => x.IsAnswer == true) > 1 ? true : false
                });
            }

            return result;
        }
    }
}