using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetierSharedMemory.Model
{
    public class Personne
    {
        [Key]
        public int IdPersonne { get; set; }

        [Display(Name ="Nom")]
        [MaxLength(80, ErrorMessage ="La taille maximale est de 80"),Required(ErrorMessage ="*")]
        public string Nom { get; set; }

        [Display(Name = "Prenom")]
        [MaxLength(80, ErrorMessage = "La taille maximale est de 80"), Required(ErrorMessage = "*")]
        public string Prenom { get; set; }
    }
}