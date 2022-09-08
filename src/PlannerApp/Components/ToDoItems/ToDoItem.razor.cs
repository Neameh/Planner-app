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

namespace PlannerApp.Components
{
    public partial class ToDoItem
    {
        [Parameter]
        public ToDoItems ToDoItems { get; set; }

        private bool _isChecked = false;
        private bool _isEditMode = false;
        private string _description = " Study blazor with .Net 6 and Asp.net core";
    }
}