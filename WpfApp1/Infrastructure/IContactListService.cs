using WpfApp1.Models;

namespace WpfApp1.Infrastructure
{
    public interface IContactListService
    {
        List<Contact> OpenContactList();
        void SaveContactList(List<Contact> contacts);
    }
}