using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Business.Models.Statuses;
using Transport.Entities.DTOs.StatusesDTOs;

namespace Transport.Business.Abstract
{
    public interface IStatusesService
    {
        Task<StatusesListDTO> GetAll();
        Task<List<GetStatusesByStatusCodeResponse>> GetByStatusCode(GetStatusesByStatusCodeRequest req);
    }
}
