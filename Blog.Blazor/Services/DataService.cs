using Blog.Model;
using Blog.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyBlog.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Blazor.Services
{
    public class DataService
    {
        private DataBase dataBase;
        public DataService(DataBase dataBase)
        {
            this.dataBase = dataBase;
        }

        [HttpGet("[action]")]
        public Task<List<ArticleSummaryModel>> GetArcitalTitles(SortType sortType)
        {
            return Task.FromResult(dataBase.QueryLastestSixArticles());

        }

        [HttpGet("[action]")]
        public Task<List<ShareModel>> GetShareWays()
        {
            return Task.FromResult(Config.Configuration.GetSection("ShareModels").Get<List<ShareModel>>());
        }
    }
}
