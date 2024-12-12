namespace TaskListCRUD.DataAccess
{
    public class TaskListData
    {
        public long id { get; set; }
        public string? nameTask { get; set; }
        public string? description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool finishTask { get; set; }
    }
}
