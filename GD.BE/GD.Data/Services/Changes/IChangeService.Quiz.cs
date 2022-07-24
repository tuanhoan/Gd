using GD.Data.Models.Requests;
using GD.Entity.Tables;
using GD.SDK.Data;
using GD.SDK.Models;

namespace GD.Data.Services.Interface
{
    public partial interface IChangeService : IAsyncChange, IUnitOfWork
	{
        Task Submit(List<QuizRequest> quizRequest);
        
	}
}