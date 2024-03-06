using Microsoft.Extensions.Options;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;
using WpfApp1.Infrastructure;
using WpfApp1.Models;
using WpfApp1.Options;

namespace WpfApp1.Services
{
    internal class LocalContactsService : IContactListService
    {
        private readonly ContactListOptions opt;

        public LocalContactsService(IOptions<ContactListOptions> opt)
        {
            this.opt = opt.Value;
        }

        public List<Contact> OpenContactList()
        {
            if (!File.Exists(opt.FilePath))
            {
                throw new FileNotFoundException(string.Format("The file '{0}' could not be found.", opt.FilePath));
            }

            var jsonContent = File.ReadAllText(opt.FilePath);
            if (string.IsNullOrWhiteSpace(jsonContent))
            {
                return new List<Contact>();
            }

            return JsonSerializer.Deserialize<List<Contact>>(jsonContent) ?? new List<Contact>();
        }

        public void SaveContactList(List<Contact> contacts)
        {
            var jsonContent = JsonSerializer.Serialize(contacts);

            if (!File.Exists(opt.FilePath))
            {
                File.Create(opt.FilePath).Close();
            }

            File.WriteAllText(opt.FilePath, jsonContent, Encoding.UTF8);
        }
    }
}