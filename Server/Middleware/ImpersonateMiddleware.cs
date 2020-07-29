using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System.Security.Principal;

namespace MyComp.KPortal.Server.Middleware
{
    public class ImpersonateMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IConfiguration configuration;
        public ImpersonateMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            this.next = next;
            this.configuration = configuration;
        }
        public async Task Invoke(HttpContext context)
        {
            var UserId = configuration["Impersonation:UserId"];
            var identity = new GenericIdentity(UserId);
            var genericPrincipal = new GenericPrincipal(identity, new string[] { "All" });
            context.User = genericPrincipal;
            await next.Invoke(context);
        }
    }
}
