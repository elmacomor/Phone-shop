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
    public class GradController : ControllerBase
    {

        private readonly MojDbContext _dbContext;
        public GradController(MojDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult Snimi([FromBody] GradSnimiVM g)
        {
            Grad? grad;
            if (g.ID == 0)
            {
                grad = new Grad();
                _dbContext.Add(grad);
            }
            else
            {
                grad = _dbContext.Grad.Find(g.ID);
                if (grad == null)
                    return BadRequest("Pogresan ID");
            }
            grad.Naziv = g.Naziv;
            grad.PostanskiBroj = g.PostanskiBroj;
            grad.DrzavaID = g.DrzavaID;

            _dbContext.SaveChanges();
            return Ok(grad);
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var podaci = _dbContext.Grad.Select(g => new GradGetAllVM()
            {
                ID = g.ID,
                Naziv = g.Naziv,
                PostanskiBroj = g.PostanskiBroj,
                DrzavaID = g.DrzavaID,
                DrzavaNaziv = g.Drzava.Naziv
            });
            return Ok(podaci.ToList());
        }

        [HttpPost]
        public ActionResult Delete([FromBody] GradSnimiVM g)
        {
            Grad? grad = _dbContext.Grad.Find(g.ID);

            if (grad == null)
                return BadRequest("Pogresan ID");
            else
            {
                _dbContext.Remove(grad);
            }

            _dbContext.SaveChanges();
            return Ok(grad);
        }
    }
}
