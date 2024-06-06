using Forum.Entities;
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

        Task<List<CommentForGettingDto>> GetAllCommentsAsync();
        Task<CommentForGettingDto> GetSingleCommentsAsync(int id);
        Task AddCommentAsync(CommentForAddingDto model);
        Task UpdateCommentAsync(CommentForUpdatingDto model);
        Task DeleteCommentAsync(int id);
    }
}
