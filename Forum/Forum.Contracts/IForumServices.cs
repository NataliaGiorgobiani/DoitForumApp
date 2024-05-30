using Forum.Models;

namespace Forum.Contracts
{
    public interface IForumServices
    {
        Task<List<ForumForGettingDto>> GetAllAsync();
        Task<ForumForGettingDto> GetAllAsync(int id);
        Task AddAsync(ForumForAddingDto model);
        Task UpdateAsync(ForumForUpdatingDto model);
        Task DeleteAsync(int id);
    }
}
