namespace SegurosTestGAP.Dominio.Clientes
{
    public class TipoDocumento : Entity
    {
        public string Nombre { get; set; }

        public TipoDocumento() => Nombre = default!;

        public TipoDocumento(string nombre) => Nombre = nombre;
    }
}
