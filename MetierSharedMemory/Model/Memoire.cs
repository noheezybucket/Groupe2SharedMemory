using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetierSharedMemory.Model
{
    public class Memoire
    {
        [Key]
        public int IdMemoire { get; set; }

        [Display(Name = "Sujet du mémoire")]
        [MaxLength(300, ErrorMessage = "La taille maximale est de 300"), Required(ErrorMessage = "*")]
        public string Sujet { get; set; }
        [Display(Name = "Nom du document")]
        [MaxLength(80, ErrorMessage = "La taille maximale est de 80"), Required(ErrorMessage = "*")]
        
        public string Filename { get; set;}
        [Required(ErrorMessage ="*")]

        public int Annee { get; set; }

        public int? IdEncadreur { get; set; }
        [ForeignKey("IdEncadreur")]

        public Encadreur Encadreur { get; set; }
    }
}