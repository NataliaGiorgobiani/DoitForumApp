
using AutoMapper;
using Forum.Contracts;
using Forum.Entities;
using Forum.Models;
using Forum.Service.Exeptions;

namespace Forum.Service.Implementations
{
    public class ForumService : IForumServices
    {
        private readonly IForumRepository _forumRepository;
        private readonly IMapper _mapper;

        public int ForumEntityId { get; private set; }

        public ForumService(IForumRepository forumRepository)
        {
            _forumRepository = forumRepository;
            _mapper = MappingInitializer.Initialize();
        }

        public async Task AddAsync(ForumForAddingDto model)
        {
            if (model is null) throw new ArgumentNullException("Invalid argument!");


            var result = _mapper.Map<ForumEntity>(model);
            await _forumRepository.AddAsync(result);
            await _forumRepository.Save();
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0) throw new ArgumentException("Invalid argument!");
            var result = await _forumRepository.GetSingleAsync(x => x.Id == id);

            if (result == null) throw new TopicNotFoundExp();

            _forumRepository.Delete(result);
            await _forumRepository.Save();
        }

        public async Task<List<ForumForGettingDto>> GetAllAsync()
        {
            var raw = await _forumRepository.GetAllAsync();
            if (raw.Count == 0) throw new TopicNotFoundExp();



            var comments = await _forumRepository.GetAllCommentsAsync();


            var groupedComments = comments
                .GroupBy(c => c.ForumEntityId)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(comment => new CommentForGettingDto
                    {
                        Id = comment.Id,
                        ForumEntityId = comment.ForumEntityId,
                        TopicComent = comment.TopicComent,
                        UserID = comment.UserID
                    }).ToList()
                );
            /*
                        if (raw.Count == 0) throw new TopicNotFoundExp();

                        var result = _mapper.Map<List<ForumForGettingDto>>(raw);

                        return result;*/
            var forumDtos = raw.Select(forum => new ForumForGettingDto
            {
                Id = forum.Id,
                Title = forum.Title,
                Description = forum.Description,
                CreatedDate = forum.CreatedDate,
                Status = forum.Status,
                State = forum.State,
/*                ForumUserID = forum.ForumUserID,
*/                Comments = groupedComments.ContainsKey(forum.Id) ? groupedComments[forum.Id] : new List<CommentForGettingDto>(),
                TotalComments = groupedComments.ContainsKey(forum.Id) ? groupedComments[forum.Id].Count : 0
            }).ToList();

            return forumDtos;

        }

        public async Task<ForumForGettingDto> GetAllAsync(int id)
        {
            if (id <= 0) throw new ArgumentException("Invalid argument!");
            var raw = await _forumRepository.GetSingleAsync(x => x.Id == id);

            if (raw == null) throw new TopicNotFoundExp();

            var result = _mapper.Map<ForumForGettingDto>(raw);

            return result;
        }

        public async Task UpdateAsync(ForumForUpdatingDto model)
        {
            if (model is null) throw new ArgumentNullException("Invalid argument!");

            var result = _mapper.Map<ForumEntity>(model);
            await _forumRepository.UpdateAsync(result);
            await _forumRepository.Save();
        }

        public async Task AddCommentAsync(CommentForAddingDto comment)
        {
            if (comment is null) throw new ArgumentNullException("Invalid argument!");
            var result = _mapper.Map<Comments>(comment);
            await _forumRepository.AddCommentAsync(result);
            await _forumRepository.Save();
        }

        public async Task DeleteCommentAsync(int id)
        {
            if (id <= 0) throw new ArgumentException("Invalid argument!");
            var result = await _forumRepository.GetSingleCommentsAsync(x => x.Id == id);
            if (result == null) throw new TopicNotFoundExp();

            _forumRepository.DeleteCommentAsync(result);
            await _forumRepository.Save();
        }

        public async Task<List<CommentForGettingDto>> GetAllCommentsAsync()
        {
            var raw = await _forumRepository.GetAllCommentsAsync();
            if (raw.Count == 0) throw new TopicNotFoundExp();

            var result = _mapper.Map<List<CommentForGettingDto>>(raw);
            return result;
        }

        public async Task<CommentForGettingDto> GetAllCommentsAsync(int id)
        {
            if (id <= 0) throw new ArgumentException("Invalid argument!");
            var raw = await _forumRepository.GetSingleCommentsAsync(x => x.Id == id);

            if (raw == null) throw new TopicNotFoundExp();

            var result = _mapper.Map<CommentForGettingDto>(raw);
            return result;
        }

        public async Task UpdateCommentAsync(CommentForUpdatingDto model)
        {
            if (model is null) throw new ArgumentNullException("Invalid argument!");

            var result = _mapper.Map<Comments>(model);
            await _forumRepository.UpdateCommentAsync(result);
            await _forumRepository.Save();
        }

        public Task<List<CommentForGettingDto>> GetSingleCommentsAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<CommentForGettingDto> IForumServices.GetSingleCommentsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddCommentAsync(ForumForAddingDto model)
        {
            throw new NotImplementedException();
        }
    }
}
