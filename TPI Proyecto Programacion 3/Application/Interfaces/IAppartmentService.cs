using Application.Models.AppartmentModels.Request;
using Application.Models.AppartmentModels.Response;

namespace Application.Interfaces
{
    public interface IAppartmentService
    {
        AppartmentResponse Create(AppartmentRequest appartment);
        List<AppartmentResponse> GetAll();
        AppartmentResponse? GetById(int id);
        AppartmentResponse UpdateAppartment(int id, AppartmentRequest appartment);
        AppartmentResponse DeleteAppartment(int id);
        bool AddRating(int id, RatingRequest ratingRequest);
    }
}
