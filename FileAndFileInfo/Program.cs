using Microsoft.Build.BuildEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.AccessControl;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;

namespace FileAndFileInfo
{
    internal class Program
    {
        static void Main(string[] args)
        {


            try
            {

                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Service ");
                ManagementObjectCollection services = searcher.Get();
                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                filePath += @"\services.txt";

                // Check if file already exists. If yes, delete it.     
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                Console.WriteLine(filePath);



                int count = 0;
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    foreach (var obj in services)
                    {
                        string name = obj["Name"] as string;
                        string displayName = obj["DisplayName"] as string;
                        string pathName = obj["PathName"] as string;
                        if (displayName.ToLower().Contains("ayty"))
                        {
                            string line = "sc create ";
                            line += name;
                            line += " binPath= ";
                            line += pathName.Split(' ')[0];
                            line += " DisplayName= " + displayName;
                            line += " Start= disabled";
                            
                            pathName = pathName.Split(' ')[0];
                            sw.WriteLine(line);

                            count++;
                        }

                    }
                }
                if (count == 0)
                {
                    Console.WriteLine("Não foi encontrado nenhum serviço com o nome : Ayty");
                }
                else
                {
                    Console.WriteLine("Programa Finalizado.");
                }
                Console.ReadKey();




            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
