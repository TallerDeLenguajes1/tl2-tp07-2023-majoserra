using EspacioAccesoADatos;
using EspacioTarea;

namespace EspacioManejoTarea;

public class ManejoTarea{

    private AccesoADatos accesoTarea;
    private List<Tarea> listaTarea;

    private static int id_pedido;


    // constructor
    public ManejoTarea(AccesoADatos accesoTarea){
        this.accesoTarea = accesoTarea;
        listaTarea = accesoTarea.LeerLista();
    }

    public Tarea CrearTarea(Tarea tarea){
        var ultimaTarea = listaTarea.Last();
        tarea.Id = ultimaTarea.Id+1;
        listaTarea.Add(tarea);
        accesoTarea.Guardar(listaTarea);
        return tarea;
    }

    public Tarea BuscarTarea(int idTarea){
        Tarea tarea = listaTarea.FirstOrDefault(t => t.Id == idTarea);
        return tarea;
    }

    public Tarea ActualizarTarea(int idTarea){
        Tarea tarea = listaTarea.FirstOrDefault(t => t.Id == idTarea);

        if (tarea.Estado == Estado.Pendiente )
        {
            tarea.Estado = Estado.Enprogreso;
        }else
        {
            tarea.Estado = Estado.Completada;
        }

        accesoTarea.Guardar(listaTarea);
        return tarea;
    }

    // Eliminar una Tarea
    public Tarea EliminarTarea(int idTarea){
        Tarea tarea = listaTarea.FirstOrDefault(t => t.Id == idTarea);
        listaTarea.Remove(tarea);
        accesoTarea.Guardar(listaTarea);
        return tarea;
    }

    // ListarTodasLasTareas
    public List<Tarea> ListarTareas(){
        return listaTarea;
    }

    // ListarTareasCompletadas
    public List<Tarea> ListarTareasCompletadas(){
        List<Tarea> listaAux = listaTarea;
        List<Tarea> listaCompletadas = new List<Tarea>();
        int i=0;
        while (i < listaAux.Count())
        {
            if (listaAux[i].Estado == Estado.Completada)
            {
                listaCompletadas.Add(listaAux[i]);
            }
            listaAux.Remove(listaAux[i]);
        }
        return listaCompletadas;
    }
}