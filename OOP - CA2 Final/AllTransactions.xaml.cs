using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for AllTransactions.xaml
    /// </summary>
    public partial class AllTransactions : Window
    {
        public AllTransactions()
        {
            InitializeComponent();
        }
        


        //calling the objects
        DAO dao = new DAO();
        SqlDataAdapter da;
        DataTable dt;
        SqlDataReader dr;
        CollectionViewSource cs = new CollectionViewSource();

        //calling the objects again depending the user's choice

        private void _allNewAccount_Click(object sender, RoutedEventArgs e)
        {
            Registration r = new Registration();
            r.Show();
        }

        private void _allEditAccount_Click(object sender, RoutedEventArgs e)
        {
            EditAccounts ed = new EditAccounts();
            ed.Show();
        }

        private void _allDepositFunds_Click(object sender, RoutedEventArgs e)
        {
            Deposit dep = new Deposit();
            dep.Show();
        }

        private void _allWithdrawFunds_Click(object sender, RoutedEventArgs e)
        {
            Withdraw with = new Withdraw();
            with.Show();
        }

        private void _allTransferFunds_Click(object sender, RoutedEventArgs e)
        {
            Transfer tran = new Transfer();
            tran.Show();
        }

        private void _allViewTransactions_Click(object sender, RoutedEventArgs e)
        {
            AllTransactions allt = new AllTransactions();
            allt.Show();
        }

        //for logout closes all windows and display a message
        private void _allLogOut_Click(object sender, RoutedEventArgs e)
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

        private void _allExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //btn show all uses the stored procedure alltransactions
        private void btnShowAll_Click(object sender, RoutedEventArgs e)
        {
            CollectionViewSource cs = new CollectionViewSource();
            da = new SqlDataAdapter();
            dt = new DataTable();


            SqlCommand cmd = dao.OpenCon().CreateCommand();
            cmd.CommandText = "uspAllTransactions";
            cmd.CommandType = CommandType.StoredProcedure;

            da.SelectCommand = cmd;
            da.Fill(dt);
            cs.Source = dt.DefaultView;
            dgvtransac.ItemsSource = cs.View;

            dao.CloseCon();
        }


        //populates combobox with accounttype (current or savings)
        void PopulateCombo()
        {
            
            SqlCommand cmd = dao.OpenCon().CreateCommand();
            cmd.CommandText = "uspPopCombo";
            cmd.CommandType = CommandType.StoredProcedure;

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string act = dr["AccountType"].ToString();
                if (!cboAType.Items.Contains(act))
                {
                    cboAType.Items.Add(act);
                }


            }
            dao.CloseCon();


        }

        //btn all accounts uses stored procedure all accounts to show
        private void btnAllAccounts_Click(object sender, RoutedEventArgs e)
        {
            CollectionViewSource cs = new CollectionViewSource();
            da = new SqlDataAdapter();
            dt = new DataTable();


            SqlCommand cmd = dao.OpenCon().CreateCommand();
            cmd.CommandText = "uspAllAccounts";
            cmd.CommandType = CommandType.StoredProcedure;

            da.SelectCommand = cmd;
            da.Fill(dt);
            cs.Source = dt.DefaultView;
            dgvtransac.ItemsSource = cs.View;

            dao.CloseCon();
        }

        private void cboAType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void AllTransactionsWindows_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateCombo();
            
        }

        //this button is when the users select an option, if no then asks to select one
        //also calling uspAccType to show the content depending user's choice
        private void btnByAccType1_Click(object sender, RoutedEventArgs e)
        {
            
            da = new SqlDataAdapter();
            dt = new DataTable();

            if (cboAType.SelectedItem == null)
            {
                MessageBox.Show("Please select an option");
            }
            else
            {
                string acctype = cboAType.SelectedItem.ToString();


                SqlCommand cmd = dao.OpenCon().CreateCommand();
                cmd.CommandText = "uspAccType";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@acctype", acctype);

                da.SelectCommand = cmd;
                da.Fill(dt);
                cs.Source = dt.DefaultView;
                dgvtransac.ItemsSource = cs.View;

                dao.CloseCon();
            }
        }
    }
}
