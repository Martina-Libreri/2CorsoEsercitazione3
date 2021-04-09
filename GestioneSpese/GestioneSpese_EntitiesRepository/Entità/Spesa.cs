using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestioneSpese_EntitiesRepository.Entità
{
    public class Spesa : IEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
        public int CategoriaId { get; set; }
        [ForeignKey(nameof(CategoriaId))]
        public Categorie Categoria { get; set; }

        [MaxLength(500)]
        public string Descrizione { get; set; }

        [MaxLength(100)]
        public string Utente { get; set; }
        public decimal Importo { get; set; }
        public bool Approvato { get; set; } = false;



        //Metodo
        public override string ToString()
        {
            return $"{Id} : {Descrizione}, Importo: {Importo} , Data: {Data} , Categoria: {CategoriaId}, Utente: {Utente}, Approvazione: {Approvato}";
        }

    }
}
