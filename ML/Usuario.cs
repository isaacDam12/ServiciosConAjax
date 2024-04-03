namespace ML
{
    public class Usuario
    {
        public int IdUsuario {  get; set; }

        public string Nombre { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public int Edad {get; set; }

        public List<ML.Usuario> Usuarios { get; set; }
    }
}
