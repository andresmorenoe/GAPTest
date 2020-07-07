namespace SegurosTestGAP.Dominio.Polizas
{
    public class TipoCubrimiento : Entity
    {
        public string Nombre { get; set; }

        public TipoCubrimiento() => Nombre = default!;

        public TipoCubrimiento(string nombre) => Nombre = nombre;
    }
}
