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

namespace PlannerApp.Pages.Plans
{
    public partial class CreateEditPlan
    {
        private List<BreadcrumbItem> _BreadcrumbItems = new List<BreadcrumbItem>()
        {
            new BreadcrumbItem("Home", "/"),
            new BreadcrumbItem("Plans","plans"),
            new BreadcrumbItem("Create","plans/form",true)
        };

    }
}