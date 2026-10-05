using Microsoft.AspNetCore.Mvc;
using Transport.Shared.Models.Drivers;
using Transport.Shared.DTOs.DriversDTOs;
using Transport.Shared.DTOs;

namespace Transport.WebUI.Services
{
    public class DriversService
    {
        private readonly TransportWebApiService _api;

        public DriversService(TransportWebApiService api) => _api = api;

        public Task<DriversListDTO> GetAllAsync() =>
        _api.GetAsync<DriversListDTO>("api/Drivers/GetAll");

        public Task<GetDriversByIdResponse> GetByIdAsync(GetDriversByIdRequest req) =>
        _api.PostAsync<GetDriversByIdRequest, GetDriversByIdResponse>("api/Drivers/GetById", req);

        public Task AddAsync(DriversCreateDTO req) =>
        _api.PostAsync("api/Drivers/Add", req);

        public Task UpdateAsync(DriversUpdateDTO req) =>
        _api.PostAsync("api/Drivers/Update", req);

        public Task DeleteAsync(Guid id)=> 
        _api.PostAsync("api/Drivers/Delete", id);

        public Task<GetDriversByPhoneResponse> GetByPhoneAsync(GetDriversByPhoneRequest req) =>
        _api.PostAsync<GetDriversByPhoneRequest, GetDriversByPhoneResponse>("api/Drivers/GetByPhone", req);

        public Task<List<GetDriversByFullNameResponse>> GetByFullName(GetDriversByFullNameRequest req) =>
        _api.PostAsync<GetDriversByFullNameRequest, List<GetDriversByFullNameResponse>>("api/Drivers/GetByFullName", req);

        public Task<GetDriversByEmailResponse> GetByEmailAsync(GetDriversByEmailRequest req) =>
        _api.PostAsync<GetDriversByEmailRequest, GetDriversByEmailResponse>("api/Drivers/GetByEmail", req);

    }
}
