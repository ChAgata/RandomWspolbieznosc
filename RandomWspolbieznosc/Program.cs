using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RandomWspolbieznosc
{
    public class Program
    {
        static void Main(string[] args)
        {
            //losowanie liczby większej od 1000 
            int liczba=0;
            do
            {
                Random x = new Random();
                liczba = x.Next();

            }
            while (liczba <= 1000);
            Console.WriteLine(liczba);

            //liniowo
            Console.WriteLine("Liniowo: ");
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            CzynnikiPierwsze(liczba);
            stopWatch.Stop();
            Console.WriteLine(Time(stopWatch));

            //wspolbieznie
            Console.WriteLine("Współbieżnie: ");
            Thread thread = new Thread(() => CzynnikiPierwsze(liczba));
            Stopwatch stopWatchWs = new Stopwatch();
            stopWatchWs.Start();
            thread.Start();
            stopWatchWs.Stop();
            Console.WriteLine(Time(stopWatchWs));
            Console.ReadLine();
        }

        //rozkladanie liczby na czynniki pierwsze
        private static void CzynnikiPierwsze(int liczba)
        {
            string wynik = "Czynniki pierwsze liczby " + liczba + " to:";
            int i = 2;
            int e = (int)Math.Sqrt(liczba);
            while (i <= e)
            {
                while ((liczba % i) == 0)
                {
                    liczba /= i;
                    e = (int)Math.Sqrt(liczba);
                    wynik += " " + i;
                }
                i++;
            }
            if (liczba > 1) wynik += " " + liczba;
            Console.WriteLine(wynik);
        }

        //liczenie czasu
        private static string Time(Stopwatch stopWatch)
        {
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            string time = "Czas wykonania zadania: " + elapsedTime;
            return time;
        }
    }
}
