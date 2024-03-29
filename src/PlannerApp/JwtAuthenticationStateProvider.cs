﻿using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

public class JwtAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService _storageService;
    public JwtAuthenticationStateProvider(ILocalStorageService storageService)
    {
        _storageService = storageService;
    }
    public async override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        if(await _storageService.ContainKeyAsync("access_token"))
        {
            // The user is logged in 
            var tokenAsString = await _storageService.GetItemAsStringAsync("access_token");
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(tokenAsString);

            var identity = new ClaimsIdentity(token.Claims,"Bearer");
            var user = new ClaimsPrincipal(identity);
            var authState =new AuthenticationState(user);

            NotifyAuthenticationStateChanged(Task.FromResult(authState));
            return authState;
        }

        return new AuthenticationState(new ClaimsPrincipal()); // No identity - No user
    }
        

}
