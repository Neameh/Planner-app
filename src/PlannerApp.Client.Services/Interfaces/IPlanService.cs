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
        Task<ApiResponse<PagedList<PlanSummary>>> GetPlanSync(string query,int pageNumber=1,int pageSize=10);

        Task<ApiResponse<PlanDetails>> CreatePlanAsync(PlanDetails model, FormFile coverFile );
        Task<ApiResponse<PlanDetails>> EditPlanAsync(PlanDetails model, FormFile coverFile);

        Task<ApiResponse<PlanDetails>> GetPlanById(string Id);

        Task DeletePlanAsync(string Id);

    }
}
