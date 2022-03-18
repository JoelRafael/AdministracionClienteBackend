using Microsoft.AspNetCore.Mvc;
using AdministracionEmpresa.Models;
using Microsoft.EntityFrameworkCore;
namespace AdministracionEmpresa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdministracionController : ControllerBase
    {
        private readonly DbCong _ctx;

        public AdministracionController(DbCong ctx)
        {
            this. _ctx = ctx;
        }
        [HttpGet]
        [Route("GetAllEmpresa")]
        public  async Task<IActionResult> GetAllEmpresa()
        {
            var json = await _ctx.Empresas.Include(x => x.Clientes).ToListAsync();
            return Ok(new {Error=false, Message="", Data= json});
        }
        [HttpPost]
        [Route("PostEmpresas")]
        public async Task<IActionResult> PostEmpresas([FromBody] Empresa json)
        {
            if (json.Nombre == null)
            {
                return BadRequest();
            }
            Empresa empresa = new Empresa
            {
                Nombre = json.Nombre,
                FechaConstituida = json.FechaConstituida
            };
            _ctx.Add(json);
            await _ctx.SaveChangesAsync();
            return StatusCode(201, new {  Error = false, Mensaje = "El tipo personal fue agregado con exito", Data="" });
        }
        [HttpGet]
        [Route("GetAllClientes")]
        public async Task<IActionResult> GetAllClientes()
        {

            return Ok(new {Error=false, Message="", Data= await _ctx.Clientes.Include(x=>x.Empresa).ToListAsync() });
        }

        [HttpPost]
        [Route("PostClientes")]
        public async Task<IActionResult> PostClientes(Cliente json)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _ctx.Add(json);

            var save =   await _ctx.SaveChangesAsync();
            var sa = 28;
            return StatusCode(201, new { Error = false, Mensaje = "El cliente fue agregado con exito", Data = "" });
        }
        [HttpGet]
        [Route("GetDireccionesClientes/{idcliente}")]
        public async Task<IActionResult> GetDireccionesClientes(int idcliente)
        {
            if (idcliente == 0)
            {
                return BadRequest(new { Error = true, Message = "Tienes que especificar el id del cliente", Data = "" });
            }
            var Direccioness = await _ctx.Direciones.Where(x => x.ClienteId == idcliente).ToListAsync();
            if (Direccioness.Count == 0)
            {
                return BadRequest(new { Error = true, Message = "Este cliente no tiene direccion registrada", Data = "" });
            }
            return Ok(new { Error = false, Message = "", Data = Direccioness });
        }
        [HttpPost]
        [Route("PostDireccionesClientes")]
        public async Task<IActionResult> PostDireccionesClientes([FromBody] Direccion json)
        {
            if (!ModelState.IsValid)
            {return BadRequest(ModelState);}
            _ctx.Add(json);
            var save = await _ctx.SaveChangesAsync();
            if (save==0)
            {return StatusCode(500, new { Error = true, Message = "Hubo un problema con el servidor", Data = "" });}
             return StatusCode(201, new { Error = false, Mensaje = "Direccion registrada con exito", Data = "" });
        }
        [HttpPut]
        [Route("PutEmpresa/{empresaid}")]
        public async Task<IActionResult> PutEmpresa(int empresaid, [FromBody] Empresa json)
        {
            if (empresaid == 0) { empresaid = json.EmpresaId; }
            var select = await _ctx.Empresas.Where(x => x.EmpresaId == empresaid).SingleOrDefaultAsync();
            if (select == null) { return NotFound(new { Error = true, Message = "Esta empresa no existe", Data = "" }); }
            if (!ModelState.IsValid) { return BadRequest(ModelState);}
            //_ctx.Entry(json).State = EntityState.Modified;
            select.Nombre = json.Nombre;
            select.FechaConstituida = json.FechaConstituida;
            var update = await _ctx.SaveChangesAsync();
            if (update == 0)
            { return StatusCode(500, new { Error = true, Message = "Hubo un problema con el servidor", Data = "" }); }
              return StatusCode(201, new { Error = false, Mensaje = "Empresa actualizada con exito", Data = ""  });
        }
        [HttpPut]
        [Route("PutClientes/{clienteid}")]
        public async Task<IActionResult> PutEmpresa(int clienteid, [FromBody] Cliente json)
        {
            if (clienteid == 0) { clienteid = json.ClienteId; }
            var select = await _ctx.Clientes.Where(x => x.ClienteId == clienteid).SingleOrDefaultAsync();
            if (select == null) { return NotFound(new { Error = true, Message = "Este cliente no existe", Data = "" }); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            //_ctx.Entry(json).State = EntityState.Modified;
            select.EmpresaId = json.EmpresaId;
            select.SexoId = json.SexoId;
            select.Nombre = json.Nombre;
            select.Apellido = json.Apellido;
            select.Cedula = json.Cedula;
            select.FechaNacimiento = json.FechaNacimiento;
            var update = await _ctx.SaveChangesAsync();
            if (update == 0)
            { return StatusCode(500, new { Error = true, Message = "Hubo un problema con el servidor", Data = "" }); }
            return StatusCode(201, new { Error = false, Mensaje = "Cliente actualizado con exito", Data = "" });
        }
        [HttpGet]
        [Route("GetSexo")]
        public async Task<IActionResult> GetASexo()
        {
            var json = await _ctx.Sexos.ToListAsync();
            return Ok(new { Error = false, Message = "", Data = json });
        }

    }
}
