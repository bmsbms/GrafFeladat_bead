using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafFeladat_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var graf = new Graf(6);

            graf.Hozzaad(0, 1);
            graf.Hozzaad(1, 2);
            graf.Hozzaad(0, 2);
            graf.Hozzaad(2, 3);
            graf.Hozzaad(3, 4);
            graf.Hozzaad(4, 5);
            graf.Hozzaad(2, 4);

            Console.WriteLine(graf);

            Console.WriteLine("Szélesség Bejárasa 2. kezdőponttól");
            graf.szelessegiBejar(2);
            Console.WriteLine("Mélyeségi Bejárasa 2. kezdőponttól");
            graf.melysegiBejar(2);
            Console.WriteLine("Összefüggőség megvizsgálása: {0}", graf.osszefuggo());
            var feszitoFa = graf.feszitoFa();
            Console.WriteLine(feszitoFa);
            var sulyok = new Dictionary<int, CsucsAdat>(graf.Dijkstra(2));
            foreach (var i in sulyok)
            {
                Console.WriteLine(i.Key + " a csúcsba eljutni: " + i.Value.koltseg);
            }


            Console.ReadLine();
        }
    }
}
