using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OgrenciKursApp.Data;

namespace OgrenciKursApp.Controllers
{
    public class OgrenciController : Controller
    {
        //DB'ye okuma özelliğiyle context oluşturdum. Her seferinde oluşturmaktansa buradan çekmek mantıklı olanıdır.
        private readonly DataContext _context;
        public OgrenciController(DataContext context)
        {

            _context = context;

        }

        //Öğrencileri liste şeklinde sunucudan çektim
        public async Task< IActionResult> Index()
        {
          //var ogrenciler =  await _context.Ogrenciler.ToListAsync();
            return View(await _context.Ogrenciler.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }


        //Gelen verileri db'ye gönderdim.
        [HttpPost]
        public async Task<IActionResult> Create(Ogrenci model)
        {

            _context.Ogrenciler.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
           
        }
    }
}
