using GameX.HelperClass;
using GameX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameX.ViewModel
{
    public class EventViewModel
    {
        public List<Events> Events { get; set; }

    }
    public class EventInputModel
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public DateTime Date { get; set; }
        public string HouseNumber { get; set; }
        public string PostCode { get; set; }
        public string Description { get; set; }
        public int DiciplineId { get; set; }
        public int? EventId { get; set; }
        public int? EventAdressId { get; set; }
        public int SelectedDisciplineID { get; set; }
        public int SelectedEventAddressID { get; set; }
        public List<CoordAddress> Address { get; set; }
        public List<Disciplines> Disciplines { get; set; }
        public int Limit { get; set; }
    }
    public class EventAddressModel{
        public List<CoordAddress> Address { get; set; } 
        public List<Disciplines> Disciplines { get; set; }
    }
}
