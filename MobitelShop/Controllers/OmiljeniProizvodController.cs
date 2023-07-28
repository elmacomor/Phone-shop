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
    public class OmiljeniProizvodController:ControllerBase
    {
        private readonly MojDbContext _dbContext;
        public OmiljeniProizvodController(MojDbContext dbContext)
        {
            _dbContext = dbContext; 
        }
        [HttpGet]
        public ActionResult OmiljeniGetAll()
        {
            var podaci = _dbContext.OmiljeniProizvod.Select(x => new OmiljeniProizvodGetAllVM()
            {
                ID = x.ID,
                ProizvodID = x.ProizvodID,
                KupacID = x.KorisnikID,
                Aktivan = x.Aktivan,
            });
            return Ok(podaci.ToList());
        }
        [HttpPost]
        public OmiljeniProizvod Snimi([FromBody] OmiljeniProizvodSnimiVM x)
        {
            OmiljeniProizvod? novi;
            if (x.ID == 0)
            {
                novi = new OmiljeniProizvod();
                _dbContext.Add(novi);
            }
            else
            {
                novi = _dbContext.OmiljeniProizvod.Find(x.ID);
            }
            novi.ProizvodID = x.ID;
            novi.KorisnikID = x.KupacID;
            _dbContext.SaveChanges();
            return novi;
        }
    }
}
