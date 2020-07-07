namespace SegurosTestGAP.Dominio.Roles
{
    public class Role : Entity
    {
        public string Nombre { get; set; }

        public Role() => Nombre = default!;

        public Role(string nombre) => Nombre = nombre;
    }
}
