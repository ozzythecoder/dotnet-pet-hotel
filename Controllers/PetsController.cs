using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PetsController(ApplicationContext context)
        {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<Pet> GetAllPets()
        {
            return _context.Pet.Include(pet => pet.petOwner);
        }

        [HttpGet("{id}")]
        public ActionResult<Pet> GetPetById(int id)
        {
            Pet petFound = _context.Pet
                .Include(pet => pet.petOwner)
                .SingleOrDefault(pet => pet.id == id);
            if (petFound is null)
                return NotFound();
            return petFound;
        }

        [HttpPost]
        public ActionResult<Pet> PostPet(Pet newPet)
        {
            _context.Add(newPet);
            _context.SaveChanges();
            return Created($"~/api/Pets/{newPet.id}", newPet);
        }

        [HttpPut("{id}")]
        public Pet UpdatePet(Pet petUpdate, int id)
        {
            _context.Update(petUpdate);
            _context.SaveChanges();
            return petUpdate;
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePet(int id)
        {
            Pet badPet = _context.Pet.Find(id);
            _context.Remove(badPet);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}/checkin")]
        public ActionResult<Pet> CheckinPet(int id)
        {
            Pet newPet = _context.Pet.Find(id);
            if (newPet.checkedInAt is null)
            {
                newPet.checkedInAt = DateTime.Now;
                _context.SaveChanges();
                return newPet;
            }
            else
                return BadRequest();
        }

        [HttpPut("{id}/checkout")]
        public ActionResult<Pet> CheckoutPet(int id)
        {
            Pet newPet = _context.Pet.Find(id);
            if (newPet.checkedInAt is null)
                return BadRequest();
            else
            {
                newPet.checkedInAt = null;
                _context.SaveChanges();
                return newPet;
            }
        }

        // [HttpGet]
        // [Route("test")]
        // public IEnumerable<Pet> GetPets() {
        //     PetOwner blaine = new PetOwner{
        //         name = "Blaine"
        //     };

        //     Pet newPet1 = new Pet {
        //         name = "Big Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Black,
        //         breed = PetBreedType.Poodle,
        //     };

        //     Pet newPet2 = new Pet {
        //         name = "Little Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Golden,
        //         breed = PetBreedType.Labrador,
        //     };

        //     return new List<Pet>{ newPet1, newPet2};
        // }
    }
}
