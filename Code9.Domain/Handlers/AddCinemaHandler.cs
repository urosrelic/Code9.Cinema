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
    public class AddCinemaHandler : IRequestHandler<AddCinemaCommand, Cinema>
    {
        private readonly ICinemaRepository _cinemaRepository;

        public AddCinemaHandler(ICinemaRepository cinemaRepository)
        {
            this._cinemaRepository = cinemaRepository;
        }

        public async Task<Cinema> Handle(AddCinemaCommand request, CancellationToken cancellationToken)
        {
            var cinema = new Cinema
            {
                Name = request.Name,
                City = request.City,
                Street = request.Street,
                NumberOfAuditoriums = request.NumberOfAuditoriums
            };

            await _cinemaRepository.AddCinema(cinema);
            return cinema;
        }
    }
}
