using Domain.Models;

namespace Application.Abstractions
{
    public interface IPostRepository
    {
        Task<ICollection<Post>> GetAllPost();
        Task<Post> GetPostById(int id);
        Task<Post> CreatePost(Post toCreate);
        Task<Post> UpdatePost(string updatedContent, int postId);
        Task DeletePost(int postid);
    }
}
