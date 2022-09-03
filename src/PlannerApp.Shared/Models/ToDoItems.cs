namespace PlannerApp.Shared.Models
{
    public class ToDoItems
    {
        public string Id { get; set; }
        public string Description { get; set; }
        //public DateTime estimationDate { get; set; }
        //public DateTime achievedDate { get; set; }
        public bool IsDone { get; set; }
        public string PlanId { get; set; }


    }
}
