using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibreriaProgra.Models
{
    [Table("t_carrito")]
    public class Carrito
    {

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int ID { get; set; }

    [Column("name")]
    public string nombre { get; set; }

    [Column("precio")]
    public int precio { get; set; }

    [Column("cantidad")]
    public int cantidad { get; set; }

    [Column("subtotal")]
    public int subtotal { get; set; }

    [NotMapped]
    public String Response { get; set; }

    }
}