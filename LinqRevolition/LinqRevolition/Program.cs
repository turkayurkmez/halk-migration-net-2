// See https://aka.ms/new-console-template for more information
using LinqRevolition;
using System.Xml;

Console.WriteLine("Hello, World!");
var collection = Enumerable.Range(1, 10);
collection.ToList().ForEach(x => Console.Write($" {x} "));
Console.WriteLine();
Console.WriteLine("--- Index olayı ---");
Console.WriteLine($" index değeri:  {collection.ToArray()[0]}");
Console.WriteLine("Range ve index pozisyonu");
Console.WriteLine("Sondan ikinci: ^2", collection.ElementAt(^2));

collection.Skip(0).Take(3).ToList().ForEach(n => Console.Write(n + " "));
Console.WriteLine();
collection.Skip(3).Take(3).ToList().ForEach(n => Console.Write(n + " "));
Console.WriteLine();

collection.Skip(6).Take(3).ToList().ForEach(n => Console.Write(n + " "));
Console.WriteLine();

Console.WriteLine("Range ile...");
Console.Write("Başlangiç indexi: ");
int start = int.Parse(Console.ReadLine());
Console.WriteLine("Bitiş İndeksi");
int end = int.Parse(Console.ReadLine());


collection.Take(start..end).ToList().ForEach(n => Console.Write(n + " "));
Console.WriteLine();
Console.WriteLine("Sondan ikinciden başlayarak");
collection.Take(^2..).ToList().ForEach(n => Console.Write(n + " "));
Console.WriteLine();
Console.WriteLine("Sondan ikinciye kadar");

collection.Take(..^2).ToList().ForEach(n => Console.Write(n + " "));
//Sondan başa doğru
Console.WriteLine();
Console.WriteLine("Sondan başa:");

collection.Take(^9..^2).ToList().ForEach(n => Console.Write(n + " "));

// By ile biten extension'lar:

var employees = new EmployeeService().GetEmployees();

Console.WriteLine();
Console.WriteLine("En fazla maaş alan kişi");
// var employee = employees.Where( e=>e.Salary ==  employees.Max(e => e.Salary));
var employee = employees.MaxBy(e => e.Salary);
Console.WriteLine(employee.FirstName + " " + employee.LastName);
Console.WriteLine();
Console.WriteLine("En az maaş alan kişi");
var employee2 = employees.MinBy(e => e.Salary);
Console.WriteLine(employee2.FirstName + " " + employee2.LastName);
Console.WriteLine();
Console.WriteLine("Distinct BY (çalışanların şehirleri:)");
Console.WriteLine();

var cities = employees.DistinctBy(e => e.City);
cities.ToList().ForEach(e => Console.WriteLine(e.City));

List<string> addresses = new List<string>() { "Sümer mh.", "Bağlar", "Hamam yolu" };
var result = addresses.FirstOrDefault(a => a.StartsWith("A"), "Bulunamadı!");
Console.WriteLine(result);





