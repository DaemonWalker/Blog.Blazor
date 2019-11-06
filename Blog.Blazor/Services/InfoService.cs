using MyBlog.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Blazor.Services
{
    public class InfoService
    {
        DBContext dBContext;
        public InfoService(DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public Task<string> GetDBPath()
        {
            return Task.FromResult(dBContext.GetDBPath());
        }
    }
}
