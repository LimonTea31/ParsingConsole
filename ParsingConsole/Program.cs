using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ParsingConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string xmlFilePath = "C:\\Users\\ADMIN\\Desktop\\Список.xml";
            string Content = "";

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);
            XmlNodeList stages = xmlDoc.SelectNodes("/project/stage");
            
            foreach (XmlNode stage in stages)
            {
                string name = stage.SelectSingleNode("Name").InnerText;
                string dateStart = stage.SelectSingleNode("DateStart").InnerText;
                string duration = stage.SelectSingleNode("Duration").InnerText;

                Content = $"// Stage: {name}\n// Date Start: {dateStart}\n// Duration: {duration}\n";
               

                XmlNodeList users = stage.SelectNodes("Users/User");
                foreach (XmlNode user in users)
                {
                    Content += $"// User: {user.InnerText}\n";
                }

                XmlNode connectStage = stage.SelectSingleNode("connectStage");
                if (connectStage != null)
                {
                    Content += $"// Connected to Stage: {connectStage.InnerText}\n";
                }

                Content += "\n";
            }
            string projectFilePath = "C:\\Users\\ADMIN\\Desktop\\Список.cs";
            System.IO.File.WriteAllText(projectFilePath, Content);
            Console.WriteLine(Content);
            Console.WriteLine("Файл проекта успешно создан.");
            Console.ReadKey();
        }
    }
}
