using System.Xml;
using Newtonsoft.Json;

Console.Clear();
string targetData = FileCopyToString();
JsonToXml(targetData);

static string FileCopyToString()
{
    string currPath = Directory.GetCurrentDirectory();
    string fileContent = "";
    string[] files = Directory.GetFiles(currPath, "*.json");
    if (files.Length == 0)
    {
        Console.WriteLine("Файл с расширением .json не найден. Добавьте файл в формате .json в директорию и попытайтесь преобразовать снова");
    }
    else
    {
        using (StreamReader sr = new StreamReader(files[0]))
        {
            fileContent = sr.ReadToEnd();
        }
    }
    return fileContent;
}

static void JsonToXml(string data)
{
    XmlDocument docXml = (XmlDocument)JsonConvert.DeserializeXmlNode(data);
    docXml.Save(Console.Out);
}