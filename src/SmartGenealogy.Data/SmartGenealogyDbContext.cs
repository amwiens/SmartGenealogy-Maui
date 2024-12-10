using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

using SmartGenealogy.Data.Models;

namespace SmartGenealogy.Data;

public class SmartGenealogyDbContext : DbContext
{
    private readonly string? path;

    public SmartGenealogyDbContext(string path)
    {
        this.path = path;
    }

    public SmartGenealogyDbContext(DbContextOptions options)
        : base(options)
    {
        SQLitePCL.Batteries_V2.Init();
        this.Database.Migrate();
    }

    public DbSet<Place> Places { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
#if DEBUG
        optionsBuilder.EnableSensitiveDataLogging();
#endif
        var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SmartGenealogy.db");
        optionsBuilder.UseSqlite($"Data Source={path}")
            .ConfigureWarnings(warning => warning.Log(RelationalEventId.PendingModelChangesWarning));
    }
}