using System.Security.Cryptography;
using System.Text;
using UrlShortener.Web.Models.DTO;
using UrlShortener.Web.Models.Entity;
using UrlShortener.Web.Repositories;
using static UrlShortener.Web.Models.DTO.UrlDto;

namespace UrlShortener.Web.Services
{
    public class UrlService : IUrlService
    {
        private readonly IUrlRepository _urlRepository;

        public UrlService(IUrlRepository repository)
        {
            _urlRepository = repository;
        }
        public UrlDTO MapToDTO(Url url)
        {
            return new UrlDTO(url.shortUrl, url.longUrl);
        }
        public string GetRandomUrl(string longUrl)
        {
            using (SHA256 sHA256 = SHA256.Create())
            {
                byte[] hashBytes = sHA256.ComputeHash(Encoding.UTF8.GetBytes(longUrl));
                string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                byte[] hashBytes2 = Encoding.UTF8.GetBytes(hash);
                string shortUrlPart = Convert.ToBase64String(hashBytes2);
                shortUrlPart = shortUrlPart.Replace("+", "-").Replace("/", "_").TrimEnd('=').Substring(0,8);
                return shortUrlPart;
            }
        }
        public UrlDTO CreateShortUrl(string longUrl)
        {
            string randomUrl = GetRandomUrl(longUrl);

            while (_urlRepository.CheckShortUrl(randomUrl))
            {
                randomUrl = GetRandomUrl(longUrl);
            }
            
            Url newUrl = new Url() { longUrl = longUrl, shortUrl = randomUrl };
            _urlRepository.CreateUrl(MapToDTO(newUrl));
            return MapToDTO(newUrl);
        }

        public UrlDTO GetUrl(string shortUrl)
        {
            return _urlRepository.GetUrl(shortUrl);
        }
    }
}
