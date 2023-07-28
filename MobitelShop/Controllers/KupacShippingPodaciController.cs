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
    public class KupacShippingPodaciController : ControllerBase
    {

        private readonly MojDbContext _dbContext;

        public KupacShippingPodaciController(MojDbContext dbContext)
        {
            _dbContext = dbContext;

        }

       /* [HttpPost]
        public ActionResult Snimi([FromBody] KupacShippingPodaciSnimiVM x)
        {
            KupacShippingPodaci? novi;
            if (x.ID == 0)
            {
                novi = new KupacShippingPodaci();
                _dbContext.Add(novi);
            }
            else
            {
                novi = _dbContext.KupacShippingPodaci.Find(x.ID);
            }
            if (novi == null)
                return BadRequest("pogresan ID");

            
            novi.Adresa = x.Adresa;
            novi.BrojTelefona = x.BrojTelefona;
            novi.GradID = x.GradID;

            _dbContext.SaveChanges();
            return Ok(novi);
        }
        [HttpGet]
        public ActionResult GetKupacShippingPodaci()
        {
            var podaci = _dbContext.KupacShippingPodaci.Select(x => new KupacShippingPodaciGetAllVM()
            {
                ID=x.ID,
                Adresa=x.Adresa,
                BrojTelefona=x.BrojTelefona,
                GradID=x.GradID



            });
            return Ok(podaci.ToList());
        }*/

    }
}
