using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameX.Models
{
    public class Disciplines
    {
        [Key]
        public int DieciplineId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
