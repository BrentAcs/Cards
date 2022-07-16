// See https://aka.ms/new-console-template for more information

using System.Runtime.CompilerServices;
using Cards.Core;
using Cards.Core.Cards;
using Cards.Core.Extensions;
using Cards.Core.Utilities;

Console.WriteLine("Hello, World!");

ICardDeckFactory factory = new StandardCardDeckFactory();
var deck = factory.Create();
deck.ToList().ForEach( c => Console.WriteLine($"{c.ToConsoleDisplay()}"));

Console.WriteLine();
Console.WriteLine("---Shuffle---");
Console.WriteLine();

deck.Shuffle();
deck.ToList().ForEach( c => Console.WriteLine($"{c.ToConsoleDisplay()}"));

// var list = new List<int> { 1, 2, 3, 4, 5 };
// list.Shuffle();

Console.ReadKey(true);




