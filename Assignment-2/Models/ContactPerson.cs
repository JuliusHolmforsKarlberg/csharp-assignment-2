using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.Models
{
    // This method creates the contact persons' structure and a personal Guid Id for every instance (every new ContactPerson).
    public class ContactPerson
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string StreetName { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string? City { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }
}
