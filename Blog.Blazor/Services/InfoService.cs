using MyBlog.Data;
using System;
using System.Collections.Generic;
using System.IO;
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
        public Task<List<string>> LS()
        {
            return Task.Run(() =>
            {
                var dir = new DirectoryInfo(Directory.GetCurrentDirectory());
                var stack = new Stack<DirectoryInfo>();
                var result = new List<string>();
                stack.Push(dir);
                while (stack.Count > 0)
                {
                    dir = stack.Pop();
                    foreach (var d in dir.GetDirectories())
                    {
                        stack.Push(d);
                    }
                    foreach (var f in dir.GetFiles())
                    {
                        result.Add(f.FullName);
                    }
                }
                return result.OrderBy(_ => _).ToList();
            });

        }
    }
}
