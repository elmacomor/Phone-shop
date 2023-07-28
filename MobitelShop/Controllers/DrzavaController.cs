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
    public class DrzavaController : ControllerBase
    {
        private readonly MojDbContext _dbContext;
        public DrzavaController(MojDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult Snimi([FromBody] DrzavaGetAllVM d)
        {
            Drzava? drzava;
            if (d.ID == 0)
            {
                drzava = new Drzava();
                _dbContext.Add(drzava);
            }
            else
            {
                drzava = _dbContext.Drzava.Find(d.ID);
                if (drzava == null)
                    return BadRequest("Pogresan ID");

            }

            drzava.Naziv = d.Naziv;

            _dbContext.SaveChanges();
            return Ok(drzava);
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var podaci = _dbContext.Drzava.Select(d => new DrzavaGetAllVM()
            {
                ID = d.ID,
                Naziv = d.Naziv
            });
            return Ok(podaci.ToList());
        }



        [HttpPost]
        public ActionResult Delete([FromBody] DrzavaGetAllVM x)
        {
            Drzava? drzava = _dbContext.Drzava.Find(x.ID);

            if (drzava == null)
                return BadRequest("Pogresan ID");

            _dbContext.Remove(drzava);

            _dbContext.SaveChanges();
            return Ok(drzava);
        }
    }
}
