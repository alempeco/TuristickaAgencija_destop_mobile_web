using System;
using System.Collections.Generic;

namespace TuristickaAgencijaWebAPI.Database
{
    public partial class Putovanja
    {
        public Putovanja()
        {
            Komentari = new HashSet<Komentari>();
            Novosti = new HashSet<Novosti>();
            OcjenePutovanja = new HashSet<OcjenePutovanja>();
            TerminiPutovanja = new HashSet<TerminiPutovanja>();
        }

        public int PutovanjaId { get; set; }
        public int? GradId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public byte[] Slika { get; set; }
        public int? VrstaPutovanjaId { get; set; }
        public int? ZaposlenikId { get; set; }
        public int? PrevozId { get; set; }

        public Gradovi Grad { get; set; }
        public Prevoz Prevoz { get; set; }
        public VrstePutovanja VrstaPutovanja { get; set; }
        public Zaposlenici Zaposlenik { get; set; }
        public ICollection<Komentari> Komentari { get; set; }
        public ICollection<Novosti> Novosti { get; set; }
        public ICollection<OcjenePutovanja> OcjenePutovanja { get; set; }
        public ICollection<TerminiPutovanja> TerminiPutovanja { get; set; }
    }
}
