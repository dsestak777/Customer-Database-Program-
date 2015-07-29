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
    /// Interaction logic for EditRecord.xaml
    /// </summary>
    public partial class EditRecord : Window
    {
        //create a customer object
        Customer customer;

        public EditRecord(Customer cust)
        {
            InitializeComponent();
            //asign cust to customer object
            this.customer = cust;

            //put customer data into form fields
            ID.Text = customer.CustomerID;
            CompanyName.Text = customer.CompanyName;
            ContactName.Text = customer.ContactName;
            ContactTitle.Text = customer.ContactTitle;
            Country.Text = customer.Country;
            City.Text = customer.City;
            Region.Text = customer.Region;
            PostalCode.Text = customer.PostalCode;
            Address.Text = customer.Address;
            Phone.Text = customer.Phone;
            Fax.Text = customer.Fax;

        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            
            // Add the record to the datbase 

            // Create an instance of a data connection to the database customer table 
            CustomerDataDataContext con = new CustomerDataDataContext();


            Customer cust = con.Customers.Single(u => u.CustomerID == customer.CustomerID);
         //   cust.CustomerID = ID.Text.Trim();
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

            

            // submit changes record to the database 
            con.SubmitChanges();

            //show sucess message
            MessageBox.Show("Customer " + cust.CustomerID + " Was edited ok");

            //update display grid to show changes
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
