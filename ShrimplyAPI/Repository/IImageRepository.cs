using ShrimplyAPI.Models.Domain;
using System.Net;

namespace ShrimplyAPI.Repository
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}
