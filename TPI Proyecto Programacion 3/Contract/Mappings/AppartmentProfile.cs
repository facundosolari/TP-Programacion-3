using Contract.AppartmentModels.Request;
using Contract.AppartmentModels.Response;
using Domain.Entities;

namespace Contract.Mappings
{
    public static class AppartmentProfile
    {
        public static Appartment ToAppartmentEntity(AppartmentRequest request)
        {
            return new Appartment()
            {
                Floor = request.Floor,
                Number = request.Number,
                Bathrooms = request.Bathrooms,
                Rooms = request.Rooms,
                Pictures = request.Pictures,
                Description = request.Description,
                Price = request.Price,
                Tenant = request.Tenant
            };
        }

        public static void ToAppartmentEntityUpdate(Appartment appartment, AppartmentRequest request)
        {
            appartment.Floor = request.Floor;
            appartment.Number = request.Number;
            appartment.Bathrooms = request.Bathrooms;
            appartment.Rooms = request.Rooms;
            appartment.Pictures = request.Pictures;
            appartment.Description = request.Description;
            appartment.Price = request.Price;
            appartment.Tenant = request.Tenant;
        }

        public static AppartmentResponse ToAppartmentResponse(Appartment entity)
        {
            return new AppartmentResponse
            {
                Floor = entity.Floor,
                Number = entity.Number,
                Bathrooms = entity.Bathrooms,
                Rooms = entity.Rooms,
                Pictures = entity.Pictures,
                Description = entity.Description,
                Price = entity.Price,
                Tenant = entity.Tenant,
            };
        }
    }
}
