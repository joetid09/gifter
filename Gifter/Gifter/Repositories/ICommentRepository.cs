using Gifter.Models;
using System.Collections.Generic;

namespace Gifter.Repositories
{
    public interface ICommentRepository
    {
        void AddComment(Comment comment);
        void DeleteComment(int id);
        List<Comment> GetAll();
        Comment GetById(int id);
        List<Comment> GetByUserId(int id);
        void UpdateComment(Comment comment);
    }
}