using UrlShortener.Web.Models.Entity;
using static UrlShortener.Web.Models.DTO.UrlDto;

namespace UrlShortener.Web.Repositories
{
    public interface IUrlRepository
    {
        void CreateUrl(UrlDTO urlDto);
        bool CheckShortUrl(string shortUrl);
        UrlDTO GetUrl(string shortUrl); 
    }
}
