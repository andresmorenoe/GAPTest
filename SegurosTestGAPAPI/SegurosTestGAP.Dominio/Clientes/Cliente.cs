namespace SegurosTestGAP.Dominio.Clientes
{
    public class Cliente : Entity
    {
        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string Documento { get; set; }

        public string? Email { get; set; }

        public TipoDocumento TipoDocumento { get; set; }

        public Cliente()
        {
            Nombres = default!;
            Apellidos = default!;
            Documento = default!;
            Email = default!;
        }

        public Cliente(string nombres, string apellidos, string documento, string? email, TipoDocumento tipoDocumento)
        {
            Nombres = nombres;
            Apellidos = apellidos;
            Documento = documento;
            Email = email;
            TipoDocumento = tipoDocumento;
        }
    }
}
