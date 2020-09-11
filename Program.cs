using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace NewSilkWay
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }
        // using main classes
        public static wwwroot.Root Root = new wwwroot.Root();
        // Models
        public static wwwroot.Models.StaticFiles StaticFiles = new wwwroot.Models.StaticFiles();

        // using main variables
        public static string JWTKey = "kghskcksvwrlwuydugvaadguytfuysvuv";
        public static string URL = "http://192.168.1.202:11111";/* "http://localhost:11111";*/



        //StaticFiles
       
        public static XmlDocument SqlConnectionStrings = StaticFiles.xmlDocumentSqlConnections();// SQL Connections
        public static XmlDocument XmlMail = StaticFiles._xmlDocumentMail();// Mail rekvizites



        //Tests

        public static wwwroot.Tests.Tests Tests = new wwwroot.Tests.Tests();

        








        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseUrls(URL)
                .UseStartup<Startup>();
    }
}
