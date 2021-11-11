// https://twitter.com/okyrylchuk/status/1443298075095732233

using System;
using System.Collections.Generic;
using System.Linq;

List<Product> products = new()
{
    new() { Name = "Product1", Price = 100 },
    new() { Name = "Product2", Price = 5 },
    new() { Name = "Product3", Price = 50 },
};

Product theCheapestProduct = products.MinBy(x => x.Price);
Product theMostExpensiveProduct = products.MaxBy(x => x.Price);
Console.WriteLine(theCheapestProduct);
// Output: Product { Name = Product2, Price = 5 }
Console.WriteLine(theMostExpensiveProduct);
// Output: Product { Name = Product1, Price = 100 }

record Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}

