using SegurosTestGAP.Dominio.Usuarios;

namespace SegurosTestGAP.Dominio.Roles
{
    public class RoleUsuario : Entity
    {
        public Role Role { get; set; }

        public Usuario Usuario { get; set; }

        public RoleUsuario() => (Role, Usuario) = (default!, default!);

        public RoleUsuario(Role role, Usuario usuario) => (Role, Usuario) = (role, usuario);
    }
}
