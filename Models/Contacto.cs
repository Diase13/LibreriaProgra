using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibreriaProgra.Models
{
    [Table("t_libro")]
    public class Contacto
    {

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int ID { get; set; }

    [Column("name")]

    public string nombre { get; set; }

    [Column("autor")]

    public string autor { get; set; }

    [Column("idioma")]

    public string idioma { get; set; }

    [Column("isbn")]

    public string isbn { get; set; }

    [Column("editorial")]

    public string editorial { get; set; }

    [Column("precio")]

    public int precio { get; set; }
    
    [Column("pages")]

    public int pagina { get; set; }


    [Column("descripcion")]

    public string descripcion { get; set; }

    [NotMapped]

    public String Respuesta { get; set; }

    }
}