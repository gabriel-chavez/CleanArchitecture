using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IVideoRepository:IAsyncRepositeory<Video>
    {
        Task<Video> GetVideoByNombre(string nombreVideo);
        Task<IEnumerable<Video>> GetVideoByUserName(string userName);
      
    }
}
