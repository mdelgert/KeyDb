using System.IO;
using System.Xml;

namespace KeyDb.Shared.Helpers;

public static class XmlHelper
{
    public static void ParseFolder(string folderPath)
    {
        string[] files = System.IO.Directory.GetFiles(folderPath, "*.xml");

        foreach(var file in files)
        {
            //Console.WriteLine(file);

            XmlDocument serverDoc = new XmlDocument();
            serverDoc.Load(file);
            XmlNodeList xml = serverDoc.SelectNodes("root/YourKey/Product_Key");

            foreach (XmlNode node in xml)
            {
                //var name = node.Attributes["Name"].Value.Replace("\n", string.Empty);
                var name = node.Attributes["Name"].Value;
                var key = node.SelectSingleNode("Key").InnerText;

                int length = key.Length;

                if(length <= 29)
                {
                    Console.WriteLine($"Name={name} Key={key}");
                }
            }

        }
    }
}

//https://stackoverflow.com/questions/5013936/how-to-read-values-from-xml-file