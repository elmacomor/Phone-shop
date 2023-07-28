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
    public class RacunController:ControllerBase
    {
        private readonly MojDbContext _dbContext;

        public RacunController(MojDbContext dbContext)
        {
            _dbContext = dbContext;
        }

    //    [HttpGet]
    //    public ActionResult GetAll()
    //    {
    //        var podaci = _dbContext.Racun.Select(x => new RacunSnimiVM()
    //        {
    //            ID = x.ID,
    //            BrojRacuna = x.BrojRacuna,
    //            IznosRacuna = x.IznosRacuna,
    //            NacinPlacanja = x.NacinPlacanja,
    //            UposlenikID = x.UposlenikID,
    //            KreditnaKarticaID = x.KreditnaKarticaID,
    //        });
    //        return Ok(podaci.ToList());
    //    }
    //    [HttpPost]
    //    public Racun Snimi([FromBody] RacunSnimiVM x)
    //    {
    //        Racun? novi;
    //        if (x.ID == 0)
    //        {
    //            novi = new Racun();
    //            _dbContext.Racun.Add(novi);
    //        }
    //        else
    //        {
    //            novi = _dbContext.Racun.Find(x.ID);
    //        }
    //        novi.BrojRacuna = x.BrojRacuna;
    //        novi.NacinPlacanja = x.NacinPlacanja;
    //        novi.IznosRacuna = x.IznosRacuna;
    //        novi.UposlenikID = x.UposlenikID;
    //        novi.KreditnaKarticaID = x.KreditnaKarticaID;
    //        _dbContext.SaveChanges();
    //        return novi;
    //    }
    }
}
