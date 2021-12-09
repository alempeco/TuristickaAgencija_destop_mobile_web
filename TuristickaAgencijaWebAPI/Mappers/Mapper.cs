using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuristickaAgencija.Model.Requests;
using TuristickaAgencijaWebAPI.Database;

namespace TuristickaAgencijaWebAPI.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Gradovi, GradoviInsertRequest>().ReverseMap();
            CreateMap<Gradovi, TuristickaAgencija.Model.Gradovi>().ReverseMap();

            CreateMap<Firme, FirmeInsertRequest>().ReverseMap();
            CreateMap<Firme, TuristickaAgencija.Model.Firme>().ReverseMap();

            CreateMap<Drzave, DrzaveInsertRequest>().ReverseMap();
            CreateMap<Drzave, TuristickaAgencija.Model.Drzave>().ReverseMap();
            CreateMap<TipPrevoza, TipPrevozaInsertRequest>().ReverseMap();
            CreateMap<TipPrevoza, TuristickaAgencija.Model.TipPrevoza>().ReverseMap();


            CreateMap<Smjestaj, TuristickaAgencija.Model.Smjestaj>().ReverseMap();
            CreateMap<Smjestaj, TuristickaAgencija.Model.Requests.SmjestajInsertRequest>().ReverseMap();
            CreateMap<Smjestaj, TuristickaAgencija.Model.Smjestaj>().ForMember(x => x.Grad,
              a => a.MapFrom(
              y => new MyContext().Gradovi.Find(y.GradId).NazivGrada)).ReverseMap();


            CreateMap<Prevoz, TuristickaAgencija.Model.Prevoz>().ReverseMap();
            CreateMap<Prevoz, TuristickaAgencija.Model.Requests.PrevozInsertRequest>().ReverseMap();
            CreateMap<Prevoz, TuristickaAgencija.Model.Prevoz>().ForMember(x => x.Firma,
              a => a.MapFrom(
              y => new MyContext().Firme.Find(y.FirmaId).NazivFirme))
                  .ForMember(s => s.TipPrevoza, a =>
                     a.MapFrom(b => new MyContext().TipPrevoza.Find(b.TipPrevozaId).NazivTipa)).ReverseMap();


            CreateMap<Vodici, TuristickaAgencija.Model.Requests.VodicInsertRequest>().ReverseMap();
            CreateMap<Vodici, TuristickaAgencija.Model.Vodici>().ReverseMap();



            CreateMap<VrstePutovanja, TuristickaAgencija.Model.VrstaPutovanja>().ReverseMap();
            CreateMap<VrstePutovanja, VrstaPutovanjaInsertRequest>().ReverseMap();



            CreateMap<Ocjene, TuristickaAgencija.Model.Ocjene>().ReverseMap();
            CreateMap<Ocjene, OcjeneInsertRequest>().ReverseMap();


            CreateMap<Zaposlenici, TuristickaAgencija.Model.Zaposlenici>().ReverseMap();
            CreateMap<Zaposlenici, ZaposleniciInsertRequest>().ReverseMap();

            CreateMap<PutniciKorisnici, PutniciKorisniciInsertRequest>().ReverseMap();
            CreateMap<PutniciKorisnici, TuristickaAgencija.Model.PutniciKorisnici>().ReverseMap();


            CreateMap<Database.Zaposlenici, TuristickaAgencija.Model.KorisnikLogin>().ReverseMap();
            CreateMap<Database.PutniciKorisnici, TuristickaAgencija.Model.KorisnikLogin>().ReverseMap();



            CreateMap<Putovanja, PutovanjaInsertRequest>().ReverseMap();
            CreateMap<Putovanja, TuristickaAgencija.Model.Putovanja>().ReverseMap();
            CreateMap<Putovanja, TuristickaAgencija.Model.Putovanja>()
                     .ForMember(s => s.Grad, a =>
                     a.MapFrom(b => new MyContext().Gradovi.Find(b.GradId).NazivGrada))
                      .ForMember(s => s.Prevoz, a =>
                     a.MapFrom(b => new MyContext().Prevoz.Find(b.PrevozId).Firma))

                     .ForMember
                     (s => s.VrstaPutovanja, a => a.MapFrom(y => new MyContext().VrstePutovanja.
                         Find(y.VrstaPutovanjaId).Oznaka)).ReverseMap();



            CreateMap<TerminiPutovanja, TerminiPutovanjaInsertRequest>().ReverseMap();
            CreateMap<TerminiPutovanja, TuristickaAgencija.Model.TerminiPutovanja>().ReverseMap();
            CreateMap<TerminiPutovanja, TuristickaAgencija.Model.TerminiPutovanja>().ForMember(x => x.TerminPutovanjaPodaci
            , a => a.MapFrom(
            y => new MyContext().Putovanja.Find(y.PutovanjeId).Naziv + " | " + y.DatumPolaska.ToString())
            ).ForMember(x => x.Smjestaj, a => a.MapFrom(y => new MyContext().Smjestaj.Find(y.SmjestajId).Naziv)).
            


            ReverseMap();


            CreateMap<TerminiPutovanja, TerminiPutovanjaInsertRequest>().ReverseMap();
            CreateMap<TerminiPutovanja, TuristickaAgencija.Model.TerminiPutovanja>().ReverseMap();
            CreateMap<TerminiPutovanja, TuristickaAgencija.Model.TerminiPutovanja>().ForMember(x => x.TerminPutovanjaPodaci
            , a => a.MapFrom(
            y => new MyContext().Putovanja.Find(y.PutovanjeId).Naziv + " | " + y.DatumPolaska.ToString())
            ).ForMember(x => x.Smjestaj, a => a.MapFrom(y => new MyContext().Smjestaj.Find(y.SmjestajId).Naziv)).
            ReverseMap();


          

            CreateMap<Novosti, TuristickaAgencija.Model.Novosti>().ReverseMap();
            CreateMap<Novosti, NovostiInsertRequest>().ReverseMap();
            CreateMap<Novosti, TuristickaAgencija.Model.Novosti>().ForMember(x => x.Putovanje
              , a => a.MapFrom(
             y => new MyContext().Putovanja.Find(y.PutovanjeId).Naziv)).ForMember(x => x.Zaposlenik,
             a => a.MapFrom(y => new MyContext().Zaposlenici.Find(y.ZaposlenikId).KorisnickoIme))
            .ReverseMap();

            CreateMap<Rezervacije, TuristickaAgencija.Model.Rezervacije>().ReverseMap();
            CreateMap<Rezervacije, RezervacijeInsertRequest>().ReverseMap();
            CreateMap<Rezervacije, TuristickaAgencija.Model.Rezervacije>().ForMember(x => x.PutnikKorisnikPodaci
                 , a => a.MapFrom(
                 y => new MyContext().PutniciKorisnici.
                 Find(y.PutnikKorisnikId).KorisnickoIme)).
                 ForMember(x => x.TerminPutovanjaPodaci, a => a.MapFrom(k => new MyContext().
                      TerminiPutovanja.Where(x => x.TerminPutovanjaId == k.TerminPutovanjaId).
                      FirstOrDefault().
                      DatumPolaska.ToString()
                    )).ForMember(x => x.PutovanjePodaci, a => a.MapFrom(k => new MyContext().
                         TerminiPutovanja.
                         Where(x => x.TerminPutovanjaId == k.TerminPutovanjaId).Include(x => x.Putovanje).FirstOrDefault().
                         TerminPutovanja.Putovanje.Naziv)).ReverseMap();




            CreateMap<Uplate, UplateInsertRequest>().ReverseMap();
            CreateMap<Uplate, TuristickaAgencija.Model.Uplate>().ReverseMap();
            CreateMap<Uplate, TuristickaAgencija.Model.Uplate>().
            ForMember(x => x.PutnikKorisnikPodaci,
            a => a.MapFrom(y => new MyContext().Rezervacije.
            Where(x => x.RezervacijaId == y.RezervacijaId).
            Include(x => x.PutnikKorisnik).FirstOrDefault().
            PutnikKorisnik.KorisnickoIme)).
            ForMember(x => x.TerminPutovanjaPodaci,
            a => a.MapFrom(y => new MyContext().Rezervacije.
              Where(x => x.RezervacijaId == y.RezervacijaId).Include(x => x.TerminPutovanja).
              FirstOrDefault().TerminPutovanja.DatumPolaska.ToString())).
            ForMember(x => x.PutovanjePodaci, a => a.MapFrom(
                   y => new MyContext().Rezervacije.
                   Where(x => x.RezervacijaId == y.RezervacijaId).
                   Include(x => x.TerminPutovanja).Include(x => x.TerminPutovanja.Putovanje).
                   FirstOrDefault().TerminPutovanja.Putovanje.Naziv
                   )).ReverseMap();




            CreateMap<Pretplate, TuristickaAgencija.Model.Pretplate>().ReverseMap();
            CreateMap<Pretplate, PretplateInsertRequest>().ReverseMap();
            CreateMap<Pretplate, TuristickaAgencija.Model.Pretplate>().ForMember(x => x.PutnikKorisnik,
                a => a.MapFrom(y => new MyContext().PutniciKorisnici.Find(y.PutnikKorisnikId).KorisnickoIme)).ForMember
                (x => x.VrstaPutovanja, a => a.MapFrom(y => new MyContext().VrstePutovanja.Find(y.VrstaPutovanjaId).Oznaka)).ReverseMap();


            



            CreateMap<Komentari, KomentariInsertRequest>().ReverseMap();
            CreateMap<Komentari, TuristickaAgencija.Model.Komentari>().ReverseMap();
            CreateMap<Komentari, TuristickaAgencija.Model.Komentari>().
                ForMember(x => x.Putovanje, a => a.MapFrom(y => new MyContext().Putovanja.Find(y.PutovanjeId).Naziv)
                ).ForMember(x => x.PutnikKorisnik, a => a.MapFrom(y => new MyContext().PutniciKorisnici.Find(y.PutnikKorisnikId).KorisnickoIme))
                .ReverseMap();


            CreateMap<OcjenePutovanja, OcjenePutovanjaInsertRequest>().ReverseMap();
            CreateMap<OcjenePutovanja, TuristickaAgencija.Model.OcjenePutovanja>().ReverseMap();
            CreateMap<OcjenePutovanja, TuristickaAgencija.Model.OcjenePutovanja>().ForMember
             (x => x.PutnikKorisnik, a => a.MapFrom(y => new MyContext().PutniciKorisnici.Find(y.PutnikKorisnikId).KorisnickoIme)).
             ForMember(x => x.Putovanje, a => a.MapFrom(y => new MyContext().Putovanja.Find(y.PutovanjeId).Naziv)
             ).ForMember(x => x.OcjenaVrijednost, a => a.MapFrom(y => new MyContext().Ocjene.Find(y.OcjenaId).Vrijednost
                ))
            .ReverseMap();









            //CreateMap<OnlinePay, OnlinePayInsertRequest>().ReverseMap();
            //CreateMap<OnlinePay, TuristickaAgencija.Model.OnlinePay>().ReverseMap();
            //CreateMap<OnlinePay, TuristickaAgencija.Model.OnlinePay>().
            //ForMember(x => x.PutniciKorisniciId,
            //a => a.MapFrom(y => new MyContext().PutniciKorisnici.
            //Where(x => x.PutnikKorisnikId == y.PutniciKorisniciId);





            CreateMap<OnlinePay, TuristickaAgencija.Model.OnlinePay>().ReverseMap();
            CreateMap<OnlinePay, TuristickaAgencija.Model.Requests.OnlinePayInsertRequest>().ReverseMap();
            CreateMap<OnlinePay, TuristickaAgencija.Model.OnlinePay>().ForMember(x => x.PutniciKorisniciId,
              a => a.MapFrom(
              y => new MyContext().PutniciKorisnici.Find(y.PutniciKorisniciId).PutnikKorisnikId)).ReverseMap();





        }


    }
}
