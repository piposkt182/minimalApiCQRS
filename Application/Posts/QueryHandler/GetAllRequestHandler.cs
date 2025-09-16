
using Application.Abstractions;
using Application.Posts.Queries;
using Domain.Models;
using MediatR;

namespace Application.Posts.QueryHandler
{
    public class GetAllRequestHandler : IRequestHandler<GetAllPosts, ICollection<Post>>
    {
        private readonly IPostRepository _postRepository;
        public GetAllRequestHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<ICollection<Post>> Handle(GetAllPosts request, CancellationToken cancellationToken)
        {
            return await _postRepository.GetAllPost();
        }
    }
}
