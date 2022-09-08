using PlannerApp.Shared.Models;
using PlannerApp.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApp.Client.Services.Interfaces
{
    public interface IToDoItemService
    {
        // How I know what the parametes that I should Pass 
        // Why we use ApiResponse 
        Task<ApiResponse<ToDoItems>> CreateItemAsync(string planId, string description);
        Task<ApiResponse<ToDoItems>> EditItemAsync(string planId, string description, string Id);

        Task ToggleItemAync(string Id);
        Task DeleteItemAsync(string Id);

    }
}
