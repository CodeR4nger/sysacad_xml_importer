using Microsoft.EntityFrameworkCore;
using XMLDataImporter.Data;
using DotNetEnv;

namespace XMLDataImporter.Tests
{
    public class DatabaseTests : IDisposable
    {
        private readonly DatabaseContext _db;

        public DatabaseTests()
        {
            Env.Load();

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseNpgsql($"Host={Env.GetString("POSTGRES_HOST")};" +
                            $"Username={Env.GetString("POSTGRES_USER")};" +
                            $"Password={Env.GetString("POSTGRES_PASSWORD")};" +
                            $"Database={Env.GetString("POSTGRES_DB")};") 
                .Options;

            _db = new DatabaseContext(options); 
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        [Fact]
        public async Task IsConnectedToDatabase()
        {
            var result = await _db.Database.ExecuteSqlRawAsync("SELECT 1");
            Assert.Equal(-1, result); 
        }
    }
}
