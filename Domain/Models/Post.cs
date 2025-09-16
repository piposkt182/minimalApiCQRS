
namespace Domain.Models
{
    public class Post
    {
        public int Id { get; set; } 
        public string? Content { get; set; }
        public DateTime DataCreated{ get; set; }
        public DateTime LastModified{ get; set; }
    }
}
