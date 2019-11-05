using Blog.Blazor.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Blazor.Utils
{
    public static class ExtenssionMethods
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<DataService>();
            services.AddSingleton<ArticleService>();
            services.AddSingleton<TagService>();
        }
    }
}
