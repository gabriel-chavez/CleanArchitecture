using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IUnitOfWork: IDisposable
    {
        IStreamerRepository StreamerRepository { get; }
        IVideoRepository VideoRepository { get; }


        //Metodo generico que me devuelve la instancia del servicio repositorio que quiero utilizar
        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;
        //Metodo para saber cuando una transacción ya ha culminado
        Task<int> Complete();
    }
}
