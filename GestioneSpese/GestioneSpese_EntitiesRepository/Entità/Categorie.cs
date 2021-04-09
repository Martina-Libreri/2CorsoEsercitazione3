using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestioneSpese_EntitiesRepository.Entità
{
    public class Categorie : IEntity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Categoria { get; set; }
        public ICollection<Spesa> Spese { get; set; } = new List<Spesa>();

    }
}
