using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gifter.Data;
using Gifter.Models;
using Microsoft.EntityFrameworkCore;

namespace Gifter.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Comment> GetAll()
        {
            return _context.Comment.Include(u => u.UserProfile).Include(p => p.Post).ToList();
        }

        public Comment GetById(int id)
        {
            return _context.Comment.Include(u => u.UserProfile).Include(p => p.Post).FirstOrDefault(c => c.Id == id);
        }

        public List<Comment> GetByUserId(int id)
        {
            return _context.Comment
                .Include(u => u.UserProfile)
                .Include(p => p.Post)
                .Where(c => c.UserProfileId == id)
                .ToList();
        }

        public void AddComment(Comment comment)
        {
            _context.Comment.Add(comment);
            _context.SaveChanges();
        }

        public void UpdateComment(Comment comment)
        {
            _context.Entry(comment).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteComment(int id)
        {
            var comment = GetById(id);
            _context.Comment.Remove(comment);
            _context.SaveChanges();
        }
    }
}
