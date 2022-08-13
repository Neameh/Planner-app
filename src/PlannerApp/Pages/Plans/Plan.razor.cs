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

namespace PlannerApp.Components
{
    public partial class Plan
    {
        private List<BreadcrumbItem> _Breadcrumbs  = new List<BreadcrumbItem>()
        {
            new BreadcrumbItem("Home" , "/index"),
            new BreadcrumbItem("Plans" ,"/plans" , true )
        };
    }
}