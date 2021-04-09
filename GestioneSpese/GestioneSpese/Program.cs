using GestioneSpese_EF.Repository;
using GestioneSpese_EntitiesRepository.Entità;
using GestioneSpese_EntitiesRepository.Repository;
using System;

namespace GestioneSpese
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Gestione Spese");

            Console.WriteLine("Benvenuto Inserisci il tuo nome");
            string utente = Console.ReadLine();


            //Menu
            bool x = true;

            do
            {
                Console.WriteLine("Benvenuto nel Menu");
                Console.WriteLine("1 - Creazione Spesa");
                Console.WriteLine("2 - Approvazione Spesa");
                Console.WriteLine("3 - Cancellazione Spesa");
                Console.WriteLine("4 - Elenco Spese Approvate");
                Console.WriteLine("5 - Elenco Spese Utente");
                Console.WriteLine("6 - Totale Spese Per Categorie");
                Console.WriteLine("7 - Uscita dal Menu");

                char c = Console.ReadKey().KeyChar;

                Console.WriteLine();

                switch (c)
                {
                    case '1':
                        Operazioni.CreateSpesa(utente);
                        break;
                    case '2':
                        Operazioni.Approvazione();
                        break;
                    case '3':
                        Operazioni.Cancellazione();
                        break;
                    case '4':
                        Operazioni.Elenco();
                        break;
                    case '5':
                        Operazioni.ElencoUtente(utente);
                        break;
                    case '6':
                        Operazioni.TotaleSpese();
                        break;
                    case '7':
                        x = false;
                        break;
                    default:
                        Console.WriteLine("Scelta sbagliata");
                        break;
                }


            } while (x == true);
        }
    }
}
