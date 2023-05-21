using Microsoft.AspNetCore.Mvc;
using UrlShortener.Web.Models.Entity;
using static UrlShortener.Web.Models.DTO.UrlDto;

namespace UrlShortener.Web.Repositories
{
    public class UrlRepository : IUrlRepository
    {
        private readonly UrlDbContext _context;
        public UrlRepository(UrlDbContext context)
        {
            _context = context;
        }
        public UrlDTO MapToDTO(Url url)
        {
            return new UrlDTO(url.shortUrl, url.longUrl);
        }
        public void CreateUrl(UrlDTO urlDto)
        {
            var urlEntity = new Url()
            {
                longUrl = urlDto.longUrl,
                shortUrl = urlDto.shortUrl
            };
            _context.Urls.Add(urlEntity);
            _context.SaveChanges();
        }

        public bool CheckShortUrl(string shortUrl)
        {
            return _context.Urls.Any(s => s.shortUrl == shortUrl) ? true : false;
        }

        public UrlDTO GetUrl(string shortUrl)
        {
            var url = _context.Urls.Find(shortUrl);
            return url != null ? MapToDTO(url)  : null;
        }
    }
}
