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
    public class RepositoryCategorieEF : IRepositoryCategorie
    {
        public bool Create(Categorie item)
        {
            using (var ctx = new GestioneSpeseContext())
            {
                if(item == null)
                {
                    return false;
                }

                ctx.Categorie.Add(item);
                ctx.SaveChanges();

                return true;
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Categorie> Elenco()
        {
            List<Categorie> lista = new List<Categorie>();
            using (var ctx = new GestioneSpeseContext())
            {
                foreach (var item in ctx.Categorie)
                {
                    lista.Add(item);
                }
                return lista;
            }
        }

        public Categorie GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Categorie GetByName(string item)
        {
            using (var ctx = new GestioneSpeseContext())
            {
                if (item == null)
                {
                    return null;
                }

                var categoria = ctx.Categorie.Where(c => c.Categoria == item).SingleOrDefault();
                return categoria;
            }
        }

      

        public int GetID(Categorie categorie)
        {
            using (var ctx = new GestioneSpeseContext())
            {
                if (categorie == null)
                {
                    return 0;
                }

                var categoriaID = ctx.Categorie.Where(c => c.Id == categorie.Id).SingleOrDefault();
                return categoriaID.Id;
            }
        }
    }
}
