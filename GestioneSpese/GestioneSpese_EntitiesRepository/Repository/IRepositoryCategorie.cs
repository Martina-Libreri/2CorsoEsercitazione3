using GestioneSpese_EntitiesRepository.Entità;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneSpese_EntitiesRepository.Repository
{
    public interface IRepositoryCategorie : IRepository<Categorie>
    {
        public Categorie GetByName(string item);
        public int GetID(Categorie categorie);
        
    }
}
