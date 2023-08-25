using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.Videos.Queries.GetVideosList
{
    public class GetVideosListQueryHandler : IRequestHandler<GetVideosListQuery, List<VideosVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IVideoRepository _videoRepository;
        private readonly IMapper _mapper;

        public GetVideosListQueryHandler( IMapper mapper, IUnitOfWork unitOfWork)
        {
            //_videoRepository = videoRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<VideosVm>> Handle(GetVideosListQuery request, CancellationToken cancellationToken)
        {
            //var videoList = await _videoRepository.GetVideoByUserName(request._UserName);
            var videoList = await _unitOfWork.VideoRepository.GetVideoByUserName(request._UserName);

            return _mapper.Map<List<VideosVm>>(videoList);
        }
    }
}
