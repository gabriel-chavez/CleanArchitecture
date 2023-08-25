using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;


namespace CleanArchitecture.Application.Features.Directors.Commands.CreateDirector
{
    public class CreateDirectorCommandHandler : IRequestHandler<CreateDirectorCommand, int>
    {
        private readonly ILogger<CreateDirectorCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateDirectorCommandHandler(ILogger<CreateDirectorCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateDirectorCommand request, CancellationToken cancellationToken)
        {
            var directorEntity = _mapper.Map<Director>(request);
            //Ahora se necesita insartar este objeto director dentro de la tabla director de la BD
            //usualmente a quien se llama para la transaccion es a una interface, a un servicio.
            //Este servicio tiene que ser genérico ya que no declaramos una interface personalizada para director
            //Utilizaremos la interface genérica y a su vez para poder llamar a la interace genérica
            //debo instanciar a unit of work
            _unitOfWork.Repository<Director>().AddEntity(directorEntity);
            //agregamos este registro en memoria, aun no esta en la base de datos

            //Si se requiere ya insertarlo en la base de datos,se debe llamar al confirm al metodo completeasync
            //ese metodo tambien ya lo creamos dentro de la interface genérica unitOfWork

            var result= await _unitOfWork.Complete();

            if(result <= 0)
            {
                _logger.LogError("No se pudo insertar el record del director");
                throw new System.Exception("No se pudo insertar el record del director");
            }
            return directorEntity.Id;
        }
    }
}
