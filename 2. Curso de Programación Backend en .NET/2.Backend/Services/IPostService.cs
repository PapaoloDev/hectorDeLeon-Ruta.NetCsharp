using _2.Backend.DTOs;

namespace _2.Backend.Services
{
    public interface IPostService
    {
        public Task<IEnumerable<PostDto>> Get();
    }
}
