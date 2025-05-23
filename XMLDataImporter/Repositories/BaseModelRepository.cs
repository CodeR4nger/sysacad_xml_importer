using XMLDataImporter.Data;
using Microsoft.EntityFrameworkCore;

namespace XMLDataImporter.Repositories;

public abstract class BaseModelRepository<T>(DatabaseContext context) where T : class
{
    protected readonly DatabaseContext _context = context;
    protected readonly DbSet<T> _dbSet = context.Set<T>();

    public virtual T Create(T entity)
    {
        _dbSet.Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public virtual T? SearchById(int id)
    {
        return _dbSet.Find(id);
    }

    public virtual List<T> SearchAll()
    {
        return _dbSet.ToList();
    }

    public virtual T Update(T entity)
    {
        _dbSet.Update(entity);
        _context.SaveChanges();
        return entity;
    }

    public virtual bool DeleteById(int id)
    {
        var entity = _dbSet.Find(id);
        if (entity == null) return false;

        _dbSet.Remove(entity);
        _context.SaveChanges();
        return true;
    }
}
