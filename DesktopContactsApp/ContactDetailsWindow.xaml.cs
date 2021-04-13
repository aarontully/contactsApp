using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DesktopContactsApp.Classes;
using SQLite;

namespace DesktopContactsApp
{
    public partial class ContactDetailsWindow : Window
    {
        Contact contact;
        public ContactDetailsWindow(Contact contact)
        {
            InitializeComponent();

            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;

            this.contact = contact;
            nameTextBox.Text = contact.Name;
            phoneTextBox.Text = contact.Phone;
            emailTextBox.Text = contact.Email;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

            contact.Name = nameTextBox.Text;
            contact.Phone = phoneTextBox.Text;
            contact.Email = emailTextBox.Text;

            using(SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Update(contact);
            };

            Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            using(SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Delete(contact);
            };

            Close();
        }
    }
}
