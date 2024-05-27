using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace OrderApi.Authentication
{
    public class ApiKeyAuthFilter : IAuthorizationFilter
    {
        private readonly IConfiguration _configuration;
        public ApiKeyAuthFilter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(AuthConstants.ApiKeyName, out var key))
            {
                context.Result = new UnauthorizedObjectResult("Api Key Missing");
                return;
            }
            var api_key = _configuration.GetValue<string>(AuthConstants.ApiKeyName);
            if(api_key != null)
            {
                if (!api_key.Equals(key))
                {
                    context.Result = new UnauthorizedObjectResult("Invalid Api Key");
                    return;
                }
            }
        }
    }
}
