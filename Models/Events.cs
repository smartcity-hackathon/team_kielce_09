using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace GameX.Models
{ 


    public class Events
    {
        [Key]
        public int EventId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string Coords { get; set; }

        public string Description { get; set; }

        
        public int DisciplineId { get; set; }
        public Disciplines Discipline { get; set; }
        

        public int EventAdressId { get; set; }
        public EventAdress EventAdress { get; set; }

        public int Limit { get; set; }


    }
}
