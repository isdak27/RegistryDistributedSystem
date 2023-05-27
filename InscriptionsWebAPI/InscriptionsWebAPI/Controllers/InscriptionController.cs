using Microsoft.AspNetCore.Mvc;
using InscriptionsWebAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Web.Http.OData;
using Microsoft.AspNetCore.Authorization;

namespace InscriptionsWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InscriptionController : ControllerBase
    {
        private readonly InscriptionDbContext _inscriptionDb;

        public InscriptionController(InscriptionDbContext inscriptionDb)
        {
            _inscriptionDb = inscriptionDb;
        }

        [Authorize] // Requiere autenticación
        [HttpGet("consultar")]
        public ActionResult<Inscription> Get(int code)
        {
            var token = Request.Headers["Authorization"].ToString().Substring("Bearer ".Length);
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            
            var inscription = _inscriptionDb.Inscriptions.FirstOrDefault(i => i.code == code);

            if (inscription == null)
            {
                return NotFound();
            }

            return Ok(inscription);
        }

        [Authorize] // Requiere autenticación
        [HttpPost("agregar")]
        public ActionResult<Inscription> Post(int codigoEstudiante, int codigoMateria, string estado)
        {
            var token = Request.Headers["Authorization"].ToString().Substring("Bearer ".Length);
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            
            var nuevaInscripcion = new Inscription
            {
                StudentCode = codigoEstudiante,
                SubjectCode = codigoMateria,
                Status = estado
            };

            _inscriptionDb.Inscriptions.Add(nuevaInscripcion);
            _inscriptionDb.SaveChanges();
            return Ok(nuevaInscripcion);
        }
    }


}