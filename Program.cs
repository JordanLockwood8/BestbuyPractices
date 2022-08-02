using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using BestbuyPractices;
//^^^^MUST HAVE USING DIRECTIVES^^^^

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
string connString = config.GetConnectionString("DefaultConnection");
IDbConnection conn = new MySqlConnection(connString);

//making and getting department tables

//var department = new DapperDepartmentRepository(conn);

//Console.WriteLine("Type a new Department name");

//var userdepartment = Console.ReadLine();
////insert department into sql
//department.InsertDepartment(userdepartment);

//var allDep = department.GetAllDepartments();
//foreach (var item in allDep)
//{
//    Console.WriteLine(item.Name);
//    Console.WriteLine(item.DepartmentId);
//}
// utalizing products tables
var pRepo = new DapperProductRepository(conn);

var productCollection = pRepo.GetAllProducts();
foreach (var item in productCollection)
{
    Console.WriteLine(item.Name);
    Console.WriteLine(item.ProductID);
    Console.WriteLine(item.Price);
    Console.WriteLine(item.OnSale);
    Console.WriteLine();    
}