using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Globalization;

namespace CursoApis.Datos
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApliccationDboContext>
    {
        public ApliccationDboContext CreateDbContext(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<ApliccationDboContext>();
            builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new ApliccationDboContext(builder.Options);
        }
    }
}
