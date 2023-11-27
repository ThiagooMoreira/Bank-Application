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
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : Window
    {
        public Welcome()
        {
            InitializeComponent();
        }

        
        //calling the objects.
        DAO dao = new DAO();
        SqlDataAdapter da;
        DataTable dt;
        SqlDataReader dr;
        CollectionViewSource cs = new CollectionViewSource();
        List<Window> openedWindows = new List<Window>();
        

        //open or closes windows depending on user's choice.
        private void _wNewAccount_Click(object sender, RoutedEventArgs e)
        {
            Registration r = new Registration();
            r.Show();
        }

        private void _wEditAccount_Click(object sender, RoutedEventArgs e)
        {
            EditAccounts ed = new EditAccounts();
            ed.Show();
        }

        private void _wDepositFunds_Click(object sender, RoutedEventArgs e)
        {
            Deposit dep = new Deposit();
            dep.Show();
        }

        private void _wWithdrawFunds_Click(object sender, RoutedEventArgs e)
        {
            Withdraw with = new Withdraw();
            with.Show();
        }

        private void _wTransferFunds_Click(object sender, RoutedEventArgs e)
        {
            Transfer tran = new Transfer();
            tran.Show();
        }

        private void _wViewTransactions_Click(object sender, RoutedEventArgs e)
        {
            AllTransactions allt = new AllTransactions();
            allt.Show();
        }


        //closes everything
        private void _wLogOut_Click(object sender, RoutedEventArgs e)
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

        //closes application
        private void _wExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        //populates info and shows all accounts
        private void WelcomeWindow_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateCombo();
        }
        void PopulateCombo()
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
            dgvWelcome.ItemsSource = cs.View;

            dao.CloseCon();


        }
    }
}
