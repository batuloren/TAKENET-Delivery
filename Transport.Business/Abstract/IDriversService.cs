using Transport.Business.Models.Drivers;
using Transport.Entities.Concrete;
using Transport.Entities.DTOs;
using Transport.Entities.DTOs.DriversDTOs;

namespace Transport.Business.Abstract
{
    public interface IDriversService
    {

        Task<DriversListDTO> GetAll();

        Task Add(DriversCreateDTO req);
        Task Update(Guid id, DriversUpdateDTO req);
        Task DeleteAsync(Guid id);

        Task<GetDriversByIdResponse> GetById(GetDriversByIdRequest req);
        Task<GetDriversByPhoneResponse> GetByPhone(GetDriversByPhoneRequest req);
        Task<List<GetDriversByFullNameResponse>> GetByFullName(GetDriversByFullNameRequest req);
        Task<GetDriversByEmailResponse> GetByEmail(GetDriversByEmailRequest req);    
            
    }
}
