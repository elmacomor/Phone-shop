using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MobitelShop.Data;
using MobitelShop.Helpers;
using MobitelShop.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;

namespace MobitelShop.Controllers
{
  [Route("[controller]/[action]")]
  [ApiController]
  public class AutentifikacijaController : ControllerBase
  {
    private readonly MojDbContext _dbContext;
    public AutentifikacijaController(MojDbContext dbContext)
    {
      this._dbContext = dbContext;
    }

    public class SignUpVM
    {
      public string Ime { get; set; }
      public string Prezime { get; set; }
      public string Email { get; set; }
      public string Username { get; set; }
      public string Password { get; set; }
    }

    [HttpPost]
    public ActionResult SignUp([FromBody] SignUpVM x)
    {
      Korisnik? korisnik;
      if (x==null)
      {
        return BadRequest();
      }
      if (PostojiLiUsername(x.Username) == true)
        return BadRequest(new { Message = "Username already exist !" });
      if (PostojiLiEmail(x.Email) == true)
        return BadRequest(new { Message = "Email already exist !" });

      var password = CheckPasswordStrength(x.Password);
      if (!string.IsNullOrEmpty(password))
        return BadRequest(new { Message = password.ToString() });

      else
      {
        korisnik = new Korisnik()
        {
        };
        _dbContext.Add(korisnik);

        korisnik.Ime = x.Ime;
        korisnik.Prezime = x.Prezime;
        korisnik.Email = x.Email;
        korisnik.Username = x.Username;
        korisnik.Password = PasswordHasher.HashPassword(x.Password);
        korisnik.Role = "kupac";
        korisnik.Token = "";

        _dbContext.SaveChanges();
        return Ok(new
        {
          Message = "Korisnik uspjesno registrovan"
        });
      }
    }

    private bool PostojiLiUsername(string username)
    {
      if (_dbContext.Korisnik.Any(x => x.Username == username))
        return true;
      else
        return false;
    }

    private bool PostojiLiEmail(string email)
    {
      if (_dbContext.Korisnik.Any(x => x.Email == email))
        return true;
      else
        return false;
    }

    private string CheckPasswordStrength(string password)
    {
      StringBuilder sb = new StringBuilder();

      if (password.Length < 8)
        sb.Append("Minimum password length should be 8" + Environment.NewLine);
      if (!(Regex.IsMatch(password, "[a-z]") && Regex.IsMatch(password, "[A-Z]") && Regex.IsMatch(password, "[0-9]")))
        sb.Append("Password should be Alphanumeric" + Environment.NewLine);
      if (!Regex.IsMatch(password, "[<,>,@,!,#,$,%,&,/,(,),=,',+,*,|,-]"))
        sb.Append("Password should contain special chars" + Environment.NewLine);

      return sb.ToString();
    }

    public class LoginVM
    {
      public string Username { get; set; }
      public string Password { get; set; }
    }

    [HttpPost]
    public ActionResult Login([FromBody] LoginVM x)
    {
      if(x==null)
        return BadRequest();

      var korisnik = _dbContext.Korisnik.FirstOrDefault(k=> k.Username == x.Username);

      if(korisnik==null)
        return NotFound(new { Message="Korisnik ne postoji !" });

      if(!PasswordHasher.VerifyPassword(x.Password, korisnik.Password))
      {
        return BadRequest(new { Message = "Password is incorrect" }); //alert
      }

      korisnik.Token = KreirajJWT(korisnik);
      
        return Ok(new
        {
          Token = korisnik.Token,
          Message = "Korisnik uspjesno logiran !"
        });
    }

        private string KreirajJWT(Korisnik korisnik)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("veryverysecret.....");
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Role, korisnik.Role),
                new Claim(ClaimTypes.Name,$"{korisnik.Ime} {korisnik.Prezime}"),
                new Claim(ClaimTypes.NameIdentifier, korisnik.ID.ToString())
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);

        }


        public class ProfilVM
        {
            public int Id { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string Email { get; set; }
            public string Username { get; set; }
        }

        [Authorize]
        [HttpGet]
        public ActionResult<ProfilVM> GetProfil()
        {
            // Dohvati ID korisnika iz trenutno prijavljenog JWT tokena
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var korisnikId = int.Parse(identity.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");


            // Dohvati korisnika iz baze
            var korisnik = _dbContext.Korisnik.Find(korisnikId);

            // Kreiraj ProfilVM objekat sa podacima iz baze
            var profilVM = new ProfilVM
            {
                Id = korisnik.ID,
                Ime = korisnik.Ime,
                Prezime = korisnik.Prezime,
                Email = korisnik.Email,
                Username = korisnik.Username
            };

            return Ok(profilVM);
        }




        [Authorize]
    [HttpGet]
    public ActionResult<Korisnik> GetUsers()
    {
      return Ok(_dbContext.Korisnik.ToList());
    }

  }
}
