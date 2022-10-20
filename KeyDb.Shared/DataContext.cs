namespace KeyDb.Shared;

public class DataContext : DbContext
{
    public DbSet<KeyModel> Keys { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
    }
    
    // protected override void OnModelCreating(ModelBuilder builder)
    // {
    //     builder.Entity<KeyModel>().ToContainer("Keys");
    // }
}

//https://stackoverflow.com/questions/54354186/dbcontextoptionsbuilder-enablesensitivedatalogging-doesnt-do-anything