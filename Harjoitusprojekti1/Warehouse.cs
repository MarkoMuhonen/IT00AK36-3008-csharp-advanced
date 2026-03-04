
// namespace Exercise009
//{
    using System;
    using System.Collections.Generic;

    public class Warehouse
    {
        private Dictionary<string, List<string>> storage;
        public Warehouse()
        {
            this.storage = new Dictionary<string, List<string>>();
        }

        public void Add(string unit, string item)
        {
            if (!this.storage.ContainsKey(unit))
            {
                this.storage.Add(unit, new List<string>());
            }
            this.storage[unit].Add(item);

        }
        public List<string> Contents(string storageUnit)
        /*
            palauttaa listan, joka sisältää kaikki parametrina annetussa varastoyksikössä olevat tavarat.
            Jos varastotilaa ei ole olemassa, palautetaan tyhjä lista.
        */  
                
        {
            if (!this.storage.ContainsKey(storageUnit))
            {
                this.storage.Add(storageUnit, new List<string>());
            }
            return this.storage[storageUnit];
        }

        public void Remove(string storageUnit, string item)
        /*
            Poistaa parametrina annetun tavaran parametrina annetusta varastoyksiköstä.
            Jos varastoyksikkö tyhjenee tavaran poistamisen jälkeen, koko varastoyksikkö poistetaan.
        */


        {
            if (this.storage.ContainsKey(storageUnit))
            {
                this.storage[storageUnit].Remove(item);
                if (this.storage[storageUnit].Count == 0)
                {
                    this.storage.Remove(storageUnit);
                }
            }
        }


        public List<string> StorageUnits()
        /*
            palauttaa listan kaikista varastoyksiköistä, joissa on tavaroita.
        */
        {
            List<string> unitsWithItems = new List<string>();

            Dictionary<string, List<string>>.KeyCollection keys = this.storage.Keys;   

            foreach (string storages in keys)
            {
                unitsWithItems.Add(storages);
            }
            return unitsWithItems;
        }
    }
//}