using Blog.Model;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Blazor.Services
{
    public class ArticleService
    {
        private DataBase dataBase;
        public ArticleService(DataBase dataBase)
        {
            this.dataBase = dataBase;
        }


        public Task<ArticleModel> GetArticle(string name)
        {
            return Task.FromResult(dataBase.QueryArticleByTitleEn(name));

        }

        public Task<ArticleModel> GetArticle2(string name)
        {
            return Task.FromResult(dataBase.QueryArticleByTitleEn(name));
        }
    }
}
