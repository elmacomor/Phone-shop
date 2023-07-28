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
    public class ProizvodiTipController:ControllerBase
    {
        private readonly MojDbContext _dbContext;

        public ProizvodiTipController(MojDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        [HttpGet]
        public ActionResult GetProizvodiTip()
        {
            var Podaci = _dbContext.ProizvodTip.Select(t => new ProizvodTipGetVM()
            {
                ID = t.ID,
                Naziv = t.Naziv,
            });
            return Ok(Podaci.ToList());
        }

        [HttpPost]
        public ProizvodTip Snimi([FromBody] ProizvodTipSnimiVM x)
        {
            ProizvodTip? novi;
            if (x.ID == 0)
            {
                novi = new ProizvodTip();
                _dbContext.Add(novi);
            }
            else
            {
                novi = _dbContext.ProizvodTip.Find(x.ID);
            }
            novi.Naziv = x.Naziv;
            _dbContext.SaveChanges();
            return novi;
        }
    }
}
