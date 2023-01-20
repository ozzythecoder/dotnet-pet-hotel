using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace pet_hotel
{

    public enum actionType {
        Checkin,
        Checkout,
        CreatedPet,
        DeletedPet,
        CreatedOwner,
        DeletedOwner
    }

    public class Transaction
    {
        public int id {get; set;}
        public DateTime timestamp {get; set;}
        public actionType actionType {get; set;}

        [ForeignKey("pet")]
        public int? petId {get; set;}

        [ForeignKey("owner")]
        public int? ownerId {get; set;}
    }
}
