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
using PlannerApp.Shared.Models;

namespace PlannerApp.Components
{
    public partial class PlanCardsList
    {
        private int _pageNumber = 1;
        private int _pageSize = 10;
        private string _query = string.Empty;
        private bool _isBusy;

        private PagedList<PlanSummary> _result = new();

        [Parameter]
        public  Func<string,int,int,Task<PagedList<PlanSummary>>> FetchPlans { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await GetPlans();
        }

        private async Task GetPlans(int pageNumber = 1)
        {
            _pageNumber = pageNumber;
            _isBusy = true;
            _result = await FetchPlans?.Invoke(_query, _pageNumber, _pageSize);
            _isBusy = false;
        }
    }
}