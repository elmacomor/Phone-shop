using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MobitelShop.Data;
using MobitelShop.Models;
using MobitelShop.ViewModels;
using System.Security.Claims;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Authorization;

namespace MobitelShop.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize]
    public class VikendAkcijaController:ControllerBase
    {
        private readonly MojDbContext _dbContext;

        public VikendAkcijaController(MojDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        [HttpGet]
        public ActionResult AkcijeGetAlll()
        {
            var podaci = _dbContext.VikendAkcija.Select(s => new VikendAkcijaGetAllVM()
            {
                ID = s.ID,
                IznosPopusta = s.IznosPopusta,
                Od = s.Od,
                Do = s.Do,
            });
            return Ok(podaci.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail()
        {
            var users = _dbContext.Korisnik.ToList();
            var message = new MimeMessage();
            //var senderEmailClaim=User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            //var senderNameClaim=User.Claims.FirstOrDefault(c=>c.Type==ClaimTypes.Name);
            //if (senderEmailClaim == null|| senderNameClaim==null)
            //{
            //    return BadRequest("Nemamo posiljatelja");
            //}
            //var senderEmail = senderEmailClaim.Value;
            //var senderName = senderNameClaim.Value;
            message.From.Add(new MailboxAddress("Elma", "elma.comor@edu.fit.ba"));  
            foreach(var user in users)
            {
                if(user.Role=="kupac")
                message.To.Add(new MailboxAddress(user.Ime, user.Email));
            }
            message.Subject = "Obavjestenje kupcima";
            message.Body = new TextPart("plain")
            {
                Text = "Dragi kupci," +
                "\n" +
                "U toku je nova akcija koju možete naći na našoj stranici.\n" +
                "Za sve dodatne pogodnosti kontaktirajte nas na naš e-mail ili kontakt telefon." +
                "\nVidimo se u našim poslovnicama." +
                "\n\nLijep pozdrav,\nImpuls shop."
            };

            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.office365.com", 587, SecureSocketOptions.StartTls);
            //await client.AuthenticateAsync("//,//");
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
            return Ok("Poslani mailovi");
        }

        [HttpGet]
        public ActionResult VikendAkcijaGetAllForCmb()
        {
            var podaci = _dbContext.VikendAkcija.Select(s => new VikendAkcijaGetAllForCmbVM()
            {
                id = s.ID,
                akcija = s.Od.Day+"."+s.Od.Month + "-" + s.Do.Day +"."+s.Do.Month+ "->" + s.IznosPopusta + "%",
            }).ToList();
            return Ok(podaci);
        }

        [HttpPost]
        public ActionResult Snimi([FromBody] VikendAkcijaSnimiVM x)
        {
            VikendAkcija? nova;
            if (x.ID == 0)
            {
                nova = new VikendAkcija();
                _dbContext.Add(nova);
            }
            else
            {
                nova = _dbContext.VikendAkcija.Find(x.ID);
                if (nova == null)
                {
                    return BadRequest();
                }
            }
            nova.Od = x.Od;
            nova.Do = x.Do;
            nova.IznosPopusta = x.IznosPopusta;
            _dbContext.SaveChanges();
            return Ok(nova);
        }


    }
}
