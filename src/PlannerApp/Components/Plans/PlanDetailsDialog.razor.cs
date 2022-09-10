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
using PlannerApp.Components;
using PlannerApp.Shared.Models;
using PlannerApp.Client.Services.Interfaces;
using PlannerApp.Client.Services.Exceptions;

namespace PlannerApp.Components
{
    public partial class PlanDetailsDialog
    {
        [CascadingParameter] 
        MudDialogInstance MudDialog { get; set; }
        // We fetch the planId and not the plan cause I can use this dialog over all the app
        [Parameter]
        public string PlanId { get; set; }

        [Inject]
        public IPlanService planService { get; set; }

        private bool _isBusy;
        private PlanDetails _plan;

        private async Task FetchPlanAsync()
        {
            _isBusy = true;
            try
            {
                var result = await planService.GetPlanById(PlanId);
                _plan = result.Value;
            }
            catch(ApiException ex)
            {
                // To Do : Handle this exception
            }
            catch (Exception ex)
            {

                // To Do : Habdle this exception
            }
            _isBusy = false;
        }
        protected override void OnParametersSet()
        {
            if (PlanId == null)
                throw new ArgumentNullException(nameof(PlanId));
            base.OnParametersSet();
        }
        protected async override Task OnInitializedAsync()
        {
            await FetchPlanAsync();
        }
        private void Close()
        {
            MudDialog.Cancel();
        }

        private void OnToDoItemAddedCallback(ToDoItems toDoItems)
        {
            Console.WriteLine(toDoItems.Id);
            Console.WriteLine(toDoItems.Description);
        }
    }
}