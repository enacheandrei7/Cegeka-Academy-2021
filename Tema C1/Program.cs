using System;
using System.Collections.Generic;
static class Car
{
    static List<string> listaStatica;
    static List<string> listaCuPachete;

    static Car()
    {
        listaStatica = new List<string>();
        listaCuPachete = new List<string>();
    }

    public static void Record(string value) /*Adaugarea de elemente in lista*/
    {

        int i = 0;
        foreach (var valoare in listaStatica)
        {
            if (value == valoare)
            {
                i++;
            }
        }
        if (i==0)
        {
            listaStatica.Add(value);
            Console.WriteLine("---------------------------------------------\nMasina model " + value + " a fost adaugata cu succes!\n---------------------------------------------\n");
        }
        else
        {
            Console.WriteLine("\nMasina deja existenta in lista.\n");
        }
    }

    public static void RecordPachet(string Masina)
    {
        if (listaStatica.Contains(Masina))
        {
            Console.WriteLine("--------------------\nCe doriti sa contina pachetul dumneavoastra?\n");
            string PachetNou = Console.ReadLine();
            listaCuPachete.Add(Masina + " " + PachetNou);
            Console.WriteLine("---------------------------------------------\nPachetul dumneavoastra a fost adaugat!\n---------------------------------------------\n");
        }
        else
        {
            Console.WriteLine("-------------------------------------------\nNe pare rau, masinea aleasa de dumneavoastra nu se afla in lista.\n-------------------------------------------\n");
        }
    }

    public static void Display() /*Display al elementelor listei*/
    {
        foreach (var valoare in listaStatica)
        {
            Console.WriteLine("-"+valoare);
        }
    }
    public static void DisplayFUll() /*Display al elementelor listei*/
    {
        int i = 1;
        foreach (var valoare in listaCuPachete)
        {
            Console.WriteLine(" " + i + " - " + valoare);
            i++;
        }
    }
    public static void AdaugarePachet(string numar)
    {
        int x = Int32.Parse(numar)-1;
        Console.WriteLine("--------------------\nCe doriti sa adaugati la pachetul dumneavoastra?\n--------------------");
        string pacheteAdaugate = Console.ReadLine();
        var a = listaCuPachete[x]+" "+ pacheteAdaugate;
        listaCuPachete.RemoveAt(x);
        listaCuPachete.Insert(x, a);
        Console.WriteLine("--------------------\nElementele au fost adaugate cu succes!\n--------------------");
    }
    public static void DisplayNrMasini() /*Display al nr de elemente din lista*/
    {
        Console.WriteLine("---------------------------------\nNumarul total de masini construite:");
        Console.WriteLine("---> "+listaCuPachete.Count);
        Console.WriteLine("---------------------------------\n");
    }
}
class Program
{
    static void Main(string[] args)
    {
        bool doNotExit = true;
        while (doNotExit)
        {
            Console.WriteLine("Introduceti litera corespunzatoare actiunii dorite:\n a - Inserarea unui nou model de masina\n b - Vizualizarea modelelor de masini existente\n c - Adaugarea de pachete pentru un anumit model de masina\n d - Afisarea modelelor cu optiunile aferente\n e - Adaugarea elementelor unei masini cu un pachet existent\n f - Iesirea din meniu\n g - Numar de masini fabricate " );
            string input = Console.ReadLine();
            if (input == "a")
            {
                Console.WriteLine("\nVa rugam introduceti marca masinii:\n");
                string Model = Console.ReadLine();
                Car.Record(Model/*+ " " + Package */);
            }
            else if (input == "b")
            {
                Console.WriteLine("---------------\n Modele masini\n---------------");
                Car.Display();
                Console.WriteLine("---------------\n");
            }
            else if (input == "c")
            {
                Console.WriteLine("---------------\n Modele masini\n---------------");
                Car.Display();
                Console.WriteLine("---------------\n");
                Console.WriteLine("\nPentru ce model va fi adaugat pachetul?");
                string Pachet = Console.ReadLine();
                Car.RecordPachet(Pachet);

            }
            else if (input == "d")
            {
                Console.WriteLine("---------------------------\n Modele masini cu optiuni\n---------------------------");
                Car.DisplayFUll();
            }
            else if (input == "e")
            {
                Console.WriteLine("---------------------------\n Modele masini cu optiuni\n---------------------------");
                Car.DisplayFUll();
                Console.WriteLine("---------------------------\nAlegeti numarul corespunzator modelului\n---------------------------\n");
                string nrModel = Console.ReadLine();
                Car.AdaugarePachet(nrModel);
            }
            else if (input == "f")
            {
                doNotExit = false;
            }
            else if (input == "g")
            {
                Car.DisplayNrMasini();
            }
            else
            {
                Console.WriteLine("--------------------------------------------\nComanda necunoscuta. Va rugam reincercati!\n--------------------------------------------");
            }
        }

    }
}