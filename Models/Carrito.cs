using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibreriaProgra.Models
{
     public class Carrito
    {
        [Display(Name="Nombre")]
        public String Nombre { get; set; }

        [Display(Name="Precio")]
        public String Precio { get; set; }

        [Display(Name="Cantidad")]
        public int Cantidad { get; set; }

        [Display(Name="Subtotal")]
        public int Subtotal { get; set; }

        [Display(Name="Mensaje")]
        public String Message { get; set; }

        public String Response { get; set; }
    }
}