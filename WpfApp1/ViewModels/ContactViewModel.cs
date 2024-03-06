using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public partial class ContactViewModel : ObservableObject
    {
        [ObservableProperty]
        private int id;
        [ObservableProperty]
        private string firstname = string.Empty;
        [ObservableProperty]
        private string lastname = string.Empty;
        [ObservableProperty]
        private DateTime? dateOfBirth = null;
        [ObservableProperty]
        private string email = string.Empty;
        [ObservableProperty]
        private string phonenumber = string.Empty;
        [ObservableProperty]
        private string country = string.Empty;
        [ObservableProperty]
        private string zipCode = string.Empty;
        [ObservableProperty]
        private string city = string.Empty;
        [ObservableProperty]
        private string street = string.Empty;
        [ObservableProperty]
        private string housenumber = string.Empty;

        public ContactViewModel()
        {
        }

        public ContactViewModel(Contact contact)
        {
            this.Id = contact.Id;
            this.Firstname = contact.Firstname;
            this.Lastname = contact.Lastname;
            this.DateOfBirth = contact.DateOfBirth?.DateTime;
            this.Email = contact.Email;
            this.Phonenumber = contact.Phonenumber;
            this.Country = contact.Country;
            this.ZipCode = contact.ZipCode;
            this.City = contact.City;
            this.Street = contact.Street;
            this.housenumber = contact.Housenumber;
        }

        public Contact ToContact()
        {
            return new Contact()
            {
                Id = this.Id,
                Firstname = this.Firstname,
                Lastname = this.Lastname,
                DateOfBirth = this.DateOfBirth,
                Email = this.Email,
                Phonenumber = this.Phonenumber,
                Country = this.Country,
                ZipCode = this.ZipCode,
                City = this.City,
                Street = this.Street,
                Housenumber = this.Housenumber
            };
        }
    }
}
