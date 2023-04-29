using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Stadium.Shared.Entities
{
    public class Ticket
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}")]
        [Display(Name = "Fecha")]
        public DateTime? Date { get; set; }

        [Display(Name = "Usada")]
        public bool Used { get; set; } = false;

        [Display(Name = "Porteria")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string? Entrance { get; set; }
    }
}
