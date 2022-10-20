namespace KeyDb.Shared.Helpers;

public static class XmlHelper
{
    public static List<KeyModel> ParseFolder(string folderPath)
    {
        var files = Directory.GetFiles(folderPath, "*.xml");
        var keys = new List<KeyModel>();
        
        foreach(var file in files)
        {
            var xmlDocument = new XmlDocument();
            
            xmlDocument.Load(file);
            
            var xml = xmlDocument.SelectNodes("root/YourKey/Product_Key");

            if (xml == null) continue;
            
            foreach (XmlNode node in xml)
            {
                var nameValue = node.Attributes?["Name"]?.Value.Replace("\n", string.Empty);

                string? typeValue = null;

                foreach (XmlNode c in node.ChildNodes)
                {
                    var keyValue = c.InnerText;

                    typeValue = c.Attributes?["Type"]?.Value;

                    var length = keyValue?.Length;


                    if (!(length <= 29)) continue;

                    var key = new KeyModel
                    {
                        Name = nameValue,
                        Type = typeValue,
                        Value = keyValue
                    };

                    keys.Add(key);

                    Console.WriteLine($"Name={key.Name} Key={key.Value}");
                }
            }
        }

        return keys;
    }
}

//https://stackoverflow.com/questions/5013936/how-to-read-values-from-xml-file
//https://github.com/svickn/microsoft-key-importer-plugin