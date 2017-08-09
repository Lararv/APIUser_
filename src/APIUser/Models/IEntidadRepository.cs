using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIUser.Models
{
    public interface IuserRepository
    {
        void Add(user item);
        IEnumerable<user> GetAll();
        user Find(long key);
        void Remove(long key);
        void Update(user item);
    }
}
