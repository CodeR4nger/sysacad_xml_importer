using XMLDataImporter.Data;

namespace XMLDataImporter.Tests.Data;

public class DatabaseTests : IDisposable
{
    private readonly DatabaseContext _db;

    public DatabaseTests(IDatabaseContextFactory? factory = null)
    {
        factory ??= new DatabaseContextFactory(); 
        _db = factory.CreateDbContext([]);
    }

    public void Dispose()
    {
        _db.Dispose();
    }

    [Fact]
    public async Task IsConnectedToDatabase()
    {
        var result = await _db.Database.CanConnectAsync();
        Assert.True(result);
    }
}

