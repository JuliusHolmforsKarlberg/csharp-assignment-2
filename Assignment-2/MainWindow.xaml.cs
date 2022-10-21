using Assignment_2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Assignment_2.AddressBook
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<ContactPerson> contacts; // List of contacts.

        public MainWindow()
        {
            InitializeComponent();
            contacts = new ObservableCollection<ContactPerson>();
            lv_Contacts.ItemsSource = contacts; // Gathers the information from the contact list.
        }

        public void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            // This method adds a new ContactPerson, if the email already exists show message box.
            var contact = contacts.FirstOrDefault(x => x.Email == tb_Email.Text);
            if (contact == null) // Adds the contact if the Email is unique.
            {
                contacts.Add(new ContactPerson
                {
                    FirstName = tb_FirstName.Text,
                    LastName = tb_LastName.Text,
                    Email = tb_Email.Text,
                    StreetName = tb_StreetName.Text,
                    PostalCode = tb_PostalCode.Text,
                    City = tb_City.Text
                });
            }
            else
            {
                MessageBox.Show("There is already a contact with the same e-mail address."); // Ger ut ett felmeddelande ut om e-posten redan existerar.
            }

            ClearFields();
        }

        public void ClearFields()
        {
            // This method cleans up the formular about the contact.
            tb_FirstName.Text = "";
            tb_LastName.Text = "";
            tb_Email.Text = "";
            tb_StreetName.Text = "";
            tb_PostalCode.Text = "";
            tb_City.Text = "";
        }

        public void btn_Remove_Click(object sender, RoutedEventArgs e) // Fucntion to remove a contact.
        {
            try // Trying to remove a contact.
            {
                // This method makes a click on the button remove a contact.
                var button = sender as Button;
                var contact = (ContactPerson)button!.DataContext;

                contacts.Remove(contact);
            }
            catch { } // If it doesn't work save the file.
        }

        public void lv_Contacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try // Trying to show the list containing all the contacts saved in the application and in case you remove all the contacts the program doesn't crash.
            {
                // This method takes out the object (ContactPerson) and gives the information.
                var contact = (ContactPerson)lv_Contacts.SelectedItems[0]!;
                tb_FirstName.Text = contact.FirstName;
                tb_LastName.Text = contact.LastName;
                tb_Email.Text = contact.Email;
                tb_StreetName.Text = contact.StreetName;
                tb_PostalCode.Text = contact.PostalCode;
                tb_City.Text = contact.City;
            }
            catch { } // If it doesn't work, do nothing.

        }
    }
}
