using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace kolbensrod.news.webapi.Controllers
{
    [Route("api/v1/[controller]")]
    public class NewsController : Controller
    {
        [HttpGet]
        public IEnumerable<Models.News> Get()
        {
            var n1 = new Models.News()
            {
                NewsId = 1,
                Title = "Ny nettside",
                Text = "Vi har nå fått oss ny nettside. Følg med og få med deg alt som skjer!",
                PublishedDate = new DateTime(2018, 04, 25)

            };
            var n2 = new Models.News()
            {
                NewsId = 2,
                Title = "Nytt adgangssystem",
                Text = "Vi har nå fått oss nytt adgangssystem. Ta turen oppom resepsjonen for å bytte til nytt kort!",
                PublishedDate = new DateTime(2018, 04, 25)

            };
            var news = new List<Models.News>();
            news.Add(n1);
            news.Add(n2);
            return news;
        }

        [HttpGet()]
        [Route("{id}")]
        public Models.News Get(string id)
        {
            var n1 = new Models.News()
            {
                NewsId = 1,
                Title = "Ny nettside",
                Text = "Vi har nå fått oss ny nettside. Følg med og få med deg alt som skjer!",
                PublishedDate = new DateTime(2018, 04, 25)

            };
           
            return n1;
        }

    }
}
