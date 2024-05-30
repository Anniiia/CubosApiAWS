using CubosApiAWS.Models;
using CubosApiAWS.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CubosApiAWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CubosController : ControllerBase
    {
        private RepositoryCubos repo;

        public CubosController(RepositoryCubos repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cubo>>>Get()
        {
            return await this.repo.GetCubosAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cubo>> GetId(int id)
        {
            return await this.repo.FindCubosAsync(id);
        }
        [HttpGet]
        [Route("[action]/{marca}")]
        public async Task<ActionResult<List<Cubo>>>Find(string marca)
        {
            return await this.repo.FindCubosMarcasAsync(marca);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<string>>> GetMarcas()
        {
            return await this.repo.GetMarcasAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Cubo cubo)
        {
            await this.repo.CreateCuboAsync(cubo.Nombre, cubo.Marca, cubo.Imagen, cubo.Precio);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(Cubo cubo)
        {
            await this.repo.UpdateCuboAsync(cubo.IdCubo, cubo.Nombre, cubo.Marca, cubo.Imagen, cubo.Precio);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await this.repo.DeleteCuboAsync(id);
            return Ok();
        }





    }
}
