namespace KeyDb.Shared.Models;

public class KeyModel
{
    //[Key]
    public int Id { get; set; }
    //public int KeyModelId { get; set; }
    public string? Name { get; set; }
    public string? Value { get; set; }
    public string? Type { get; set; }
}
