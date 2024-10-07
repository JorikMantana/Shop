using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IProductRepository<T>
    {
        public Task AddToDb(T model);
        public Task RemoveFromDb(int id);
        public Task UpdateToDb(T model);
        public Task GetFromDb(int id);
        public Task<IQueryable<T>> GetAllFromDb();
    }
}
