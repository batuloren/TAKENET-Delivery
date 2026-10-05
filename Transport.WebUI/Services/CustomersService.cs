using Transport.Shared.DTOs.CustomersDTOs;
using Transport.Shared.Models.Customers;

namespace Transport.WebUI.Services
{
    public class CustomersService
    {
        private readonly TransportWebApiService _api;

        public CustomersService(TransportWebApiService api) => _api = api;

        public Task<CustomersListDTO> GetAllAsync() =>
        _api.GetAsync<CustomersListDTO>("api/Customers/GetAll");

        public Task<GetCustomersByIdResponse> GetByIdAsync(GetCustomersByIdRequest req) =>
        _api.PostAsync<GetCustomersByIdRequest, GetCustomersByIdResponse>("api/Customers/GetById", req);

        public Task<Guid> AddAsync(CustomersCreateDTO req) =>
        _api.PostAsync<CustomersCreateDTO, Guid>("api/Customers/Add", req);

        public Task UpdateAsync(Guid id, CustomersUpdateDTO req) =>
        _api.PostAsync("api/Customers/Update", req);

        public Task DeleteAsync(Guid id) =>
        _api.PostAsync("api/Customers/Delete", id);

        public Task<GetCustomersByEmailResponse> GetByEmailAsync(GetCustomersByEmailRequest req) =>
        _api.PostAsync<GetCustomersByEmailRequest, GetCustomersByEmailResponse>("api/Customers/GetByEmail", req);

        public Task<List<GetCustomersByFullNameResponse>> GetByFullName(GetCustomersByFullNameRequest req) =>
        _api.PostAsync<GetCustomersByFullNameRequest, List<GetCustomersByFullNameResponse>>("api/Customers/GetByFullName", req);

        public Task<GetCustomersByPhoneResponse> GetByPhone(GetCustomersByPhoneRequest req) =>
        _api.PostAsync<GetCustomersByPhoneRequest, GetCustomersByPhoneResponse>("api/Customers/GetByPhone", req);

    }
}
