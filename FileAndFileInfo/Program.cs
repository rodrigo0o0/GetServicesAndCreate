using Microsoft.Build.BuildEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace FileAndFileInfo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = @"c:\temp\file1.txt";
            //string sourcePath = "c:\\temp\\file1.txt";
            string targetPath = @"c:\temp\file2.txt";

            try
            {
                File.Copy(sourcePath, targetPath);
                string [] lines = File.ReadAllLines(sourcePath);
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
                Console.WriteLine("teste");
                Console.ReadKey();
                
            }catch(IOException e)
            {
                Console.WriteLine("Error! ",e.Message);
                Console.ReadKey();
            }
        }
    }
}
