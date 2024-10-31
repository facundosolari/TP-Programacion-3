using Application.Models.AppartmentModels.Request;
using Application.Models.AppartmentModels.Response;
using Domain.Entities;

namespace Application.Models.Mappings
{
    public static class AppartmentProfile
    {
        public static Appartment ToAppartmentEntity(AppartmentRequest request, Building building)
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
                BuildingId = request.BuildingId,
                Building = building,
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
                Rating = entity.Rating,
            };
        }

        public static Rating ToRatingEntity(RatingRequest ratingRequest, Appartment appartment, Tenant tenant)
        {
            return new Rating
            {
                Value = ratingRequest.Value,
                AppartmentId = ratingRequest.AppartmentId,
                TenantId = ratingRequest.TenantId,
                Tenant = tenant,
                Appartment = appartment,
            };
        }
    }
}
