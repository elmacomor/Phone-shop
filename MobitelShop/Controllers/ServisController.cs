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
    public class ServisController:ControllerBase
    {
        private readonly MojDbContext _dbContext;

        public ServisController(MojDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult Snimi([FromBody] ServisSnimiVM x)
        {
            Servis? novi;

            if (x.ID == 0)
            {
                novi = new Servis();
                _dbContext.Add(novi);
            }
            else
            {
                novi = _dbContext.Servis.Find(x.ID);
            }

            if (novi == null)
                return BadRequest("pogresan ID");

            novi.NazivServisa = x.NazivServisa;
            novi.BrojTelefona = x.BrojTelefona;
            novi.GradID = x.GradID;
            novi.cijena = x.cijena;

            _dbContext.SaveChanges();
            return Ok(novi);
        }

        [HttpGet]
        public ActionResult GetServisi()
        {
            var podaci = _dbContext.Servis.Select(x => new ServisGetAllVM()
            {
            ID=x.ID,
            NazivServisa=x.NazivServisa,
            BrojTelefona=x.BrojTelefona,
            GradID=x.GradID,
            nazivGrada = x.Grad.Naziv,
            cijena = x.cijena
            });

            return Ok(podaci.ToList());
        }

    [HttpPost]
    public ActionResult Delete([FromBody] ServisSnimiVM g)
    {
      Servis? servis = _dbContext.Servis.Find(g.ID);

      if (servis == null)
        return BadRequest("Pogresan ID");
      else
      {
        _dbContext.Remove(servis);
      }

      _dbContext.SaveChanges();
      return Ok(servis);
    }
  }
}
