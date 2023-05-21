using UrlShortener.Web.Models.DTO;
using UrlShortener.Web.Models.Entity;
using static UrlShortener.Web.Models.DTO.UrlDto;

namespace UrlShortener.Web.Services
{
    public interface IUrlService
    {
        UrlDTO CreateShortUrl(string longUrl);

        UrlDTO GetUrl(string shortUrl);
    }
}
