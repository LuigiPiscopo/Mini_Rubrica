using System;
using System.IO;
using System.Collections.Generic;


class Program
{                     // Rubrica 
    static void Main()
    {

        List<(string Nome, string Numero)> rubrica = new List<(string, string)>();

        CaricaRubricaDaFile(rubrica);

        while (true)
        {
            Console.WriteLine("\n Mini Rubrica Telefonica ");
            Console.WriteLine("1 Aggiungi un contatto ");
            Console.WriteLine("2 Visualizza tutti i contatti ");
            Console.WriteLine("3 Cerca un contatto ");
            Console.WriteLine("4 Elimina un contatto ");
            Console.WriteLine("5 Esci ");
            Console.Write("Scegli un'opzione; \n");

            string scelta = Console.ReadLine() ?? string.Empty;

            switch (scelta)
            {
                case "1":
                    AggiungiContatto(rubrica);
                    break;
                case "2":
                    VisualizzaContatti(rubrica);
                    break;
                case "3":
                    CercaContattoXnomeONumero(rubrica);
                    break;
                case "4":
                    EliminaContatto(rubrica);
                    break;
                case "5":
                    Console.WriteLine("Uscita dal programma, Arrivederci");
                    return;
                default:
                    Console.WriteLine("X Scelta non valida, riprova.");
                    break;
            }
        }

    }

    static void AggiungiContatto(List<(string Nome, string Numero)> rubrica)
    {

        Console.WriteLine("Inserisci il nome ");
        string nome = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Inserisci il numero ");
        string numero = Console.ReadLine() ?? string.Empty;

        rubrica.Add((nome, numero));
        Console.WriteLine("Contatto aggiunto con succeso ");

        SalvaRubricaSuFile(rubrica);

    }

    static void VisualizzaContatti(List<(string Nome, string Numero)> rubrica)
    {
        if (rubrica.Count == 0)
        {
            Console.WriteLine("La rubrica e vuota.");
            return;

        }

        Console.WriteLine("\n Lista Contatti");
        foreach (var contatto in rubrica)
        {
            Console.WriteLine($"{contatto.Nome} - {contatto.Numero}");
        }
    }
                                // Nuova funzione CercaContattoXnomeONumero Riga 156

                                // Funzione Obsoleta.
    // static void CercaContatto(List<(string Nome, string Numero)> rubrica)
    // {
    //     Console.Write("Inserisci il nome da cercare \n");
    //     string nomeCercato = (Console.ReadLine() ?? string.Empty).ToLower();

    //     bool trovato = false;

    //     foreach (var contatto in rubrica)
    //     {
    //         if (contatto.Nome.ToLower().Contains(nomeCercato))
    //         {
    //             Console.WriteLine($"Contatto trovato: {contatto.Nome} - {contatto.Numero}");
    //             trovato = true;
    //         }
    //     }

    //     if (!trovato)
    //     {
    //         Console.WriteLine("Contatto non trovato.");
    //     }
    // }

    static void EliminaContatto(List<(string Nome, string Numero)> rubrica)
    {
        Console.Write("Inserisci il nome dal contatto da eliminare:");
        string nomeDaEliminare = (Console.ReadLine() ?? string.Empty).ToLower();

        for (int i = 0; i < rubrica.Count; i++)
        {

            if (rubrica[i].Nome.ToLower() == nomeDaEliminare)
            {
                Console.WriteLine($"Contatto {rubrica[i].Nome} eliminato con successo.");
                rubrica.RemoveAt(i);

                SalvaRubricaSuFile(rubrica);
                return;
            }
        }

        Console.WriteLine("Contatto non trovato.");
    }
    static void SalvaRubricaSuFile(List<(string Nome, string Numero)> rubrica)
    {
        using (StreamWriter sw = new StreamWriter("rubrica.txt"))
        {
            foreach (var contatto in rubrica)
            {
                sw.WriteLine($"{contatto.Nome} - {contatto.Numero}");
            }
        }
    }


    static void CaricaRubricaDaFile(List<(string Nome, string Numero)> rubrica)
    {
        if (File.Exists("rubrica.txt"))
        {
            string[] righe = File.ReadAllLines("rubrica.txt");
            foreach (string riga in righe)
            {
                string[] dati = riga.Split('-');
                if (dati.Length == 2)
                {
                    rubrica.Add((dati[0], dati[1]));
                }
            }
        }
    }

    static void CercaContattoXnomeONumero(List<(string Nome, string Numero)> rubrica)
    {
        Console.Write("Inserisci il nome o il numero da cercare: ");
        string inputCercato = (Console.ReadLine() ?? string.Empty).ToLower();
        bool trovato = false;

        foreach(var contatto in rubrica){
            if (contatto.Nome.ToLower().Contains(inputCercato) || contatto.Numero.Contains(inputCercato)){
                Console.WriteLine($"Contatto trovato: {contatto.Nome} - {contatto.Numero}");
                trovato = true;
            }
        }
        if(!trovato){
            Console.WriteLine("Contatto non trovato.");
        }   
    }


}