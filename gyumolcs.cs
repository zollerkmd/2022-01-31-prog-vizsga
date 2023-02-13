using System;
using System.Collections.Generic;

namespace Gyumolcsok
{

    class Program
    {
        struct Gyumolcsok
        {
            public string nev;
            public string fajta;
            public int ar;
            public int db = 0;
            public string megjegyzes;
        }

        static List<Gyumolcsok> lista_Gyumolcs = new List<Gyumolcsok>();
        static Gyumolcsok gyumolcs;
        static int hely_index = 0;
        static string fajlnev = "gyümi.txt";

        static void Beker()
        {
            gyumolcs.nev = "a";
            while (gyumolcs.nev != "")
            {
                Console.Clear();
                Console.WriteLine("=========   B E K É R É S   ==========");
                Console.WriteLine("Kérem a gyümölcs nevét (Üres jelre kilép)!");
                gyumolcs.nev = Console.ReadLine();
                if (gyumolcs.nev == "")
                {
                    Console.WriteLine("Visszalépés főmenübe...");
                    // Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Kérem a gyümölcs fajtáját (h - honos vagy d - déli)!");
                    gyumolcs.fajta = Console.ReadLine();
                    Console.WriteLine("Kérem a gyümölcs árát!");
                    gyumolcs.ar = Convert.ToInt32(Console.ReadLine());
                    Random veletlen = new Random();
                    gyumolcs.db = veletlen.Next(0, 10);
                    lista_Gyumolcs.Add(gyumolcs);
                    hely_index++;
                }

                // Lista kiiratása
                Console.WriteLine("Lista elemeinek kiiratása: ");
                foreach (Gyumolcsok a in lista_Gyumolcs)
                {
                    Console.WriteLine(a.nev + "\t" + honos(a.fajta) + "\t" + Convert.ToString(a.ar) + "\t" + Convert.ToString(a.db));
                }
            }

            Console.Write("\nVisszalépés főmenübe...");
            Console.ReadKey();
            Fomenu();
        }

        static string honos(string faj)
        {
            string faj_vissza;
            switch (faj)
            {
                case "h":
                    faj_vissza = "honos";
                    break;
                case "d":
                    faj_vissza = "déli";
                    break;
                default:
                    faj_vissza = "rossz érték";
                    break;
            }
            honosM(faj_vissza);
            return faj_vissza;
        }

        static void honosM(string faj)
        {
            gyumolcs.megjegyzes = faj;
        }

        static void Kereses()
        {
            Console.Clear();
            Console.WriteLine("\n==========   K E R E S É S   ==========");
            Console.Write("Kérem a keresendő gyümölcs nevét! ");
            string keres_nev = Console.ReadLine();
            bool megvan = false;
            int hely = 0;

            for (int i = 0; i < hely_index; i++)
            {
                if (keres_nev == lista_Gyumolcs[i].nev)
                {
                    megvan = true;
                    hely = i;
                }
            }

            if (megvan == true)
            {
                Console.WriteLine("Megvan!");
                Console.WriteLine(lista_Gyumolcs[hely].nev + "\t" + honos(lista_Gyumolcs[hely].fajta) + "\t" + Convert.ToString(lista_Gyumolcs[hely].ar) + "\t" + Convert.ToString(lista_Gyumolcs[hely].db));
            }
            else
            {
                Console.WriteLine("Nincs ilyen nevű gyümölcs!");
            }
            Console.Write("\nVisszalépés főmenübe...");
            Console.ReadKey();
            Fomenu();
        }

        static void Legdragabb()
        {
            Console.Clear();
            Console.WriteLine("\n==========   L E G D R Á G Á B B   ==========");
            bool megvan = false;
            int hely = 0;
            int max_ar = 0;

            for (int i = 0; i < hely_index; i++)
            {
                if (max_ar < lista_Gyumolcs[i].ar)
                {
                    max_ar = lista_Gyumolcs[i].ar;
                    hely = i;
                }
            }

            Console.WriteLine(lista_Gyumolcs[hely].nev + "\t" + honos(lista_Gyumolcs[hely].fajta) + "\t" + Convert.ToString(lista_Gyumolcs[hely].ar) + "\t" + Convert.ToString(lista_Gyumolcs[hely].db));
            
            Console.Write("\nVisszalépés főmenübe...");
            Console.ReadKey();
            Fomenu();
        }

        static void Fajlbair()
        {
            Console.Clear();
            Console.WriteLine("\n==========   F Á J L B A   Í R Á S   ==========");
            StreamWriter kiir = new StreamWriter(fajlnev);
            // Lista kiiratása
            Console.WriteLine("Lista elemeinek kiírása fájlba... ");
            foreach (Gyumolcsok a in lista_Gyumolcs)
            {
                Console.WriteLine(a.nev + "\t" + honos(a.fajta) + "\t" + Convert.ToString(a.ar) + "\t" + Convert.ToString(a.db));
                kiir.WriteLine(a.nev + "\t" + honos(a.fajta) + "\t" + Convert.ToString(a.ar) + "\t" + Convert.ToString(a.db));
            }
            kiir.Flush();
            kiir.Close();
            Console.Write("\nVisszalépés főmenübe...");
            Console.ReadKey();
            Fomenu();
        }

        static void Fomenu()
        {
            Console.Clear();
            Console.WriteLine("==========   F Ő M E N Ű   ==========");
            Console.WriteLine("1., Adatok bekérése");
            Console.WriteLine("2., Keresés névre");
            Console.WriteLine("3., Legdrágább keresése");
            Console.WriteLine("4., Kiiratás fájlba");
            Console.WriteLine("5., ...");
            Console.WriteLine("0., Kilépés");
            string menupont = Console.ReadLine();

            switch (Convert.ToInt32(menupont))
            {
                case 1:
                    Beker();
                    break;
                case 2:
                    Kereses();
                    break;
                case 3:
                    Legdragabb();
                    break;
                case 4:
                    Fajlbair();
                    break;
                case 5:
                    Fomenu();
                    break;
                case 0:
                    return;
                default:
                    return;
            }
        }

        static void Main(string[] args)
        {
            Fomenu();
        }
    }
}
