using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TuristickaAgencijaWebAPI.Database
{
    public partial class MyContext : DbContext
    {
        public MyContext()
        {
        }

        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Drzave> Drzave { get; set; }
        public virtual DbSet<Firme> Firme { get; set; }
        public virtual DbSet<Gradovi> Gradovi { get; set; }
        public virtual DbSet<Komentari> Komentari { get; set; }
        public virtual DbSet<Novosti> Novosti { get; set; }
        public virtual DbSet<Ocjene> Ocjene { get; set; }
        public virtual DbSet<OcjenePutovanja> OcjenePutovanja { get; set; }
        public virtual DbSet<OnlinePay> OnlinePay { get; set; }
        public virtual DbSet<Pretplate> Pretplate { get; set; }
        public virtual DbSet<Prevoz> Prevoz { get; set; }
        public virtual DbSet<PutniciKorisnici> PutniciKorisnici { get; set; }
        public virtual DbSet<Putovanja> Putovanja { get; set; }
        public virtual DbSet<Rezervacije> Rezervacije { get; set; }
        public virtual DbSet<Smjestaj> Smjestaj { get; set; }
        public virtual DbSet<TerminiPutovanja> TerminiPutovanja { get; set; }
        public virtual DbSet<TipPrevoza> TipPrevoza { get; set; }
        public virtual DbSet<Uplate> Uplate { get; set; }
        public virtual DbSet<Vodici> Vodici { get; set; }
        public virtual DbSet<VrstePutovanja> VrstePutovanja { get; set; }
        public virtual DbSet<Zaposlenici> Zaposlenici { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=160090;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drzave>(entity =>
            {
                entity.Property(e => e.DrzaveId).HasColumnName("DrzaveID");

                entity.Property(e => e.NazivDrzave).IsRequired();
            });

            modelBuilder.Entity<Firme>(entity =>
            {
                entity.HasKey(e => e.FirmaId);

                entity.Property(e => e.FirmaId).HasColumnName("FirmaID");

                entity.Property(e => e.NazivFirme).IsRequired();
            });

            modelBuilder.Entity<Gradovi>(entity =>
            {
                entity.HasKey(e => e.GradId);

                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.Property(e => e.DrzaveId).HasColumnName("DrzaveID");

                entity.Property(e => e.NazivGrada).IsRequired();

                entity.HasOne(d => d.Drzave)
                    .WithMany(p => p.Gradovi)
                    .HasForeignKey(d => d.DrzaveId)
                    .HasConstraintName("FK_Gradovi_Drzave");
            });

            modelBuilder.Entity<Komentari>(entity =>
            {
                entity.HasKey(e => e.KomentarId);

                entity.HasIndex(e => e.PutnikKorisnikId);

                entity.HasIndex(e => e.PutovanjeId);

                entity.Property(e => e.KomentarId).HasColumnName("KomentarID");

                entity.Property(e => e.PutnikKorisnikId).HasColumnName("PutnikKorisnikID");

                entity.Property(e => e.PutovanjeId).HasColumnName("PutovanjeID");

                entity.Property(e => e.Sadrzaj).HasMaxLength(250);

                entity.Property(e => e.Vrijeme).HasColumnType("date");

                entity.HasOne(d => d.PutnikKorisnik)
                    .WithMany(p => p.Komentari)
                    .HasForeignKey(d => d.PutnikKorisnikId)
                    .HasConstraintName("FK_Komentari_PutniciKorisnici");

                entity.HasOne(d => d.Putovanje)
                    .WithMany(p => p.Komentari)
                    .HasForeignKey(d => d.PutovanjeId)
                    .HasConstraintName("FK_Komentari_Putovanja");
            });

            modelBuilder.Entity<Novosti>(entity =>
            {
                entity.HasKey(e => e.NovostId);

                entity.HasIndex(e => e.PutovanjeId);

                entity.HasIndex(e => e.ZaposlenikId);

                entity.Property(e => e.NovostId).HasColumnName("NovostID");

                entity.Property(e => e.DatumVrijeme).HasColumnType("date");

                entity.Property(e => e.Naslov)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PutovanjeId).HasColumnName("PutovanjeID");

                entity.Property(e => e.Sadrzaj).IsRequired();

                entity.Property(e => e.ZaposlenikId).HasColumnName("ZaposlenikID");

                entity.HasOne(d => d.Putovanje)
                    .WithMany(p => p.Novosti)
                    .HasForeignKey(d => d.PutovanjeId)
                    .HasConstraintName("FK_Novosti_Putovanja");

                entity.HasOne(d => d.Zaposlenik)
                    .WithMany(p => p.Novosti)
                    .HasForeignKey(d => d.ZaposlenikId)
                    .HasConstraintName("FK_Novosti_Zaposlenici");
            });

            modelBuilder.Entity<Ocjene>(entity =>
            {
                entity.HasKey(e => e.OcjenaId);

                entity.Property(e => e.OcjenaId).HasColumnName("OcjenaID");

                entity.Property(e => e.Vrijednost).HasMaxLength(10);
            });

            modelBuilder.Entity<OcjenePutovanja>(entity =>
            {
                entity.HasKey(e => e.OcjenaPutovanjeId);

                entity.HasIndex(e => e.OcjenaId);

                entity.HasIndex(e => e.PutnikKorisnikId);

                entity.HasIndex(e => e.PutovanjeId);

                entity.Property(e => e.OcjenaPutovanjeId).HasColumnName("OcjenaPutovanjeID");

                entity.Property(e => e.OcjenaId).HasColumnName("OcjenaID");

                entity.Property(e => e.PutnikKorisnikId).HasColumnName("PutnikKorisnikID");

                entity.Property(e => e.PutovanjeId).HasColumnName("PutovanjeID");

                entity.HasOne(d => d.Ocjena)
                    .WithMany(p => p.OcjenePutovanja)
                    .HasForeignKey(d => d.OcjenaId)
                    .HasConstraintName("FK_OcjenePutovanja_Ocjene");

                entity.HasOne(d => d.PutnikKorisnik)
                    .WithMany(p => p.OcjenePutovanja)
                    .HasForeignKey(d => d.PutnikKorisnikId)
                    .HasConstraintName("FK_OcjenePutovanja_PutniciKorisnici");

                entity.HasOne(d => d.Putovanje)
                    .WithMany(p => p.OcjenePutovanja)
                    .HasForeignKey(d => d.PutovanjeId)
                    .HasConstraintName("FK_OcjenePutovanja_Putovanja");
            });

            modelBuilder.Entity<OnlinePay>(entity =>
            {
                entity.Property(e => e.OnlinePayId).HasColumnName("OnlinePayID");

                entity.Property(e => e.KorisnickoIme).IsRequired();

                entity.Property(e => e.PutniciKorisniciId).HasColumnName("PutniciKorisniciID");

                entity.Property(e => e.Svrha).HasMaxLength(350);
            });

            modelBuilder.Entity<Pretplate>(entity =>
            {
                entity.HasKey(e => e.PretplataId);

                entity.HasIndex(e => e.PutnikKorisnikId);

                entity.HasIndex(e => e.VrstaPutovanjaId);

                entity.HasOne(d => d.PutnikKorisnik)
                    .WithMany(p => p.Pretplate)
                    .HasForeignKey(d => d.PutnikKorisnikId)
                    .HasConstraintName("FK_Pretplate_PutniciKorisnici");

                entity.HasOne(d => d.VrstaPutovanja)
                    .WithMany(p => p.Pretplate)
                    .HasForeignKey(d => d.VrstaPutovanjaId)
                    .HasConstraintName("FK_Pretplate_VrstePutovanja");
            });

            modelBuilder.Entity<Prevoz>(entity =>
            {
                entity.HasIndex(e => e.FirmaId);

                entity.Property(e => e.PrevozId).HasColumnName("PrevozID");

                entity.Property(e => e.FirmaId).HasColumnName("FirmaID");

                entity.Property(e => e.TipPrevozaId).HasColumnName("TipPrevozaID");

                entity.HasOne(d => d.Firma)
                    .WithMany(p => p.Prevoz)
                    .HasForeignKey(d => d.FirmaId)
                    .HasConstraintName("FK_Prevoz_Firma");

                entity.HasOne(d => d.TipPrevoza)
                    .WithMany(p => p.Prevoz)
                    .HasForeignKey(d => d.TipPrevozaId)
                    .HasConstraintName("FK_Prevoz_TipPrevoza");
            });

            modelBuilder.Entity<PutniciKorisnici>(entity =>
            {
                entity.HasKey(e => e.PutnikKorisnikId);

                entity.Property(e => e.PutnikKorisnikId).HasColumnName("PutnikKorisnikID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Kontakt)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.KorisnickoIme).HasMaxLength(50);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Putovanja>(entity =>
            {
                entity.HasIndex(e => e.GradId);

                entity.HasIndex(e => e.PrevozId);

                entity.HasIndex(e => e.VrstaPutovanjaId);

                entity.HasIndex(e => e.ZaposlenikId);

                entity.Property(e => e.PutovanjaId).HasColumnName("PutovanjaID");

                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.Property(e => e.PrevozId).HasColumnName("PrevozID");

                entity.Property(e => e.VrstaPutovanjaId).HasColumnName("VrstaPutovanjaID");

                entity.Property(e => e.ZaposlenikId).HasColumnName("ZaposlenikID");

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Putovanja)
                    .HasForeignKey(d => d.GradId)
                    .HasConstraintName("FK_Putovanja_Gradovi");

                entity.HasOne(d => d.Prevoz)
                    .WithMany(p => p.Putovanja)
                    .HasForeignKey(d => d.PrevozId)
                    .HasConstraintName("FK_Putovanja_");

                entity.HasOne(d => d.VrstaPutovanja)
                    .WithMany(p => p.Putovanja)
                    .HasForeignKey(d => d.VrstaPutovanjaId)
                    .HasConstraintName("FK_Putovanja_VrstePutovanja");

                entity.HasOne(d => d.Zaposlenik)
                    .WithMany(p => p.Putovanja)
                    .HasForeignKey(d => d.ZaposlenikId)
                    .HasConstraintName("FK_Putovanja_Zaposlenici");
            });

            modelBuilder.Entity<Rezervacije>(entity =>
            {
                entity.HasKey(e => e.RezervacijaId);

                entity.HasIndex(e => e.PutnikKorisnikId);

                entity.HasIndex(e => e.TerminPutovanjaId);

                entity.Property(e => e.RezervacijaId).HasColumnName("RezervacijaID");

                entity.Property(e => e.PutnikKorisnikId).HasColumnName("PutnikKorisnikID");

                entity.Property(e => e.TerminPutovanjaId).HasColumnName("TerminPutovanjaID");

                entity.Property(e => e.Vrijeme).HasColumnType("date");

                entity.HasOne(d => d.PutnikKorisnik)
                    .WithMany(p => p.Rezervacije)
                    .HasForeignKey(d => d.PutnikKorisnikId)
                    .HasConstraintName("FK_PutniciKorisniciPutovanja_PutniciKorisnici_PutnikKorisnikID");

                entity.HasOne(d => d.TerminPutovanja)
                    .WithMany(p => p.Rezervacije)
                    .HasForeignKey(d => d.TerminPutovanjaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rezervacije_TerminiPutovanja");
            });

            modelBuilder.Entity<Smjestaj>(entity =>
            {
                entity.HasIndex(e => e.GradId);

                entity.Property(e => e.SmjestajId).HasColumnName("SmjestajID");

                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Opis).IsUnicode(false);

                entity.Property(e => e.TipSobe)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Smjestaj)
                    .HasForeignKey(d => d.GradId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Smjestaj_Gradovi");
            });

            modelBuilder.Entity<TerminiPutovanja>(entity =>
            {
                entity.HasKey(e => e.TerminPutovanjaId);

                entity.HasIndex(e => e.PutovanjeId);

                entity.HasIndex(e => e.SmjestajId);

                entity.Property(e => e.TerminPutovanjaId)
                    .HasColumnName("TerminPutovanjaID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DatumPolaska).HasColumnType("datetime");

                entity.Property(e => e.DatumPovratka).HasColumnType("datetime");

                entity.Property(e => e.PutovanjeId).HasColumnName("PutovanjeID");

                entity.Property(e => e.SmjestajId).HasColumnName("SmjestajID");

                entity.Property(e => e.VodicId).HasColumnName("VodicID");

                entity.HasOne(d => d.Putovanje)
                    .WithMany(p => p.TerminiPutovanja)
                    .HasForeignKey(d => d.PutovanjeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TerminiPutovanja_Putovanja");

                entity.HasOne(d => d.Smjestaj)
                    .WithMany(p => p.TerminiPutovanja)
                    .HasForeignKey(d => d.SmjestajId)
                    .HasConstraintName("FK_TerminiPutovanja_Smjestaj");

                entity.HasOne(d => d.TerminPutovanja)
                    .WithOne(p => p.InverseTerminPutovanja)
                    .HasForeignKey<TerminiPutovanja>(d => d.TerminPutovanjaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TerminiPutovanja_TerminiPutovanja");

                entity.HasOne(d => d.Vodic)
                    .WithMany(p => p.TerminiPutovanja)
                    .HasForeignKey(d => d.VodicId)
                    .HasConstraintName("FK_TerminiPutovanja_Vodici");
            });

            modelBuilder.Entity<TipPrevoza>(entity =>
            {
                entity.Property(e => e.TipPrevozaId).HasColumnName("TipPrevozaID");

                entity.Property(e => e.NazivTipa).IsRequired();
            });

            modelBuilder.Entity<Uplate>(entity =>
            {
                entity.HasKey(e => e.UplataId);

                entity.HasIndex(e => e.RezervacijaId);

                entity.Property(e => e.UplataId).HasColumnName("UplataID");

                entity.Property(e => e.RezervacijaId).HasColumnName("RezervacijaID");

                entity.HasOne(d => d.Rezervacija)
                    .WithMany(p => p.Uplate)
                    .HasForeignKey(d => d.RezervacijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Uplate_Rezervacije");
            });

            modelBuilder.Entity<Vodici>(entity =>
            {
                entity.HasKey(e => e.VodicId);

                entity.Property(e => e.VodicId).HasColumnName("VodicID");

                entity.Property(e => e.Jmbg).HasColumnName("JMBG");
            });

            modelBuilder.Entity<VrstePutovanja>(entity =>
            {
                entity.HasKey(e => e.VrstaPutovanjaId);

                entity.Property(e => e.VrstaPutovanjaId).HasColumnName("VrstaPutovanjaID");

                entity.Property(e => e.Oznaka).HasMaxLength(10);
            });

            modelBuilder.Entity<Zaposlenici>(entity =>
            {
                entity.HasKey(e => e.ZaposlenikId);

                entity.Property(e => e.ZaposlenikId).HasColumnName("ZaposlenikID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Kontakt)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.KorisnickoIme).HasMaxLength(50);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(30);
            });
        }
    }
}
