using System;
using System.Collections.Generic;

/*

Tavoite

Rakennat konsoliohjelman, joka ylläpitää varastoa ja 
tuote-ryhmittelyä sanakirjoilla.

Liitteenä ohjelmointityön ohjeistus (Harjoitusprojekti1.pdf) 
ja mallipohja (project1.cs) toteutettavalle ohjelmalle.

Käytettävät syntaksit/komennot (pakolliset):

Dictionary<TKey, TValue>
Add(...)
ContainsKey(...)
TryGetValue(...)
Remove(...)
foreach (var item in ...)
Keys ja/tai Values
 
Palautettavat dokumentit:
1. Päivitetty ohjelmistodokumentti (.cs tiedosto)
2. Raportti: harjoitusprojekti#1 (käytä materiaaleissa annettua raporttipohjaa)
- https://centria.itslearning.com/plans/courses/10887/plan/116421/element/660172?BackDestination=0&BackData=%7B%22BackDestination%22%3A%2210%22%2C%22planner2-sb-collapsed%22%3A%22false%22%7D

*/

public class Program
{
    public static void Main()
    {
        Dictionary<string, int> stock = new Dictionary<string, int>();

        stock.Add("Milk", 10);
        stock.Add("Bread", 5);
        stock.Add("Apple", 20);

        PrintStock(stock);

        AddOrIncrease(stock, "Milk", 3);
        AddOrIncrease(stock, "Banana", 7);

        TrySell(stock, "Apple", 5);
        TrySell(stock, "Apple", 500);
        TrySell(stock, "Cheese", 1);

        RemoveProduct(stock, "Bread");
        RemoveProduct(stock, "Bread");

        Console.WriteLine();
        PrintStock(stock);

        // Ryhmittely
        Dictionary<string, List<string>> categories = new Dictionary<string, List<string>>();
        AddToCategory(categories, "Dairy", "Milk");
        AddToCategory(categories, "Fruit", "Apple");
        AddToCategory(categories, "Fruit", "Banana");

        Console.WriteLine();
        PrintCategories(categories);
    }

    static void PrintStock(Dictionary<string, int> stock)
    {
        foreach (var pair in stock)
        {
            Console.WriteLine(pair.Key + ": " + pair.Value);
        }
    }

    static void AddOrIncrease(Dictionary<string, int> stock, string name, int amount)
    {
        // TODO: ContainsKey + Add / kasvatus
    }

    static void TrySell(Dictionary<string, int> stock, string name, int amount)
    {
        // TODO: TryGetValue + säännöt
    }

    static void RemoveProduct(Dictionary<string, int> stock, string name)
    {
        // TODO: Remove + tulostus
    }

    static void AddToCategory(Dictionary<string, List<string>> categories, string category, string product)
    {
        // TODO: ContainsKey/TryGetValue + lista
    }

    static void PrintCategories(Dictionary<string, List<string>> categories)
    {
        foreach (var pair in categories)
        {
            Console.WriteLine(pair.Key + ":");
            foreach (var product in pair.Value)
            {
                Console.WriteLine(" - " + product);
            }
        }
    }
}
