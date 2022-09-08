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
    public class HttpToDoItemService : IToDoItemService
    {
        private readonly HttpClient _httpClient;
        public HttpToDoItemService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ApiResponse<ToDoItems>> CreateItemAsync(string planId, string description)
        {
            var Response = await _httpClient.PostAsJsonAsync("/api/v2/ToDos", new
            {
                planId = planId,
                description = description
            });
            if (Response.IsSuccessStatusCode)
            {
                var result = await Response.Content.ReadFromJsonAsync<ApiResponse<ToDoItems>>();
                return result;
            }
            else
            {
                var errorResponse = await Response.Content.ReadFromJsonAsync<ApiErrorResponse>();
                throw new Exception(errorResponse.Message);
            }
        }

        public async Task<ApiResponse<ToDoItems>> EditItemAsync(string planId, string description, string Id)
        {
            // new ? 
            var Response = await _httpClient.PutAsJsonAsync("/api/v2/ToDos", new
            {
                planId = planId,
                description = description,
                Id = Id
            });
            if (Response.IsSuccessStatusCode)
            {
                var result = await Response.Content.ReadFromJsonAsync<ApiResponse<ToDoItems>>();
                return result;
            }
            else
            {
                var errorResponse = await Response.Content.ReadFromJsonAsync<ApiErrorResponse>();
                throw new ApiException(errorResponse, Response.StatusCode);
            }
        }

        public async Task DeleteItemAsync(string id)
        {
            var response =await _httpClient.DeleteAsync($"api/v2/ToDos/{id}");
            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
                throw new ApiException(errorResponse, response.StatusCode);
            }

        }
        public async Task ToggleItemAync(string id)
        {
            var response = await _httpClient.PutAsJsonAsync<object>($"api/v2/ToDos/{id}",null);
            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
                throw new ApiException(errorResponse, response.StatusCode);
            }
        }
    }
}
