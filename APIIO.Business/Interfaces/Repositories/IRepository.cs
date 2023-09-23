using APIIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace APIIO.Business.Interfaces.Repositories
{
    public  interface IRepository<TEntity> : IDisposable where TEntity : Entity 
    {
        Task Adicionar (TEntity entity);
        Task<TEntity> ObterPorId (Guid id);

        Task<ICollection<TEntity>> ObterTodos ();

        Task Atualizar(TEntity entity);

        Task Remover(Guid id);

        //Essa função receba uma função lambda que servirá como uma busca filtrada para retornar uma lista de objetos
        Task<IEnumerable<TEntity>> Buscar (Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}
