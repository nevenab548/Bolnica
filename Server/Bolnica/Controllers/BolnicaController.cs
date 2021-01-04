using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bolnica.Models;
using Microsoft.EntityFrameworkCore;

namespace Bolnica.Controllers
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
        public async Task<List<Bolnica.Models.Bolnica>>  PreuzmiBolnice()
        {
            return await Context.Bolnice.Include(p=>p.Sobe).Include(p=>p.Smene).ToListAsync();
        } 

        [Route("UpisBolnice")]
        [HttpPost]
        public async Task UpisiBolnicu([FromBody] Bolnica.Models.Bolnica bolnica)
        {
            Context.Bolnice.Add(bolnica);
            await Context.SaveChangesAsync();
        }
        [Route("IzmeniBolnicu")]
        [HttpPut]
        public async Task IzmeniBolnicu([FromBody] Bolnica.Models.Bolnica bolnica )
        {

            Context.Update<Bolnica.Models.Bolnica>(bolnica);
            await Context.SaveChangesAsync();
        }

    [Route("IzbrisiBolnicu/{id}")]
    [HttpDelete]
    public async Task IzbrisiBolnicu(int id)
    {
        var bolnica=await Context.FindAsync<Bolnica.Models.Bolnica>(id);
        Context.Remove(bolnica);
        await Context.SaveChangesAsync();
    }

    [Route("UpisSobe/{idBolnice}")]
    [HttpPost]
    public async Task UpisiSobu(int idBolnice,[FromBody] Soba soba)
    {
        var bolnica= await Context.Bolnice.FindAsync(idBolnice);
        soba.Bolnica=bolnica;
        Context.Sobe.Add(soba);
        await Context.SaveChangesAsync();
    }
    [Route("UpisSmene/{idBolnice}")]
    [HttpPost]
    public async Task UpisiSmenu(int idBolnice, [FromBody] Smena smena)
    {
        var bolnica= await Context.Bolnice.FindAsync(idBolnice);
        smena.Bolnica=bolnica;
        Context.Smene.Add(smena);
        await Context.SaveChangesAsync();
    }
    [Route("IzbrisiSobu/{id}")]
    [HttpDelete]
    public async Task IzbrisiSobu(int id)
    {
        var soba=await Context.FindAsync<Soba>(id);
        Context.Remove(soba);
        await Context.SaveChangesAsync();
    }
    [Route("IzbrisiSmenu/{id}")]
    [HttpDelete]
    public async Task IzbrisiSmenu(int id)
    {
        var smena=await Context.FindAsync<Smena>(id);
        Context.Remove(smena);
        await Context.SaveChangesAsync();
    }
    [Route("IzmeniSobu")]
        [HttpPut]
        public async Task IzmeniSobuu([FromBody] Soba soba )
        {

            Context.Update<Soba>(soba);
            await Context.SaveChangesAsync();
        }
        [Route("IzmeniSmenu")]
        [HttpPut]
        public async Task IzmeniSmenu([FromBody] Smena smena )
        {

            Context.Update<Smena>(smena);
            await Context.SaveChangesAsync();
        }
        [Route("PreuzmiSobe")]
        [HttpGet]
        public async Task<List<Soba>>  PreuzmiSobe()
        {
            return await Context.Sobe.ToListAsync();
        } 
        [Route("PreuzmiSmene")]
        [HttpGet]
        public async Task<List<Smena>> PreuzmiSmene()
        {
            return await Context.Smene.ToListAsync();
        } 
    }
    
}
