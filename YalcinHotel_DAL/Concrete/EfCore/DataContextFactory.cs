using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace YalcinHotel_DAL.Concrete.EfCore
{
    /// <summary>
    /// Creates the database context for EF Core tooling without starting the web
    /// application or loading its UI/business-layer assemblies.
    /// </summary>
    public sealed class DataContextFactory : IDesignTimeDbContextFactory<DataContext>  // DataContextFactory class'ını açmamızın sebebi , EF Core'un tasarım zamanı araçları (örneğin, migration oluşturma) için bir DbContext örneği sağlamaktır. Bu sayede uygulamayı başlatmadan veya UI/BL derlemelerini yüklemeden veritabanı bağlamını oluşturabiliriz.
    {
        public DataContext CreateDbContext(string[] args) => new(); // (string[] args) parametresi, EF Core'un tasarım zamanı araçları tarafından sağlanan komut satırı argümanlarını temsil eder. Bu argümanlar, veritabanı bağlamını oluştururken kullanılabilir. Örneğin, farklı bir veritabanı sağlayıcısı veya bağlantı dizesi belirtmek için kullanılabilir. Ancak bu örnekte, args parametresi kullanılmamaktadır ve varsayılan bir DataContext örneği döndürülmektedir.
    }
}
