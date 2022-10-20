namespace KeyDb.Tests.Services;

public class KeyServiceTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly IKeyService _keyService;
    
    public KeyServiceTests(ITestOutputHelper testOutputHelper, IKeyService keyService)
    {
        _testOutputHelper = testOutputHelper;
        _keyService = keyService;
    }

    [Fact]
    public async Task ReadAllTest()
    {
        var keys = await _keyService.ReadAll();
        
        foreach (var key in keys)
        {
            _testOutputHelper.WriteLine(key.ProductName);    
        }
    }
    
    
}
