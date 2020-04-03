namespace ToDosManagerBackSide.Domain.Entities
{
    public class Record
    {
        public int Id { get; set; }
        public int DayId { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
    }
}