using EspacioAccesoADatos;
using EspacioTarea;
using EspacioManejoTarea;
using Microsoft.AspNetCore.Mvc;

namespace TareaController;

[ApiController]
[Route("[controller]")]

public class TareaController : ControllerBase{ // Herencia de controller base

    private ManejoTarea manejoTarea; 
    private readonly ILogger<TareaController> _logger;
    
    public TareaController(ILogger<TareaController> logger){
        _logger = logger;
        AccesoADatos accesoTareas = new AccesoADatos();
        manejoTarea = new ManejoTarea(accesoTareas);
    }

    // crear una nueva Tarea
    [HttpPost("AgregarTarea")]
    public ActionResult<Tarea> AgregarTarea(Tarea t){
        var tarea = manejoTarea.CrearTarea(t);
        return Ok(tarea);
    }

    // Obtener una Tarea por id
    [HttpGet("GetTareaID")]
    public ActionResult<Tarea> GetTareaID(int idTarea){
        var tarea = manejoTarea.BuscarTarea(idTarea);
        return Ok(tarea);
    }

    // Cambiar Estado Tarea (Actualizarla)
    [HttpPut("ActualizarEstado")]
    public ActionResult<Tarea> ActualizarEstado(int idTarea){
        var tarea = manejoTarea.ActualizarTarea(idTarea);
        return Ok(tarea);
    }

    // Eliminar Tarea
    [HttpGet("EliminarUnaTarea")]
    public ActionResult<Tarea> EliminarUnaTarea(int idTarea){
        var Tarea = manejoTarea.EliminarTarea(idTarea);
        return Ok(Tarea);
    }

    // ListarTodasLasTareas
    [HttpGet("ListarTodasLasTareas")]
    public ActionResult<List<Tarea>> ListarTodasLasTareas(){
        List<Tarea> listaTarea = manejoTarea.ListarTareas();
        return Ok(listaTarea);
    }

    [HttpGet("ListarCompletadas")]
    public ActionResult<List<Tarea>> ListarCompletadas(){
        List<Tarea> listaCompletadas = manejoTarea.ListarTareasCompletadas();
        return Ok(listaCompletadas);
    }
}