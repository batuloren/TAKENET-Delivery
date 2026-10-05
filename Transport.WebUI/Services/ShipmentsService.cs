using Transport.Shared.DTOs;
using Transport.Shared.DTOs.ShipmentsDTOs;
using Transport.Shared.Models.Shipments;
using Transport.Shared.Shipments.DTOs;

namespace Transport.WebUI.Services
{
    public class ShipmentsService
    {
        private readonly TransportWebApiService _api;

        public ShipmentsService(TransportWebApiService api) => _api = api;

        public Task<List<ShipmentsTableAdminDTO>> GetAllShipmentsAsync() =>
        _api.GetAsync<List<ShipmentsTableAdminDTO>>("api/Shipments/Table_CP");

        public Task<ShipmentsList_ADMIN_DTO> GetAllAdminAsync() =>
        _api.GetAsync<ShipmentsList_ADMIN_DTO>("api/Shipments/All_CP");

        public Task<ShipmentsList_ADMIN_Item> GetByIdAsync(Guid id) =>
        _api.GetAsync<ShipmentsList_ADMIN_Item>($"api/Shipments/GetById_CP/{id}");

        public Task<string> AddAsync(ShipmentsCreateDTO dto) =>
        _api.PostAsync<ShipmentsCreateDTO, string>("api/Shipments/Add", dto);

        public Task UpdateAsync(ShipmentsUpdateDTO dto) =>
        _api.PostAsync("api/Shipments/Update_CP", dto);

        public Task DeleteAsync(Guid id) =>
        _api.PostAsync("api/Shipments/Delete_CP", id);

        public Task<GetShipmentsByCustomerEmailResponse> GetByCustomerEmailAsync(GetShipmentsByCustomerEmailRequest req) =>
        _api.PostAsync<GetShipmentsByCustomerEmailRequest, GetShipmentsByCustomerEmailResponse>("api/Shipments/GetByCustomerEmail_CP", req);

        public Task<GetShipmentsByTrackIdResponse> GetByTrackIdAsync(GetShipmentsByTrackIdRequest req) =>
        _api.PostAsync<GetShipmentsByTrackIdRequest, GetShipmentsByTrackIdResponse>("api/Shipments/GetByTrackId_UP", req);

    }
}
