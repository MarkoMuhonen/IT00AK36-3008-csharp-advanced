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
            LotteryRow myRow = new LotteryRow();
            
            try
            {
                player = new Player(playerName, myRow);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Error: " + e.Message);
                return;
            }

            // TODO: -
            // DONE: 
            // - Luo pelaajan rivi ja voittorivi
            LotteryRow winningRow = new LotteryRow();

            // TODO: -
            // DONE:
            // - Laske osumat
            int hits = CountHits(player.MyRow, winningRow);

            // TODO: Lisää tulos historiaan ja tallenna
            // - Historyfileformat: 2026-02-18; Name=Anna; Hits=3; My=...; Win=... 
            history.AddLine(DateTime.Now.ToString("yyyy-MM-dd") + "; Name=" + player.Name + "; Hits=" + hits + "; My=" + player.MyRow.ToString() + "; Win=" + winningRow.ToString());
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
