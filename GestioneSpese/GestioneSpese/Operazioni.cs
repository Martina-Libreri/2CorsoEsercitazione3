using GestioneSpese_EF.Repository;
using GestioneSpese_EntitiesRepository.Entità;
using GestioneSpese_EntitiesRepository.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneSpese
{
    //Classe d'appoggio per separare l'Interazone con l'utente

    public static class Operazioni
    {
        private static IRepositorySpesa repositorySpesa = new RepositorySpeseEF();
        private static IRepositoryCategorie repositoryCategorie = new RepositoryCategorieEF();

        public static void CreateSpesa(string utente)
        {
            Console.WriteLine("Inserisci la descrizione");
            string descrizione = Console.ReadLine();
            Console.WriteLine("Inserisci l'importo");
            decimal importo = 0;
            do
            {
                try
                {
                    importo = Convert.ToDecimal(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Errore, imserisci l'importo corretto!");
                }

            } while (importo == 0);

            Console.WriteLine("Inserisci la categoria");
            string categoria = Console.ReadLine();


            Spesa spesa = new Spesa()
            {
                Descrizione = descrizione,
                Utente = utente,
                CategoriaId = repositoryCategorie.GetID(repositoryCategorie.GetByName(categoria)),
                Importo = importo
            };

            repositorySpesa.Create(spesa);
        }

        public static bool Approvazione()
        {
            List<Spesa> lista = repositorySpesa.Elenco();
            //Creare la lista
            foreach (var item in lista)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("Dimmi l'id della spesa da approvare");
            int id = Convert.ToInt32(Console.ReadLine());

            Spesa spesa = repositorySpesa.GetById(id);
            return repositorySpesa.ApprovazioneSpese(spesa);
        }

        public static bool Cancellazione()
        {
            List<Spesa> lista = repositorySpesa.Elenco();
            //Creare la lista
            foreach (var item in lista)
            {
                Console.WriteLine(item.Id + " " + item.Descrizione);
            }

            Console.WriteLine("Dimmi l'id della spesa da Eliminare");
            int id = Convert.ToInt32(Console.ReadLine());

            return repositorySpesa.Delete(id);
        }

        public static void Elenco()
        {
            List<Spesa> lista = repositorySpesa.ElencoSpeseApprovate();
            foreach (var item in lista)
            {
                Console.WriteLine(item.ToString());
            }
        }
        public static void ElencoUtente(string utente)
        {
            List<Spesa> lista = repositorySpesa.ElencoPerUtente(utente);
            foreach (var item in lista)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public static void TotaleSpese()
        {
            foreach (var item in repositoryCategorie.Elenco())
            {
                Console.WriteLine( item.Categoria + " " + repositorySpesa.TotaleSpese(item.Id));
            }
            
        }
    }

    
}
