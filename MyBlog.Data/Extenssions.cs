using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace MyBlog.Data
{
    static class Extenssions
    {
        public static List<T> ToModel<T>(this DbDataReader reader)
        {
            var list = new List<T>();
            var type = typeof(T);
            while (reader.Read())
            {
                T t = Activator.CreateInstance<T>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    var prop = type.GetProperties().FirstOrDefault(p => p.Name.ToLower() == reader.GetName(i).ToLower());
                    if (prop == null)
                    {
                        continue;
                    }
                    prop.SetValue(t, Convert.ChangeType(reader.GetString(i), prop.PropertyType));
                }
                list.Add(t);
            }
            reader.Close();
            return list;
        }
        public static List<string> ToListString(this DbDataReader reader)
        {
            var list = new List<string>();
            while (reader.Read())
            {
                list.Add(reader.GetValue(0).ToString());
            }
            return list;
        }

    }
}
