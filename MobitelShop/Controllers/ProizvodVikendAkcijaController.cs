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
    public class ProizvodVikendAkcijaController:ControllerBase
    {
        private readonly MojDbContext _dbContex;

        public ProizvodVikendAkcijaController(MojDbContext dbContext)
        {
            _dbContex= dbContext;
        }
        [HttpGet]
        public ActionResult ProizvodAkcijaGetAll()
        {
            var podaci = _dbContex.ProizvodVikendAkcija.Select(s => new ProizvodVikendAkcijaGetAllVM()
            {
                ID = s.ID,
                ProizvodID = s.ProizvodID,
                VikendAkcijaID = s.VikendAkcijaID,
            });
            return Ok(podaci.ToList());
        }

        [HttpPost]
        public ActionResult Obrisi(int id)
        {
            ProizvodVikendAkcija? akcija = _dbContex.ProizvodVikendAkcija.Find(id);
            if (akcija == null)
            {
                BadRequest("Akcija ne postoji u bazi");
            }

            _dbContex.ProizvodVikendAkcija.Remove(akcija);
            _dbContex.SaveChanges();
            return Ok();    
        }

        [HttpPost]
        public ProizvodVikendAkcija Snimi([FromBody] ProizvodVikendAkcijaSpremiVM x)
        {
            ProizvodVikendAkcija? nova;
            if (x.ID == 0)
            {
                nova = new ProizvodVikendAkcija();
                _dbContex.Add(nova);
            }
            else
            {
                nova = _dbContex.ProizvodVikendAkcija.Find(x.ID);
            }
            nova.ProizvodID = x.ProizvodID;
            nova.VikendAkcijaID = x.VikendAkcijaID;
            _dbContex.SaveChanges();
            return nova;
        }
    }
}
