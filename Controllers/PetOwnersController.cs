using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<PetOwner> GetPetOwners (){ 
            return _context.PetOwner; 
        }
        
        [HttpGet("{id}")]
        public ActionResult<PetOwner> GetPetOwnerById (int id){ 
            PetOwner petowner = _context.PetOwner.FirstOrDefault(petowner => petowner.id == id);
            
            if (petowner is null){ 
                return NotFound();
            }

            return petowner;
        }

        [HttpPost]
        public PetOwner Post(PetOwner petowner)
        {
            _context.Add(petowner);
            _context.SaveChanges();
            return petowner;
        }


        [HttpDelete("{id}")]
        public PetOwner DeletePetOwner(int id)
        {

            PetOwner removeOwner = _context.PetOwner.Find(id);
            _context.Remove(removeOwner);
            _context.SaveChanges();
            return removeOwner;
        }
        [HttpPut("{id}")]
        public PetOwner UpdatePetOwner(PetOwner petOwnerUpdate, int id)
        {
            _context.Update(petOwnerUpdate);
            _context.SaveChanges();
            return petOwnerUpdate;
        }




        
        // [HttpGet]
        // public IEnumerable<PetOwner> GetPets() {
        //     return new List<PetOwner>();
        // }
    }
}
