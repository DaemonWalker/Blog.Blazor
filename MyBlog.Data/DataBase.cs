using Blog.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MyBlog.Data
{
    public class DataBase
    {
        public List<ArticleSummaryModel> QueryLastestSixArticles()
        {
            var sql = @"select * from Article t order by t.Date desc limit 6";
            List<ArticleSummaryModel> list;
            using (var db = new DBContext())
            {
                list = db.SetSql(sql).Query<ArticleSummaryModel>();
            }
            foreach (var article in list)
            {
                article.Tags = QueryTagsByArticle(article.TitleEn);
            }
            return list;
        }
        public List<TagModel> QueryAllTags()
        {
            var sql = @"select distinct(t.Tag) as name from Tags t";
            using (var db = new DBContext())
            {
                return db.SetSql(sql).Query<TagModel>();
            }
        }
        public List<ArticleSummaryModel> QuerySummaryByTag(string tag)
        {
            List<ArticleSummaryModel> list;
            var sql = @"
SELECT
	t.Title,
	t.Date,
	t.Summary,
	t.TitleEn 
FROM
	Article t
	INNER JOIN Tags t1 ON t.titleen = t1.titleen 
WHERE
	t1.tag = @tag";
            using (var db = new DBContext())
            {
                list = db.AddParam(DbType.String, "@tag", tag).SetSql(sql).Query<ArticleSummaryModel>();
            }
            foreach (var article in list)
            {
                article.Tags = QueryTagsByArticle(article.TitleEn);
            }
            return list;
        }

        public List<TagModel> QueryTagsByArticle(string titleEn)
        {
            var sql = @"select t.Tag as name from Tags t where t.TitleEn= @TitleEn";
            using (var db = new DBContext())
            {
                return db.AddParam(DbType.String, "@TitleEn", titleEn).SetSql(sql).Query<TagModel>();
            }
        }
        public ArticleModel QueryArticleByTitleEn(string titleEn)
        {
            var sql = @"select * from Article t where t.TitleEn= @TitleEn";
            using (var db = new DBContext())
            {
                return db.AddParam(DbType.String, "@TitleEn", titleEn).SetSql(sql).Query<ArticleModel>().First();
            }
        }
    }
}
