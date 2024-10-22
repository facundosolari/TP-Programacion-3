using Contract.AppartmentModels.Request;
using Contract.AppartmentModels.Response;

namespace Contract.Mappings
{
    public static class AppartmentProfile
    {
        public static Domain.Entities.Appartment ToAppartmentEntity(AppartmentRequest request)
        {
            return new Domain.Entities.Appartment()
            {
                Floor = request.Floor,
                Number = request.Number,
                Bathrooms = request.Bathrooms,
                Rooms = request.Rooms,
                Description = request.Description,
                Rating = request.Rating,
                BuildingId = request.BuildingId,
                Tenant = request.Tenant,
                Price = request.Price,
                isAvailable = request.IsAvailable,
                Pictures = request.Pictures ?? new List<string>()
            };
        }

        public static void ToAppartmentEntityUpdate(Domain.Entities.Appartment appartment, AppartmentRequest request)
        {
            appartment.Floor = request.Floor;
            appartment.Number = request.Number;
            appartment.Bathrooms = request.Bathrooms;
            appartment.Description = request.Description;
            appartment.Rating = request.Rating;
            appartment.BuildingId = request.BuildingId;
            appartment.Tenant = request.Tenant;
            appartment.Price = request.Price;
            appartment.isAvailable = request.IsAvailable;
            appartment.Pictures = request.Pictures ?? new List<string>();
        }

        public static AppartmentResponse ToAppartmentResponse(Domain.Entities.Appartment entity)
        {
            return new AppartmentResponse
            {
                Floor = entity.Floor,
                Number = entity.Number,
                Bathrooms = entity.Bathrooms,
                Rooms = entity.Rooms,
                Description = entity.Description,
                Rating = entity.Rating,
                Id = entity.AppartmentID,
                BuildingId = entity.BuildingId,
                Tenant = entity.Tenant, 
                Price = entity.Price,
                IsAvailable = entity.isAvailable,
                Pictures = entity.Pictures
            };
        }
    }
}
