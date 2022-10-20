namespace KeyDb.Shared.Helpers;

public static class ConfigHelper
{
    public static void SetEnvironment(string settingsPath)
    {
        using var file = File.OpenText(settingsPath);
        var reader = new JsonTextReader(file);
        var jObject =
            JsonConvert.DeserializeObject<Dictionary<string, string>>(
                JObject.Load(reader).GetValue("Settings")!.ToString());
        if (jObject == null) return;
        foreach (var key in jObject.Keys) Environment.SetEnvironmentVariable(key, jObject[key]);
    }
}