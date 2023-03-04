using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace IdentityProvider.Shared
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationState _anonymous;
        public AuthStateProvider(ILocalStorageService localStorage)
        {
            //_httpClient = httpClient;
            _localStorage = localStorage;
            _anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
     
            if (string.IsNullOrWhiteSpace(token))
                return _anonymous;
            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwtAuthType")));
        }
        public async Task NotifyUserAuthentication(string email)
        {
            var state = await GetAuthenticationStateAsync();
            
            var authState = Task.FromResult(new AuthenticationState(state.User));
            NotifyAuthenticationStateChanged(authState);
        }
        public void NotifyUserLogout()
        {
            var authState = Task.FromResult(_anonymous);
            NotifyAuthenticationStateChanged(authState);
        }
        public void NotifyAllPages()
        {
            var authState = Task.FromResult(_anonymous);
            AuthenticationStateChanged += OnAuthenticationStateChanged;
            NotifyAuthenticationStateChanged(authState);
        }

        private void OnAuthenticationStateChanged(Task<AuthenticationState> task)
        {
            throw new NotImplementedException();
        }
    }
}
