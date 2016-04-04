using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Data.Repository
{
    public interface IRepository<TEntity>
    {
        Task<Acknowledgement<TEntity>> CreateRecord(TEntity Entity);
        Task<Acknowledgement<TEntity>> UpdateRecord(string id, UpdateDefinition<TEntity> Entity);
        Task<Acknowledgement<TEntity>> DeleteRecord(IEnumerable<string> ids);
        Task<Acknowledgement<TEntity>> GetItems(IEnumerable<string> ids);
        Task<Acknowledgement<TEntity>> GetAll();
    }
}
