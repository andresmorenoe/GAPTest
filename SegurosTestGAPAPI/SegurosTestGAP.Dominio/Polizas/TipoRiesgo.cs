namespace SegurosTestGAP.Dominio.Polizas
{
    public class TipoRiesgo : Entity
    {
        public string Nombre { get; set; }

        public TipoRiesgo() => Nombre = default!;

        public TipoRiesgo(string nombre) => Nombre = nombre;
    }
}
