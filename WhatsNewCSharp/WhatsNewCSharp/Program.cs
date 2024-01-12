
// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;
using WhatsNewCSharp;

Console.WriteLine("Hello, World!");

#region lambda changes
Func<int, bool> isEven = (int number) => number % 2 == 0;
//Dikkat!!! "var" keywordu'ü belirttiğiniz lambda kuralına göre, delegeyi tahmin edebilir. 
var isEvenNew = (int number) => number % 2 == 0;

var show = (string message) => Console.WriteLine(message);

//var isOdd = x => x % 2 == 0; Bu satır kesinlikle hata verir!!!

object isEvenObject = (int number) => number % 2 == 0;
Delegate isEvenDelegate = (int number) => number % 2 == 0;

Func<int> read = Console.Read;
var readNew = Console.Read;

Action<string> write = Console.Write;
//var writeNew = Console.Write; - Olmaz çünkü, Console.Write fonksiyonunun onlarca overload'ı var.

var response = object (bool x) => x ? 1 : "noResult";

var parse = (string s) => int.Parse(s);
var choose = object (bool b) => b ? 1 : "hatalı";

#endregion


#region struct

Address address = new Address();

Person person = new Person("Türkay", "Ürkmez");
Person person1 = new Person("Türkay", "Ürkmez");

Console.WriteLine($"record struct'lar karşılaştırılıyor: {person == person1}");

#endregion


#region records overview
var comments = new string[2];
ProductRecord product = new ProductRecord("Şemsiye", 250, comments);
ProductRecord product2 = new ProductRecord("Şemsiye", 250, comments);

//var anP1 = new { Name = "Şemsiye", Price = 250 };
//var anP2 = new { Name = "Şemsiye", Price = 250 };


Console.WriteLine(product == product2);
//Console.WriteLine(anP1 == anP2);
Console.WriteLine(ReferenceEquals(product, product2));

product2.comments[1] = "Güzelmiş";

product.comments.ToList().ForEach(comment => Console.WriteLine($"Bu product: {comment}"));
product2.comments.ToList().ForEach(comment => Console.WriteLine($"Bu product-2: {comment}"));


#endregion


#region toplu değişken tanımlama

int x;
int y;

(x, y) = (3, 5);
(var a, var b) = (8, 9);

//C# 10.0'da hem önceden tanımlı hem de o an tanımlanabilen değişkenlere değer atayabiliyorum.
(y, var z) = (-5, 12);
#endregion


#region Property patterns
object pro = new Product
{
    Name = "Akıllı TV",
    Price = 10000,
    Vendor = new Vendor { CompanyName = "Philips" }
};

if (pro is Product { Vendor: { CompanyName: "Philips" } })
{
    Console.WriteLine("Evet... Philips");
}

if (pro is Product { Vendor.CompanyName: "Philips" }) //property pattern
{
    Console.WriteLine("Burası C# 10'da çalışır!");
}


#endregion

#region Koşullu argüman kavramı

var test = 8;
var isChecked = true;
checkCondition(isChecked);
checkCondition(test < 8);


void checkCondition(bool condition, [CallerArgumentExpression("condition")] string? message = null)
{
    Console.WriteLine($"condition: {message}");
}

#endregion




var outputFromDivide = divide(13, 3);
Console.WriteLine(outputFromDivide.Item1);
Console.WriteLine(outputFromDivide.Item2);

(int result, int modulo) = divide(13, 3);
Console.WriteLine($"Bölüm: {result}, kalan:{modulo}");






(int, int) divide(int number1, int number2)
{
    //var tuple = Tuple.Create(number1/number2, number1%number2);
    return (number1 / number2, number1 % number2);
}
