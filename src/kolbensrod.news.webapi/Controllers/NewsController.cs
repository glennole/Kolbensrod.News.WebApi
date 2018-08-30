using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using kolbensrod.news.webapi.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace kolbensrod.news.webapi.Controllers
{
    [Route("api/v1/[controller]")]
    public class NewsController : Controller
    {
        [HttpGet]
        public IEnumerable<News> Get()
        {
            var news = new List<News>();
            using (var connection =
                new NpgsqlConnection("Server=172.17.0.2;Port=5432;Database=News;User Id=postgres;Password=test;"))
            {
                connection.Open();
                return (List<News>) connection.Query<News>("SELECT * FROM News");
            }
        }

        [HttpGet()]
        [Route("{id}")]
        public Models.News Get(string id)
        {
            var n1 = new Models.News()
            {
                Title = "Ny nettside",
                Text = "Vi har nå fått oss ny nettside. Følg med og få med deg alt som skjer!",
                PublishedDate = new DateTime(2018, 08, 29)
            };

            return n1;
        }

        [HttpPost]
        public News Post([FromBody] News news)
        {
            using (var connection =
                new NpgsqlConnection("Server=172.17.0.2;Port=5432;Database=News;User Id=postgres;Password=test;"))
            {
                connection.Open();
                string query =
                    "INSERT INTO News (Title, Text, PublishedDate, Active) VALUES(@Title, @Text, @PublishedDate, @Active)";

                connection.Execute(query, news);

                return news;
            }
        }
    }
}