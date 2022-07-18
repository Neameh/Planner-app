using Blazored.LocalStorage;

public class AuthorizationMesssageHandler : DelegatingHandler
{
    private readonly ILocalStorageService _localStorage;
    public AuthorizationMesssageHandler(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if(await _localStorage.ContainKeyAsync("access_token"))
        {
            var token = await _localStorage.GetItemAsStringAsync("access_token");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",  token);
        }
        Console.WriteLine("Authorization Message Handler Called");
        return await base.SendAsync(request, cancellationToken);
    }
}