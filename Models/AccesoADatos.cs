using System.Text.Json;
using EspacioTarea;

namespace EspacioAccesoADatos
{
    public class AccesoADatos{
        
        public List<Tarea> LeerLista(){
            string? jsonTarea = File.ReadAllText("Tarea.json");    
            List<Tarea> ListaTarea = JsonSerializer.Deserialize<List<Tarea>>(jsonTarea);
            return ListaTarea;
        }

        public bool Guardar(List<Tarea> tareas){// mandamos una lista de tareas
            string listaTarea = JsonSerializer.Serialize(tareas);  // serealizmos la lista de tareas
            File.WriteAllText("Tarea.json", listaTarea);
            if (listaTarea!=null)
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
}