using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobitelShop.Data;
using MobitelShop.Helpers;
using MobitelShop.Models;
using MobitelShop.ViewModels;

namespace MobitelShop.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize]
    public class NarudzbaController:ControllerBase
    {
   
            private readonly MojDbContext _dbContext;
          
            public NarudzbaController(MojDbContext dbContext)
            {
                _dbContext = dbContext;
                
            }

        [HttpPost]
        public ActionResult Snimi([FromBody] NarudzbaSnimiVM x)
        {
            Narudzba? nova;
            if (x.ID == 0)
            {
                nova = new Narudzba();
                _dbContext.Add(nova);
            }
            else
            {
                nova = _dbContext.Narudzba.Find(x.ID);
            }
            if (nova == null)
                return BadRequest("pogresan ID");


            nova.DatumNarudzbe = x.DatumNarudzbe;
            nova.KorisnikID = x.KupacID;
            nova.ShippingPodaciID = x.ShippingPodaciID;

            _dbContext.SaveChanges();
            return Ok(nova);
        }
        [HttpGet]
        public ActionResult GetNarudzba()
        {
            var podaci = _dbContext.Narudzba.Select(x => new NarudzbaGetAllVM()
            {
                ID = x.ID,
                DatumNarudzbe = x.DatumNarudzbe,
                KupacID = x.KorisnikID,
                ShippingPodaciID = x.ShippingPodaciID



            });
            return Ok(podaci.ToList());
        }

    }
    }

