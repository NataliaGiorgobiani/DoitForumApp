using Forum.Contracts;
using Forum.Data;
using Forum.Entities;
using Forum.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Forum.Repositories
{
    public class ForumRepository : IForumRepository
    {
        private readonly ApplicationDbContext _context;

        public ForumRepository(ApplicationDbContext context) {
           _context = context;
        
        }

        public async Task AddAsync(ForumEntity entity)
        {
            if (entity != null)
            {
                await _context.Forum.AddAsync(entity);
            }
            
        }

        public void Delete(ForumEntity entity)
        {
            if (entity != null)
            {
                _context.Forum.Remove(entity);
            }
        }

        public async Task<List<ForumEntity>> GetAllAsync()
        {
            return await _context.Forum
                .ToListAsync();
        }

        public async Task<List<ForumEntity>> GetAllAsync(Expression<Func<ForumEntity, bool>> filter)
        {
            return await _context.Forum
                .Where(filter)
                .ToListAsync();
        }

        public async Task<ForumEntity> GetSingleAsync(Expression<Func<ForumEntity, bool>> filter)
        {
            return await _context.Forum
                .FirstOrDefaultAsync(filter);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ForumEntity entity)
        {
            if (entity != null)
            {
                var forumToUpdate = await _context.Forum.FirstOrDefaultAsync(x => x.Id == entity.Id);
                if (forumToUpdate != null)
                {
                    forumToUpdate.Title = entity.Title;
                    forumToUpdate.Description = entity.Description;
                    forumToUpdate.CreatedDate = entity.CreatedDate;
                    forumToUpdate.State = entity.State;
                    forumToUpdate.Status = entity.Status;

                    _context.Forum.Update(forumToUpdate);
                }
            }
        }

        public async Task AddCommentAsync(Comments comment) 
        { 
            if(comment != null)
            {
                await _context.Comment.AddAsync(comment);
            }
        
        }
        public async void DeleteCommentAsync(Comments comment)
        {
            if (comment != null)
            {
                _context.Comment.Remove(comment);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Comments>> GetAllCommentsAsync()
        {
            return await _context.Comment
                .ToListAsync();
        }

        public async Task<List<Comments>> GetAllCommentsAsync(Expression<Func<Comments, bool>> filter)
        {
            return await _context.Comment
                .Where(filter)
                .ToListAsync();
        }
        public async Task<Comments> GetSingleCommentsAsync(Expression<Func<Comments, bool>> filter)
        {
            return await _context.Comment.FirstOrDefaultAsync(filter);
        }

        public async Task UpdateCommentAsync(Comments comment)
        {
            if (comment != null)
            {
                var commentToUpdate = await _context.Comment.FirstOrDefaultAsync(x => x.Id == comment.Id); // Ensure you query the Comments DbSet
                if (commentToUpdate != null)
                {
                    commentToUpdate.TopicComent = comment.TopicComent;
                   

                    _context.Comment.Update(commentToUpdate);
                }
            }
        }

        Task<List<Comments>> IForumRepository.GetSingleCommentsAsync(Expression<Func<Comments, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommentAsync(List<Comments> result)
        {
            throw new NotImplementedException();
        }
    }
}
