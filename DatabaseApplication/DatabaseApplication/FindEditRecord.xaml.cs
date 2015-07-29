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
    /// Interaction logic for FindEditRecord.xaml
    /// </summary>
    public partial class FindEditRecord : Window
    {
        public FindEditRecord()
        {
            InitializeComponent();
        }

       

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            // Close the find edit window 
            DialogResult = false;
        }

       

        private void FindRecord_Click(object sender, RoutedEventArgs e)
        {
            //create a new empty customer object
            Customer find = new Customer();

            //get customer ID from form
            String CustID = FindID.Text.Trim();

            // Create an instance of a data connection to the database customer table 
            CustomerDataDataContext con = new CustomerDataDataContext();

            //find customer based upod ID 
            find = (from cust in con.Customers
                      where (cust.CustomerID == CustID)
                      select cust).FirstOrDefault();

            //if a matching customer is not found
            if (object.Equals(find, default(Customer)))
            
            {
                MessageBox.Show("Customer Does not Exist!");
            }
            //if found proceed
            else
            {
                // Close the find edit window 
                DialogResult = false;

                //open the edit record window
                EditRecord editRecordWindow = new EditRecord(find);
                editRecordWindow.ShowDialog();

               

            }

         

        }
    }
}
