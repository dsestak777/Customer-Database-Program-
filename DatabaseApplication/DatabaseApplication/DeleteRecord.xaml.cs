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
    /// Interaction logic for DeleteRecord.xaml
    /// </summary>
    public partial class DeleteRecord : Window
    {
        public DeleteRecord()
        {
            InitializeComponent();
         

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            // Close the add window 
            DialogResult = false;
            
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

         /**   Customer remove = new Customer();

            String CustID = DeleteID.Text.Trim();

            // Create an instance of a data connection to the database customer table 
            CustomerDataDataContext con = new CustomerDataDataContext();


           
                 remove = (from cust in con.Customers
                                   where (cust.CustomerID == CustID)
                                   //   select cust).SingleOrDefault();
                                   select cust).FirstOrDefault();


                 if (object.Equals(remove, default(Customer)))
               //  if (remove == null)
                 {
                     MessageBox.Show("Customer Does not Exist!");
                 }
                 else
                 {

                     // delete record from the database 
                     con.Customers.DeleteOnSubmit(remove);
                     con.SubmitChanges();

                     MessageBox.Show("Customer " + CustID + " Was Deleted ok");
                 }
                Application app = Application.Current;
                MainWindow main = (MainWindow)app.MainWindow;
                main.refreshGrid();
                DialogResult = true;

            **/

            String CustID = DeleteID.Text.Trim();

            try
            {
                using (CustomerDataDataContext con = new CustomerDataDataContext())
                {
                    //get customer that match matches ID from customer table
                    var q =
                        (from c in con.GetTable<Customer>()
                         where c.CustomerID == CustID
                         select c).Single<Customer>();

                    //get all orders from Order that include customer ID
                    foreach (Order ord in q.Orders)
                    {
                        //loop through order and mark for deletion records with matching customer
                        con.GetTable<Order>().DeleteOnSubmit(ord);

                        //loop through order details and mark for deletion records with matching order
                        foreach (Order_Detail od in ord.Order_Details)
                        {
                            con.GetTable<Order_Detail>().DeleteOnSubmit(od);
                        }
                    }

                    //delete matching customer entry
                    con.GetTable<Customer>().DeleteOnSubmit(q);
                    con.SubmitChanges();

                    MessageBox.Show("Customer " + CustID + " Was Deleted ok");
                }

                //refresh display grid to show changes
                Application app = Application.Current;
                MainWindow main = (MainWindow)app.MainWindow;
                main.refreshGrid();
                DialogResult = true;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
            
    }


}
