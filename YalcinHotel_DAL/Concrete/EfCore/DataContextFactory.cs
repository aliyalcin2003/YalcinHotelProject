using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace YalcinHotel_DAL.Concrete.EfCore
{
    /// <summary>
    /// Creates the database context for EF Core tooling without starting the web
    /// application or loading its UI/business-layer assemblies.
    /// </summary>
    public sealed class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args) => new();
    }
}
