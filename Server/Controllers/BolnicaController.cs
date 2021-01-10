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
            return await Context.Bolnice.Include(p=> p.Sobe).Include(p=>p.Smene).Include(p=>p.Lekari).ToListAsync();
        }
        [Route("PreuzmiSobe")]
        [HttpGet]
        public async Task<List<Soba>> PreuzmiSobe()
        {
            return await Context.Sobe.ToListAsync();
        }
        [Route("PreuzmiSmene")]
        [HttpGet]
        public async Task<List<Smena>> PreuzmiSmene()
        {
            return await Context.Smene.ToListAsync();
        }
        [Route("PreuzmiLekare")]
        [HttpGet]
        public async Task<List<Lekar>> PreuzmiLekare()
        {
            return await Context.Lekari.ToListAsync();
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
        public async Task UpisLekara(int idBolnice,[FromBody] Lekar lekar)
        {
            var bolnica=await Context.Bolnice.FindAsync(idBolnice);
            lekar.Bolnica=bolnica;
            Context.Lekari.Add(lekar);
            await Context.SaveChangesAsync();
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
           var bolnica = await Context.Bolnice.FindAsync(id);
            Context.Remove(bolnica);
            await Context.SaveChangesAsync();
        }
        [Route("IzbrisiSobu")]
        [HttpDelete]
        public async Task IzbrisiSobu(int id)
        {
           var soba = await Context.Sobe.FindAsync(id);
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
