using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/")]
    public class TransactionsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public TransactionsController(ApplicationContext context) {
            _context = context;
        }

        // we will only post (or maybe also get)
        // will fire when actions occur at api/pets and api/petowners
        [HttpPost]
        public IEnumerable<PetOwner> GetPets() {
            return new List<PetOwner>();
        }
    }
}
