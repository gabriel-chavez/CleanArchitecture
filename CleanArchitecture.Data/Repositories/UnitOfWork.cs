using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Infraestructure.Persistence;
using System.Collections;

namespace CleanArchitecture.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        //UnitOfWork como instancia va a almacenar la colección de referencias
        //a los servicios repositorios, entonces se necesita un objeto collection
        private Hashtable _repositories;
        //se requiere una instancia de entity framework core
        private readonly StreamerDbContext _context;
        //personalizadas
        private IVideoRepository _videoRepository;
        private IStreamerRepository _streamerRepository;

        public IVideoRepository VideoRepository=>_videoRepository??=new VideoRepository(_context);
        public IStreamerRepository StreamerRepository => _streamerRepository ??= new StreamerRepository(_context);


        public UnitOfWork(StreamerDbContext context)
        {
            _context = context;
        }
        //se encarga de disparar la confiruacion de todas las trancacciones que se esta realizando
        public async Task<int> Complete()
        {            
            return await _context.SaveChangesAsync();
        }
        //para que se elimine el context cuando la transacción culimne
        public void Dispose()
        {
            _context.Dispose();
        }

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        {
            //si la colección de repositorios es nula se generara instancias de ese repositorio
            //crea la colección
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }
            //Capturar el nombre de la entidad que se esta trabajando
            //a este nivel no se sabe porque se esta trabajando con TEntity
            var type=typeof(TEntity).Name;
            //si esta entidad que estoy referenciando para este servicio
            //no existe dentro de mi Hashtable, agregarlo
            if (!_repositories.ContainsKey(type))
            {
                //creamos su instancia
                var repositoryType= typeof(RepositoryBase<>);
                var repositoryInstance=Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)),_context);
                //ya se tiene la instancia del repositorio, son esta instancia lo agregamos al Hashtable
                _repositories.Add(type, repositoryInstance);
            }
            //una vez agregado el repositorio a Hashtable, ya se puede retornar toda la lista de repositorios
            return (IAsyncRepository<TEntity>)_repositories[type];
        }
    }
}
