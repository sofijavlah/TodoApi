using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TodoApi.Models
{
    public class Osoba
    {

        //!
        public static List<Osoba> Osobe
        {
            get
            {
                var jsonLoad = File.ReadAllText("proba.json");
                var list = JsonConvert.DeserializeObject<List<Osoba>>(jsonLoad);
                return list;
            }
        }

        public long Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string MestoRodjenja { get; set; }
        public string EmailAdresa { get; set; }

    }
}
