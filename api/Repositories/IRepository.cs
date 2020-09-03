using System.Collections.Generic;
using System.Threading.Tasks;
using api.Model;

namespace api.Repositories {
    public interface IRepository<T> where T : IDocument
    {

        Task<T> add(T entity);

        Task<T> delete(T entity);

        Task<IList<T>> addAll(IList<T> entities);

        Task<T> update(T entity);

        Task<T> findByCodigo(string codigo);

        Task<IEnumerable<T>> findAll();
    }
}