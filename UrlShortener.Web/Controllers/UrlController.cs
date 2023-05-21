using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Web.Models.Entity;
using UrlShortener.Web.Services;

namespace UrlShortener.Web.Controllers
{
    public class UrlController : Controller
    {
        private readonly IUrlService _urlService;
        public UrlController(IUrlService service)
        {
            _urlService = service;
        }
        [HttpGet]
        public IActionResult Shorten()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ShortenUrl(string longUrl)
        {
            var shortenedUrl = _urlService.CreateShortUrl(longUrl);
            var url = new Url { longUrl = longUrl, shortUrl = HttpContext.Request.Headers["host"] +"/" +shortenedUrl.shortUrl };

            return View("Shorten", url);
        }



    }
}
