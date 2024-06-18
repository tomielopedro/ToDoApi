using System.IO.Compression;
using System.Runtime.InteropServices;
using Aposta.Data;
using Aposta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aposta.Controllers
{
    [ApiController]
    public class ApostaController : ControllerBase
    {
        [HttpGet("/aposta")]
        public IActionResult Get([FromServices] AppDbContext context)
            => Ok(context.Apostas.ToList());

        [HttpGet("/aposta/{id:int}")]
        public IActionResult GetById(
            [FromRoute] int id,
            [FromServices] AppDbContext context
        )
        {
            var apostaId = context.Apostas.FirstOrDefault(x => x.Id == id);
            if (apostaId == null) NotFound();
            return Ok(apostaId);

        }


        [HttpPost("/aposta")]
        public IActionResult Post(
            [FromBody] ApostaModel aposta,
            [FromServices] AppDbContext context)
        {
            context.Apostas.Add(aposta);
            context.SaveChanges();
            return Ok($"Nome: {aposta.Nome} Cpf: {aposta.Cpf} Aposta: {aposta.NumerosAposta}");
        }


        [HttpDelete("/aposta/{id:int}")]

        public IActionResult Delete(
            [FromRoute] int id,
            [FromServices] AppDbContext context
        )
        {
            var aposta = context.Apostas.FirstOrDefault(x => x.Id == id);
            if (aposta == null)
                NoContent();
            context.Apostas.Remove(aposta);
            context.SaveChanges();
            return Ok("Aposta deletada com sucesso"!);


        }

        [HttpPut("/aposta/{id:int}")]
        public IActionResult Put(
            [FromBody] ApostaModel model,
            [FromRoute] int id,
            [FromServices] AppDbContext context
        )
        {
            var aposta = context.Apostas.FirstOrDefault(x => x.Id == id);
            aposta.NumerosAposta = model.NumerosAposta;
            context.Apostas.Update(aposta);
            context.SaveChanges();
            return Ok("Aposta Mudada com sucesso");

        }
    }


}