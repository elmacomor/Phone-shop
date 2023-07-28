using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobitelShop.Data;
using MobitelShop.Models;
using MobitelShop.ViewModels;

namespace MobitelShop.Controllers
{
  [Route("[controller]/[action]")]
  [ApiController]
    [Authorize]
    public class UposlenikController : ControllerBase
  {
    private readonly MojDbContext _dbContext;

    public UposlenikController(MojDbContext dbContext)
    {
      this._dbContext = dbContext;
    }


    [HttpPost]
    public ActionResult Snimi([FromBody] KorisnikGetAllVM u)
    {
      Korisnik? korisnik;

      if(u.ID==0)
      {
        korisnik = new Korisnik();
        _dbContext.Add(korisnik);
      }
      else
      {
        korisnik = _dbContext.Korisnik.Find(u.ID);
        if (korisnik == null)
          return BadRequest("Pogresan ID");
      }

      korisnik.Ime = u.Ime;
      korisnik.Prezime = u.Prezime;
      korisnik.Username = u.Username;
      korisnik.Password = u.Password;

      _dbContext.SaveChanges();
      return Ok(korisnik);
    }


    [HttpGet]
    public ActionResult GetAll()
    {
      var podaci = _dbContext.Korisnik.Select(u => new KorisnikGetAllVM()
      {
        ID=u.ID,
        Ime=u.Ime,
        Prezime=u.Prezime,
        Username=u.Username,
        Password=u.Password
      });
      return Ok(podaci.ToList());
    }

    [HttpPost]
    public ActionResult Delete([FromBody] KorisnikDeleteVM x)
    {
      Korisnik? korisnik = _dbContext.Korisnik.Find(x.ID);

      if (korisnik == null)
        return BadRequest("Pogresan ID");
      else
        _dbContext.Remove(korisnik);

      _dbContext.SaveChanges();
      return Ok(korisnik);
    }

  }
}
