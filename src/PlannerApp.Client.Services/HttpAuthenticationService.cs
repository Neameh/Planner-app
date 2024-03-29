﻿using Microsoft.Win32;
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
    public class HttpAuthenticationService : IAthenticationService
    {
        private readonly HttpClient _httpClient ;
        public HttpAuthenticationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponse> RegisterUserAsync(RegisterRequest model)
{
            var response = await _httpClient.PostAsJsonAsync("/api/v2/Auth/Register",model);
            if(response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ApiResponse>();
                return result;
            }
            else
            {
                var errorRespones = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
                throw new ApiException(errorRespones, response.StatusCode);

            }
                
        }
    }
}
