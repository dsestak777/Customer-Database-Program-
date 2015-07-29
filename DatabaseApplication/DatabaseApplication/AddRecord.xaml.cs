using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DatabaseApplication
{
    /// <summary>
    /// Interaction logic for AddRecord.xaml
    /// </summary>
    public partial class AddRecord : Window
    {
        public AddRecord()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            
            // Add the record to the datbase 

            // The ID must be unique and specified or do not proceed with the add 
            if (ID.Text.Trim() == "")
            {
                MessageBox.Show("Missing unique customer ID", "Entry error",
                       MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }
            
            // Add the record 
            Customer cust = new Customer();
            cust.CustomerID = ID.Text.Trim();
            cust.CompanyName = CompanyName.Text.Trim();
            cust.ContactName = ContactName.Text.Trim();
            cust.ContactTitle = ContactTitle.Text.Trim();
            cust.Country = Country.Text.Trim();
            cust.City = City.Text.Trim();
            cust.Region = Region.Text.Trim();
            cust.PostalCode = PostalCode.Text.Trim();
            cust.Address = Address.Text.Trim();
            cust.Phone = Phone.Text.Trim();
            cust.Fax = Fax.Text.Trim();

            // Create an instance of a data connection to the database customer table 
            CustomerDataDataContext con = new CustomerDataDataContext();

            // Add new record to the database 
            con.Customers.InsertOnSubmit(cust);
            con.SubmitChanges();


            MessageBox.Show("Customer " + cust.CustomerID + " Was added ok");

            //refresh the display grid to show changes
            Application app = Application.Current;
            MainWindow main = (MainWindow) app.MainWindow;
            main.refreshGrid();
            DialogResult = true;
	        }

   
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            // Close the add window 
            DialogResult = false;

        }
    }
}
