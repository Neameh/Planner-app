using Microsoft.AspNetCore.Http;

namespace PlannerApp.Shared.Models
{
    public class PlanDetails : PlanSummary
    {
        public IFormFile CoverFile { get; set; }
        // Add To Do Items here 

        public List<ToDoItems> ToDoItems { get; set; }
    }
}
