using Blog.Model;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Blazor.Services
{
    public class TagService
    {
        private DataBase dataBase;
        public TagService(DataBase dataBase)
        {
            this.dataBase = dataBase;
        }
        public Task<List<TagModel>> GetTags()
        {
            return Task.FromResult(dataBase.QueryAllTags());
        }
        public Task<List<ArticleSummaryModel>> GetInfo([FromBody]string tagName)
        {
            return Task.FromResult(dataBase.QuerySummaryByTag(tagName));
        }
    }
}
