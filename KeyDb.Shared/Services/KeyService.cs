namespace KeyDb.Shared.Services;

public interface IKeyService
{
    Task<List<KeyModel>> SearchName(string name);
    Task<List<KeyModel>> ReadAll();
    Task Import(string folderPath);
}

public class KeyService : IKeyService
{
    private readonly DataContext _dbContext;

    public KeyService(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<KeyModel>> SearchName(string name)
    {
        var keys = _dbContext.Keys
            .Where(k => k.ProductName.Contains(name))
            .ToList();
        
        foreach (var key in keys)
        {
            Console.WriteLine($"{key.ProductName} {key.ProductKey}");
        }

        return Task.FromResult(keys);
    }

    public Task<List<KeyModel>> ReadAll()
    {
        var keys = _dbContext.Keys.ToList();

        foreach(var key in keys)
        {
            Console.WriteLine($"{key.ProductName} {key.ProductKey}");
        }

        return Task.FromResult(keys);
    }

    public Task Import(string folderPath)
    {
        var keys = XmlHelper.ParseFolder(folderPath);
        
        foreach (var key in from key in keys let dbKeys = _dbContext.Keys
                     .Where(k => k.ProductName == key.ProductName && k.ProductKey == key.ProductKey)
                     .ToList() where dbKeys.Count == 0 select key)
        {
            _dbContext.Keys.Add(key);
            _dbContext.SaveChanges();
        }
        
        return Task.CompletedTask;
    }
    
}
