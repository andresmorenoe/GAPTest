namespace SegurosTestGAP.Dominio.Usuarios
{
    public class Usuario : Entity
    {
        public string Nombre { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Contrasena { get; set; }

        public string Token { get; set; }

        public Usuario()
        {
            Nombre = default!;
            UserName = default!;
            Email = default!;
            Contrasena = default!;
            Token = default!;
        }

        public Usuario(string nombre, string userName, string email, string contrasena, string token)
        {
            Nombre = nombre;
            UserName = userName;
            Email = email;
            Contrasena = contrasena;
            Token = token;
        }
    }
}
