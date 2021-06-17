using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatDomain
{
    public class voznja
    {
        public int id { get; set; }
        public virtual user user { get; set; }
        public virtual vozac vozac { get; set; }

        public virtual markaKola markaKola { get; set; }

        public virtual tip_auta Tip_Auta { get; set; }
        public string adresa { get; set; }

        public int userId { get; set; }
        public int vozacId { get; set; }
        public int markaKolaid { get; set; }
        public int Tip_Autaid { get; set; }





    }
}
