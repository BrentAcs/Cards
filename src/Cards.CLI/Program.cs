// See https://aka.ms/new-console-template for more information
using Cards.Core;

Console.WriteLine("Hello, World!");

ICardDeckFactory factory = new StandardCardDeckFactory();
var deck = factory.Create();

foreach(var card in deck)
{
   Console.WriteLine($"{card}");
}

Console.ReadKey(true);
