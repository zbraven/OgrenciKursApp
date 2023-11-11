using Microsoft.EntityFrameworkCore;

namespace OgrenciKursApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Kurs> Kurslar => Set<Kurs>();
        public DbSet<Ogrenci> Ogrenciler => Set<Ogrenci>();
        public DbSet<KursKayit> KursKayitlari => Set<KursKayit>();

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kurs>().ToTable("Kurslar");
            modelBuilder.Entity<Ogrenci>().ToTable("Ogrenciler");
            modelBuilder.Entity<KursKayit>().ToTable("KursKayitlari");
        }
    }
}
