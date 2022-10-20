namespace KeyDb.Shared.Services;

public interface IKeyService
{
    Task Import(string folderPath);
}

public class KeyService : IKeyService
{
    private readonly DataContext _dbContext;

    public KeyService(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task Import(string folderPath)
    {
        var keys = XmlHelper.ParseFolder(folderPath);
        
        foreach (var key in keys)
        {
            _dbContext.Keys.Add(key);
            _dbContext.SaveChanges();
        }

        return Task.CompletedTask;
    }
}
