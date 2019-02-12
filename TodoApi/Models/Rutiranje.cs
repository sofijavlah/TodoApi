using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class Rutiranje
    {
        public long Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime datumRodjenja { get; set; }
        public string mestoRodjenja { get; set; }
        public string emailAdresa { get; set; }             
    }
}
