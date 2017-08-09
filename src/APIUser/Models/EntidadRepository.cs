using System;
using System.Collections.Generic;
using System.Linq;

namespace APIUser.Models
{
    public class userRepository : IuserRepository
    {

        private  userContext _context;

        public userRepository(userContext context)
        {
            _context = context;           
        }

        public IEnumerable<user> GetAll()
        {
            return _context.userItems.ToList();
        }

        public void Add(user item)
        {
            _context.userItems.Add(item);
            _context.SaveChanges();
        }

        public user Find(long key) 
        {
            return _context.userItems.FirstOrDefault(t => t.Id == key);
        }

        public void Remove(long key)
        {
            var entity = _context.userItems.First(t => t.Id == key);
            _context.userItems.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(user item)
        {
            _context.userItems.Update(item);
            _context.SaveChanges();
        }

    }
}
