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

        public async Task<ApiResponse<PlanDetails>> CreatePlanAsync(PlanDetails model, FormFile coverFile)
        {
            var form = PreparePlanForm(model, coverFile,false);
            var response = await _httpClient.PostAsync("/api/v2/Plans", form);
            if(response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ApiResponse<PlanDetails>>();
                return result;
            }  
            else
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
                throw new ApiException(errorResponse, response.StatusCode);
            }


        }

        public async Task<ApiResponse<PlanDetails>> EditPlanAsync(PlanDetails model, FormFile coverFile)
        {
            var form = PreparePlanForm(model, coverFile, true);
            var response = await _httpClient.PutAsync("/api/v2/Plans", form);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ApiResponse<PlanDetails>>();
                return result;
            }
            else
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
                throw new ApiException(errorResponse, response.StatusCode);
            }
        }

        public async Task<ApiResponse<PlanDetails>> GetPlanById(string id)
        {
            var response = await _httpClient.GetAsync($"/api/v2/Plans/{id}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ApiResponse<PlanDetails>>();
                return result;
            }
            else
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
                throw new ApiException(errorResponse, response.StatusCode);
            }
        }

        public async Task<ApiResponse<PagedList<PlanSummary>>> GetPlanSync(string query = null, int pageNumber = 1, int pageSize = 10)
        {
            var Response = await _httpClient.GetAsync($"/api/v2/plans?query={query}&pageNumber={pageNumber}&pageSize={pageSize}");
            if (Response.IsSuccessStatusCode)
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
        private HttpContent PreparePlanForm(PlanDetails model, FormFile CoverFile, bool isUpdated)
        {
            var form = new MultipartFormDataContent();
            form.Add(new StringContent(model.title), nameof(PlanDetails.title));
            if (!String.IsNullOrEmpty(model.Description))
                form.Add(new StringContent(model.Description), nameof(PlanDetails.Description));
            if (isUpdated)
                form.Add(new StringContent(model.id), nameof(PlanDetails.id));
            if (CoverFile != null)
                //form.Add(new StreamContent(CoverFile.FileStream), nameof(CoverFile.FileName)); !
                form.Add(new StreamContent(CoverFile.FileStream), nameof(model.CoverFile),CoverFile.FileName);
            return form;
        }
    }
}
