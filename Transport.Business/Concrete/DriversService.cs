using System.Threading.Tasks;
using Transport.Business.Abstract;
using Transport.Business.Models.Drivers;
using Transport.Entities.Concrete;
using Transport.Entities.DTOs;
using Transport.Entities.DTOs.DriversDTOs;

namespace Transport.Business.Concrete
{

    public class DriversService(IGenericRepository<Drivers> repository) : IDriversService
    {
        public async Task<DriversListDTO> GetAll()
        {
            try
            {
                var result = await repository.GetAllAsync();

                return new DriversListDTO
                {
                    IsSuccess = true,
                    data = [.. result.Select(s => new DriversListItem { Id = s.id, Ad = s.Ad , Soyad = s.Soyad , FullName = s.FullName, Telefon = s.Telefon, Email = s.Email, AktifMi = s.AktifMi })]
                };
            }
            catch (Exception ex)
            {
                return new DriversListDTO { IsSuccess = false, Message = ex.Message };
            }

        }

        public async Task<GetDriversByIdResponse> GetById(GetDriversByIdRequest req)
        {
            if (req.Id == null || req.Id == Guid.Empty)
                throw new ArgumentNullException(nameof(req.Id));

            var result = await repository.GetByIdAsync(req.Id.Value);

            if (result == null) throw new Exception("Sürücü bulunamadı!");

            return new GetDriversByIdResponse
            {
                Ad = result.Ad,
                Soyad = result.Soyad,
                Telefon = result.Telefon,
                Email = result.Email,
                AktifMi = result.AktifMi
            };

        }

        public async Task Add(DriversCreateDTO req)
        {
            var driver = new Drivers
            {
                id = Guid.NewGuid(),
                Ad = req.Ad,
                Soyad = req.Soyad,
                Telefon = req.Telefon,
                Email = req.Email,
                AktifMi = true
            };

            await repository.AddAsync(driver);
            await repository.SaveAsync();
        }

        public async Task Update(Guid id, DriversUpdateDTO req)
        {
            var existing = await repository.GetByIdAsync(id);

            if (existing == null)  
              throw new Exception("Sürücü bulunamadı!");

            existing.Ad = req.Ad;
            existing.Soyad = req.Soyad;
            existing.Telefon = req.Telefon;
            existing.Email = req.Email;
            existing.AktifMi = req.AktifMi;
        
            await repository.Update(existing);
            await repository.SaveAsync();

        }

        public async Task DeleteAsync(Guid id)
        {
           var driver = await repository.GetByIdAsync(id);

            if (driver == null) throw new Exception("Sürücü bulunamadı!");

            await repository.DeleteAsync(id);

        }

        public async Task<GetDriversByPhoneResponse> GetByPhone(GetDriversByPhoneRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.Telefon))
                return new GetDriversByPhoneResponse();

            var result = await repository.GetWhereAsync(w => w.Telefon == req.Telefon);

            var driver = result.FirstOrDefault();

            if (driver == null)
                return new GetDriversByPhoneResponse();

            return new GetDriversByPhoneResponse
            {
                Ad = driver.Ad,
                Soyad = driver.Soyad,
            };
        }

        public async Task<List<GetDriversByFullNameResponse>> GetByFullName(GetDriversByFullNameRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.FullName))
                return new List<GetDriversByFullNameResponse>();

            var result = await repository.GetWhereAsync(
                w => (w.Ad + " " + w.Soyad) == (req.FullName)
            );

            return result?
                .Select(s => new GetDriversByFullNameResponse
                {
                    telefon = s.Telefon,
                    email = s.Email
                })
                .ToList()
                ?? new List<GetDriversByFullNameResponse>();
        }

        public async Task<GetDriversByEmailResponse> GetByEmail(GetDriversByEmailRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.Email))
                return new GetDriversByEmailResponse();

            var result = await repository.GetWhereAsync(w => w.Email == req.Email);

            var driver = result.FirstOrDefault();

            if (driver == null)
                return new GetDriversByEmailResponse();

            return new GetDriversByEmailResponse
            {
                Ad = driver.Ad,
                Soyad = driver.Soyad,
                Telefon = driver.Telefon,
            };
        }

    }
}
