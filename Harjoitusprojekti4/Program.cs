namespace Harjoitusprojekti4
{
    using System;
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: -
            // DONE: 
            // - Luo historia ja lataa tiedosto
            GameHistory history = new GameHistory("history.txt");
            history.Load();

            // TODO: -
            // DONE: 
            // - Kysy pelaajan nimi ja luo Player try/catchilla
            // - try { ... } catch (ArgumentException e) { ... }
            Console.WriteLine("Please enter your name:");
            string playerName = Console.ReadLine();
            Player player;
            
            try
            {
                player = new Player(playerName, new LotteryRow());
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Error: " + e.Message);
                return;
            }

            // TODO: -
            // DONE: 
            // - Luo pelaajan rivi ja voittorivi
            LotteryRow myRow = new LotteryRow();
            LotteryRow winningRow = new LotteryRow();

            // TODO: -
            // DONE:
            // - Laske osumat
            int hits = CountHits(myRow, winningRow);

            // TODO: Lisää tulos historiaan ja tallenna
            history.AddLine(player.Name + " | My Row: " + myRow.ToString() + " | Winning Row: " + winningRow.ToString() + " | Hits: " + hits);
            history.Save();

            // TODO: 
            // DONE: 
            // - Tulosta lopuksi historia
            history.Print();
        }

        // Apumetodi osumien laskuun (ei LINQiä)
        static int CountHits(LotteryRow myRow, LotteryRow winningRow)
        {
            int hits = 0;

            foreach (int number in myRow.Numbers())
            {
                if (winningRow.ContainsNumber(number))
                {
                    hits++;
                }
            }

            return hits;
        }
    }
}
