using Forum.Entities;
using System.Linq.Expressions;


namespace Forum.Contracts
{
    public interface IForumRepository : ISave
    {
        Task<List<ForumEntity>> GetAllAsync(); // მოგვაქვს ყველა
        Task<List<ForumEntity>> GetAllAsync(Expression<Func<ForumEntity, bool>> filter); // იღებს დელეგატს
        Task<ForumEntity> GetSingleAsync(Expression<Func<ForumEntity, bool>> filter); // მოაქვს ერთი ჩანაწერი

        Task AddAsync(ForumEntity entity); 
        Task UpdateAsync(ForumEntity entity);
        void Delete(ForumEntity entity);

        Task<List<Comments>> GetAllCommentsAsync();
        Task<List<Comments>> GetAllCommentsAsync(Expression<Func<Comments, bool>> filter);
        Task<List<Comments>> GetSingleCommentsAsync(Expression<Func<Comments, bool>> filter);
        Task AddCommentAsync(Comments comment);
        Task UpdateCommentAsync(Comments comment);
        void DeleteCommentAsync(Comments comment);
        void DeleteCommentAsync(List<Comments> result);
    }
}
