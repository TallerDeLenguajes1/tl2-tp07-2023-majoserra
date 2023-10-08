namespace EspacioTarea
{
    public enum Estado{
        Pendiente,
        Enprogreso,
        Completada

    }
    public class Tarea{
        // atributos
        private int id;
        private string titulo;
        private string descripcion;
        private Estado estado;

        //contructor vacio de tarea
        public Tarea(){

        }
        public Tarea(int id, string titulo, string descripcion, Estado estado){
            this.id = id;
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.estado = estado;
        }

        public int Id { get => id; set => id = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public Estado Estado { get => estado; set => estado = value; }
    }
}