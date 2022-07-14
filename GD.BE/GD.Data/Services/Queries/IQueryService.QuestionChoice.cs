using GD.Entity.Tables;
using GD.SDK.Data;
using GD.SDK.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using GD.Data.Dto.QuestionChoice;

namespace GD.Data.Services.Interface
{
    public partial interface IQueryService : IAsyncQuery
    {
        Task<List<QuestionsDto>> GetQuestionChoices();
    }
}