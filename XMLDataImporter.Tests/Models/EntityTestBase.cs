
using XMLDataImporter.Data;
using XMLDataImporter.Tests.Utils;
namespace XMLDataImporter.Tests.Models;

public abstract class EntityTestBase<TEntity, TService> : BaseTestDB
    where TEntity : class
    where TService : class
{
    protected readonly TService Service;

    protected EntityTestBase(Func<DatabaseContext, TService> serviceFactory)
    {
        Service = serviceFactory(Context);
    }

    protected abstract TEntity CreateEntity();
    protected abstract void CheckEntity(TEntity entity);
    protected abstract TEntity Create(TEntity entity);
    protected abstract TEntity? GetById(int id);
    protected abstract IList<TEntity> GetAll();
    protected abstract TEntity Update(TEntity entity);
    protected abstract bool Delete(int id);
    protected abstract int GetId(TEntity entity);
    protected abstract void ModifyEntity(TEntity entity);
    protected abstract void CheckUpdatedEntity(TEntity entity);

    [Fact]
    public void CanCreateEntity()
    {
        var entity = CreateEntity();
        var created = Create(entity);
        CheckEntity(created);
        Assert.True(GetId(created) > 0);
    }
    [Fact]
    public void CanReadEntity()
    {
        var entity = Create(CreateEntity());
        var fetched = GetById(GetId(entity));
        Assert.NotNull(fetched);
        CheckEntity(fetched);
    }
    [Fact]
    public void CanReadAllEntities()
    {
        Create(CreateEntity());
        Create(CreateEntity());
        var all = GetAll();
        Assert.True(all.Count >= 2);
    }
    [Fact]
    public void CanUpdateEntity()
    {
        var entity = Create(CreateEntity());
        ModifyEntity(entity);
        var updated = Update(entity);
        Assert.Equal(GetId(entity), GetId(updated));
        var fetched = GetById(GetId(entity));
        Assert.NotNull(fetched);
        CheckUpdatedEntity(fetched);
    }
    [Fact]
    public void CanDeleteEntity()
    {
        var entity = Create(CreateEntity());
        var deleted = Delete(GetId(entity));
        Assert.True(deleted);
        var found = GetById(GetId(entity));
        Assert.Null(found);
    }
}