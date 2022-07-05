using TasksApi.Responses;
using TasksApi.Entity.Table;
namespace TasksApi.Data.Interfaces
{
    public interface ITaskService
    {
        Task<GetTasksResponse> GetTasks(int userId);

        Task<SaveTaskResponse> SaveTask(Entity.Table.Task task);

        Task<DeleteTaskResponse> DeleteTask(int taskId, int userId);
    }
}
