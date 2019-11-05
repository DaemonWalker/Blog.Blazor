using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System;

namespace Blog.Shared
{
    public static class Config
    {
        public static IConfiguration Configuration { get; private set; }
        public static void UseStaticConfig(this IApplicationBuilder app)
        {
            Config.Configuration = app.ApplicationServices.GetService(typeof(IConfiguration)) as IConfiguration;
        }
    }
}
