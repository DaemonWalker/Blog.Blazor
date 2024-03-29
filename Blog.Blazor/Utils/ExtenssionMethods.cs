﻿using Blog.Blazor.Services;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.Data;
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
            services.AddSingleton<DataBase>();
            services.AddSingleton<DBContext>();
            services.AddSingleton<DataService>();
            services.AddSingleton<ArticleService>();
            services.AddSingleton<TagService>();
            services.AddSingleton<InfoService>();
        }
    }
}
