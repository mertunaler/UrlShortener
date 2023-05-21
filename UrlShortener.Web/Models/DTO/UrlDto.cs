namespace UrlShortener.Web.Models.DTO
{
    public class UrlDto
    {
        public record UrlDTO(string shortUrl, string longUrl);
    }
}
