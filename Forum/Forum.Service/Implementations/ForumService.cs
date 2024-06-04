
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

            var result = _mapper.Map<List<ForumForGettingDto>>(raw);
            return result;
        }

        public async Task<ForumForGettingDto> GetAllAsync(int id)
        {
            if (id <= 0) throw new ArgumentException("Invalid argument!");
            var raw = await _forumRepository.GetSingleAsync(x => x.Id == id);

            if(raw == null) throw new TopicNotFoundExp();

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
    }
}
