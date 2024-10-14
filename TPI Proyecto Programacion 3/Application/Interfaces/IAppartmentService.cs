using Contract.AppartmentModels.Request;
using Contract.AppartmentModels.Response;

namespace Application.Interfaces
{
    public interface IAppartmentService
    {
        AppartmentResponse Create(AppartmentRequest appartment);

        List<AppartmentResponse> GetAll();

        AppartmentResponse? GetById(int id);
    }
}
