using System.Reflection.Metadata.Ecma335;
using Transport.Business.Abstract;
using Transport.Business.Models.Statuses;
using Transport.Entities.Concrete;
using Transport.Entities.DTOs.StatusesDTOs;

namespace Transport.Business.Concrete
{
    public class StatusesService(IGenericRepository<Statuses> repository) : IStatusesService
    {
        public async Task<StatusesListDTO> GetAll()
        {
            try
            {
                var result = await repository.GetAllAsync();
                return new StatusesListDTO()
                {
                    IsSuccess = true,
                    data = [.. result.Select(s => new StatusesListItem { Id = s.id ,StatusCode = s.StatusCode, Durum = s.Durum })]
                };
            }
            catch (Exception ex)
            {
                return new StatusesListDTO { IsSuccess  = false  , Message = ex.Message};
            }
        }

        public async Task<List<GetStatusesByStatusCodeResponse>> GetByStatusCode(GetStatusesByStatusCodeRequest req)
        {
            if (req.statusCode == null)
                return new List<GetStatusesByStatusCodeResponse>();

            var result = await repository.GetWhereAsync(s => s.StatusCode == req.statusCode);

            if (result == null || !result.Any())
                return new List<GetStatusesByStatusCodeResponse>();

            return result
                .Select(s => new GetStatusesByStatusCodeResponse
                {
                    durum = s.Durum
                })
                .ToList();
        }
    }
}
