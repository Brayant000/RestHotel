using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RestHotel.Persistence.Base
{
    public abstract class BaseRepository<T> where T : class
    {
        protected readonly HotelContext _context;

        public BaseRepository(HotelContext context)
        {
            _context = context;
        }

        public void Add(T entity) => _context.Set<T>().Add(entity);
        public void Remove(T entity) => _context.Set<T>().Remove(entity);
        public IEnumerable<T> GetAll() => _context.Set<T>().ToList();
    }
}