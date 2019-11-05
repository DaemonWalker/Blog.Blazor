using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Blog.Shared
{
    public static class Extenssions
    {
        public static string UrlEncode(this string content)
        {
            var str = HttpUtility.UrlEncode(content);
            str = str.Replace("#", "%23");
            return str;
        }

        public static string UrlDecode(this string content)
        {
            var str = HttpUtility.UrlDecode(content);
            return str;
        }

        private static string chineseNumber = @"零一二三四五六七八九十";
        public static string ToLoacalTimeString(this DateTime dateTime)
        {
            var sb = new StringBuilder();
            var month = dateTime.Month;
            sb.AppendFormat("{0}{1}月",
                month < 10 ? string.Empty : chineseNumber[10].ToString(),
                month % 10 == 0 ? string.Empty : chineseNumber[month % 10].ToString());
            sb.AppendFormat(" {0}日,{1}", dateTime.Day, dateTime.Year);
            return sb.ToString();
        }
    }
}
