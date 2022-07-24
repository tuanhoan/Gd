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
using GD.Data.Models.Requests;

namespace GD.Data.Services
{
    public partial class ChangeService : EfChange<GDContext>, IChangeService
    {
        public async Task Submit(List<QuizRequest> quizRequest)
        {
            var datas = await dbContext.QuestionChoices.ToListAsync();
            var list = new List<ChoiceQuestion>();

            foreach (var quiz in quizRequest)
            {
                var qsId = Convert.ToInt32(quiz.answerChoice.Split(",").ToList().FirstOrDefault());
                var answer = datas.FirstOrDefault(x => x.QuestionFId == quiz.questionId && x.is_answer == true);

                var ds = new ChoiceQuestion
                {
                    AnswerChoice = qsId,
                    QuestionId = quiz.questionId,
                    IsCorrect = answer?.id == qsId ? true : false,
                    AswerCorrect = answer?.id
                };
                list.Add(ds);
            }

            quizRequest.ForEach(item =>
            {
                var choices = item.answerChoice.Split(",").ToList();
            });
            await SaveAsync();
        }


    }
    public class ChoiceQuestion
    {
        public int QuestionId { get; set; }
        public int AnswerChoice { get; set; }
        public int? AswerCorrect { get; set; }
        public bool IsCorrect { get; set; }
    }
}