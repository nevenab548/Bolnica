using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Server.Models;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BolnicaController : ControllerBase
    {
        public BolnicaContext Context { get; set; }
        public BolnicaController(BolnicaContext context)
        {
            Context=context;
        }

        [Route("PreuzmiBolnice")]
        [HttpGet]
        public async Task<List<Bolnica>> PreuzmiBolnice()
        {
            return await Context.Bolnice.Include(p=> p.Sobe).Include(p=>p.Smene).ToListAsync();
        }
        [Route("PreuzmiSobe/{idBolnice}")]
        [HttpGet]
        public async Task<List<Soba>> PreuzmiSobe(int idBolnice)
        {
            return await Context.Sobe.Where(soba => soba.Bolnica.ID==idBolnice).OrderBy(soba=>soba.BrojSobe).ToListAsync();
        }
        [Route("PreuzmiSmene/{idBolnice}")]
        [HttpGet]
        public async Task<List<Smena>> PreuzmiSmene(int idBolnice)
        {
            return await Context.Smene.Where(smena=> smena.Bolnica.ID==idBolnice).OrderBy(smena=>smena.Broj).ToListAsync();
        }
        [Route("PreuzmiLekare/{idBolnice}")]
        [HttpGet]
        public async Task<List<Lekar>> PreuzmiLekare(int idBolnice)
        {
            return await Context.Lekari.Where(lekar=> lekar.Bolnica.ID==idBolnice).ToListAsync();
        }
        [Route("UpisBolnice")]
        [HttpPost]
        public async Task UpisBolnice([FromBody] Bolnica bolnica)
        {
            Context.Bolnice.Add(bolnica);
            await Context.SaveChangesAsync();
        }
        [Route("UpisSobe/{idBolnice}")]
        [HttpPost]
        public async Task UpisSobe(int idBolnice,[FromBody] Soba soba)
        {
            var bolnica=await Context.Bolnice.FindAsync(idBolnice);
            soba.Bolnica=bolnica;
            Context.Sobe.Add(soba);
            await Context.SaveChangesAsync();
        }
        [Route("UpisSmene/{idBolnice}")]
        [HttpPost]
        public async Task UpisSmene(int idBolnice,[FromBody] Smena smena)
        {
            var bolnica=await Context.Bolnice.FindAsync(idBolnice);
            smena.Bolnica=bolnica;
            Context.Smene.Add(smena);
            await Context.SaveChangesAsync();
        }
        [Route("UpisLekara/{idBolnice}")]
        [HttpPost]
        public async Task<IActionResult> UpisLekara(int idBolnice,[FromBody] Lekar lekar)
        {
            
            var bolnica=await Context.Bolnice.FindAsync(idBolnice);
            lekar.Bolnica=bolnica;
            if(Context.Lekari.Any(p=>p.Ime==lekar.Ime && p.Prezime==lekar.Prezime))
            {
                return StatusCode(406);
            }
            if(lekar.Ime==null || lekar.Prezime==null)
            return StatusCode(406);
            else
            {
            Context.Lekari.Add(lekar);
            await Context.SaveChangesAsync();
            return Ok();
            }
            
        }
        [Route("IzmeniBolnicu")]
        [HttpPut]
        public async Task IzmeniBolnicu([FromBody] Bolnica bolnica)
        {
            Context.Update<Bolnica>(bolnica);
            await Context.SaveChangesAsync();
        }
        [Route("IzmeniSobu")]
        [HttpPut]
        public async Task IzmeniSobu([FromBody] Soba soba)
        {
            
            Context.Update<Soba>(soba);
            await Context.SaveChangesAsync();
            
        }
        [Route("IzmeniSmenu")]
        [HttpPut]
        public async Task IzmeniSmenu([FromBody] Smena smena)
        {
            Context.Update<Smena>(smena);
            await Context.SaveChangesAsync();
        }
        [Route("IzmeniLekara")]
        [HttpPut]
        public async Task IzmeniLekara([FromBody] Lekar lekar)
        {
            Context.Update<Lekar>(lekar);
            await Context.SaveChangesAsync();
        }
        [Route("IzbrisiBolnicu")]
        [HttpDelete]
        public async Task IzbrisiBolnicu(int id)
        {
           var nizSoba=Context.Sobe.Where(s=>s.Bolnica.ID==id);
            await nizSoba.ForEachAsync(s=>{
                Context.Remove(s);
            });
            var nizSmena=Context.Smene.Where(s=>s.Bolnica.ID==id);
            await nizSmena.ForEachAsync(s=>{
                Context.Remove(s);
            });
            var nizLekara=Context.Lekari.Where(l=>l.Bolnica.ID==id);
            await nizLekara.ForEachAsync(l=>{
                Context.Remove(l);
            });
           var bolnica = await Context.Bolnice.FindAsync(id);
            Context.Remove(bolnica);
            await Context.SaveChangesAsync();
        }
        [Route("IzbrisiSobu/{idSobe}")]
        [HttpDelete]
        public async Task IzbrisiSobu(int idSobe)
        {
           var soba = await Context.Sobe.FindAsync(idSobe);
            Context.Remove(soba);
            await Context.SaveChangesAsync();
        }
        [Route("IzbrisiSmenu")]
        [HttpDelete]
        public async Task IzbrisiSmenu(int id)
        {
           var smena = await Context.Smene.FindAsync(id);
            Context.Remove(smena);
            await Context.SaveChangesAsync();
        }
        [Route("IzbrisiLekara")]
        [HttpDelete]
        public async Task IzbrisiLekara(int id)
        {
           var lekar = await Context.Lekari.FindAsync(id);
            Context.Remove(lekar);
            await Context.SaveChangesAsync();
        }
    }
}
