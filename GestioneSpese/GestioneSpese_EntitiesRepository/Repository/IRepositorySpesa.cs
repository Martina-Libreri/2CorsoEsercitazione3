using GestioneSpese_EntitiesRepository.Entità;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneSpese_EntitiesRepository.Repository
{
    public interface IRepositorySpesa : IRepository<Spesa>
    {
        public bool ApprovazioneSpese(Spesa spesa);
        public List<Spesa> ElencoSpeseApprovate();
        public List<Spesa> ElencoPerUtente(string utente);
        public decimal TotaleSpese(int id);
      
    }
}
