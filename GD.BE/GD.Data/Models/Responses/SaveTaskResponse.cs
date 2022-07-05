namespace GD.Responses
{
    public class SaveTaskResponse : BaseResponse
    {
        public GD.Entity.Table.Task Task { get; set; }
    }
}
