using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.IdentityModel.Tokens;
using MobitelShop.Data;
using MobitelShop.Helpers;
using MobitelShop.Models;
using MobitelShop.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Runtime.InteropServices;

namespace MobitelShop.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize]
    public class ProizvodController : ControllerBase
    {
        private readonly MojDbContext _dbContext;
        public static IWebHostEnvironment _webHostEnvironment;
        private readonly IHubContext<SignalRHub> _hubContext;

        public ProizvodController(MojDbContext dbContext, IWebHostEnvironment webHostEnvironment,IHubContext<SignalRHub> hubContext)
        {
            _dbContext = dbContext;
            _webHostEnvironment = webHostEnvironment;
            _hubContext = hubContext;
        }
        //[HttopPost]-->bez spremanja u bazu
        //public ActionResult SpremiProizvod([FromForm] ProizvodSnimiVM x)
        //{
        //    try
        //    {
        //        if (x.Slika_bajtovi.Length > 0) {
        //            string putanja = _webHostEnvironment.WebRootPath + "\\proizvodi\\";
        //            if (!Directory.Exists(putanja))
        //            {
        //                Directory.CreateDirectory(putanja);
        //            }
        //            using (FileStream fs = System.IO.File.Create(putanja + x.Slika_bajtovi.FileName))
        //            {
        //                x.Slika_bajtovi.CopyTo(fs);
        //                fs.Flush();
        //                return Ok();
        //            }
        //        }
        //        else
        //        {
        //            return BadRequest();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);  
        //    }

        //}
        [HttpPost]
        public async Task<ActionResult> Snimi([FromBody] ProizvodSnimiVM x)
        {
            bool uredi = false;
            Proizvod? novi;
            if (x.ID == 0)
            {
                novi = new Proizvod();
                _dbContext.Add(novi);
            }
            else
            {
                novi = _dbContext.Proizvod.Find(x.ID);
                uredi= true;
            }
            if (novi == null)
                return BadRequest("pogresan ID");

            novi.Marka = x.Marka;
            novi.Cijena = x.Cijena;
            novi.Specifikacije = x.Specifikacije;
            novi.ProizvodTipID = x.ProizvodTipID;
            novi.Boja = x.Boja;
            novi.KratakOpisProizvoda = x.KratakOpisProizvoda;
            _dbContext.SaveChanges();
            if (uredi != true)
            {
                if (!string.IsNullOrEmpty(x.Slika_bajtovi))
                {
                    byte[]? slika = x.Slika_bajtovi?.ParsirajBase64();
                    if (slika == null)
                        return BadRequest("format slike nije base64");
                    Fajlovi.Spremi(slika, "slike_proizvoda/" + novi.ID + ".png");
                    byte[] slika_bajtovi_resize = Slike.resize(slika, 200);

                    Fajlovi.Spremi(slika_bajtovi_resize, "slike_proizvoda/" + novi.ID + "_resized" + ".png");
                }
            }
            await _hubContext.Clients.All.SendAsync("PosaljiPoruku");
            return Ok(novi);
        }
        [HttpGet]

        public ActionResult GetProizvodi()
        {
             var podaci = _dbContext.Proizvod.Select(x => new ProizvodiGetAllVM()
             {
                 ID = x.ID,
                 Marka = x.Marka,
                 Cijena = x.Cijena,
                 Specifikacije = x.Specifikacije,
                 Boja = x.Boja,
                 ProizvodTipID = x.ProizvodTipID,
                 ProizvodTipNaziv = x.ProizvodTip.Naziv,
                 KratakOpisProizvoda=x.KratakOpisProizvoda                
             }).ToList();
            podaci.ForEach(s =>
            {
                s.Slika_bajtovi = Fajlovi.Ucitaj("slike_proizvoda/" + s.ID + ".png");
                if (s.Slika_bajtovi == null)
                {
                    s.Slika_bajtovi = Fajlovi.Ucitaj("slike_proizvoda/prazno.png");
                }

                s.Slika_umanjena = Fajlovi.Ucitaj("slike_proizvoda/" + s.ID + "_resized" + ".png");
                if (s.Slika_umanjena == null)
                {
                    s.Slika_umanjena = Slike.resize(Fajlovi.Ucitaj("slike_proizvoda/prazno.png"), 200);
                }
            });
            return Ok(podaci);
        }


        [HttpGet]
        public ActionResult vratiProizvod(int id)
        {
            var x = _dbContext.Proizvod.Find(id);
            if (x == null)
            {
                return BadRequest("Nije pronadjen proizvod u bazi");
            }

            ProizvodiGetAllVM vratiProizvod = new ProizvodiGetAllVM
            {
                ID = x.ID,
                Marka = x.Marka,
                Cijena = x.Cijena,
                Specifikacije = x.Specifikacije,
                Boja = x.Boja,
                ProizvodTipID = x.ProizvodTipID,
                Slika_bajtovi = Fajlovi.Ucitaj("slike_proizvoda/" + x.ID + ".png"),
                Slika_umanjena = Fajlovi.Ucitaj("slike_proizvoda/" + x.ID + "_resized" + ".png"),
                ProizvodTipNaziv = _dbContext.ProizvodTip.Find(x.ProizvodTipID).Naziv,
                KratakOpisProizvoda=x.KratakOpisProizvoda
            };
            return Ok(vratiProizvod);
        }
    }
}

