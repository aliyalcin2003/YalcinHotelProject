using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace YalcinHotel_DAL.Concrete.EfCore
{
    /// <summary>
    /// Creates the database context for EF Core tooling without starting the web
    /// application or loading its UI/business-layer assemblies.
    /// </summary>
    public sealed class DataContextFactory : IDesignTimeDbContextFactory<DataContext>  // DataContextFactory class'ını açmamızın sebebi , EF Core'un tasarım zamanı araçları (örneğin, migration oluşturma) için bir DbContext örneği sağlamaktır. Bu sayede uygulamayı başlatmadan veya UI/iş katmanı derlemelerini yüklemeden veritabanı bağlamını oluşturabiliriz.
    {
        public DataContext CreateDbContext(string[] args) => new();
    }
}
