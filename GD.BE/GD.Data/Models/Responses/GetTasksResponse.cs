namespace GD.Responses
{
    public class GetTasksResponse : BaseResponse
    {
        public List<GD.Entity.Table.Task> Tasks { get; set; }
    }
}
