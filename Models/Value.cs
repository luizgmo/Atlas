using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtlasP.Models
{
    [Table("Value")]
    public class Value
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Informe o Nome")]
        [StringLength(60, ErrorMessage = "O Nome deve possuir no máximo 60 caracteres")]
        public string Name { get; set; }

        [Display(Name = "Valor")]
        [Column(TypeName = "decimal(10,2)")]
        [Required(ErrorMessage = "Informe o Valor")]
        public decimal Price { get; set; }

    }
}