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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DatabaseApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            // Create an instance of a data connection to the database customer    
            // table 
            CustomerDataDataContext con = new CustomerDataDataContext();

            // Create a customer list 
            List<Customer> customers = (from c in con.Customers
                                        select c).ToList();
            CustomerDataGrid.ItemsSource = customers;


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            //close the application
            Application.Current.Shutdown();
        }

        private void AddRecord_Click(object sender, RoutedEventArgs e)
        {
            //open the add record dialog
            AddRecord addRecordWindow = new AddRecord();
            addRecordWindow.ShowDialog();

        }

        private void DeleteRecord_Click(object sender, RoutedEventArgs e)
        {
            //get selected customer ID
            Customer customer = (Customer)CustomerDataGrid.SelectedItem;

            String CustID="";

            //check to see if customer has been selected
            if (customer != null)
            {
                CustID = customer.CustomerID;

                //open the delete record pop up window
                DeleteRecord deleteRecordWindow = new DeleteRecord();
                deleteRecordWindow.DeleteID.Text = CustID;
                deleteRecordWindow.ShowDialog();
            }
            else
            {
                //no cutomer has been selected
                MessageBox.Show("Please select a customer to delete!");
               
            }    

        }


        private void EditRecord_Click(object sender, RoutedEventArgs e)
        {

             //get selected customer ID
            Customer customer = (Customer)CustomerDataGrid.SelectedItem;

            String CustID="";

            //check to see if customer has been selected
            if (customer != null)
            {
                CustID = customer.CustomerID;


                //open the edit record pop up window
                FindEditRecord findEditRecordWindow = new FindEditRecord();
                findEditRecordWindow.FindID.Text = CustID;
                findEditRecordWindow.ShowDialog();
            }
            else
            {

                //no cutomer has been selected
                MessageBox.Show("Please select a customer to edit!");
            }

        }

        public void refreshGrid()
        {

            // Create an instance of a data connection to the database customer    
            // table 
            CustomerDataDataContext con = new CustomerDataDataContext();

            // Create a customer list 
            List<Customer> customers = (from c in con.Customers
                                        select c).ToList();
            CustomerDataGrid.ItemsSource = customers;

           


        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            //open the help window dialog
            Help helpWindow = new Help();
            helpWindow.ShowDialog();

        }

       
    }
}
