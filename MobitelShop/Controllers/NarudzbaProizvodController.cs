using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobitelShop.Data;
using MobitelShop.Models;
using MobitelShop.ViewModels;

namespace MobitelShop.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize]
    public class NarudzbaProizvodController:ControllerBase
    {
        private readonly MojDbContext _dbContext;


        public NarudzbaProizvodController(MojDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult Snimi([FromBody] NarudzbaProizvodSnimiVM x)
        {
            NarudzbaProizvod? novi;

            if (x.ID == 0)
            {
                novi = new NarudzbaProizvod();
                _dbContext.Add(novi);
            }
            else
            {
                novi = _dbContext.NarudzbaProizvod.Find(x.ID);
            }

            if (novi == null)
                return BadRequest("pogresan id");

            novi.Kolicina = x.Kolicina;
            novi.NarudzbaID = x.NarudzbaID;
            novi.ProizvodID = x.ProizvodID;

            _dbContext.SaveChanges();
            return Ok(novi);

        }

        [HttpGet]
        public ActionResult GetNarudzbaProizvod()
        {
            var podaci = _dbContext.NarudzbaProizvod.Select(x => new NarudzbaProizvodGetAllVM()
            {
                Kolicina = x.Kolicina,
                ProizvodID = x.ProizvodID,
                NarudzbaID = x.NarudzbaID

            });

            return Ok(podaci.ToList());
        }
    }
}
