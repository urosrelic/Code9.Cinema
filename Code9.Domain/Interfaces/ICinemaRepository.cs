using Code9.Domain.Models;

namespace Code9.Domain.Interfaces
{
    public interface ICinemaRepository
    {
        public Task<List<Cinema>> GetAllCinema();
        public Task AddCinema(Cinema cinema);
        public Task UpdateCinema(Cinema cinema);
        public Task<Cinema> findById(Guid id);
    }

    
}
