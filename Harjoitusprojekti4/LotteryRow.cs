namespace Harjoitusprojekti4
{
    using System;
    using System.Collections.Generic;
    class LotteryRow
    {
        private List<int> numbers;
        private Random random;

        public LotteryRow()
        {
            numbers = new List<int>();
            random = new Random();

            // TODO: 
            // DONE: Arvo numerot
            RandomizeNumbers();
        }

        public List<int> Numbers()
        {
            // Palauta lista (opiskelijatasolla ok) ??? mtä tarkoittaa
            return numbers;
        }

        public bool ContainsNumber(int number)
        {
            return numbers.Contains(number);
        }

        public void RandomizeNumbers()
        {
            // TODO:
            // DONE:
            // - Tyhjennä lista
            // - Arvo 7 eri numeroa väliltä 1..40
            // - Käytä random.Next(1, 41)
            // - Estä duplikaatit Contains-metodilla

            numbers.Clear();

            while (numbers.Count < 7)
            {
                int number = random.Next(1, 41);

                if (!numbers.Contains(number))
                {
                    numbers.Add(number);
                }
            }
        }

        public override string ToString()
        {
            // TODO: Palauta numerot yhtenä merkkijonona esim. "3 7 12 18 22 35 40"
            string result = "";

            foreach (int n in numbers)
            {
                result += n + " ";
            }

            return result.Trim();
        }
    }
}