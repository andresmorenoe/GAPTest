using System.Threading.Tasks;

namespace SegurosTestGAP.Aplicacion
{
    public interface IQueryHandler<TQuery, TReturn> : IRequestHandler<TQuery> where TQuery : IQuery
    {
        Task<TReturn> HandleAsync(TQuery query);
    }
}
