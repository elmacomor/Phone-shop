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
    public class KreditnaKarticaController : ControllerBase
    {

        private readonly MojDbContext _dbContext;

        public KreditnaKarticaController(MojDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        [HttpPost]
        public ActionResult Snimi([FromBody] KreditnaKarticaSnimiVM x)
        {
            KreditnaKartica? nova;
            if (x.ID == 0)
            {
                nova = new KreditnaKartica();
                _dbContext.Add(nova);
            }
            else
            {
                nova = _dbContext.KreditnaKartica.Find(x.ID);
            }
            if (nova == null)
                return BadRequest("pogresan ID");

            nova.BrojKartice = x.BrojKartice;
            nova.SC = x.SC;
            nova.KorisnikID = x.KupacID;

            _dbContext.SaveChanges();
            return Ok(nova);
        }
        [HttpGet]
        public ActionResult GetKreditnaKartica()
        {
            var podaci = _dbContext.KreditnaKartica.Select(x => new KreditnaKarticaGetAllVM()
            {
                ID = x.ID,
                BrojKartice = x.BrojKartice,
                SC = x.SC,
                KupacID = x.KorisnikID



            });
            return Ok(podaci.ToList());
        }

    }
}

