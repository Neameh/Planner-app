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
using PlannerApp.Shared.Models;
using AKSoftware.Blazor.Utilities;

namespace PlannerApp.Components
{
    public partial class PlansTable
    {
        [Inject]
        public IPlanService PlanService { get; set; }
        [Parameter]
        public EventCallback<PlanSummary> OnViewClicked { get; set; }
        [Parameter]
        public EventCallback<PlanSummary> OnEditClicked { get; set; }
        [Parameter]
        public EventCallback<PlanSummary> OnDeleteClicked { get; set; }

        private string _query = string.Empty;
        private MudTable<PlanSummary> _table; // what this ? 

        protected override void OnInitialized()
        {
            MessagingCenter.Subscribe<PlansList,PlanSummary>(this,"Plan_deleted",async (sender,args) =>
            {
                await _table.ReloadServerData();
                StateHasChanged();
            }
            );
        }
        private async Task<TableData<PlanSummary>> ServerReloadAsync(TableState state)
        {
            var result = await PlanService.GetPlanSync(_query,state.Page,state.PageSize);
            return new TableData<PlanSummary>()
            {
                Items = result.Value.Records,
                TotalItems = result.Value.ItemCount
            };
        }
        private void OnSearch(string query)
        {
            _query = query;
            _table.ReloadServerData();
        }
    }
}