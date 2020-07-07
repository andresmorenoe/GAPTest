namespace SegurosTestGAP.Aplicacion.Clientes.Comandos
{
    public class ClienteViewModel
    {
        public int Id { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string Documento { get; set; }

        public string? Email { get; set; }

        public string TipoDocumento { get; set; }

        public ClienteViewModel()
        {
            Nombres = default!;
            Apellidos = default!;
            Documento = default!;
            Email = default!;
            TipoDocumento = default!;
        }

        public ClienteViewModel(int id, 
            string nombres,
            string apellidos,
            string documento,
            string? email,
            string tipoDocumento)
        {
            Id = id;
            Nombres = nombres;
            Apellidos = apellidos;
            Documento = documento;
            Email = email;
            TipoDocumento = tipoDocumento;
        }

    }
}
