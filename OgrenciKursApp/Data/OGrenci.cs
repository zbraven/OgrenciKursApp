using System.ComponentModel.DataAnnotations;

namespace OgrenciKursApp.Data
{
    public class OGrenci
    {
        [Key]
        public int OgrenciId { get; set; }
        public string? OgnreciAd { get; set; }
        public string? OgnreciSoyad { get; set; }
        public string? Eposta { get; set; }
        public string? Telefon { get; set; }
       
    }
}
