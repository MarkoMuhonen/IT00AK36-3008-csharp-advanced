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

//
// Projektin päämetodi, jossa simuloidaan ja testataan varaston toimintoja

    public static void Main()
    {
        Dictionary<string, int> stock = new Dictionary<string, int>(); // luodaan varasto sanakirjana

        stock.Add("Milk", 10); // lisätään tuotteita varastoon
        stock.Add("Bread", 5);
        stock.Add("Apple", 20);

        PrintStock(stock);  // tulostetaan varaston sisältö

        AddOrIncrease(stock, "Milk", 3); //lisätään lisää tuotteita
        AddOrIncrease(stock, "Banana", 7);

        TrySell(stock, "Apple", 5);     // yritetään myydä tuotteita
        TrySell(stock, "Apple", 500);
        TrySell(stock, "Cheese", 1);

        RemoveProduct(stock, "Bread"); // poistetaan tuote varastosta
        RemoveProduct(stock, "Bread"); // poistetaan, mutta ei tuotetta ei ole, koska poistettu jo aiemmin -> virheilmoitus

        Console.WriteLine();
        PrintStock(stock);              // tulostetaan varaston sisältö

        // Ryhmittely, luodaan uusi sanakirja tuoteryhmille
        Dictionary<string, List<string>> categories = new Dictionary<string, List<string>>();
        AddToCategory(categories, "Dairy", "Milk"); // lisätään tuotteita tuoteryhmiin
        AddToCategory(categories, "Fruit", "Apple");
        AddToCategory(categories, "Fruit", "Banana");

        Console.WriteLine();
        PrintCategories(categories);    // tulostetaan tuoteryhmät ja tuotteet
    }

    static void PrintStock(Dictionary<string, int> stock)
    {
        foreach (var pair in stock)                             //käydään varaston tuotteet läpi
        {
            Console.WriteLine(pair.Key + ": " + pair.Value);    // tulostetaan tuote ja määrä
        }
    }

    static void AddOrIncrease(Dictionary<string, int> stock, string name, int amount)
    {
        // TODO: ContainsKey + Add / kasvatus
        // Jos tuote löytyy, lisätään määrää, tai luodaan uusi tuote varastoon
        if (stock.ContainsKey(name))
        {
            stock[name] += amount;
        }
        else
        {
            stock.Add(name, amount);
        }
    }

    static void TrySell(Dictionary<string, int> stock, string name, int amount)
    {
        // TODO: TryGetValue + säännöt
        // Yritetään myydä tuotetta, tarkistetaan ensin löytyykö tuote ja onko tarpeeksi varastossa
              
        if (!stock.TryGetValue(name, out int currentAmount))      // jos tuotetta ei ole 
        {
            Console.WriteLine("Not found: " + name);    // tulostetaan virheilmoitus
            return;
        }
        if (currentAmount < amount)                            // jos varastosaldo pienempi kuin myytävä määrä, ilmoitetaan ettei voida myydä
        {
            Console.WriteLine("Not enough stock: " + name);
            return;
        }
        else
        {
            stock[name] -= amount;                             // vähennetään myyty määrä varastosta
            Console.WriteLine("Sold" + amount + " " + name);
        }
    }

    static void RemoveProduct(Dictionary<string, int> stock, string name)
    {
        // TODO: Remove + tulostus
        //  Poistetaan tuote varastosta, ilmoitetaan jos tuotetta ei löydy
            if (stock.Remove(name))
            {
                Console.WriteLine("Removed: " + name);
            }
            else
            {
                Console.WriteLine("Not found: " + name);
            }
            
    }

    static void AddToCategory(Dictionary<string, List<string>> categories, string category, string product)
    {
        // TODO: ContainsKey/TryGetValue + lista
        // AddToCategory(categories, "Dairy", "Milk");
        // Lisätään tuote tuoteryhmään, luodaan tarvittaessa uusi ryhmä
        if (!categories.ContainsKey(category))
        {
            categories.Add(category, new List<string>());
        }
        categories[category].Add(product);
    }

    static void PrintCategories(Dictionary<string, List<string>> categories)
    {   
        // käydään läpi tuoteryhmät ja tulostetaan ryhmän nimi ja tuotteet
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
