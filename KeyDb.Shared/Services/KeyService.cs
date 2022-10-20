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
            var dbKeys = _dbContext.Keys
                .Where(k => k.Name == key.Name && k.Value == key.Value && k.Type == key.Type)
                .ToList();
            
            if (dbKeys.Count == 0)
            {
                _dbContext.Keys.Add(key);
                _dbContext.SaveChanges();
            }
        }
        
        return Task.CompletedTask;
    }
    
}
