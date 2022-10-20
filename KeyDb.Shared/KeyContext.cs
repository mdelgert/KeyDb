namespace KeyDb.Shared;

public class KeyContext : DbContext
{
    public DbSet<KeyModel> Notes { get; set; }

    public KeyContext(DbContextOptions<KeyContext> options) : base(options)
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    // protected override void OnModelCreating(ModelBuilder builder)
    // {
    //     builder.Entity<KeyModel>().ToContainer("Keys");
    // }
}