using System.Threading.Tasks;

namespace SegurosTestGAP.Aplicacion
{
    public interface IVoidCommandHandler<TCommand> : IRequestHandler<TCommand> where TCommand : ICommand
    {
        public Task HandleAsync(TCommand command);
    }
}
