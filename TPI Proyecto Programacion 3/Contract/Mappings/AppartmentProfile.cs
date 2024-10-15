using Contract.AppartmentModels.Request;
using Contract.AppartmentModels.Response;

namespace Contract.Mappings
{
    public static class AppartmentProfile
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
                BuildingId = request.BuildingId,
                TenantId = request.TenantId,
            };
        }

        public static AppartmentResponse ToApparmentResponse(Domain.Entities.Appartment entity)
        {
            return new AppartmentResponse
            {
                Floor = entity.Floor,
                Number = entity.Number,
                Bathrooms = entity.Bathrooms,
                Rooms = entity.Rooms,
                Description = entity.Description,
                Rating = entity.Rating,
                Id = entity.Id,
                BuildingId = entity.BuildingId,
                TenantId = entity.TenantId,
            };
        }
    }
}
