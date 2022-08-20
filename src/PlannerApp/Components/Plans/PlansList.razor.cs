using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using PlannerApp;
using PlannerApp.Shared;
using MudBlazor;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using PlannerApp.Shared.Components;
using Blazored.FluentValidation;
using PlannerApp.Client.Services.Interfaces;
using PlannerApp.Client.Services.Exceptions;
using PlannerApp.Shared.Models;

namespace PlannerApp.Components
{
    public partial class PlansList
    {
        [Inject]
        public IPlanService PlanService { get; set; }
        [Inject]
        public NavigationManager Navigation { get; set; }

        private bool _isBusy;
        private string _errorMessage;
        private int _pageNumber = 1;
        private int _pageSize = 10;
        private string _query = string.Empty;

        private List<PlanSummary> _plans = new List<PlanSummary>();
        public async Task<PagedList<PlanSummary>> GetPlansAsync(string query = "", int pageNumber = 1 , int pageSize = 10)
        {
            _isBusy = true;
            try
            {
                var result =await PlanService.GetPlanSync(query, pageNumber, pageSize);
                _plans = result.Value.Records.ToList();
                _pageNumber = result.Value.Page;
                _pageSize = result.Value.PageSize;

                return result.Value;
            }
            catch(ApiException ex)
            {
                _errorMessage = ex.ApiErrorResponse.Message;
                Console.WriteLine(_errorMessage);
            }
            catch (Exception ex)
            {
                _errorMessage = ex.Message;
                Console.WriteLine(_errorMessage);

            }
            _isBusy = false;
            return null;
        }
        #region Toggler
        private bool _isPlansCardView { get; set; } = true;

        private void SetPlansCardView()
        {
            _isPlansCardView = true;
        }
        private void SetPlansListView()
        {
            _isPlansCardView = false;
        }
        #endregion

        #region Edit Plan 
        private void EditPlan(PlanSummary plan)
        {
            Navigation.NavigateTo($"plans/form/{plan.id}");
        }
        #endregion

    }
}