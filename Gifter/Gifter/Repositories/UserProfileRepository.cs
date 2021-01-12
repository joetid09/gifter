using Gifter.Data;
using Gifter.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gifter.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly ApplicationDbContext _context;

        public UserProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<UserProfile> GetAll()
        {
            return _context.UserProfile.ToList();
        }

        public UserProfile GetById(int id)
        {
            return _context.UserProfile.FirstOrDefault(u => u.Id == id);
        }

        public void AddProfile(UserProfile profile)
            {
            _context.Add(profile);
            _context.SaveChanges();
        }

        public void Update(UserProfile profile)
        {
            _context.Entry(profile).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Remove(id);
            _context.SaveChanges();
        }
    }
}
