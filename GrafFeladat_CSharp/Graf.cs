﻿using System;
using System.Collections.Generic;

namespace GrafFeladat_CSharp
{
    /// <summary>
    /// Irányítatlan, egyszeres gráf.
    /// </summary>
    class Graf
    {
        int csucsokSzama;
        /// <summary>
        /// A gráf élei.
        /// Ha a lista tartalmaz egy(A, B) élt, akkor tartalmaznia kell
        /// a(B, A) vissza irányú élt is.
        /// </summary>
        readonly List<El> elek = new List<El>();
        /// <summary>
        /// A gráf csúcsai.
        /// A gráf létrehozása után új csúcsot nem lehet felvenni.
        /// </summary>
        readonly List<Csucs> csucsok = new List<Csucs>();

        /// <summary>
        /// Létehoz egy úgy, N pontú gráfot, élek nélkül.
        /// </summary>
        /// <param name="csucsok">A gráf csúcsainak száma</param>
        public Graf(int csucsok)
        {
            this.csucsokSzama = csucsok;

            // Minden csúcsnak hozzunk létre egy új objektumot
            for (int i = 0; i < csucsok; i++)
            {
                this.csucsok.Add(new Csucs(i));
            }
        }

        /// <summary>
        /// Hozzáad egy új élt a gráfhoz.
        /// Mindkét csúcsnak érvényesnek kell lennie:
        /// 0 &lt;= cs &lt; csúcsok száma.
        /// </summary>
        /// <param name="cs1">Az él egyik pontja</param>
        /// <param name="cs2">Az él másik pontja</param>
        public void Hozzaad(int cs1, int cs2)
        {
            if (cs1 < 0 || cs1 >= csucsokSzama ||
                cs2 < 0 || cs2 >= csucsokSzama)
            {
                throw new ArgumentOutOfRangeException("Hibas csucs index");
            }

            // Ha már szerepel az él, akkor nem kell felvenni
            foreach (var el in elek)
            {
                if (el.Csucs1 == cs1 && el.Csucs2 == cs2)
                {
                    return;
                }
            }

            elek.Add(new El(cs1, cs2));
            elek.Add(new El(cs2, cs1));
        }

        //A szélességi bejárás algoritmusa
        public void szelessegiBejar(int kezdopont)
        {
            var bejart = new HashSet<int>();
            var kovetkezok = new Queue<int>();

            kovetkezok.Enqueue(kezdopont);
            bejart.Add(kezdopont);

            while (kovetkezok.Count != 0)
            {
                int k = kovetkezok.Dequeue();
                Console.WriteLine(this.csucsok[k]);
                foreach (var el in this.elek)
                {
                    if (el.Csucs1 == k && !bejart.Contains(el.Csucs2))
                    {
                        kovetkezok.Enqueue(el.Csucs2);
                        bejart.Add(el.Csucs2);
                    }
                }
            }
        }

        public void melysegiBejar(int kezdopont)
        {
            var bejart = new HashSet<int>();
            bejart.Add(kezdopont);
            melysegiBejarRekurziv(kezdopont, bejart);
        }

        public void melysegiBejarRekurziv(int k, HashSet<int> bejart)
        {
            Console.WriteLine(this.csucsok[k]);
            foreach (var el in this.elek)
            {
                if (el.Csucs1 == k && !bejart.Contains(el.Csucs2))
                {
                    bejart.Add(el.Csucs2);
                    melysegiBejarRekurziv(el.Csucs2, bejart);
                }
            }
        }

        public bool osszefuggo()
        {
            var bejart = new List<int>();
            var kovetkezo = new Queue<int>();
            kovetkezo.Enqueue(0);
            bejart.Add(0);
            while (kovetkezo.Count > 0)
            {
                int k = kovetkezo.Dequeue();

                foreach (var el in this.elek)
                {
                    if (el.Csucs1 == k && !bejart.Contains(el.Csucs2))
                    {
                        kovetkezo.Enqueue(el.Csucs2);
                        bejart.Add(el.Csucs2);
                    }
                }
            }
            if (bejart.Count == this.csucsokSzama)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Graf feszitoFa()
        {
            var fa = new Graf(this.csucsokSzama);

            var bejart = new HashSet<int>();
            var kovetkezo = new Queue<int>();

            kovetkezo.Enqueue(0);
            bejart.Add(0);

            while (kovetkezo.Count > 0)
            {
                int k = kovetkezo.Dequeue();

                foreach (var el in this.elek)
                {
                    if (el.Csucs1 == elek[k].Csucs1)
                    {
                        if (!bejart.Contains(el.Csucs2))
                        {
                            bejart.Add(el.Csucs2);
                            kovetkezo.Enqueue(el.Csucs1);
                            fa.Hozzaad(el.Csucs1, el.Csucs2);
                        }
                    }
                }
            }
            return fa;
        }


        public mohoSzinezes()
        {
            szinezes = new Dictionary<int, int>();
            int maxSzin = this.csucsokSzama;
            for (int i = 0; i < this.csucsokSzama; i++)
            {
                valaszthatoSzinek = new HashSet<>();
                valaszthatoSzinet.add(maxSzin - 1);

                foreach (var el in this.elek)
                {
                    if (el.Csucs1 == i)
                    {
                        if (szinezes.ContainsKey(el.Csucs2))
                        {
                            szin = szinezes[el.Csucs2];
                            valaszthatoSzinek.Remove(szin);
                        }
                    }
                }
                valasztottSzin = Min(valaszthatoSzinek);
                szinezes.Add(new Csucs(i), valasztott_szin);
            }
            return szinezes;
        }

        public Dictionary<int, CsucsAdat> Dijkstra(int kezdopont)
        {
            var csucsAdatok = new Dictionary<int, CsucsAdat>();
            for (int i = 0; i < this.csucsokSzama-1; i++)
            {
                csucsAdatok.Add(i,new CsucsAdat());
            }
            csucsAdatok[kezdopont].koltseg = 0;
            int vizsgaltDarab = 0;
            while (vizsgaltDarad < csucsokSzama)
            {
                vizsgaltDarab++;
                var vizsgaltCsucs = this.KovetkezoCsucs(csucsAdatok);
                csucsAdatok[vizsgaltCsucs].vizsgaltuk = true;
                var aktualisCsucs = vizsgaltCsucs;
                foreach (var el in this.elek)
                {
                    if (el.Csucs1 == aktualisCsucs)
                    {
                        var ujKoltseg = csucsAdatok[vizsgaltCsucs].koltseg + e1.Suly;
                        if (ujKoltseg < csucsAdatok[el.Csucs2].koltseg)
                        {
                            csucsAdatok[el.Csucs2].koltseg = ujKoltseg;
                            csucsAdatok[el.Csucs2].forrasCsucs = aktualisCsucs;
                        }
                    }
                }
            }
            return csucsAdatok;
        }

        private int kovetkezoCsucs(Dictionary<int, CsucsAdat> csucsAdatok)
        {
            minIndex = index;
            foreach (index item in csucsAdatok)
            {
                if (item.vizsgaltuk == false && adat.koltseg < csucsAdatok[minIndex].koltseg)
                {
                    minIndex = index;
                }
            }
            return minIndex;
        }


        public override string ToString()
        {
            string str = "Csucsok:\n";
            foreach (var cs in csucsok)
            {
                str += cs + "\n";
            }
            str += "Elek:\n";
            foreach (var el in elek)
            {
                str += el + "\n";
            }
            return str;
        }

    }
}