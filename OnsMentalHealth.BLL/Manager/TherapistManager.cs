using Microsoft.Extensions.Caching.Memory;
using OnsMentalHealth.DAL.Repository;
using OnsMentalHealth.BLL.DTOs.Therapists;

namespace OnsMentalHealth.BLL.Manager
{
    public class TherapistManager : ITherapistManager
    {
        private readonly ITherapistRepo _repo;
        private readonly IMemoryCache _cache;

        public TherapistManager(ITherapistRepo repo, IMemoryCache cache)
        {
            _repo = repo;
            _cache = cache;
        }

        public async Task<List<TherapistReadDTO>> GetAllTherapistsAsync(int pageNumber, int pageSize)
        {
            string cacheKey = $"Therapists_{pageNumber}_{pageSize}";

            if (!_cache.TryGetValue(cacheKey, out List<TherapistReadDTO> cachedList))
            {
                var therapists = await _repo.GetAllAsync(pageNumber, pageSize);

                cachedList = therapists.Select(t => new TherapistReadDTO
                {
                    Id = t.TherapistId,
                    FullName = t.Name,
                    Email = t.Email,
                    Specialization = t.Speclization,
                    City = t.City,
                    Gender = t.Gender
                }).ToList();

                var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(1));
                _cache.Set(cacheKey, cachedList, cacheOptions);
            }

            return cachedList;
        }

        public async Task<TherapistReadDTO> GetTherapistByIdAsync(int id)
        {
            var t = await _repo.GetByIdAsync(id);
            if (t == null) return null;

            return new TherapistReadDTO
            {
                Id = t.TherapistId,
                FullName = t.Name,
                Email = t.Email,
                Specialization = t.Speclization,
                City = t.City,
                Gender = t.Gender
            };
        }

        public async Task<TherapistReadDTO> AddTherapistAsync(TherapistAddDTO addDto)
        {
            // استخدمنا الاسم الكامل عشان ميتلخبطش مع الفولدر
            var therapist = new OnsMentalHealthSolution.DAL.Entities.Therapist
            {
                Name = $"{addDto.FirstName} {addDto.LastName}",
                Email = addDto.Email,
                Password = addDto.Password,
                Speclization = addDto.Specialization,
                City = addDto.City,
                Gender = addDto.Gender,
                Birthday = addDto.Birthday
            };

            await _repo.AddAsync(therapist);

            return new TherapistReadDTO
            {
                Id = therapist.TherapistId,
                FullName = therapist.Name,
                Email = therapist.Email,
                Specialization = therapist.Speclization,
                City = therapist.City,
                Gender = therapist.Gender
            };
        }

        public async Task<bool> UpdateTherapistAsync(int id, TherapistUpdateDTO updateDto)
        {
            var therapist = await _repo.GetByIdAsync(id);
            if (therapist == null) return false;

            therapist.Name = $"{updateDto.FirstName} {updateDto.LastName}";
            therapist.Speclization = updateDto.Specialization;
            therapist.City = updateDto.City;

            await _repo.UpdateAsync(therapist);
            return true;
        }

        public async Task<bool> DeleteTherapistAsync(int id)
        {
            var therapist = await _repo.GetByIdAsync(id);
            if (therapist == null) return false;

            await _repo.DeleteAsync(therapist);
            return true;
        }
    }
}