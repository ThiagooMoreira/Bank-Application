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
    /// Interaction logic for Transfer.xaml
    /// </summary>
    public partial class Transfer : Window
    {
        public Transfer()
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
        string accNum2;
        string accNum3;


        //opens or closes depending on user's choice.
        private void _tNewAccount_Click(object sender, RoutedEventArgs e)
        {
            Registration r = new Registration();
            r.Show();
        }

        private void _tEditAccount_Click(object sender, RoutedEventArgs e)
        {
            EditAccounts ed = new EditAccounts();
            ed.Show();
        }
    

        private void _tDepositFunds_Click(object sender, RoutedEventArgs e)
        {
            Deposit dep = new Deposit();
            dep.Show();
        }

        private void _tWithdrawFunds_Click(object sender, RoutedEventArgs e)
        {
            Withdraw with = new Withdraw();
            with.Show();
        }

        private void _tTransferFunds_Click(object sender, RoutedEventArgs e)
        {
            Transfer tran = new Transfer();
            tran.Show();
        }

        private void _tViewTransactions_Click(object sender, RoutedEventArgs e)
        {
            AllTransactions allt = new AllTransactions();
            allt.Show();
        }

        //logout closes everything
        private void _tLogOut_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window != Application.Current.MainWindow)
                {
                    window.Close();
                }
            }
            this.Close();
            
        }

        private void _tExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void txtTransferAccNo__TextChanged()
        {

        }

        //method populate combo
        void PopulateCombo()
        {
            string accountType = rdoSavingsYes.IsChecked == true ? "Savings-Account" : "Current-Account";

            SqlCommand cmd = dao.OpenCon().CreateCommand();
            cmd.CommandText = "uspAccType";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@acctype", accountType);

            dr = cmd.ExecuteReader();
            cboAccounts.Items.Clear();

            while (dr.Read())
            {
                string acc = dr["AccountNumber"].ToString();
                cboAccounts.Items.Add(acc);

            }
            dao.CloseCon();
        }

        //popoulate combo2 is used to show either savings or current account .
        void PopulateCombo2()
        {
            string acctype = rdotransfSavings.IsChecked == true ? "Savings-Account" : "Current-Account";

            SqlCommand cmd = dao.OpenCon().CreateCommand();
            cmd.CommandText = "uspAccType";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@acctype", acctype);

            dr = cmd.ExecuteReader();
            cboAccTo.Items.Clear();

            while (dr.Read())
            {
                string acct = dr["AccountNumber"].ToString();
                cboAccTo.Items.Add(acct);

            }
            dao.CloseCon();
        }
        

       
        //method to get balance using account number
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
                //I need to convert the value before stored in cents then divide by 100 to display in euro.
                int balx = Convert.ToInt32(dr["InitialBalance"]);
                int overd = Convert.ToInt32(dr["OverdraftLimit"]);
                string fn = dr["Firstname"].ToString();
                string sn = dr["Surname"].ToString();
                string cy = dr["County"].ToString();
                decimal initialBalEur = balx / 100.0m;
                decimal OverdraftEur = overd / 100.0m;
                lblBalFrom.Content = initialBalEur.ToString("N2");
                lblOverdraft.Content = OverdraftEur.ToString("N2");
                lblTotal.Content = (initialBalEur + OverdraftEur).ToString("N2");

                lblDisplayName.Content = fn + " " + sn + " From " + cy;
            }
            dao.CloseCon();


        }

        void GetBalance2()
        {
            accNum2 = cboAccTo.SelectedItem.ToString();
            SqlCommand cmd = dao.OpenCon().CreateCommand();
            cmd.CommandText = "uspSelBalance";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@accno", accNum2);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ////I need to convert the value before stored in cents then divide by 100 to display in euro.
                int balx = Convert.ToInt32(dr["InitialBalance"]);
                string fn = dr["Firstname"].ToString();
                string sn = dr["Surname"].ToString();
                string cy = dr["County"].ToString();
                decimal initialBalEur = balx / 100.0m;
                lblBalTo.Content = initialBalEur.ToString("N2");
                txtAccHolder.Text = fn + " " + sn;
                
            }
            dao.CloseCon();


        }

        //method to get the funds from the selection and update balance using stored procedure
        void FundsFrom()
        {
            accNum = cboAccounts.SelectedItem.ToString();
            decimal amount = decimal.Parse(txtTransferTo.Text);
            decimal bal = decimal.Parse(lblBalFrom.Content.ToString());
            decimal overdraftLimit = decimal.Parse(lblOverdraft.Content.ToString());
            decimal newBalance = (bal + overdraftLimit) - amount;

            SqlCommand cmd = dao.OpenCon().CreateCommand();
            cmd.CommandText = "uspUpdateBalance";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("ovl", overdraftLimit);
            cmd.Parameters.AddWithValue("nb", newBalance * 100);
            cmd.Parameters.AddWithValue("accno", accNum);

            cmd.ExecuteNonQuery();
            dao.CloseCon();

     
        }

        //method to send funds to wish selection and also update balance using stored procedure
        void FundsTo()
        {
            accNum2 = cboAccTo.SelectedItem.ToString();
            decimal amount = decimal.Parse(txtTransferTo.Text);
            decimal bal = decimal.Parse(lblBalTo.Content.ToString());
            decimal overdraftLimit = decimal.Parse(lblOverdraft.Content.ToString());
            decimal newBalance = (bal + overdraftLimit) + amount;


            SqlCommand cmd = dao.OpenCon().CreateCommand();
            cmd.CommandText = "uspUpdateBalance";
            cmd.CommandType = CommandType.StoredProcedure;

            
            cmd.Parameters.AddWithValue("ovl", overdraftLimit);
            cmd.Parameters.AddWithValue("nb", newBalance * 100);
            cmd.Parameters.AddWithValue("accno", accNum2);
            cmd.ExecuteNonQuery();
            dao.CloseCon();
        }

        //funds to other bank, it works similarly to withdraw, it only charges the wish account and updates the balance
        void FundsOther()
        {
            accNum3 = cboAccounts.SelectedItem.ToString();
            
            decimal amount = decimal.Parse(txtTransferTo.Text);
            decimal bal = decimal.Parse(lblBalFrom.Content.ToString());
            decimal overdraftLimit = decimal.Parse(lblOverdraft.Content.ToString());
            decimal newBalance = (bal + overdraftLimit) - amount;


            SqlCommand cmd = dao.OpenCon().CreateCommand();
            cmd.CommandText = "uspUpdateBalance";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("ovl", overdraftLimit);
            cmd.Parameters.AddWithValue("nb", newBalance * 100);
            cmd.Parameters.AddWithValue("accno", accNum3);

            cmd.ExecuteNonQuery();
            dao.CloseCon();
        }

        //populates information when the window is loaded.
        private void TransferWindow_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateCombo();
            PopulateCombo2();
        }

        //get balance method
        private void cboAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetBalance();
        }
        //get balance method
        private void cboTo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetBalance2();
        }
        //if other radio button is checked just to block user's selection
        private void rdoOtherBank_Checked(object sender, RoutedEventArgs e)
        {
            cboAccTo.IsEnabled = false;
            btnTransfer.IsEnabled = false;
            

        }
        //if savings checked then make somethins enable or disabled.
        private void rdotransfSavings_Checked(object sender, RoutedEventArgs e)
        {
            cboAccTo.IsEnabled = true;
            txtTransferAccNo_.IsEnabled = false;
            PopulateCombo2();
            
        }
        //is radiobutton current check make cbo box enable and populates combo 2.
        private void rdotransfCurrent_Checked(object sender, RoutedEventArgs e)
        {
            cboAccTo.IsEnabled = true;
            txtTransferAccNo_.IsEnabled = false;
            PopulateCombo2();
        }

        //btn transfer clicks then call methods funds from and funds to and clear out everything and displays a message
        //also opens a new window if the user want to transfer again
        private void btnTransfer_Click(object sender, RoutedEventArgs e)
        {
            FundsFrom();
            FundsTo();
            rdoSavingsNo.IsChecked = false;
            rdoSavingsYes.IsChecked = false;
            txtTransferTo.Clear();
            lblBalFrom.Content = "";
            lblBalTo.Content = "";
            MessageBox.Show("Your transfer was successful and the destination account should be credited within a few seconds ;D! ");
            Transfer tran = new Transfer();
            tran.Show();


        }
        //rdo savings checked then make somethings available.
        private void rdoSavingsYes_Checked(object sender, RoutedEventArgs e)
        {
            rdotransfSavings.IsEnabled = true;
            rdotransfCurrent.IsEnabled = false;
            rdoOtherBank.IsEnabled = false;
            btnout.IsEnabled = false;
            PopulateCombo();
            
            
            
            
        }
        //rdo current checked then make somethings available.
        private void rdoSavingsNo_Checked(object sender, RoutedEventArgs e)
        {
            rdotransfSavings.IsEnabled = true;
            rdotransfCurrent.IsEnabled = true;
            rdoOtherBank.IsEnabled = true;
            btnout.IsEnabled = true;
            PopulateCombo();


        }

        private void txtTransferAccNo__TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        //btn to transfer to another account outside the dbs bank.
        private void btnout_Click(object sender, RoutedEventArgs e)
        {
            FundsFrom();
            FundsOther();
            rdoSavingsNo.IsChecked = false;
            rdoSavingsYes.IsChecked = false;
            txtTransferAccNo_.Clear();
            txtAccHolder.Clear();
            txtTransferTo.Clear();
            lblBalFrom.Content = "";
            lblBalTo.Content = "";
            MessageBox.Show("Your transfer was successful and the destination account should be credited within a few seconds ;D! ");
            Transfer tran = new Transfer();
            tran.Show();
        }
    }
}
