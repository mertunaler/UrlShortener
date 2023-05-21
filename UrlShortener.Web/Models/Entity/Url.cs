using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrlShortener.Web.Models.Entity
{
    public class Url
    {
        public Url()
        {
            
        }
        public Url(long ID, string shortUrl, string longUrl)
        {
            
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public string longUrl { get; set; }
        [Key]
        public string shortUrl { get; set; }
    }
}
