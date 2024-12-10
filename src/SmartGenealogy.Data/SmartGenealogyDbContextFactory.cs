using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SmartGenealogy.Data;

public class SmartGenealogyDbContextFactory : IDesignTimeDbContextFactory<SmartGenealogyDbContext>
{
    public SmartGenealogyDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<SmartGenealogyDbContext>();
        var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SmartGenealogy.db");
        optionsBuilder.UseSqlite($"Data Source={path}");

        return new SmartGenealogyDbContext(optionsBuilder.Options);
    }
}