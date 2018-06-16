using GameX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameX.HelperClass
{
    public class MarkerContent
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Data { get; set; }
        public string Discipline { get; set; }
        public string Adress { get; set; }
        public List<string> EventParticipents { get; set; }
        public int Limit { get; set; }
        public int ParticipantsCount { get; set; }
    }
}
