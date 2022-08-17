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

namespace PlannerApp.Components
{
    public partial class PlanForm
    {
        [Inject]
        public IPlanService PlanService { get; set; }

        private bool _isBusy = false;
        private PlanDetails _model = new PlanDetails();
        private Stream _stream = null;
        private string _fileName = string.Empty;
        private string _errorMessage = String.Empty;

        private async Task OnSubmitFormAsync()
        {
             _errorMessage = "Done";
        }

        private async Task OnChooseFileAsync(InputFileChangeEventArgs e)
        {
            _errorMessage = String.Empty;
            var file = e.File;
            if (file != null)
            {
                if (file.Size > 2097152)
                {
                    _errorMessage = "File size must be equal or less than 2MB";
                    return;
                }
            }

            string[] allowedExtention = new[] { ".jpg", ".png", ".bmp", ".svg" };
            string extention = Path.GetExtension(file.Name).ToLower();
            if (!allowedExtention.Contains(extention))
            {
                _errorMessage = "Choose a valid file, This file is not allowded to upload";
                return;
            }
            // To open file 
            using (var stream = file.OpenReadStream(2097152))
            {
                var buffer = new byte[file.Size];
                await stream.ReadAsync(buffer, 0, (int)file.Size);
                _stream = new MemoryStream(buffer);
                _stream.Position = 0;
                _fileName = file.Name;
            }
        }




    }
}