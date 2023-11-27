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
    /// Interaction logic for Deposit.xaml
    /// </summary>
    public partial class Deposit : Window
    {
        public Deposit()
        {
            InitializeComponent();
        }


        //calling objects
        DAO dao = new DAO();
        SqlDataAdapter da;
        DataTable dt;
        SqlDataReader dr;
        CollectionViewSource cs = new CollectionViewSource();
        string accNum;


        //calling the objects depending on user's choice, to open wish windows.
        private void _dNewAccount_Click(object sender, RoutedEventArgs e)
        {
            Registration r = new Registration();
            r.Show();
        }

        private void _dEditAccount_Click(object sender, RoutedEventArgs e)
        {
            EditAccounts ed = new EditAccounts();
            ed.Show();
        }

        private void _dDepositFunds_Click(object sender, RoutedEventArgs e)
        {
            Deposit dep = new Deposit();
            dep.Show();
        }

        private void _dWithdrawFunds_Click(object sender, RoutedEventArgs e)
        {
            Withdraw with = new Withdraw();
            with.Show();
        }

        private void _dTransferFunds_Click(object sender, RoutedEventArgs e)
        {
            Transfer tran = new Transfer();
            tran.Show();
        }

        private void _dViewTransactions_Click(object sender, RoutedEventArgs e)
        {
            AllTransactions allt = new AllTransactions();
            allt.Show();
        }

        //logout closes all windows
        private void _dLogOut_Click(object sender, RoutedEventArgs e)
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

        private void _dExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        //method to get balance and also gets using stored procedure//I also had to set the amount to divided by 100 because all the values are stored as cents.
        //in order to display the current amount in decimal I need to divide.
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
                string fn = dr["Firstname"].ToString();
                string sn = dr["Surname"].ToString();
                string cy = dr["County"].ToString();
                decimal initialBalEur = balx / 100.0m;
                textDepositCurrent.Text = initialBalEur.ToString("N2");
                lblDisplayName.Content = fn + " " + sn + " From " + cy;
            }
            dao.CloseCon();


        }

        private void DepositWindow_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateCombo();
        }


        //method to populate combobox.
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


        //btn deposit uses also stored procedure to update the balance
        //I had to convert everything because it is stored in cents but displays in decimal and also when it is stored again, it is stored in cents.
        //then I need to multiply by 100.
        private void btnDeposit_Click(object sender, RoutedEventArgs e)
        {
            accNum = cboAccounts.SelectedItem.ToString();
            decimal amount = decimal.Parse(txtDepositAmount.Text);
            decimal bal = decimal.Parse(textDepositCurrent.Text);
            decimal overdraftLimit = 0;
            decimal newBalance = (bal + overdraftLimit) + amount;
            


            SqlCommand cmd = dao.OpenCon().CreateCommand();
            cmd.CommandText = "uspUpdateBalance";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("ovl", overdraftLimit);
            cmd.Parameters.AddWithValue("nb", newBalance * 100);
            cmd.Parameters.AddWithValue("accno", accNum);

            cmd.ExecuteNonQuery();
            dao.CloseCon();

            textDepositCurrent.Clear();
            txtDepositAmount.Clear();


            MessageBox.Show("Your deposit was successfull and you balance should update in a few seconds ;D! ");
            Deposit dep = new Deposit();
            dep.Show();

        }

        private void cboAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetBalance();
        }
    }
}
