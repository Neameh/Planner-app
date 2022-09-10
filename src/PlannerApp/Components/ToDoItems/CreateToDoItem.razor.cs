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
using PlannerApp.Client.Services.Interfaces;
using PlannerApp.Client.Services.Exceptions;
using PlannerApp.Shared.Models;

namespace PlannerApp.Components
{
    public partial class CreateToDoItem
    {
        [Inject]
        public IToDoItemService toDoItemService { get; set; }

        [Parameter]
        public string PlanId { get; set; }

        private bool _isBusy = false;
        private string _description;
        private string _errorMessage = string.Empty;

        [Parameter]
        // ??
        public EventCallback<ToDoItems> OnToDoItemAdded { get; set; }

        private async Task AddItem()
        {
            _errorMessage = String.Empty;
            try
            {
                if(string.IsNullOrEmpty(_description))
                {
                    _errorMessage = "Description is required";
                    return;
                }
                _isBusy = true;
                // Call the API to add the item 
                var result = await toDoItemService.CreateItemAsync(PlanId, _description);
                _description = string.Empty;

                // Notify the parent that there is TODOItem added 
                // function for this event call back  ?
                await OnToDoItemAdded.InvokeAsync(result.Value);

                _isBusy = false;

            }
            // Error from the API like invalid Error
            catch(ApiException ex)
            {
                _errorMessage = ex.ApiErrorResponse.Message;
            }
            catch (Exception)
            {
                // TODO : Handle this exception 
            }

        

        }

    }
}