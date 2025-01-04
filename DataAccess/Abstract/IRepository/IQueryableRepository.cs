using Entities.Abstract;

namespace DataAccess.Abstract.IRepository
{
    public interface IQueryableRepository<T> where T : class, IEntity, new()
    {
        IQueryable<T> Table { get; }
    }
}
