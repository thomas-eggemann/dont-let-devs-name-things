using System.Runtime;

namespace WpfApp1.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Phonenumber { get; set; } = string.Empty;
        public DateTimeOffset? DateOfBirth { get; set; } = null;
        public string Email { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Housenumber { get; set; } = string.Empty;
    }
}