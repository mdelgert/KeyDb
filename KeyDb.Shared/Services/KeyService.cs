namespace KeyDb.Shared.Services;

public interface IKeyService
{
    Task Run(string? name, string? folder);
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

    public async Task Run(string? name, string? folder)
    {
        if (folder != null)
        {
            await Import(folder);
        }
        
        if (name == null)
        {
            await ReadAll();
        }
        else
        {
            await SearchName(name);
        }
    }
    
    public Task<List<KeyModel>> SearchName(string name)
    {
        var keys = _dbContext.Keys
            .Where(k => k.ProductName.ToLower().Contains(name.ToLower()))
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
