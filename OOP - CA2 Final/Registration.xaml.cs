using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
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

namespace OOP___CA2_Final
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        //calling the objects
        NewAccount acca = new NewAccount();
        DAO dao = new DAO();
        SqlDataAdapter da;
        DataTable dt;
        SqlDataReader dr;
        CollectionViewSource cs = new CollectionViewSource();
        


        
        private void _rLogOut_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _rExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        //button submit is clicked then the data is stored in the database.
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string fn = txtFN.Text;
            string sn = txtSn.Text;
            string email = txtEmail.Text;
            string pnumber = txtPhoneNo.Text;
            string address1 = txtAddress01.Text;
            string address2 = txtAddress02.Text;
            string city = txtCity.Text;
            string county = cboCounty.Text;
            string acctype = "Savings-Account";
            
            //to define account type
            if (rdoCurrent.IsChecked == true)
            {

                acctype = "Current-Account";

            }
            
            //to be able to store the amount inserted in cents in the databasewwwwww
            int initbal = (int)Convert.ToInt32(txtInitBal.Text) * 100;
            int overd = (int)Convert.ToInt32(txtOverdraft.Text) * 100;
            
            
            //uses the Add account in order to store the correct information in the database
            acca.AddAccount(fn, sn, email, pnumber, address1, address2, city, county, acctype, initbal, overd);

            //clear everything
            rdoCurrent.IsChecked = false;
            rdoSavings.IsChecked = false;
            txtFN.Clear();
            txtSn.Clear();
            txtEmail.Clear();
            txtPhoneNo.Clear();
            txtAddress01.Clear();
            txtAddress02.Clear();
            txtCity.Clear();
            txtInitBal.Clear();
            txtOverdraft.Clear();

            //displays a message
            MessageBox.Show("Your Account has been successfully added! ");

            foreach (Window window in Application.Current.Windows)
            {
                if (window != Application.Current.MainWindow)
                {
                    window.Close();
                }
            }
            this.Close();

        }

        //shows or closes windows depending on user's choice
        private void _rLogin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();


        }

        private void _rNewAccount_Click(object sender, RoutedEventArgs e)
        {
            Registration r = new Registration();
            r.Show();

        }

        private void _rEditAccount_Click(object sender, RoutedEventArgs e)
        {
            EditAccounts ed = new EditAccounts();
            ed.Show();
        }

        private void _rDepositFunds_Click(object sender, RoutedEventArgs e)
        {
            Deposit dep = new Deposit();
            dep.Show();
        }

        private void _rWithdrawFunds_Click(object sender, RoutedEventArgs e)
        {
            Withdraw with = new Withdraw();
            with.Show();
        }

        private void _rTransferFunds_Click(object sender, RoutedEventArgs e)
        {
            Transfer tran = new Transfer();
            tran.Show();
        }

        private void _rViewTransactions_Click(object sender, RoutedEventArgs e)
        {
            AllTransactions allt = new AllTransactions();
            allt.Show();
        }

        private void menuAccr_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cboCounty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {

        }

        //when the window opens, then populate combobox.
        private void RegistrationWindow_Loaded(object sender, RoutedEventArgs e)
        {
            cboCounty.ItemsSource = Enum.GetValues(typeof(County));
            PopulateCombo();
        }


        //if radio button is checked then it asks the user to input a value
        private void rdoCurrent_Checked(object sender, RoutedEventArgs e)
        {
            if (rdoCurrent.IsChecked == true && string.IsNullOrEmpty(txtOverdraft.Text.Trim()) || Convert.ToDecimal(txtOverdraft.Text) <= 0)
            {
                MessageBox.Show("You must set an Overdraft amount");
                txtOverdraft.Focus();
            }

        }


        //just to make sure the user will not add any value.
        private void rdoSavings_Checked(object sender, RoutedEventArgs e)
        {

            txtOverdraft.IsReadOnly = true;
            txtOverdraft.Text = "0";
        }

        private void txtAccNo_Loaded(object sender, RoutedEventArgs e)
        {

        }

        //method to populate combo box with account number then get the informations
        void PopulateCombo()
        {
            SqlCommand cmd = dao.OpenCon().CreateCommand();
            cmd.CommandText = "uspPopCombo";
            cmd.CommandType = CommandType.StoredProcedure;

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string accn = dr["AccountNumber"].ToString();
                txtAccNo.Text = accn;

            }
            dao.CloseCon();
        }
    }
}
