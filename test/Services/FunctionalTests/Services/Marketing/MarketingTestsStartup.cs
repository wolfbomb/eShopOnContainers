﻿namespace FunctionalTests.Services.Marketing
{
    using Microsoft.eShopOnContainers.Services.Marketing.API;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Builder;
    using FunctionalTests.Middleware;

    public class MarketingTestsStartup : Startup
    {
        public MarketingTestsStartup(IHostingEnvironment env) : base(env)
        {
        }

        protected override void ConfigureAuth(IApplicationBuilder app)
        {
            if (Configuration["isTest"] == bool.TrueString.ToLowerInvariant())
            {
                app.UseMiddleware<AutoAuthorizeMiddleware>();
            }
            else
            {
                base.ConfigureAuth(app);
            }
        }
    }
}
