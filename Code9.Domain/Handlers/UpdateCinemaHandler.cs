using Code9.Domain.Commands;
using Code9.Domain.Interfaces;
using Code9.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code9.Domain.Handlers
{
    internal class UpdateCinemaHandler : IRequestHandler<UpdateCinemaCommand, Cinema>
    {
        private readonly ICinemaRepository _cinemaRepository;

        public UpdateCinemaHandler(ICinemaRepository repository)
        {
            _cinemaRepository = repository;
        }

        public async Task<Cinema> Handle(UpdateCinemaCommand request, CancellationToken cancellationToken)
        {
            var foundCinema = await _cinemaRepository.findById(request.Id);

            if (foundCinema == null)
            {
                throw new Exception("Cinema not found");
            }

            var cinema = new Cinema
            {
                
                Name = request.cinema.Name,
                City = request.cinema.City,
                Street = request.cinema.Street,
                NumberOfAuditoriums = request.cinema.NumberOfAuditoriums
            };

            await _cinemaRepository.UpdateCinema(cinema);
            return cinema;
        }
    }
}
