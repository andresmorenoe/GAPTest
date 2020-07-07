using System.Threading.Tasks;

namespace SegurosTestGAP.Aplicacion
{
    public interface ICommandHandler<TCommand, TReturn> : IRequestHandler<TCommand> where TCommand : ICommand
    {
        Task<TReturn> HandleAsync(TCommand command);
    }
}
