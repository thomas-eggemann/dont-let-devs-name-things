using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Infrastructure;
using WpfApp1.Models;
using WpfApp1.ViewModels;

namespace WpfApp1
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private readonly IContactListService contactListService;

        [ObservableProperty]
        private ObservableCollection<ContactViewModel> contactList;

        [ObservableProperty]
        private ContactViewModel? selectedContact;

        [ObservableProperty]
        private int selectedIndex;

        // Commands
        public ICommand NewContactCommand { get; }
        public ICommand DeleteSelectedContactCommand { get; }
        public ICommand OpenContactListCommand { get; }
        public ICommand SaveContactListCommand { get; }
        public ICommand CloseApplicationCommand { get; }

        public MainWindowViewModel(IContactListService contactListService)
        {
            this.contactListService = contactListService;
            this.NewContactCommand = new RelayCommand(AddNewContact);
            this.DeleteSelectedContactCommand = new RelayCommand(DeleteSelectedContact);
            this.OpenContactListCommand = new RelayCommand(OpenContactList);
            this.SaveContactListCommand = new RelayCommand(SaveContactList);
            this.CloseApplicationCommand = new RelayCommand(CloseApplication);
            this.ContactList = new ObservableCollection<ContactViewModel>();
        }

        private void AddNewContact()
        {
            var contactVM = new ContactViewModel();

            if (this.ContactList.Count == 0)
            {
                contactVM.Id = 1;
            }
            else
            {
                contactVM.Id = this.ContactList.Max(x => x.Id) + 1;
            }

            this.ContactList.Add(contactVM);
            this.SelectedContact = contactVM;
        }

        private void DeleteSelectedContact()
        {
            this.ContactList.RemoveAt(this.SelectedIndex);
            this.SelectedContact = null;
        }

        private void OpenContactList()
        {
            try
            {
                var contacts = this.contactListService.OpenContactList();
                this.ContactList = new ObservableCollection<ContactViewModel>(contacts.Select(x => new ContactViewModel(x)).ToList());
            }
            catch (Exception ex)
            {
                var errMessage = string.Format("An error occurred while reading the data: {0}", ex.ToString());
                MessageBox.Show(errMessage);
            }
        }

        private void SaveContactList()
        {
            try
            {
                this.contactListService.SaveContactList(this.ContactList.Select(x => x.ToContact()).ToList());
            }
            catch (Exception ex)
            {
                var errMessage = string.Format("An error occured while saving the data: {0}", ex.Message);
                MessageBox.Show(errMessage);
            }
        }

        private void CloseApplication()
        {
            App.Current.Shutdown();
        }
    }
}
