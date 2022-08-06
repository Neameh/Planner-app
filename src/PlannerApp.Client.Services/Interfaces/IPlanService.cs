using PlannerApp.Shared.Models;
using PlannerApp.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApp.Client.Services.Interfaces
{
    public interface  IPlanService
    {
        Task<ApiResponse<PagedList<PlanSummary>>> GetPlanSync(string query,int PageNumber=1,int PageSize=10);
    }
}
