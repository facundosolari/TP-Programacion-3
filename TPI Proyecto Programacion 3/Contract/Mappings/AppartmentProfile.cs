using Contract.AppartmentModels.Request;
using Contract.AppartmentModels.Response;

namespace Contract.Mappings
{
    public class AppartmentProfile
    {
        public static Domain.Entities.Appartment ToAppartmentEntity(AppartmentRequest request)
        {
            return new Domain.Entities.Appartment
            {
                Floor = request.Floor,
                Number = request.Number,
                Bathrooms = request.Bathrooms,
                Rooms = request.Rooms,
                Description = request.Description,
                Rating = request.Rating,
                Id = request.Id,
                BuildingId = request.BuildingId,
                TenantId = request.TenantId,
            };
        }

        public static AppartmentResponse ToApparmentResponse(Domain.Entities.Appartment response)
        {
            return new AppartmentResponse
            {
                Floor = response.Floor,
                Number = response.Number,
                Bathrooms = response.Bathrooms,
                Rooms = response.Rooms,
                Description = response.Description,
                Rating = response.Rating,
                Id = response.Id,
                BuildingId = response.BuildingId,
                TenantId = response.TenantId,
            };
        }
    }
}
