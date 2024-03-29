﻿using AutoMapper;
using CleanArchitecture.Application.Contracts.Infraestructure;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Streamers.Commands.CreateStreamer
{
    public class CreateStreamerCommandHandler : IRequestHandler<CreateStreamerCommand, int>
    {
        //private readonly IStreamerRepository _streamerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateStreamerCommandHandler> _logger;

        public CreateStreamerCommandHandler(IStreamerRepository streamerRepository, IMapper mapper, IEmailService emailService, ILogger<CreateStreamerCommandHandler> logger, IUnitOfWork unitOfWork)
        {
            //_streamerRepository = streamerRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamerEntity = _mapper.Map<Streamer>(request);

            //var newStreamer = await _streamerRepository.AddAsync(streamerEntity);
            _unitOfWork.StreamerRepository.AddEntity(streamerEntity);
            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                throw new System.Exception($"No se pudo insetrar el record de streamer");
            }

            _logger.LogInformation($"Streamer {streamerEntity.Id} fue creado exitosamente");
            await SendEmail(streamerEntity);
            return streamerEntity.Id;
        }
        private async Task SendEmail(Streamer streamer)
        {
            var email = new Email
            {
                To = "gabriel.chavez.r@gmail.com",
                Body = "La compañia de streamer se creó correctamente",
                Subjetct = "Mensaje de alerta"
            };
            try
            {
                await _emailService.SendEmail(email);
            }
            catch (System.Exception)
            {
                _logger.LogError($"Errores enviando el email de {streamer.Id}");
            }
           
        }
    }
}
