using Transport.Shared.Models.Vehicles;
using Transport.Shared.DTOs.VehiclesDTOs;

namespace Transport.WebUI.Services
{
    public class VehiclesService
    {
        private readonly TransportWebApiService _api;

        public VehiclesService(TransportWebApiService api) => _api = api;

        public Task<VehiclesListDTO> GetAllAsync() =>
        _api.GetAsync<VehiclesListDTO>("api/Vehicles/GetAll");

        public Task<GetVehiclesByIdResponse> GetByIdAsync(GetVehiclesByIdRequest req) =>
        _api.PostAsync<GetVehiclesByIdRequest, GetVehiclesByIdResponse>("api/Vehicles/GetById", req);

        public Task Add(VehiclesCreateDTO req) =>
        _api.PostAsync("api/Vehicles/Add", req);

        public Task UpdateAsync(VehiclesUpdateDTO req) =>
        _api.PostAsync("api/Vehicles/Update", req);

        public Task DeleteAsync(Guid id) =>
        _api.PostAsync("api/Vehicles/Delete", id);

        public Task<List<GetVehiclesByCarModelResponse>> GetByCarModel(GetVehiclesByCarModelRequest req) =>
        _api.PostAsync<GetVehiclesByCarModelRequest, List<GetVehiclesByCarModelResponse>>("api/Vehicles/GetByCarModel", req);

        public Task<GetVehiclesByPlateNumberResponse> GetByPlateNumber(GetVehiclesByPlateNumberRequest req) =>
        _api.PostAsync<GetVehiclesByPlateNumberRequest, GetVehiclesByPlateNumberResponse>("api/Vehicles/GetByPlateNumber", req);

        internal object GetByIdAsync(object vehicleId)
        {
            throw new NotImplementedException();
        }
    }
}
