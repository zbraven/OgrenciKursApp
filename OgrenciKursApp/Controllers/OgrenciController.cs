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
        public async Task<IActionResult> Index()
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ogrenci model)
        {

            _context.Ogrenciler.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        //Edit metotu. ID'ye erişemezse, geçiyor varsa giriyor ve bilgilerini de atıyor. FindAsync veya FirstOrDefaultAsync ile kayıtları check'liyorum.
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogrenci = await _context.Ogrenciler.FindAsync(id);
            //var ogrenci= await _context.Ogrenciler.FirstOrDefaultAsync(o=> o.OgrenciId== id);

            if (ogrenci == null)
            {
                return NotFound();
            }
            return View(ogrenci);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Ogrenci model)
        {
            if (id != model.OgrenciId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    if (!_context.Ogrenciler.Any(o => o.OgrenciId == model.OgrenciId))    //öğrenci bulanamadı ise
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(model);


        }

       

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ogrenci = await _context.Ogrenciler.FindAsync(id);
            if (ogrenci == null)
            {
                return NotFound();
            }
            return View(ogrenci);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromForm]int id)   //Hangi id karmaşası yaşamamak için form'un içindeki Id'yi aldım demek bu.
        {
            var ogrenci = await _context.Ogrenciler.FindAsync(id);
            if (ogrenci ==null)
            {
                return NotFound();
            }
            _context.Ogrenciler.Remove(ogrenci);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
