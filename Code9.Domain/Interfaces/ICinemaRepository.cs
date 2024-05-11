using Code9.Domain.Models;

namespace Code9.Domain.Interfaces
{
    public interface ICinemaRepository
    {
        public Task<List<Cinema>> GetAllCinemas();
        public Task AddCinema(Cinema cinema);
        public Task UpdateCinema(Cinema cinema);
    }

    
}
