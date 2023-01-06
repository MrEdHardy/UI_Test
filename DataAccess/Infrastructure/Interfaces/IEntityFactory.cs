using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Infrastructure.Interfaces
{
    public interface IEntityFactory<T>
    {
        Task <List<T>> GetAll();
        Task<List<T>> GetById(int id);
        Task<T> Add(T entity);
        Task Update(int id, T entity);
        Task Delete(int id);
    }
}
