#r "System.Data"

using System;
using System.Linq;

var numbers = Enumerable.Range(1, 10);

var greaterThanFive = from n in numbers
                      where n > 5
                      select n;

Console.WriteLine("numbers : {0}", string.Join(", ", greaterThanFive));