using Transport.Shared.Models.Statuses;
using Transport.Shared.DTOs.StatusesDTOs;

namespace Transport.WebUI.Services
{
    public class StatusesService
    {
        private readonly TransportWebApiService _api;

        public StatusesService(TransportWebApiService api) => _api = api;

        public Task<StatusesListDTO> GetAll() =>
        _api.GetAsync<StatusesListDTO>("api/Statuses/GetAll");

        public Task<List<GetStatusesByStatusCodeResponse>> GetByStatusCode(GetStatusesByStatusCodeRequest req)=>
        _api.PostAsync<GetStatusesByStatusCodeRequest, List<GetStatusesByStatusCodeResponse>>("api/Statuses/GetByStatusCode",req);

    }
}
