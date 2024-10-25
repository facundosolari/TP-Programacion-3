using Application.Models.AppartmentModels.Request;
using Application.Models.AppartmentModels.Response;
using Domain.Entities;

namespace Application.Models.Mappings
{
    public static class AppartmentProfile
    {
        public static Domain.Entities.Appartment ToAppartmentEntity(CreateAppartmentRequest request, Building building)
        {
            return new Domain.Entities.Appartment()
            {
                Floor = request.Floor,
                Number = request.Number,
                Bathrooms = request.Bathrooms,
                Rooms = request.Rooms,
                Pictures = request.Pictures,
                Description = request.Description,
                Price = request.Price,
                BuildingId = request.BuildingId,
                Building = building,
            };
        }

        public static void ToAppartmentEntityUpdate(Domain.Entities.Appartment appartment, AppartmentRequest request)
        {
            appartment.Floor = request.Floor;
            appartment.Number = request.Number;
            appartment.Bathrooms = request.Bathrooms;
            appartment.Rooms = request.Rooms;
            appartment.Pictures = request.Pictures;
            appartment.Description = request.Description;
            appartment.Price = request.Price;
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
            };
        }
    }
}
