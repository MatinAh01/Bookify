using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookify.domain.Abstractions;

namespace Bookify.domain.Apartments
{
    public sealed class Apartment : Entity
    {
        public Name Name { get; private set; }
        public Description Description { get; private set; }
        public Address Address { get; private set; }
        public Money Price { get; private set; }
        public Money CleaningFee { get; private set; }
        public DateTime? LastBookedOnUtc { get; private set; }
        public List<Amenities> Amenities { get; private set; } = [];
        public Apartment
        (
            Guid id,
            Name name,
            Description description,
            Address address,
            Money price,
            Money cleaningFee,
            List<Amenities> amenities
        ) : base(id)
        {
            Name = name;
            Description = description;
            Address = address;
            Price = price;
            CleaningFee = cleaningFee;
            Amenities = amenities;
        }
    }
}