using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibreriaProgra.Models
{
    [Table("t_usuario")]
    public class Usuario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Por favor ingrese Nombre")]
        [Display(Name="Nombres Completos")]
         [Column("name")]
        public String Name { get; set; }

        [Display(Name="Email")]
        [Column("email")]
        public String Email { get; set; }

        [NotMapped]
        public String Response { get; set; }

    }
}