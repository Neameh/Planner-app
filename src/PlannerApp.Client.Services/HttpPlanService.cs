using PlannerApp.Client.Services.Exceptions;
using PlannerApp.Client.Services.Interfaces;
using PlannerApp.Shared.Models;
using PlannerApp.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApp.Client.Services
{
    public class HttpPlanService : IPlanService
    {
        private readonly HttpClient _httpClient;
        public HttpPlanService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponse<PagedList<PlanSummary>>> GetPlanSync(string query = null, int PageNumber = 1, int PageSize = 10)
        {
            var Response = await _httpClient.GetAsync($"/api/v2/Plans?query={query}&PageNumber={PageNumber}&PageSize={PageSize}");
            if(Response.IsSuccessStatusCode)
            {
                var result = await Response.Content.ReadFromJsonAsync<ApiResponse<PagedList<PlanSummary>>>();
                return result;
            }
            else
            {
                var errorResponse = await Response.Content.ReadFromJsonAsync<ApiErrorResponse>();
                throw new ApiException(errorResponse, Response.StatusCode);
            }
        }
    }
}
