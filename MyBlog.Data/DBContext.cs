using Blog.Shared;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;

namespace MyBlog.Data
{
    public class DBContext : IDisposable
    {
        private DbConnection dbConnection;
        private DbCommand dbCommand;
        public DBContext()
        {
            var conn = string.Format(Config.Configuration.GetConnectionString("default"), Directory.GetCurrentDirectory());
            dbConnection = new SqliteConnection(conn);
            SQLitePCL.Batteries.Init();
            dbConnection.Open();
            dbCommand = dbConnection.CreateCommand();
        }

        public DBContext AddParam(DbType dbType, string name, object value)
        {
            var parm = dbCommand.CreateParameter();
            parm.DbType = DbType.AnsiString;
            parm.Value = value;
            parm.ParameterName = name;
            dbCommand.Parameters.Add(parm);

            return this;
        }

        public DBContext SetSql(string sql)
        {
            dbCommand.CommandText = sql;
            dbCommand.CommandType = CommandType.Text;

            return this;
        }

        public List<T> Query<T>()
        {
            var list = dbCommand.ExecuteReader().ToModel<T>();
            dbCommand.Parameters.Clear();
            return list;
        }

        public int ExecuteNoQuery()
        {
            var r = dbCommand.ExecuteNonQuery();
            dbCommand.Parameters.Clear();
            return r;
        }

        public string GetDBPath()
        {
            return this.dbConnection.DataSource + "\t" + this.dbConnection.Database;
        }

        public void Dispose()
        {
            Dispose(true);
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (disposed == false)
                {
                    this.disposed = true;
                    this.dbConnection.Close();
                }
            }
            GC.SuppressFinalize(this);
        }
    }
}
