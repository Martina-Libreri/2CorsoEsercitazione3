using GestioneSpese_EF.Context;
using GestioneSpese_EntitiesRepository.Entità;
using GestioneSpese_EntitiesRepository.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestioneSpese_EF.Repository
{
    public class RepositorySpeseEF : IRepositorySpesa
    {
        public bool ApprovazioneSpese(Spesa spesa)
        {
            using (var ctx = new GestioneSpeseContext())
            {
                if(spesa == null)
                {
                    return false;
                }

                spesa.Approvato = true;

                ctx.Update(spesa);
                ctx.SaveChanges();

                return true;
            }
        }

        public bool Create(Spesa item)
        {
            using (var ctx = new GestioneSpeseContext())
            {
                if (item == null)
                {
                    return false;
                }

                //Recupero la categoria
                var categoria = ctx.Categorie.Include(c => c.Spese)
                                             .Where(x => x.Id == item.CategoriaId)
                                             .SingleOrDefault();

               // Aggiungo la nuova spesa alla lista spese in categorie
                if (categoria != null)
                {
                    categoria.Spese.Add(item);
                }

                ctx.Add(item);
                ctx.SaveChanges();

                return true;
            }
        }

        public bool Delete(int id)
        {
            using (var ctx = new GestioneSpeseContext())
            {
                //Controllo sull'ID
                if (id < 0)
                {
                    return false;
                }
                var spesa = ctx.Spese.Find(id);

                if (spesa != null)
                {
                    ctx.Spese.Remove(spesa);
                    ctx.SaveChanges();
                }

                return true;
            }
        }

        public List<Spesa> Elenco()
        {

            List<Spesa> spese = new List<Spesa>();
            using (var ctx = new GestioneSpeseContext())
            {
                foreach (var item in ctx.Spese)
                {
                    spese.Add(item);
                }

                return spese;
            }
        }

        public List<Spesa> ElencoPerUtente(string utente)
        {
            List<Spesa> spese = new List<Spesa>();
            using (var ctx = new GestioneSpeseContext())
            {
                if(utente == null)
                {
                    return null;
                }

                var lista = ctx.Spese.Where(x => x.Utente == utente);

                foreach (var item in lista)
                {
                   spese.Add(item);
                }

                return spese;
            }
        }



        public List<Spesa> ElencoSpeseApprovate()
        {
            List<Spesa> spese = new List<Spesa>();
            using (var ctx = new GestioneSpeseContext())
            {
                var lista = ctx.Spese.Where(x => x.Approvato == true);

                foreach (var item in lista)
                {
                    spese.Add(item);
                }

                return spese;
            }
        }

        public Spesa GetById(int id)
        {
            using (var ctx = new GestioneSpeseContext())
            {
                if (id < 0)
                {
                    return null;
                }

                var spesa = ctx.Spese.Where(c=> c.Id == id).FirstOrDefault();

                return spesa;
            }
        }

        public decimal TotaleSpese(int categoria)
        {

            using (var ctx = new GestioneSpeseContext())
            {
               var tot = ctx.Spese.Where(c=>c.CategoriaId == categoria).Sum(x => x.Importo);
                return tot;
            }
                
        }

    }
}
