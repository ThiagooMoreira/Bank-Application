using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace OOP___CA2_Final
{
    /// <summary>
    /// Interaction logic for Withdraw.xaml
    /// </summary>
    public partial class Withdraw : Window
    {
        public Withdraw()
        {
            InitializeComponent();
        }

        
        //calling the objects
        DAO dao = new DAO();
        SqlDataAdapter da;
        DataTable dt;
        SqlDataReader dr;
        CollectionViewSource cs = new CollectionViewSource();
        string accNum;



        //open or closes windows depending on user's choice.
        private void _wiNewAccount_Click(object sender, RoutedEventArgs e)
        {
            
            Registration r = new Registration();
            r.Show();
        }

        private void _wiEditAccount_Click(object sender, RoutedEventArgs e)
        {
            
            EditAccounts ed = new EditAccounts();
            ed.Show();
        }

        private void _wiDepositFunds_Click(object sender, RoutedEventArgs e)
        {

            Deposit dep = new Deposit();
            dep.Show();
        }

        public void _wiWithdrawFunds_Click(object sender, RoutedEventArgs e)
        {
            Withdraw with = new Withdraw();
            with.Show();
        }

        private void _wiTransferFunds_Click(object sender, RoutedEventArgs e)
        {
            Transfer tran = new Transfer();
            tran.Show();
        }

        private void _wiViewTransactions_Click(object sender, RoutedEventArgs e)
        {
            AllTransactions allt = new AllTransactions();
            allt.Show();
        }

        //logout and allowing a new user to login.
        private void _wiLogOut_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thanks for using our systems! ");
            foreach (Window window in Application.Current.Windows)
            {
                if (window != Application.Current.MainWindow)
                {
                    window.Close();
                }
            }
            this.Close();
        }


        //closes everything and stops the application
        private void _wiExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        //populates information.
        private void WithdrawWindow_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateCombo();
        }
        void PopulateCombo()
        {
            SqlCommand cmd = dao.OpenCon().CreateCommand();
            cmd.CommandText = "uspPopCombo";
            cmd.CommandType = CommandType.StoredProcedure;

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string act = dr["AccountNumber"].ToString();
                cboAccounts.Items.Add(act);

            }
            dao.CloseCon();
        }

        //gets balance using store procedure SelBalance and I need to divide by 100 because the amount previously stored was in cents.
        void GetBalance()
        {
            accNum = cboAccounts.SelectedItem.ToString();

            SqlCommand cmd = dao.OpenCon().CreateCommand();
            cmd.CommandText = "uspSelBalance";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@accno", accNum);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int balx = Convert.ToInt32(dr["InitialBalance"]);
                int overd = Convert.ToInt32(dr["OverdraftLimit"]);
                string fn = dr["Firstname"].ToString();
                string sn = dr["Surname"].ToString();
                string cy = dr["County"].ToString();
                decimal initialBalEur = balx / 100.0m;
                decimal OverdraftEur = overd / 100.0m;
                txtWithCurrent.Text = initialBalEur.ToString("N2");
                txtoverdl.Text = OverdraftEur.ToString("N2");
                txttotalavl.Text = (initialBalEur + OverdraftEur).ToString("N2");
                lblDisplayName.Content = fn + " " + sn + " From " + cy;
            }
            dao.CloseCon();


        }

        //it debits the wish account and stores the new balance in cents again
        private void btnWithdraw_Click(object sender, RoutedEventArgs e)
        {
            accNum = cboAccounts.SelectedItem.ToString();
            decimal amount = decimal.Parse(txtWithAmount.Text);
            decimal overdraftLimit = decimal.Parse(txtoverdl.Text);
            decimal bal = decimal.Parse(txtWithCurrent.Text);
            decimal newBalance = (bal + overdraftLimit) - amount;


            SqlCommand cmd = dao.OpenCon().CreateCommand();
            cmd.CommandText = "uspUpdateBalance";
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("ovl", overdraftLimit);
            cmd.Parameters.AddWithValue("nb", newBalance * 100);
            cmd.Parameters.AddWithValue("accno", accNum);
            cmd.ExecuteNonQuery();
            dao.CloseCon();


            txtWithCurrent.Clear();
            txtWithAmount.Clear();
            GetBalance();

            MessageBox.Show("Your Withdraw was successfull! ");
            Withdraw with = new Withdraw();
            with.Show();
        }


        //get balance
        private void cboAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetBalance();
        }
    }
}
