using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtlasP.Models
{
    [Table("Coach")]
    public class Coach
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Informe o Nome")]
        [StringLength(200, ErrorMessage = "O Nome deve possuir no máximo 200 caracteres")]
        public string Name { get; set; } 

        [Display(Name = "Descrição")]
        [StringLength(3000, ErrorMessage = "A Descrição deve possuir no máximo 3000 caracteres")]
        public string Description { get; set; }

        [Display(Name = "Foto")]
        [StringLength(200)]
        public string Image { get; set; }
    }    
}